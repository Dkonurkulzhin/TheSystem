using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Overlord
{
    public static class XMLManager
    {
        // Логика сериализации и десереализации объектова в и из XML
        // Для сервера и клиента
        private static string AppDataPath; //=GlobalVars.AppDataName;
        private static string DataPath = GlobalVars.DataPath;
        private static string FinancialPath = GlobalVars.FinancialPath;
        private static string Xmldot = ".xml";
        

        public static void SerializeAppData(AppUnit App, int AppID)
        {
            
            XmlSerializer AppXS = new XmlSerializer(typeof(AppUnit));
            string CurrentAppDataPath = AppDataPath + AppID.ToString() + Xmldot;

            if (!File.Exists(@CurrentAppDataPath))
            {
                File.Create(CurrentAppDataPath);

            }
            TextWriter AppTW = new StreamWriter(@CurrentAppDataPath);
            AppXS.Serialize(AppTW, App);
        }

        public static AppUnit DeserializeAppData(int AppID)
        {
            XmlSerializer AppXS = new XmlSerializer(typeof(AppUnit));
            string CurrentAppDataPath = AppDataPath + AppID.ToString() + Xmldot;

            using (var AppSR = new StreamReader(@CurrentAppDataPath))
            {
                AppUnit App = (AppUnit)AppXS.Deserialize(AppSR);
                return (App);
            }
            
        }
        public static void SerializeCashData(Cashbox cashbox)
        {
            XmlSerializer cashXS = new XmlSerializer(typeof(Cashbox));
            string CurrentDataPath = FinancialPath + "cashbox" + Xmldot;

            if (!File.Exists(@CurrentDataPath))
            {
                var newFile = File.Create(CurrentDataPath);
                newFile.Close();
            }
            TextWriter cashTW = new StreamWriter(@CurrentDataPath);
            cashXS.Serialize(cashTW, cashbox);
            cashTW.Close();
           
        }

        public static Cashbox DeserializeCashData()
        {
            XmlSerializer cashXS = new XmlSerializer(typeof(Cashbox));
            string CurrentDataPath = FinancialPath + "cashbox" + Xmldot;
            if (!File.Exists(@CurrentDataPath))
            {
                return null;
            }
            try
            {
                using (var cashSR = new StreamReader(@CurrentDataPath))
                {
                    Cashbox cashbox = (Cashbox)cashXS.Deserialize(cashSR);
                    cashSR.Close();
                    return (cashbox);

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public static void SerializeProductData(Product item, string productname)
        {
            XmlSerializer productXS = new XmlSerializer(typeof(Product));
            string CurrentDataPath = GlobalVars.ProductPath + productname + Xmldot;

            if (!File.Exists(@CurrentDataPath))
            {
               var newFile = File.Create(CurrentDataPath);
               newFile.Close();
                
            }
            
            TextWriter productTW = new StreamWriter(@CurrentDataPath);
            productXS.Serialize(productTW, item);
            productTW.Close();
        }

        public static Product DeserializeProductData(string productname)
        {
            XmlSerializer productXS = new XmlSerializer(typeof(Product));
            string CurrentDataPath = GlobalVars.ProductPath + productname + Xmldot;
            if (!File.Exists(@CurrentDataPath))
            {
                Console.WriteLine(CurrentDataPath + " not found");
                return null;
            }
            try
            {
                using (var productSR = new StreamReader(@CurrentDataPath))
                {
                    Product product = (Product)productXS.Deserialize(productSR);
                    productSR.Close();
                   
                    return (product);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(CurrentDataPath + " error :" + e.ToString());
                return null;
            }

        }

        public static bool DeleteProductData(string productname)
        {
            string currentPath = GlobalVars.ProductPath + productname + ".xml";
            if (!File.Exists(@currentPath))
            {
                return false;
            }
            try
            {
                File.Delete(@currentPath);
                return true;
            }
            catch (IOException)
            {
                return false;
            }
           
        }
        static bool IsFileLocked(string filename)
        {

            FileInfo file = new FileInfo(filename);
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException e)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                Console.WriteLine(e.ToString());
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        public static void SerializeGlobalSettings(GlobalSettings settings)
        {
            XmlSerializer globalXS = new XmlSerializer(typeof(GlobalSettings));
            string CurrentDataPath = DataPath + "global" + Xmldot;

            if (!File.Exists(@CurrentDataPath))
            {
                var newFile = File.Create(CurrentDataPath);
                newFile.Close();
            }
            TextWriter globalTW = new StreamWriter(@CurrentDataPath);
            globalXS.Serialize(globalTW, settings);
            globalTW.Close();

        }

        public static GlobalSettings DeserializeGlobalSettings()
        {
            XmlSerializer globalXS = new XmlSerializer(typeof(GlobalSettings));
            string CurrentDataPath = DataPath + "global" + Xmldot;
            if (!File.Exists(@CurrentDataPath))
            {
                return null;
            }
            try
            {
                using (var globalSR = new StreamReader(@CurrentDataPath))
                {
                    GlobalSettings settings = (GlobalSettings)globalXS.Deserialize(globalSR);
                    globalSR.Close();
                    return (settings);

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void SerializeMachines(Machine machine)
        {
            XmlSerializer machineXS = new XmlSerializer(typeof(Machine));
            string CurrentDataPath = GlobalVars.MachinePath + GlobalVars.MachineInnerLabel + machine.index.ToString() + Xmldot;

            if (!File.Exists(@CurrentDataPath))
            {
                var newFile = File.Create(CurrentDataPath);
                newFile.Close();

            }

            TextWriter machineTW = new StreamWriter(@CurrentDataPath);
            machineXS.Serialize(machineTW, machine);
            machineTW.Close();
        }

        public static Machine DeserializeMachine(int machineID)
        {
            XmlSerializer machineXS = new XmlSerializer(typeof(Machine));
            string CurrentDataPath = GlobalVars.MachinePath + GlobalVars.MachineInnerLabel + machineID + Xmldot;
            if (!File.Exists(@CurrentDataPath))
            {
                return null;
            }
            try
            {
                using (var machineSR = new StreamReader(@CurrentDataPath))
                {
                    Machine machine = (Machine)machineXS.Deserialize(machineSR);
                    machineSR.Close();
                    return (machine);

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
