using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReportManager
{
    class Program
    {
        static ServiceReference1.ReportManagerServiceClient client = new ServiceReference1.ReportManagerServiceClient();
        
        static void Menu()
        {
            Console.WriteLine("1.\t Alarmi u intervalu [OD-DO]");
            Console.WriteLine("2.\t Alarmi prioriteta");
            Console.WriteLine("3.\t Tagovi  u intervalu [OD-DO]");
            Console.WriteLine("4.\t Svi AnalogInput-i");
            Console.WriteLine("5.\t Svi DigitalInput-i");
            Console.WriteLine("6.\t Tag[ID]");
        }
        public static void tagIDReport()
        {
            Console.WriteLine("Tag[ID]-REPORT\n---------------------------------------");
            Console.WriteLine("Unesi Tag ID:\n>>");
            string tadId = Console.ReadLine().Trim();

            List<Tuple<double, DateTime>> tags = client.ReportByTagId(tadId).ToList();
            if (tags.Count == 0)
                Console.WriteLine("NO TAGS TO DISPLAY");
            else
            {
                Console.WriteLine($"Tag[ID]: {tadId}\n---------------------------------");
                foreach (var tag in tags)
                {
                    Console.WriteLine($"Vrednost {tag.Item1} | Vreme: {tag.Item2}");

                }
            }
            Console.WriteLine("\n>>");
            Console.ReadKey();

        }
        public static void AllDigitalInputs()
        {
            List<Tuple<double, DateTime>> tags = client.DigitalInputValuesReport().ToList();
            if (tags.Count == 0)
                Console.WriteLine("NO TAGS TO DISPLAY");
            else
            {
                Console.WriteLine($"Tags[DIGITAL INPUT]:\n---------------------------------");
                foreach (var tag in tags)
                {
                    Console.WriteLine($"Vrednost {tag.Item1} | Vreme: {tag.Item2}");

                }
            }
            Console.WriteLine("\n>>");
            Console.ReadKey();
        }
        public static void AllAnalogInputs()
        {
            List<Tuple<double, DateTime>> tags = client.AnalogInputValuesReport().ToList();
            if (tags.Count == 0)
                Console.WriteLine("NO TAGS TO DISPLAY");
            else
            {
                Console.WriteLine($"Tags[Analog INPUT]:\n---------------------------------");
                foreach (var tag in tags)
                {
                    Console.WriteLine($"Vrednost {tag.Item1} | Vreme: {tag.Item2}");

                }
            }
            Console.WriteLine("\n>>");
            Console.ReadKey();
        }
        public static void TagsInterval()
        {
            Console.WriteLine("Tag[OD-DO]-REPORT\n---------------------------------------");
            Console.WriteLine("Unesi DateTime OD [Format: 2021-05-01 14:57:32]:\n>>");
            DateTime low;
            if(!DateTime.TryParse(Console.ReadLine().Trim(),out low))
            {
                Console.WriteLine("Invalid Datetime Format...Pokusaj ponovo!\n>>");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Unesi DateTime Do [Format: 2021-05-01 14:57:32]:\n>>");
            DateTime high;
            if (!DateTime.TryParse(Console.ReadLine().Trim(), out high))
            {
                Console.WriteLine("Invalid Datetime Format...Pokusaj ponovo!\n>>");
                Console.ReadKey();
                return;
            }

            List<Tuple<double, DateTime>> tags = client.TagsInPeriod(low,high).ToList();
            if (tags.Count == 0)
                Console.WriteLine("NO TAGS TO DISPLAY");
            else
            {
                Console.WriteLine($"Tags:\n---------------------------------");
                foreach (var tag in tags)
                {
                    Console.WriteLine($"Vrednost {tag.Item1} | Vreme: {tag.Item2}");

                }
            }
            Console.WriteLine("\n>>");
            Console.ReadKey();

        

        }
        public static void AlarmsInterval()
        {
            Console.WriteLine("Alarm[OD-DO]-REPORT\n---------------------------------------");
            Console.WriteLine("Unesi DateTime OD [Format: 2021-05-01 14:57:32]:\n>>");
            DateTime low;
            if (!DateTime.TryParse(Console.ReadLine().Trim(), out low))
            {
                Console.WriteLine("Invalid Datetime Format...Pokusaj ponovo!\n>>");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Unesi DateTime Do [Format: 2021-05-01 14:57:32]:\n>>");
            DateTime high;
            if (!DateTime.TryParse(Console.ReadLine().Trim(), out high))
            {
                Console.WriteLine("Invalid Datetime Format...Pokusaj ponovo!\n>>");
                Console.ReadKey();
                return;
            }

            List<Tuple<string, double, int, DateTime>> alarms = client.AlarmsInPeriod(low, high).ToList();
            if (alarms.Count == 0)
                Console.WriteLine("NO ALARMS TO DISPLAY");
            else
            {
                Console.WriteLine($"Alarms:\n---------------------------------");
                foreach (var a in alarms)
                {
                    Console.WriteLine($"ID: {a.Item1} | Vrednost: {a.Item2} | Prioritet: {a.Item3}  | Vreme: {a.Item4}");

                }
            }
            Console.WriteLine("\n>>");
            Console.ReadKey();



        }
        public static void AlarmsByPriority()
        {
            Console.WriteLine("Alarm[PRIORITY]-REPORT\n---------------------------------------");
            Console.WriteLine("Unesi Vrednost Prioriteta[1-3]:\n>>");
            string p = Console.ReadLine().Trim();
            int priority;
            if(!int.TryParse(p,out priority ))
            {
                Console.WriteLine("INVALID INPUT[1-3]\n>>");
                Console.ReadKey();
                return;
            }
            if(priority<1 || priority>3)
            {
                Console.WriteLine("INVALID INPUT[1-3]\n>>");
                Console.ReadKey();
                return;
            }
            List<Tuple<string, double, int, DateTime>> alarms = client.AlarmsByPriority(priority).ToList();
            if (alarms.Count == 0)
                Console.WriteLine("NO ALARMS TO DISPLAY");
            else
            {
                Console.WriteLine($"Alarms[PRIORITY]: {priority}\n---------------------------------");
                foreach (var a in alarms)
                {
                    Console.WriteLine($"ID: {a.Item1} | Vrednost: {a.Item2} | Prioritet: {a.Item3}  | Vreme: {a.Item4}");

                }
            }
            Console.WriteLine("\n>>");
            Console.ReadKey();


        }
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("ReportManager:\n-----------------------------------");
                Menu();
                int input;
                bool nastavi = false;
                if (!int.TryParse(Console.ReadLine(), out input))
                    nastavi = true;
                if (input < 1 || input > 6)
                    nastavi = true;
                if(!nastavi)
                {
                    switch (input)
                    {
                        case 1:
                            AlarmsInterval();
                            break;
                        case 2:
                            AlarmsByPriority();
                            break;
                        case 3:
                            TagsInterval();
                            break;
                        case 4:
                            AllAnalogInputs();
                            break;
                        case 5:
                            AllDigitalInputs();
                            break;
                        case 6:
                            tagIDReport();
                            break;
                        default:
                            break;
                    }

                }

                Console.Clear();
            }

        }
    }
}
