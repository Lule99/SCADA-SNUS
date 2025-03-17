using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA
{
    [DataContract]
    public class AnalogOutput : OutputTag
    {

        [DataMember]
        public double lowLimit;

        [DataMember]
        public double highLimit;


        public AnalogOutput(string id, string description, string address, double initialValue, double low, double high) : base(id, description, address, initialValue)
        {
            lowLimit = low;
            highLimit = high;
        }

        public AnalogOutput() { }

        public override string ToString()
        {
            return $"ID: {tagId} | Value: {initialValue} Opis: {description} | I/O address: {ioAddress} | Low Limit: {lowLimit} | High Limit: {highLimit} ";
            
        }
    }
}