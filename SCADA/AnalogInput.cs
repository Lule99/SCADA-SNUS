using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA
{
    [DataContract]
    public class AnalogInput : InputTag
    {

        [DataMember]
        public double lowLimit { get; set; }

        [DataMember]
        public double highLimit { get; set; }



        public AnalogInput(string id, string desc, string address, string driver, int time, bool on, double low, double high) :
            base(id, desc, address, driver, time, on)
        {
            lowLimit = low;
            highLimit = high;
        }

        public AnalogInput() : base() { }

    }
}