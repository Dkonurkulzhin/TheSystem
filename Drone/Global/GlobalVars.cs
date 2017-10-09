using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Drone
{
    public static class GlobalVars
    {

        static public bool debug = true;
        // пути к xml файлам конфига
        public static string RootDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\";
        static public string AppDataName = RootDirectory + @"ApplicationsData\";
        static public string SettingsPath = RootDirectory;
        static public string LinkDirectory = RootDirectory + @"ApplicationLinks\";
        static public string BackGroundDirectory = RootDirectory + @"Backgrounds\";
        // пути к ресурсам интерфейса
        static public string InterfaceResPath = RootDirectory + @"Resources\";
        // пути к сторонним инструментам
        static public string UpdaterDirectory = RootDirectory + @"Updater\";
        static public string UpdaterPath = UpdaterDirectory + "updater.exe";
        static public ClientSettings settings;
        static public bool isUpToDate = true;
        
        static public int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
        static public int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;

        static public string[] ProcessExceptions = {"Drone","Vs","devenv","Microsoft"};
        static public volatile bool StopApplyingRights = false;

        // пути к репозиторию
        static public string UpdateInfoLink = "https://raw.githubusercontent.com/Dkonurkulzhin/SystemBuilds/master/Client/UpdateInfo.xml";

        static XMLManager xmlManager = new XMLManager(); 
        static public RateSettings rateSettings = new RateSettings();
        
     
        public static class InterfaceConfig
        {
            public class UserStatPos
            {
                public static int X = (int)(0.3F * ScreenWidth);
                public static int Y = (int)(0.84F * ScreenHeight);
            }
        }

        public static void Initialize()
        {
            LoadSettings();
            CreateSystemFolders();
            NetworkManager.OnConfig += GetConfigurationFromServer;

        }

        private static void GetConfigurationFromServer(MachineConfiguration config)
        {
            settings.PCLabel = config.MachineLabel;
            settings.PriceMultiplier = config.PriceMultiplier;
            SaveSettings();
        }



        public static bool LoadSettings()
        {
            
            settings = xmlManager.DeserializeSettings();
            if (settings == null)
            {
                settings = new ClientSettings();
                return false;
            }
            else
            {
                
                return true;
            }
           
        }

        public static void SaveSettings()
        {
            xmlManager.SerializeSettings(settings);
        }


        public static void CreateSystemFolders()
        {
            if (!Directory.Exists(AppDataName))
                Directory.CreateDirectory(AppDataName);
            if (!Directory.Exists(SettingsPath))
                Directory.CreateDirectory(SettingsPath);
            if (!Directory.Exists(LinkDirectory))
                Directory.CreateDirectory(LinkDirectory);
            if (!Directory.Exists(BackGroundDirectory))
                Directory.CreateDirectory(BackGroundDirectory);
            if (!Directory.Exists(InterfaceResPath))
                Directory.CreateDirectory(InterfaceResPath);
            foreach (string subCategory in GlobalVars.settings.AppCategories)
            {
                if (!Directory.Exists(LinkDirectory + subCategory))
                    Directory.CreateDirectory(LinkDirectory + subCategory);
            }
            if (!Directory.Exists(UpdaterDirectory))
                Directory.CreateDirectory(UpdaterDirectory);
            settings.applicationDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\";
            SaveSettings();
        }

        
    }
}
