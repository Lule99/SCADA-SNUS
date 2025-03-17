using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA
{
    [DataContract]
    public class InputTag : Tag
    {
        [DataMember]
        public int scanTime { get; set; }

        [DataMember]
        public List<string> alarms { get; set; }

        [DataMember]
        public bool scanOn{ get; set; }
        
        [DataMember]
        public string driver { get; set; }


        public InputTag() {}

        public InputTag(string id, string desc, string address, string drive, int time, bool on) : base(id, desc, address)
        {
            scanTime = time;
            scanOn = on;
            driver = drive;
            alarms = new List<string>();
        }

        public void AddAlarm(string alarm)
        {
            alarms.Add(alarm);
        }

        public void RemoveAlarm(string alarmId)
        {
            foreach (string a in alarms)
            {
                if (a.Equals(alarmId))
                {
                    alarms.Remove(a);
                    break;
                }

            }
        }

    }
}