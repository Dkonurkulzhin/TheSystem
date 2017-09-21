using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Drone
{
    public partial class InitForm : Form
    {
        ProcessManager ProcMNG = new ProcessManager();
        public InitForm()
        {
            InitializeComponent();
            Application.DoEvents();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InitForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            this.TopMost = false;

            LoadingLabel.Text = "Checking Admin status...";
            if (!Program.CheckAdmin())
                MessageBox.Show("Please run this as admin");
            Application.DoEvents();
            LoadingLabel.Text = "Configuring filesystem...";
            string[] DirExceptions = new string[] {@"D:\\Work", @"C:\\Users", @"C:\\Windows"};
            FileSystemAccessManager.Authority = true;
            //FileSystemAccessManager.ApplyFilesystemPremissions("Dias", DirExceptions, true);
            RegistryManager.SetTaskManager(false);
           //FileSystemAccessManager.ApplyFilesystemPremissions("Dias", DirExceptions, true);

            // if (!ProcMNG.DisableWinShell())
            //    MessageBox.Show("Cannot disable Windows Shell");

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in allDrives)
            {
                //Program.DevForm.PrintToLog(drive.Name +", " + drive.IsReady.ToString());
                //if (drive.IsReady)
                //    foreach (string dir in Directory.GetDirectories(drive.Name))
                //        if (Directory.Exists(dir))
                //            Program.DevForm.PrintToLog("Found Dir: " + dir);
            }
            this.Close();

        }
    }
}
