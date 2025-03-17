using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager
{
    class Program
    {
        static ServiceReference1.AuthenticationClient auth = new ServiceReference1.AuthenticationClient();
        static ServiceReference1.DatabaseManagerClient db = new ServiceReference1.DatabaseManagerClient();
        static string token;
        static bool isAdmin;
        static HashSet<int> mainMenuOptions = new HashSet<int>() { 1, 2, 3, 4, 5, 6, 7 };

        //--------------------------------------------------------------------------------------------------------//

        static string[] AuthMenu()
        {
            string[] retVal = new string[2];    
            Console.WriteLine("\tUsername:\n ");
            retVal[0] = Console.ReadLine();
            Console.WriteLine("\tPassword:\n");
            retVal[1] = Console.ReadLine();

            return retVal;
        }
        static bool UserDbEmpty()
        {
            return auth.emptyDb();
        }
        static bool Login(string username, string password)
        {

            string[] successTokens = auth.LogIn(username, password);

            if (successTokens[0].Equals("failed"))
            {
                Console.WriteLine($"Netacna kombinacija username/sifra!\nPokusaj ponovo!\n>>");
                Console.ReadKey();
                Console.Clear();
                return false;
            }


            token = successTokens[0];
            isAdmin = successTokens[1].Equals("True") ? true:false;
            Console.WriteLine($"Uspesno ulogovan korisnik: {username}\n>>");
            Console.ReadKey();
            Console.Clear();
            return true;
        }
        static void RegisterDefaultAdmin()
        {
            bool success = auth.Register("admin", "admin",true);
            if(success)
            {
                Console.WriteLine("Ne postoji ni jedan user u bazi...\nRegistrovan novi admin");
                Console.WriteLine("\tusername: admin\n\tpassword: admin");
                Login("admin", "admin");
            }
        }
        static bool RegisterNewUser()
        {
            if (AuthFailed())
                return false;
            string[] usrPsd = AuthMenu();
            Console.WriteLine("\tAdmin:\n\t\t1. Da\n\t\tX.Ne\n>> ");
            bool admin = Console.ReadLine().Trim().Equals("1");
            bool success = auth.Register(usrPsd[0], usrPsd[1], admin);
            if(success)
            {
                Console.WriteLine($"Uspesna Registracija korisnika {usrPsd[0]}! Uloga: Admin = {admin.ToString()}");
            }
            else
            {
                Console.WriteLine($"Korisnik sa username: {usrPsd[0]} vec postoji! Pokusaj ponovo!");
            }
            return success;
        }
        static void LogOut()
        {
            if (AuthFailed())
                return;
            auth.LogOut(token);
            token = "";
            isAdmin = false;
        }
        static bool AuthFailed()
        {
            return !auth.ValidateUser(token,isAdmin);
        }
        static void MainMenu()
        {
            if(isAdmin)
            {
                Console.WriteLine("0.\tRegistracija novog korisnika");
                mainMenuOptions.Add(0);
            }
            Console.WriteLine("1.\tDodaj Novi Tag");
            Console.WriteLine("2.\tPrikaz Vrednosti Izlaznih Tagova");
            Console.WriteLine("3.\tPromena Vrednosti Izlaznih Tagova");
            Console.WriteLine("4.\tUkljuci/Iskljuci Ulazni Tag");
            Console.WriteLine("5.\tDodavanje Alarma");
            Console.WriteLine("6.\tBrisanje Alarma");
            Console.WriteLine("7.\tLog Out\n>>");
        }

        //------------------------------------------------TAGOVI--------------------------------------------------------//


        static string TagTypeMenu()
        {
            string input="";
            Console.WriteLine("Odaberi Tip Taga:");
            Console.WriteLine("\t1. Ulazni");
            Console.WriteLine("\t2. Izlazni");
            Console.WriteLine("\tX. Exit");
            input = Console.ReadLine().Trim();
            return input;
        }

        static string PickDigitalAnalogMenu()
        {
            string input = "";
            Console.WriteLine("Odaberi Vrstu Taga:");
            Console.WriteLine("\t1. Digital");
            Console.WriteLine("\t2. Analog");
            Console.WriteLine("\tX. Exit");
            input = Console.ReadLine().Trim();
            return input;
        }

        static string[] AddTagBasicInfo(bool output)
        {
            string name = "";
            string description = "";
            string ioAddress = "";
            Console.WriteLine("Naziv Taga[ID]:\n>>");
            name = Console.ReadLine().Trim();
            if (name.Equals(""))
            {
                Random rnd = new Random();
                name = rnd.Next(100).ToString();
            }

            Console.WriteLine("Opis Taga:\n>>");
            description = Console.ReadLine().Trim();
            if (description.Equals("")) name = "No description";

            if(output==false)
            {
                Console.WriteLine("Addresa Taga:\n>>");
                Console.WriteLine("\tS. Sine");
                Console.WriteLine("\tC. Cosine");
                Console.WriteLine("\tR. Ramp");
                Console.WriteLine("\tX. Custom[RealTimeDriver]");
                ioAddress = Console.ReadLine().Trim();
            }else
            {
                Console.WriteLine("\tNew IOaddress:\n>>");
                ioAddress = Console.ReadLine().Trim();

            }

            string[] input = new string[3];
            input[0] = name;
            input[1] = description;
            input[2] = ioAddress;
            return input;
        }

        static bool AddDigitalInput()
        {
            string name, description, ioAddress;
            string[] basicInput = AddTagBasicInfo(false);
            name = basicInput[0];
            description = basicInput[1];
            ioAddress = basicInput[2];
            //-------------------------------------//
            string driver = "1";
            if (!(ioAddress.ToLower().Equals("s") || ioAddress.ToLower().Equals("c") || ioAddress.ToLower().Equals("r")))
                driver = "2";
            if (!driver.Equals("1")) driver = "2";
            string driverStr = driver == "1" ? "Simulation" : "RealTime";
            if (driver.Equals("2"))
            {
                Console.WriteLine("Odredi I/O Adresu\n>>");
                ioAddress = Console.ReadLine().Trim();
            }
            //-------------------------------------//
            Console.WriteLine("Scan Time[sec]:\n>>");
            int scanTime;
            if (!int.TryParse(Console.ReadLine(), out scanTime))
                scanTime = 10;
            //-------------------------------------//
            bool on = true;
            Console.WriteLine("Scan On/Off:");
            Console.WriteLine("\t1. On");
            Console.WriteLine("\t2. Off\n>>");
            if (!Console.ReadLine().Trim().Equals("1")) on = false;

            ServiceReference1.Tag tag = new ServiceReference1.Tag();
            return db.AddDigitalInputTag(name, description, ioAddress, driverStr, scanTime, on);

        }

        static bool AddAnalogInput()
        {
            string name, description, ioAddress;
            string[] basicInput = AddTagBasicInfo(false);
            name = basicInput[0];
            description = basicInput[1];
            ioAddress = basicInput[2];
            //-------------------------------------//
            string driver = "1";
            if (!(ioAddress.ToLower().Equals("s") || ioAddress.ToLower().Equals("c") || ioAddress.ToLower().Equals("r")))
                driver = "2";
            if (!driver.Equals("1")) driver = "2";
            string driverStr = driver == "1" ? "Simulation" : "RealTime";
            if(driver.Equals("2"))
            {
                Console.WriteLine("Odredi I/O Adresu\n>>");
                ioAddress = Console.ReadLine().Trim();
            }

            //-------------------------------------//
            Console.WriteLine("Scan Time[sec]:\n>>");
            int scanTime;
            if (!int.TryParse(Console.ReadLine(), out scanTime))
                scanTime = 10;
            //-------------------------------------//
            bool on = true;
            Console.WriteLine("Scan On/Off:");
            Console.WriteLine("\t1. On");
            Console.WriteLine("\t2. Off\n>>");
            if (!Console.ReadLine().Trim().Equals("1")) on = false;
            //-------------------------------------//
            Console.WriteLine("Low Limit:\n>>");
            double low;
            if (!double.TryParse(Console.ReadLine(), out low))
                low = -10000;
            //-------------------------------------//
            //-------------------------------------//
            Console.WriteLine("High Limit:\n>>");
            double high;
            if (!double.TryParse(Console.ReadLine(), out high))
                high = 10000;
            //-------------------------------------//
            ServiceReference1.Tag tag = new ServiceReference1.Tag();
            return db.AddAnalogInputTag(name, description, ioAddress, driverStr, scanTime, on, low, high);

        }

        static bool AddDigitalOutput()
        {
            string name, description, ioAddress;
            string[] basicInput = AddTagBasicInfo(true);
            name = basicInput[0];
            description = basicInput[1];
            ioAddress = basicInput[2];
            //-------------------------------------//

            Console.WriteLine("Initial Value:\n>>");
            int value;
            if (!int.TryParse(Console.ReadLine(), out value))
                value = 10;

            ServiceReference1.Tag tag = new ServiceReference1.Tag();
            return db.AddDigitalOutputTag(name, description, ioAddress, value);

        }

        static bool AddAnalogOutput()
        {
            string name, description, ioAddress;
            string[] basicInput = AddTagBasicInfo(true);
            name = basicInput[0];
            description = basicInput[1];
            ioAddress = basicInput[2];
            //-------------------------------------//

            Console.WriteLine("Initial Value:\n>>");
            double value;
            if (!double.TryParse(Console.ReadLine(), out value))
                value = 10;
     
            Console.WriteLine("Low Limit:\n>>");
            //-------------------------------------//
            double low;
            if (!double.TryParse(Console.ReadLine(), out low))
                low = -10000;
            
            //-------------------------------------//
            Console.WriteLine("High Limit:\n>>");
            double high;
            if (!double.TryParse(Console.ReadLine(), out high))
                high = 10000;
            //-------------------------------------//
            //zakucavanje vrednosti
            if (value < low)
                value = low;
            else if (value > high)
                value = high;

            ServiceReference1.Tag tag = new ServiceReference1.Tag();
            return db.AddAnalogOuputTag(name, description, ioAddress, value, low, high);

        }

        static void AddTag()
        {
            if (AuthFailed())
                return;
            Console.WriteLine("----DodaVanje novog Taga----\n");
            bool ulazni;
            bool digital;
            string tagtype = TagTypeMenu();
            if (tagtype.Equals("1")) ulazni = true;
            else if (tagtype.Equals("2")) ulazni = false;
            else return;
            tagtype = PickDigitalAnalogMenu();
            if (tagtype.Equals("1")) digital = true;
            else if (tagtype.Equals("2")) digital = false;
            else return;
            bool success = false;
            if (ulazni && digital) success = AddDigitalInput();
            else if (ulazni && !digital) success = AddAnalogInput();
            else if (!ulazni && digital) success = AddDigitalOutput();
            else if (!ulazni && !digital) success = AddAnalogOutput();

            if (success) Console.WriteLine("Uspesno dodavanje taga...\n>>");
            else Console.WriteLine("Greska! Neuspesno dodavanje taga...\n>>");
            Console.ReadKey();
        }

        //----------//
        static void PrikazIzlaznihTagova()
        {
            if (AuthFailed())
                return;
            Console.WriteLine("--- Prikaz Izlaznih Tagova :");
            List< ServiceReference1.OutputTag> tagovi = db.GetOutputTags().ToList();
            Console.WriteLine("\n--------------------Prikaz Izlaznih Tagova--------------------\n");
            foreach (var t in tagovi)
            {
                if (t is ServiceReference1.AnalogOutput)
                {
                    var tag = (ServiceReference1.AnalogOutput)t;
                    Console.WriteLine($"ID: {tag.tagId} |InitValue: {tag.initialValue} Opis: {tag.description} | I/O address: {tag.ioAddress} | Low Limit: {tag.lowLimit} | High Limit: {tag.highLimit} |");
                }
                else
                {
                    var tag = (ServiceReference1.DigitalOutput)t;
                    Console.WriteLine($"ID: {tag.tagId} | Value: {tag.initialValue} Opis: {tag.description} | I/O address: {tag.ioAddress} | ");
                }

            }
            Console.WriteLine("\n--------------------Prikaz Adresa:Vrednosti Izlaznih Tagova--------------------\n");
            Dictionary<string, double> map = db.GetOutputTagAddressesAndValues();
            foreach(var key in map.Keys)
            {
                Console.WriteLine($"Adersa: {key} | Vrednost:{map[key]}|");
            }

            Console.WriteLine(">>");
            Console.ReadKey();
        }

        static void PrikazUlaznihTagova()
        {
            List<ServiceReference1.InputTag> tagovi = db.GetInputTags().ToList();
            Console.WriteLine("--------------------Prikaz Ulaznih Tagova--------------------");
            foreach (var t in tagovi)
            {
                if (t is ServiceReference1.AnalogInput)
                {
                    var tag = (ServiceReference1.AnalogInput)t;
                    Console.WriteLine($"ID: {tag.tagId} | Opis: {tag.description} | I/O address: {tag.ioAddress} | Interval Skrniranja: {tag.scanTime} | Scan On: {tag.scanOn} | Low Limit: { tag.lowLimit} | High Limit: { tag.highLimit} | ");
                }
                else
                {
                    var tag = (ServiceReference1.DigitalInput)t;
                    Console.WriteLine($"ID: {tag.tagId} | Opis: {tag.description} | I/O address: {tag.ioAddress} | Interval Skrniranja: {tag.scanTime} | Scan On: {tag.scanOn} |");
                }
            }
            Console.WriteLine(">>");
            Console.ReadKey();
        }

        static bool PromenaIzlaznihTagova()
        {
            if (AuthFailed())
                return false;
            PrikazIzlaznihTagova();
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("--- Promena Izlaznih Tagova :");
            Console.WriteLine("Odaberi Id Taga:\n>>");
            string input = Console.ReadLine().Trim();
            List<ServiceReference1.OutputTag> tags = db.GetOutputTags().ToList();
            var tagToChange = tags.FirstOrDefault(t => t.tagId.Equals(input));
            if (tagToChange==null)
            {
                Console.WriteLine("Nepostojeci ID Taga\n>>");
                Console.ReadKey();
                return false;
            }
            Console.WriteLine($"Unesi novu vrednost za Tag: Id[{input}]:\n>>");
            double value;
            if(!double.TryParse(Console.ReadLine().Trim(), out value))
            {
                Console.WriteLine("Unos nije validan\n>>");
                Console.ReadKey();
                return false;
            }
            
            bool success = db.SetInitialValue(tagToChange.tagId, tagToChange.ioAddress, value);
            if (success) Console.WriteLine("Uspesna Izmena taga...\n>>");
            else Console.WriteLine("Greska! Neuspesna Izmena taga...\n>>");
            Console.ReadKey();
            return success;
        }

        //----------//

        static void OnOffScan()
        {
            if (AuthFailed())
                return;
            Console.WriteLine("--- On/Off Scan:");
            PrikazUlaznihTagova();
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Odaberi Id Taga [X-nazad]:\n>>");
            string input = Console.ReadLine().Trim();
            if (input.ToLower().Equals("x")) return;
            var tags = db.GetInputTags();
            var tagToChange = tags.FirstOrDefault(t => t.tagId.Equals(input));
            if (tagToChange == null)
            {
                Console.WriteLine("Nepostojeci ID Taga\n>>");
                Console.ReadKey();
                return;
            }
            bool success = false;
            if (tagToChange.scanOn) success = db.ScanOff(tagToChange.tagId);
            else success = db.ScanOn(tagToChange.tagId);


            if (success) Console.WriteLine("Uspesna Izmena taga...\n>>");
            else Console.WriteLine("Greska! Neuspesna Izmena taga...\n>>");
            Console.ReadKey();
            return;
        


        }

        static void DodajAlarm()
        {
            if (AuthFailed())
                return;
            Console.WriteLine("--- Dodavanje Alarma:");
            PrikazUlaznihTagova();
            Console.WriteLine("Odaberi Tag[ID]\nX za Nazad:\n>>");
            string tagId = Console.ReadLine().Trim();
            if (tagId.ToLower().Equals("x"))
                return;
            List<ServiceReference1.Alarm> alarms = db.GetAlarmsForTag(tagId).ToList();
            if (alarms.Count == 0)
            {
                if(db.GetTags().ToList().FirstOrDefault(x => x.tagId.Equals(tagId))==null)
                {
                    Console.WriteLine("Ne postoji Tag sa datim ID!\n>>");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine($"Tag: {tagId} ne sadrzi ni jedan alarm!");
            }
            else
            {
                Console.WriteLine($"Tag: {tagId} alarmi: \n");
                foreach (ServiceReference1.Alarm a in alarms)
                    Console.WriteLine($"Tag: {a.tagId}\t| Type: {a.type} | AlarmID: {a.alarmId} | Tag Value: {a.tagValue} | Limit Value: {a.criticalValue}  | Priority: {a.priority}");
                Console.WriteLine("----------------------------");
            }
            Console.WriteLine("Unesi ID Novog Alarma:\n>>");
            string alarmId = Console.ReadLine().Trim();
            int tipInput = 2;
            string tip = "high";
            Console.WriteLine("Unesi tip Novog Alarma:\n1.\tLow\n2.\tHigh>>");
            int.TryParse(Console.ReadLine().Trim(), out tipInput);
            if (tipInput == 1)
                tip = "low";
            Console.WriteLine("Unesi Granicnu Vrednost Novog Alarma:\n>>");
            double trigger;
            if (!double.TryParse(Console.ReadLine().Trim(),out trigger))
            {
                trigger = 100;
            }
            Console.WriteLine("Odredi Prioritet Novog Alarma [1,2,3]:\n>>");
            int prioritet;
            if (!int.TryParse(Console.ReadLine().Trim(), out prioritet))
            {
                prioritet = 1;
            }
            if (prioritet < 1 || prioritet > 3)
                prioritet = 1;
            if (db.AddAlarm(alarmId, tagId, trigger, tip, prioritet))
                Console.WriteLine("Uspesno dodavanje Alarma\n>>");
            else
                Console.WriteLine("Greska u dodavanju alarma!\n>>");
            Console.ReadKey();
            return;



        }

        static void ObrisiAlarm()
        {
            if (AuthFailed())
                return;
            Console.WriteLine("--- Brisanje Alarma:");
            List<ServiceReference1.Alarm> alarms = db.GetAllAlarms().ToList();
            if (alarms.Count == 0)
            {
                Console.WriteLine("Nema alarma u sistemu!\n>>");
                Console.ReadKey();
                return;
            }
            foreach (ServiceReference1.Alarm a in alarms)
                Console.WriteLine($"Tag: {a.tagId}\t| Type: {a.type} | AlarmID: {a.alarmId} | Tag Value: {a.tagValue} | Limit Value: {a.criticalValue}  | Priority: {a.priority}");
            Console.WriteLine("X.\tNazad\n--------------------------------------------\n>>");
            string alarmId = Console.ReadLine().Trim();
            if (alarmId.ToLower().Equals("x"))
                return;
            if (!alarms.Any(x => x.alarmId.Equals(alarmId)))
            {
                Console.WriteLine($"Ne postoji alarm sa id: {alarmId}\n>>");
                Console.ReadKey();
                return;
            }
            ServiceReference1.Alarm alarm = alarms.First(x => x.alarmId.Equals(alarmId));
            if (db.RemoveAlarm(alarm.tagId, alarmId))
                Console.WriteLine("Uspesno Uklonjen Alarm\n>>");
            else
                Console.WriteLine("Nespesno Uklanjanje Alarma\n>>");
            Console.ReadKey();
            return;



        }


        static void Main(string[] args)
        {
            token = "";
            while(true)
            {
                if (UserDbEmpty()) RegisterDefaultAdmin();
                else
                {
                    while(token.Equals(""))         //znaci nije ulogovan niko!
                    {
                        Console.WriteLine("Login:\n");
                        string[] usrPsd = AuthMenu();
                        if (Login(usrPsd[0], usrPsd[1])) break;
                    }
                }
                //ovde sam ulogovan!!
                int input = -1;       
                while (true)
                {
                    Console.Clear();
                    MainMenu();
                    if (Int32.TryParse(Console.ReadLine(), out input))
                    {
                        if (mainMenuOptions.Contains(input))
                            break;
                    }
                }
                switch (input)
                {
                    case 0:
                        RegisterNewUser();
                        break;
                    case 1:
                        AddTag();
                        break;
                    case 2:
                        PrikazIzlaznihTagova();
                        break;
                    case 3:
                        PromenaIzlaznihTagova();
                        break;
                    case 4:
                        OnOffScan();
                        break;
                    case 5:
                        DodajAlarm();
                        break;
                    case 6:
                        ObrisiAlarm();
                        break;
                    case 7:
                        LogOut();
                        Console.Clear();
                        break;
                    default:
                        break;
                }


            }
        }
    }
}
