using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeUnit
{
    class Program
    {
        static ServiceReference1.RealTimeUnitServiceClient client = new ServiceReference1.RealTimeUnitServiceClient();

        static CspParameters csp = new CspParameters();
        static RSACryptoServiceProvider rsa = null;
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//publicKey.txt";
        //adresa low,high
        static Dictionary<string, Tuple<double, double, int>> units = new Dictionary<string, Tuple<double, double, int>>();


        static void DodavanjeUnita()
        {
            Console.WriteLine("Unesi Adresu Unita [Unique]\n>>");
            string ioAddress = Console.ReadLine();
            if (TestNewAddress(ioAddress) == false)
            {
                Console.WriteLine("Adresa postoji!\n>>");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.WriteLine("Odredi Low Value\n>>");
            double low;
            if (!double.TryParse(Console.ReadLine(), out low))
            {
                Console.WriteLine("Unesi broj!\n>>");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            Console.WriteLine("Odredi High Value\n>>");
            double high;
            if (!double.TryParse(Console.ReadLine(), out high))
            {
                Console.WriteLine("Unesi broj!\n>>");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            units[ioAddress] = new Tuple<double, double, int>(low, high,generateId());
        }
        static int generateId()
        {
            int id;
            while (true)
            {
                Random rnd = new Random();
                id = rnd.Next(0, 99999);
                bool continueGenerating = false;
                foreach (string key in units.Keys)
                {
                    if (id == units[key].Item3)
                        continueGenerating = true;
                }
                if (continueGenerating == false)
                    break;
            }
            return id;

        }
        private static bool TestNewAddress(string ioAddress)
        {
            if (units.ContainsKey(ioAddress))
                return false;
            return true;
        }
        static void PrintMenu()
        {
            while(true)
            {
                Console.WriteLine("1.\t Dodaj Unit");
                Console.WriteLine("X.\t Zavrsi Dodavanje Unita\n>>");
                int unos;
                if(!int.TryParse(Console.ReadLine(),out unos))
                {
                    break;
                }
                if(unos==1)
                {
                    DodavanjeUnita();
                }
                else
                {
                    break;
                }
                Console.Clear();
            }
        }
        static void Main(string[] args)
        {
            PrintMenu();
            PrintUnits();
            kreirajkljuc();
            exportKluc();
            client.Init(path);
            Random rnd = new Random();
            while(true)
            {
                UpdateUnitValues();
                int brsec = rnd.Next(3,10);
                System.Threading.Thread.Sleep(1000 * brsec);
            }
        }

        private static void UpdateUnitValues()
        {
            Random rnd = new Random();
            double value;
            string toSend;
            foreach(string key in units.Keys)
            {
                //[0.0-1.0]* max-min + min..
                value = rnd.NextDouble() * (units[key].Item2- units[key].Item1)+ units[key].Item1;
                toSend = key + ":" + value.ToString()+":"+units[key].Item3.ToString();
                byte[] potpisano = potpisi(toSend);
                client.Write(toSend, potpisano);
            }
        }

        private static void PrintUnits()
        {
           foreach(string key in units.Keys)
            {
                Console.WriteLine($"UNIT: \tAddress: {key} | Low: {units[key].Item1} | High: {units[key].Item2} | ID: {units[key].Item3}");
            }
        }

        static void kreirajkljuc()
        {
            rsa = new RSACryptoServiceProvider(csp);
        }

        static void exportKluc()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(rsa.ToXmlString(false));
            }
        }

        static byte[] potpisi(string msg)
        {
            byte[] hash = null;

            using (SHA256 sha = SHA256Managed.Create())
            {
                hash = sha.ComputeHash(Encoding.UTF8.GetBytes(msg));
            }
            RSAPKCS1SignatureFormatter formater = new RSAPKCS1SignatureFormatter(rsa);
            formater.SetHashAlgorithm("SHA256");
            return formater.CreateSignature(hash);
        }


    }
}
