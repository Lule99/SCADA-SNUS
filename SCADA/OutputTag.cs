using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace SCADA
{
    [DataContract]
    public class OutputTag : Tag
    {
        [DataMember]
        public double initialValue { get; set; }

        public OutputTag() {}

        public OutputTag(string id, string desc, string address, double value) : base(id, desc, address)
        {
            initialValue = value;
        }

        public override string ToString()
        {
            if (this is AnalogOutput)
                return ((AnalogOutput)this).ToString();
            if (this is DigitalOutput)
                return ((DigitalOutput)this).ToString();
            return "Output Tag";
        }

    }
}