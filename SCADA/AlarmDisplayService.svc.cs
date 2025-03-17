using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SCADA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlarmDisplayService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlarmDisplayService.svc or AlarmDisplayService.svc.cs at the Solution Explorer and start debugging.
    public class AlarmDisplayService : IAlarmDisplayService
    {
        IAlarmDisplayServiceCallback proxy;

        public void initReciever()
        {
            proxy = OperationContext.Current.GetCallbackChannel<IAlarmDisplayServiceCallback>();
            TagProcessing.onAlarm += ActivateAlarm;
        }

        public void ActivateAlarm(Alarm alarm)
        {
            proxy.ActivateAlarm(alarm);
        }
    }
}
