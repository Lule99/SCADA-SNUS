using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace SCADA
{

    public class ReportManagerService : IReportManagerService
    {
        public List<Tuple<string, double, int, DateTime>> AlarmsByPriority(int priority)
        {

            return TagProcessing.AlarmsByPriority(priority);
        }

        public List<Tuple<string, double, int, DateTime>> AlarmsInPeriod(DateTime low, DateTime high)
        {
            return TagProcessing.AlarmsInPeriod( low,  high);
        }

        public List<Tuple<double, DateTime>> AnalogInputValuesReport()
        {
            return TagProcessing.AnalogInputValuesReport();
        }

        public List<Tuple<double, DateTime>> DigitalInputValuesReport()
        {
            return TagProcessing.DigitalInputValuesReport();
        }

        public List<Tuple<double, DateTime>> ReportByTagId(string tagId)
        {
            return TagProcessing.ReportByTagId(tagId);
        }

        public List<Tuple<double, DateTime>> TagsInPeriod(DateTime low, DateTime high)
        {
            return TagProcessing.TagsInPeriod(low, high);
        }
    }
}
