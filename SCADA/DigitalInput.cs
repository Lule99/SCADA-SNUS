using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA
{
    [DataContract]
    public class DigitalInput : InputTag
    { 

        public DigitalInput(string id, string description, string driver, string address, int time, bool on) : base(id, description, driver, address, time, on) { }

        public DigitalInput() : base() { }

    }
}