using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SCADA
{

    [ServiceContract(CallbackContract = typeof(IAlarmDisplayServiceCallback))]
    public interface IAlarmDisplayService
    {
        [OperationContract(IsOneWay = true)]
        void initReciever();
    }


    [ServiceContract]
    public interface IAlarmDisplayServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void ActivateAlarm(Alarm Alarm);
    }
}
