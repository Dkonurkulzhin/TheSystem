using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overlord
{
    static class Program
    {
        static public XMLManager xmlmanager = new XMLManager();
        static public Cashbox cashbox = new Cashbox();
        static public TempUserControllu uscon = new TempUserControllu();

        static public Form1 MainForm;
        static public ConsoleForm consoleForm;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

       
        static void Main()
        {
            GlobalVars.LoadSettings();
            LoadCashData();
            ProductManager.UpdateAvailableProducts();
            GlobalVars.InitDataPathes();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TelegramManager.InitBot();
            MachineManager.LoadMachines();

            MainForm = new Form1();
            consoleForm = new ConsoleForm();
            consoleForm.Hide();


            Application.Run(MainForm);
            
        }

        public static void LoadCashData()
        {
            cashbox = xmlmanager.DeserializeCashData();
        }
       
    }
}
