using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Xml.Serialization;


namespace SCADA
{

    
    public class DbManagerService : IDatabaseManager, IAuthentication
    {
    
        //Auth funkcije
        //-------------------------------------------------------------------------//

        public bool Register(string username, string password, bool admin)
        {
            string encryptedPassword = TagProcessing.EncryptValue(password);
            User user = new User(username, encryptedPassword,admin);
            using (var db = new UserDatabase())
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    LogIn(username, password);
                } catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }

        public string[] LogIn(string username, string password)
        {
            string[] retVal = new string[2];
             
            using (var db = new UserDatabase())
            {
                foreach (var user in db.Users)
                {
                    if (username == user.Username && TagProcessing.ValidateEncryptedData(password, user.EncryptedPassword))
                    {
                        string token = TagProcessing.GenerateToken(username);
                        TagProcessing.authenticatedUsers.Add(token, user);
                        retVal[0] = token;
                        retVal[1] = user.isAdmin.ToString();
                        return retVal;
                    }
                }
            }
            retVal[0] = "failed";
            retVal[1] = "False";
            return retVal;
        }

        public bool LogOut(string token)
        {
            TagProcessing.SaveData();
            return TagProcessing.authenticatedUsers.Remove(token); 
        }

        public bool ValidateUser(string token, bool isAdmin)
        {
            if (TagProcessing.authenticatedUsers.ContainsKey(token)){
                return TagProcessing.authenticatedUsers[token].isAdmin == isAdmin;
            }
            return false;
        }

        public bool emptyDb()
        {
            using (var db = new UserDatabase())
            {
                if (db.Users.Count() == 0)
                {
                    return true;
                }
            }
                return false;
        }
        //-------------------------------------------------------------------------//
        //Db funkcije
        public bool AddAlarm(string alarmId, string tagId, double triggerValue, string type, int priority)
        {
            if (!TagProcessing.CheckNewAlarm(alarmId, tagId, triggerValue, type, priority))
                return false;

            Alarm newAlarm = new Alarm(alarmId, tagId, triggerValue, type, priority);
            lock (TagProcessing.locker)
            {
                InputTag parentTag = (InputTag)TagProcessing.tagMap[newAlarm.tagId];
                if (parentTag.alarms.Contains(alarmId))
                    return false;
                parentTag.AddAlarm(newAlarm.alarmId);
                TagProcessing.alarms.Add(newAlarm.alarmId, newAlarm);
            }
            TagProcessing.SaveData();
            return true;

        }

        public bool RemoveAlarm(string tagId, string alarmId)
        {
            if (!(TagProcessing.tagMap[tagId] is InputTag))
                return false;
            lock (TagProcessing.locker)
            {
                ((InputTag)TagProcessing.tagMap[tagId]).RemoveAlarm(alarmId);
                TagProcessing.alarms.Remove(alarmId);
            }
            TagProcessing.SaveData();
            return true;
        }

        public List<Alarm> GetAllAlarms()
        {
            return TagProcessing.alarms.Values.ToList();
        }

        public bool AddDigitalInputTag(string id, string description, string address, string driver, int time, bool on)
        {
            Tag newTag = new DigitalInput(id, description, address, driver, time, on);
            return AddTag(newTag);
        }

        public bool AddDigitalOutputTag(string id, string description, string address, int value)
        {
            Tag newTag = new DigitalOutput(id, description, address, value);
            return AddTag(newTag);
        }

        public bool AddAnalogInputTag(string id, string desc, string address,string driver, int time, bool on, double low, double high)
        {
            Tag newTag = new AnalogInput(id, desc, address, driver, time, on, low, high);
            return AddTag(newTag);
        }

        public bool AddAnalogOuputTag(string id, string description, string address, double initialValue, double low, double high)
        {
            Tag newTag = new AnalogOutput(id, description, address, initialValue, low, high);
            return AddTag(newTag);
        }

        public bool AddTag(Tag newTag)
        {
            lock (TagProcessing.locker)
            {
                if (TagProcessing.tagMap.ContainsKey(newTag.tagId)) return false;

                TagProcessing.tagMap.Add(newTag.tagId, newTag);
                
                if(newTag is InputTag)
                {
                    TagProcessing.WriteTagValueToMap(newTag, 0);
                    InputTag tag = (InputTag)newTag;
                    if (tag.scanOn)
                        TagProcessing.StartScanning(tag);
                }
                else
                {
                    OutputTag tag = (OutputTag)newTag;
                    TagProcessing.WriteTagValueToMap(newTag, tag.initialValue);
                }
            }

            TagProcessing.SaveData();
            return true;
        }

        public bool RemoveTag(string tagId)
        {
            lock (TagProcessing.locker)
            {
                if (!TagProcessing.tagMap.ContainsKey(tagId)) return false;
                
                if(TagProcessing.tagMap[tagId] is InputTag)
                {
                    if (((InputTag)TagProcessing.tagMap[tagId]).scanOn)
                    {
                        TagProcessing.threadMap[tagId].Abort();
                        TagProcessing.threadMap.Remove(tagId);
                    }
                }

                TagProcessing.tagMap.Remove(tagId);
                TagProcessing.tag_Adres_Value_Map.Remove(tagId);
               
            }
            TagProcessing.SaveData();
            return true;
        }

        public void UpdateTag(Tag tag)
        {
            string id = tag.tagId;
            lock (TagProcessing.locker)
            {
                if (TagProcessing.tagMap.ContainsKey(id))
                {
                    TagProcessing.tagMap[id] = tag;
                    
                }
            }
            TagProcessing.SaveData();

        }

        public List<OutputTag> GetOutputTags()
        {
            lock (TagProcessing.locker)
            {

                return TagProcessing.tagMap.Values.OfType<OutputTag>().ToList();

            }
        
}

        public List<InputTag> GetInputTags()
        {
            lock (TagProcessing.locker)
            {

                return TagProcessing.tagMap.Values.OfType<InputTag>().ToList();

            }
        }

        public List<Tag> GetTags()
        {
            lock (TagProcessing.locker)
            {
                return new List<Tag>(TagProcessing.tagMap.Values);
            }
        }

        public List<Alarm> GetAlarmsForTag(string tagId)
        {
            List<Alarm> alarmsToRet = TagProcessing.alarms.Where(x => x.Value.tagId.Equals(tagId)).Select(s => s.Value).ToList();
            return alarmsToRet;
        }
        public bool ScanOff(string tagId)
        {
            ((InputTag)TagProcessing.tagMap[tagId]).scanOn = false;
            TagProcessing.threadMap[tagId].Abort();
            TagProcessing.SaveData();

            return true;
        }
        public bool ScanOn(string tagId)
        {
            ((InputTag)TagProcessing.tagMap[tagId]).scanOn = true;
            TagProcessing.SaveData();
            TagProcessing.StartScanning((InputTag)TagProcessing.tagMap[tagId]);

            return true;
        }

        public bool SetInitialValue(string tagId, string ioAddress, double value)
        {
            lock (TagProcessing.locker)
            {
                if (TagProcessing.tagMap[tagId] is InputTag) return false;
                if (TagProcessing.tagMap[tagId] is AnalogOutput)
                {
                    AnalogOutput tag = (AnalogOutput)TagProcessing.tagMap[tagId];
                    if (value < tag.lowLimit)
                        value = tag.lowLimit;
                    else if (value > tag.highLimit)
                        value = tag.highLimit;
                }
                else
                {
                    //digitalni output
                    value = value > 0 ? 1:0;
                }

                TagProcessing.WriteTagValueToMap(TagProcessing.tagMap[tagId], value);
            }
            TagProcessing.SaveData();
            return true;
        }

        public Dictionary<string, double> GetOutputTagAddressesAndValues()
        {
            return TagProcessing.tag_Adres_Value_Map;
        }
    }

}
