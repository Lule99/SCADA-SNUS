using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Xml.Serialization;

namespace SCADA
{
    public static class TagProcessing
    {
        //{ID:{ioAddres:Value}}
        public static Dictionary<string,double> tag_Adres_Value_Map = new Dictionary<string,double>();
        public static Dictionary<string, User> authenticatedUsers = new Dictionary<string, User>();
        public static Dictionary<string, Tag> tagMap = new Dictionary<string, Tag>();
        public static Dictionary<string, Thread> threadMap = new Dictionary<string, Thread>();
        public static Dictionary<string, Alarm> alarms = new Dictionary<string, Alarm>();
        public static object locker = new object();
        public static string wsPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string pathTags = wsPath + "\\scadaConfig.xml";
        public static string pathAlarms = wsPath + "\\alarmConfig.xml";
        private static bool isRunning = init();
        public  delegate void alarmDelegate(Alarm alarm);
        public  delegate void TagDelegate(Tag inputTag, double value);
        public static event TagDelegate onInputTagChanged;
        public static event alarmDelegate onAlarm;





        
        public static void LoadData()
        {
            if (!File.Exists(pathTags))
            {
                Console.WriteLine($"ERROR:\tFile on {pathTags} does not exist!");
                return;
            }
            if (!File.Exists(pathAlarms))
            {
                Console.WriteLine($"ERROR:\tFile on {pathAlarms} does not exist!");
                return;
            }
            using (var sr = new StreamReader(pathTags))
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Tag>));
                var tagList = (List<Tag>)xmlserializer.Deserialize(sr);

                if (tagList == null || tagList.Count == 0)
                {
                    Console.WriteLine($"ERROR:\tFile on {pathTags} empty!");
                }

                lock (locker)
                {
                    if (tagList != null)
                    {
                        tagMap = tagList.ToDictionary(tag => tag.tagId);
                    }
                    foreach (var tag in tagMap.Values)
                    {
                        if (tag is InputTag)
                        {
                            var iTag = (InputTag)tag;
                            WriteTagValueToMap(tag, 0);
                            if (iTag.scanOn)
                            {
                                StartScanning(iTag);
                            }
                        }
                        else
                        {
                            var oTag = (OutputTag)tag;
                            WriteTagValueToMap(tag, oTag.initialValue);

                        }

                    }
                }
            }
            using (var sr = new StreamReader(pathAlarms))
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Alarm>));
                var alarmList = (List<Alarm>)xmlserializer.Deserialize(sr);

                if (alarmList == null || alarmList.Count == 0)
                {
                    Console.WriteLine($"ERROR:\tFile on {pathAlarms} empty!");
                }

                lock (locker)
                {
                    if (alarmList != null)
                    {
                        alarms = alarmList.ToDictionary(alarm => alarm.alarmId);
                    }

                }
            }
        }
        public static void SaveData()
        {
            using (var writer = new StreamWriter(pathTags))
            {
                var serializer = new XmlSerializer(typeof(List<Tag>));
                serializer.Serialize(writer, tagMap.Values.ToList());
                Console.WriteLine($"Tag config data saved to: {pathTags}");
            }

            using (var writer = new StreamWriter(pathAlarms))
            {
                var serializer = new XmlSerializer(typeof(List<Alarm>));
                serializer.Serialize(writer, alarms.Values.ToList());
                Console.WriteLine($"Alarm config data saved to: {pathAlarms}");
            }
        }
        public static void StartScanning(InputTag itag)
        {
            Thread thread = new Thread(Scan);
            threadMap[itag.tagId]=thread;
            thread.Start(itag);
        }
        public static void Scan(object obj)
        {
            InputTag iTag = (InputTag)obj;
            double driverValue = 0;

            while (true)
            {
                if (iTag.driver.Equals("Simulation"))
                {
                    lock (locker)
                    {
                        driverValue = SimulationDriver.ReturnValue(iTag.ioAddress);
                    }
                }
                else
                {
                    lock (locker)
                    {
                        driverValue = RealTimeDriver.ReturnValue(iTag.ioAddress);
                    }
                }

                lock (locker)
                {

                    if (iTag is AnalogInput)
                    {

                        //zakucavanje vrednosti
                        if (driverValue < ((AnalogInput)iTag).lowLimit)
                            driverValue = ((AnalogInput)iTag).lowLimit;
                        else if (driverValue > ((AnalogInput)iTag).highLimit)
                            driverValue = ((AnalogInput)iTag).highLimit;

                    }
                    else
                    {
                        if (iTag is DigitalInput) driverValue = driverValue < 0 ? 0 : 1;

                    }
                    UpdateInputTag(iTag, driverValue);

                }
                Thread.Sleep(iTag.scanTime * 1000);
            }
        }
        public static void UpdateInputTag(InputTag iTag, double value)
        {

                FireTagChanged(iTag, value);
                WriteTagToDB(iTag, value);
                foreach (string alarmid in iTag.alarms)
                {
                    Alarm alarm = alarms[alarmid];

                    if (alarm.type.Equals("low"))
                    {
                        if (value < alarm.criticalValue)
                        {
                            alarm.tagValue = value;
                            AlarmFired(alarm);
                            WriteAlarmToDB(alarm);
                        }
                    }
                    else
                    {
                        if (value > alarm.criticalValue)
                        {
                            alarm.tagValue = value;
                            AlarmFired(alarm);
                            WriteAlarmToDB(alarm);

                    }
                }
                }
            
        }
        public static void AlarmFired(Alarm alarm)
        {
            onAlarm(alarm);
        }
        public static bool CheckNewAlarm(string alarmId, string tagId, double triggerValue, string type, int priority)
        {

            //Ako vec postoji alarm sa datim kljucem
            if (alarms.ContainsKey(alarmId))
                return false;
            //ako ne postoji trazeni tag
            if (!tagMap.Where(x => (x.Value is InputTag) && x.Key == tagId.Trim()).Any())
                return false;
            //ako nije odg tipa
            if (!type.Equals("low") && !type.Equals("high"))
                return false;
            //neodgovarajuci prioritet
            if (priority < 1 || priority > 3)
                return false;
            return true;


        }
        static bool init()
        {
            LoadData();
            onInputTagChanged += WriteTagValueToMap;
            onInputTagChanged += WriteTagToDB;
            onAlarm += WriteAlarmToDB;
            return true;
        }

        //---------------------//
        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            byte[] salt = new byte[32];
            crypto.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public static string GenerateToken(string username)
        {
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            byte[] token = new byte[32];
            crypto.GetBytes(token);
            return username + Convert.ToBase64String(token);
        }

        public static string EncryptValue(string strValue)
        {
            string saltValue = GenerateSalt();
            byte[] saltedPassword = Encoding.UTF8.GetBytes(saltValue + strValue);
            using (SHA256Managed sha = new SHA256Managed())
            {
                byte[] hash = sha.ComputeHash(saltedPassword);
                return $"{Convert.ToBase64String(hash)}:{saltValue}";
            }
        }

        public static bool ValidateEncryptedData(string valueToValidate, string valueFromDatabase)
        {
            string[] arrValues = valueFromDatabase.Split(':');
            string encryptedDbValue = arrValues[0];
            string salt = arrValues[1];
            byte[] saltedValue = Encoding.UTF8.GetBytes(salt + valueToValidate);
            using (var sha = new SHA256Managed())
            {
                byte[] hash = sha.ComputeHash(saltedValue);
                string enteredValueToValidate = Convert.ToBase64String(hash);
                return encryptedDbValue.Equals(enteredValueToValidate);
            }
        }

        //---------------------//
        public static void FireTagChanged(Tag tag, double value)
        {
            if (onInputTagChanged == null)
                return;
            onInputTagChanged(tag, value);
        }

        public static void WriteTagValueToMap(Tag tag, double value)
        {
            lock(locker)
            {
                if(tag is OutputTag)
                    tag_Adres_Value_Map[tag.ioAddress] = value;
                WriteTagToDB(tag, value);
            }

        }

        public static void WriteTagToDB(Tag tag, double value)
        {
            using (var db = new TagDatabase())
            {
                try
                {
                    DbTag dbtag = new DbTag(tag, DateTime.Now, value);
                    db.Tags.Add(dbtag);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return;
                }
            }
            return;
        }

        public static void WriteAlarmToDB(Alarm alarm)
        {
            string log = $"Alarm[ID]: {alarm.alarmId}| Trigger Value: {alarm.criticalValue} | Prioritet: {alarm.priority} | Tag Value: {alarm.tagValue} | Time: {DateTime.Now}";

            //dodaj u log file
            if (!File.Exists(wsPath + "//alarmsLog.txt"))
            {
                using (StreamWriter sw = File.CreateText(wsPath+"//alarmsLog.txt"))
                {
                    sw.WriteLine(log);

                }
            }

            using (StreamWriter sw = File.AppendText(wsPath+"//alarmsLog.txt"))
            {
                sw.WriteLine(log);
            }
         
            //dodaj u bazu
            using (var db = new AlarmDB())
            {
                try
                {
                    
                    db.Alarms.Add(new DbAlarm(alarm, DateTime.Now));
                    int count = db.Alarms.Count();
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return;
                }
            }
            return;
        }

        //-----------------//
        public static List<Tuple<string, double, int, DateTime>> AlarmsInPeriod(DateTime low, DateTime high)
        {
            List<Tuple<string, double, int, DateTime>> alarmsToRet = new List<Tuple<string, double, int, DateTime>>();

            using (var db = new AlarmDB())
            {
                try
                {
                    var alarms = db.Alarms.Where(a => DateTime.Compare(a.timeStamp, low) >= 0 && DateTime.Compare(a.timeStamp, high) <= 0).Select(t => new { Id = t.alarm.alarmId, Priority = t.alarm.priority, Value = t.alarm.tagValue, Time = t.timeStamp });
                    alarms.OrderBy(a => a.Priority).ThenBy(a => a.Time);
                    foreach (var a in alarms)
                    {
                        alarmsToRet.Add(new Tuple<string, double, int, DateTime>(a.Id, a.Value, a.Priority, a.Time));
                    }
                }
                catch
                {

                }

            }
            return alarmsToRet;
        }

        public static List<Tuple<string, double, int, DateTime>> AlarmsByPriority(int priority)
        {
            List<Tuple<string, double, int, DateTime>> alarmsToRet = new List<Tuple<string, double, int, DateTime>>();
            if (priority < 1 || priority > 3)
                return alarmsToRet;
            using (var db = new AlarmDB())
            {
                var alarms = db.Alarms.Where(a => a.alarm.priority.Equals(priority)).Select(t => new { Id = t.alarm.alarmId, Priority = t.alarm.priority, Value = t.alarm.tagValue, Time = t.timeStamp });
                alarms.OrderBy(t => t.Time);
                foreach (var a in alarms)
                {
                    alarmsToRet.Add(new Tuple<string, double, int, DateTime>(a.Id,a.Value,a.Priority,a.Time));
                }
            }
            return alarmsToRet;
        }

        public static List<Tuple<double, DateTime>> TagsInPeriod(DateTime low, DateTime high)
        {
            List<Tuple<double, DateTime>> tagsToRet = new List<Tuple<double, DateTime>>();

            using (var db = new TagDatabase())
            {
                var tags = db.Tags.Where(t => DateTime.Compare(t.timeStamp, low) >= 0 && DateTime.Compare(t.timeStamp, high) <= 0).Select(t => new { Value = t.value, Time = t.timeStamp });
                tags.OrderBy(t => t.Time);
                foreach (var tag in tags)
                {
                    tagsToRet.Add(new Tuple<double, DateTime>(tag.Value, tag.Time));
                }
            }
            return tagsToRet;
        }

        public static List<Tuple<double, DateTime>> AnalogInputValuesReport()
        {
            List<Tuple<double, DateTime>> tagsToRet = new List<Tuple<double, DateTime>>();

            using (var db = new TagDatabase())
            {
                var tags = db.Tags.Where(t => t.tag is AnalogInput).Select(t => new { Value = t.value, Time = t.timeStamp });
                tags.OrderBy(t => t.Time);
                foreach (var tag in tags)
                {
                    tagsToRet.Add(new Tuple<double, DateTime>(tag.Value, tag.Time));
                }
            }
            return tagsToRet;
        }

        public static List<Tuple<double, DateTime>> DigitalInputValuesReport()
        {
            List<Tuple<double, DateTime>> tagsToRet = new List<Tuple<double, DateTime>>();

            using (var db = new TagDatabase())
            {
                var tags = db.Tags.Where(t => t.tag is DigitalInput).Select(t => new { Value = t.value, Time = t.timeStamp });
                tags.OrderBy(t => t.Time);
                foreach (var tag in tags)
                {
                    tagsToRet.Add(new Tuple<double, DateTime>(tag.Value, tag.Time));
                }
            }
            return tagsToRet;
        }

        public static List<Tuple<double, DateTime>> ReportByTagId(string tagId)
        {
            List<Tuple<double, DateTime>> tagsToRet = new List<Tuple<double, DateTime>>();
            using (var db = new TagDatabase())
            {

                var tags = db.Tags.Where(t => t.tag.tagId.Equals(tagId)).OrderBy(t => t.value).Select(t => new { Value = t.value, Time = t.timeStamp });
                foreach(var tag in tags)
                {
                    tagsToRet.Add(new Tuple<double, DateTime>(tag.Value, tag.Time));
                }
            }
            return tagsToRet;
        }


    }
}