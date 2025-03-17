using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlarmDisplay.ServiceReference1;
using System.ServiceModel;

namespace AlarmDisplay
{

    public class Callback : IAlarmDisplayServiceCallback
    {
        public void ActivateAlarm(Alarm a)
        {
            for (int i = 0; i < a.priority; i++)
                Console.WriteLine($"ID:\t{a.alarmId} | Aktivaciona Vrednost: {a.criticalValue} | Vrednost Taga: {a.tagValue} | Tag: {a.tagId} | Tip: {a.type} |");
        }


    }
    class Program
    {
        static AlarmDisplayServiceClient client;
        static void Main(string[] args)
        {
            Console.WriteLine("Alarms:\n--------------------------------------------------------------");

            InstanceContext ic = new InstanceContext(new Callback());
            client = new AlarmDisplayServiceClient(ic);
            client.initReciever();
            Console.ReadKey();
        }
    }
}
