using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SCADA
{
    [ServiceContract(CallbackContract = typeof(ITrendingServiceCallback))]
    public interface ITrendingService
    {
        [OperationContract(IsOneWay = true)]
        void initReciever();
    }

   
    public interface ITrendingServiceCallback
    {
        [OperationContract (IsOneWay = true)]
        void SendTag(Tag t, double value);
    }
}
