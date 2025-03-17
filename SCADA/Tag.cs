using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SCADA
{
    [DataContract]
    [XmlInclude(typeof(AnalogInput))]
    [XmlInclude(typeof(AnalogOutput))]
    [XmlInclude(typeof(DigitalInput))]
    [XmlInclude(typeof(DigitalOutput))]
    [XmlInclude(typeof(InputTag))]
    [XmlInclude(typeof(OutputTag))]
    [KnownType(typeof(InputTag))]
    [KnownType(typeof(OutputTag))]
    [KnownType(typeof(AnalogInput))]
    [KnownType(typeof(AnalogOutput))]
    [KnownType(typeof(DigitalInput))]
    [KnownType(typeof(DigitalOutput))]
    public class Tag
    {
        [DataMember]
        public string tagId { get; set; }

        [DataMember]
        public string description { get; set; }


        [DataMember]
        public string ioAddress { get; set; }


        public Tag() {}

        public Tag(string id) { tagId = id; }

        public Tag(string id, string desc, string address)
        {
            tagId = id;
            description = desc;
            ioAddress = address;
        }


        public override string ToString()
        {
            return string.Format($"{tagId} | {description} | {ioAddress}");
        }

    }
}
