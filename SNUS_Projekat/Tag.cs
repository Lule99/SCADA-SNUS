using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.ServiceModel;

namespace SNUS_Projekat
{
    [DataContract]
    [XmlInclude(typeof(AnalogInput))]
    [XmlInclude(typeof(AnalogOutput))]
    [XmlInclude(typeof(DigitalInput))]
    [XmlInclude(typeof(DigitalOutput))]
    [KnownType(typeof(AnalogInput))]
    [KnownType(typeof(AnalogOutput))]
    [KnownType(typeof(DigitalInput))]
    [KnownType(typeof(DigitalOutput))]
    public class Tag
    {
        [DataMember]
        private string tagId;

        [DataMember]
        private string description;

        [DataMember]
        private string ioAddress;


        public Tag() { }

        public Tag(string id) { tagId = id; }

        public Tag(string id, string desc, string address)
        {
            tagId = id;
            description = desc;
            simulationDriver = null;
            ioAddress = address;
        }

        public Tag(string id, string desc, SimulationDriver driver, string address)
        {
            tagId = id;
            description = desc;
            simulationDriver = driver;
            ioAddress = address;
        }

        public override string ToString()
        {
            return string.Format("{0}; {1}; {2};", tagId, description, ioAddress);
        }

        public string TagId
        {
            get { return tagId; }
            set { tagId = value; }
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public SimulationDriver SimulationDriver
        {
            get { return simulationDriver; }
            set { simulationDriver = value; }
        }


        public string IOAddress
        {
            get { return ioAddress; }
            set { ioAddress = value; }
        }


    }
}
