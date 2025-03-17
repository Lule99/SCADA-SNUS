using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA
{
    [DataContract]
    public class DigitalOutput : OutputTag
    {

        public DigitalOutput(string id, string description, string address, int value) : base(id, description, address, value)
        { }

        public DigitalOutput() { }


        public override string ToString()
        {
            return $"ID: {tagId} | Value: {initialValue} Opis: {description} | I/O address: {ioAddress} | ";

        }


    }
}