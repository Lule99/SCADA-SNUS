﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SCADA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRealTimeUnitService" in both code and config file together.
    [ServiceContract]
    public interface IRealTimeUnitService
    {
        [OperationContract(IsOneWay = true)]
        void Init(string keyPath);

        [OperationContract(IsOneWay = true)]
        void Write(string message, byte[] signature);
    }
}
