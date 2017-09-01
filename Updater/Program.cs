using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworkCommsDotNet;
using Drone;

namespace Updater
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static ClientSettings settings = new ClientSettings();
        public static XMLManager xmlManager = new XMLManager();
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GlobalVars.LoadSettings();
            Application.Run(new MainForm());
        }

      
       
    }

    
}
