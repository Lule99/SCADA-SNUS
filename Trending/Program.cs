using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Trending.ServiceReference1;

namespace Trending
{
    public class Callback : ITrendingServiceCallback
    {
        public void SendTag(Tag t, double value)
        {
            if(t is DigitalInput)
            {
                var tag = (DigitalInput)t;
                Console.WriteLine($"ID: {tag.tagId}| Vrednost: {value} | Opis: {tag.description} | I/O address: {tag.ioAddress} | Interval Skrniranja: {tag.scanTime} | Scan On: {tag.scanOn} |");
            }
            else
            {
                var tag = (AnalogInput)t;
                Console.WriteLine($"ID: {tag.tagId} | Vrednost: {value} | Opis: {tag.description} | I/O address: {tag.ioAddress} | Interval Skrniranja: {tag.scanTime} | Scan On: {tag.scanOn} | Low Limit: { tag.lowLimit} | High Limit: { tag.highLimit} | ");
            }
        }
    }
    class Program
    {
        static TrendingServiceClient client;
        

        static void Main(string[] args)
        {
            Console.WriteLine("Trending:\n--------------------------------------------------------------");

            InstanceContext ic = new InstanceContext(new Callback());
            client = new TrendingServiceClient(ic);
            client.initReciever();
            Console.ReadKey();
        }
    }
}
