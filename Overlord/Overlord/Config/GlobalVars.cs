using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Overlord
{
    static class GlobalVars
    {
        public static bool debug = true; //дебаг

        public static bool isLocal = true;
        public static string SoftWareVersion = "inDev";
        public static string DefaultCurrency = "tg";

        public static string MachineInnerLabel = "pc";

        public static string DataPath = AppDomain.CurrentDomain.BaseDirectory + @"data\";
        public static string FinancialPath = DataPath + @"financial\";
        public static string ProductPath = DataPath + @"products\";
        public static string MachinePath = DataPath + @"machines\";
        public static string TempUserPath = DataPath + @"users\";

        public static string ResourcesPath = AppDomain.CurrentDomain.BaseDirectory + @"resources\";
        public static string IconsPath = ResourcesPath + @"icons\";

        public static string TelegramBotAPIkey;
        public static long TelegramChatID;

        public static string DefaultMachineGroup = "Default";
        public static GlobalSettings Settings = new GlobalSettings();
        public static bool Authority = false;

        public static Image FreePCimg = Image.FromFile(IconsPath + @"ready16.bmp");
        public static Image OKPCimg = Image.FromFile(IconsPath + @"enabled16.bmp");
        public static Image ReservedPCimg = Image.FromFile(IconsPath + @"reserved16.bmp");
        //public static ImageList MachineStatImages = newMachineStatImageList();

        public static ImageList newMachineStatImageList(int size)
        {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(size, size);
            Dictionary<MachineManager.MachineStatus, string> ImagesDict = new Dictionary<MachineManager.MachineStatus, string>() {
                 {MachineManager.MachineStatus.Ready, IconsPath + @"ready.png"  },
                 {MachineManager.MachineStatus.Busy,IconsPath +"busy.png"},
                 {MachineManager.MachineStatus.Reserved, IconsPath + "reserved.png"},
                 {MachineManager.MachineStatus.Disabled, IconsPath + @"disabled.png" },
                 {MachineManager.MachineStatus.Unavailable, IconsPath + "outoforder.png"}
            };
            foreach (MachineManager.MachineStatus stat in Enum.GetValues(typeof(MachineManager.MachineStatus)))
            {
                try
                {
                    imageList.Images.Add(stat.ToString(), Image.FromFile(ImagesDict[stat]));
                    Console.WriteLine("pic loaded");   
                }
                catch (Exception e)
                {

                }
                
            }
            return imageList;
        }

        public static void LoadSettings()
        {
            //Settings.Telegram_BotAPIkey = "353962558:AAFyXOdXIr1RkpZfF1lAaVNFtrs1_7cMgy4";
            //Settings.Telegram_ChatID = -164571152;
            //SaveSettings();

            Settings = Program.xmlmanager.DeserializeGlobalSettings();
            if (Settings != null)
            {
                TelegramBotAPIkey = Settings.Telegram_BotAPIkey;
                TelegramChatID = Settings.Telegram_ChatID;
            }
            Settings.Administration_AdminPassword = "test1234";
            Settings.AuthorityMenuItems.Add("Настройки кассы"); Settings.AuthorityMenuItems.Add("Добавление продуктов");
            Settings.AuthorityMenuItems.Add("Настройки Telegram"); Settings.AuthorityMenuItems.Add("Настройки консолей");
            Settings.AuthorityMenuItems.Add("Выйти из под админа"); Settings.AuthorityMenuItems.Add("Настройки");

            
            if (!Settings.MacineGroups.Contains(DefaultMachineGroup))
                Settings.MacineGroups.Add(DefaultMachineGroup);
            InitConsoles();
            SaveSettings();
        }

        public static void SaveSettings()
        {
            Program.xmlmanager.SerializeGlobalSettings(Settings);
        }
           
        

        public static void InitDataPathes()
        {
            if (!Directory.Exists(DataPath))
                Directory.CreateDirectory(DataPath);
            if (!Directory.Exists(FinancialPath))
                Directory.CreateDirectory(FinancialPath);
            if (!Directory.Exists(ProductPath))
                Directory.CreateDirectory(ProductPath);
            if (!Directory.Exists(MachinePath))
                Directory.CreateDirectory(MachinePath);
            if (!Directory.Exists(TempUserPath))
                Directory.CreateDirectory(TempUserPath);



        }

        public static void InitConsoles()
        {
            if (Settings.Consoles_Labels == null)
            {
               string[] names = new string[Settings.Consoles_amount];
               for (int i = 0; i < Settings.Consoles_amount; i++)
                    names[i] = "Консоль " + (i + 1).ToString();
               Settings.Consoles_Labels = names;
               
            }
        }

    }

   
}
