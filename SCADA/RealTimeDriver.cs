using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADA
{
    public static class RealTimeDriver
    {
        //adresa RTU: (id[RTU],value)
        static Dictionary<string, Tuple<int,double>> addresses = new Dictionary<string, Tuple<int, double>>();

        public static void WriteToAdresses(string address, int id, double value)
        {
                      
            addresses[address] = new Tuple<int, double>(id, value);

        }

        internal static double ReturnValue(string ioAddress)
        {
            if (addresses.ContainsKey(ioAddress))
                return addresses[ioAddress].Item2;
            else
                return -1000;
        }
    }
}