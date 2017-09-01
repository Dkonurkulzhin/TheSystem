using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    public class ClientSettings
    {
        public string adminPassword = "admin";
        public int pcNumber = 0;
        public string serverIP = "127.0.0.1";
        public int pcsAmount = 0;
        public string applicationDirectory;
        public List<string> AppCategories = new List<string>(new string[] { "Игры", "Интернет", "Офис", "Настройки" });
    }
}
