using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA
{
    [DataContract]
    public class Alarm
    {
        [DataMember]
        public string alarmId { get; set; }

        [DataMember]
        public string tagId { get; set; }
        [DataMember]
        public double criticalValue { get; set; }


        [DataMember]
        public string type { get; set; }

        [DataMember]
        public int priority { get; set; }

        [DataMember]
        public double tagValue { get; set; }

        public Alarm() { }


        public Alarm(string alarmId, string tagId, double triggerValue, string type, int priority)
        {
            this.tagId = tagId;
            this.alarmId = alarmId;
            criticalValue = triggerValue;
            this.type = type;
            this.priority = priority;
        }



        public override string ToString()
        {
            return string.Format($"Tag:{tagId} | Type: {type} | AlarmID: {alarmId} | Tag Value: {tagValue} | Limit Value: {criticalValue}  | Priority: {priority}");
        }


    }
}