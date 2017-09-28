using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overlord
{
    public class GlobalSettings
    { 
        public string Telegram_BotAPIkey;
        public long Telegram_ChatID;
        public bool Telegram_notifyProducts;
        public bool Telegram_notifyEnd;
        public bool Telegram_notifyStockEdit;

        public string Administration_AdminPassword;

        public bool Products_ShowOnlyAvailable;

        public List<string> AuthorityMenuItems = new List<string>();

        public int Consoles_amount;
        public string[] Consoles_Labels;

        public int PC_amount;
        public List<string> MacineGroups = new List<string>();
        public List<string> UserGroups = new List<string>();
        public long Machines_MaxAddTime = 1440;

        public string UpdateFolder = "";

    }
}
