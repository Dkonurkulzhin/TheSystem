using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overlord
{
    static class Program
    {
        static public Form1 MainForm;
        static public ConsoleForm consoleForm;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        
        static void Main()
        {
            GlobalVars.LoadSettings();

            ProductManager.UpdateProductList();
            GlobalVars.InitDataPathes();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            ClientCommunicationManager.Init();
            MainForm = new Form1();
            consoleForm = new ConsoleForm();
            consoleForm.Hide();
            InitManagers();


            Application.Run(MainForm);
            
        }
        static void InitManagers()
        {
            MachineManager.Initialize();
            FinancialManager.Initialize();
            UserManager.Initialize();
            ProductManager.Initialize();
            TelegramManager.InitBot();
            DebugManager.Initialize();

        }

       
       
    }
}
