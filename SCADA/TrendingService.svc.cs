using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SCADA
{

    public class TrendingService : ITrendingService
    {
        ITrendingServiceCallback proxy;
        public void initReciever()
        {
            proxy = OperationContext.Current.GetCallbackChannel<ITrendingServiceCallback>();
            TagProcessing.onInputTagChanged += sendTag;
        }

        public void sendTag(Tag tag, double value)
        {
            if (tag is OutputTag)
                return;
            proxy.SendTag(tag,value);
        }

    }
}
