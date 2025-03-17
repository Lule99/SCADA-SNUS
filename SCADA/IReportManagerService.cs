using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SCADA
{
    [ServiceContract]
    public interface IReportManagerService
    {
        [OperationContract]
        List<Tuple<string, double, int, DateTime>> AlarmsInPeriod(DateTime low, DateTime high);

        [OperationContract]
        List<Tuple<string, double, int, DateTime>> AlarmsByPriority(int priority);

        [OperationContract]
        List<Tuple<double, DateTime>> TagsInPeriod(DateTime low, DateTime high);
        [OperationContract]
        List<Tuple<double, DateTime>> AnalogInputValuesReport();

        [OperationContract]
        List<Tuple<double, DateTime>> DigitalInputValuesReport();

        [OperationContract]
        List<Tuple<double, DateTime>> ReportByTagId(string tagId);

    }
}
