using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCADA
{
    [ServiceContract]
    public interface IDatabaseManager
    {

        [OperationContract]
        bool AddDigitalInputTag(string id, string description, string address, string driver, int time, bool on);

        [OperationContract]
        bool AddDigitalOutputTag(string id, string description, string address, int value);

        [OperationContract]
        bool AddAnalogInputTag(string id, string desc, string address, string driver, int time, bool on, double low, double high);

        [OperationContract]
        bool AddAnalogOuputTag(string id, string description, string address, double initialValue, double low, double high);

        [OperationContract]
        bool RemoveTag(string tagId);

        [OperationContract]
        void UpdateTag(Tag tag);

        [OperationContract]
        bool SetInitialValue(string tagId, string ioAddress, double value);

        [OperationContract]
        List<Tag> GetTags();

        [OperationContract]
        List<InputTag> GetInputTags();

        [OperationContract]
        List<Alarm> GetAlarmsForTag(string tagId);

        [OperationContract]
        List<Alarm> GetAllAlarms();

        [OperationContract]
        List<OutputTag> GetOutputTags();
        [OperationContract]
        Dictionary<string, double> GetOutputTagAddressesAndValues();

        [OperationContract]
        bool ScanOn(string tagId);

        [OperationContract]
        bool ScanOff(string tagId);

        [OperationContract]
        bool AddAlarm(string alarmId, string tagId, double triggerValue, string type, int priority);

        [OperationContract]
        bool RemoveAlarm(string tagId, string alarmId);


    }
}
