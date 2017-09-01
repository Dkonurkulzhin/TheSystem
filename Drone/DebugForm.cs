using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drone
{
     public partial class DebugForm : Form
    {
        ProcessManager ProcManager = new ProcessManager();

        public  DebugForm()
        {
            InitializeComponent();
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {
            label1.Text = label1.Text + GlobalVars.ScreenWidth.ToString() + "x" + GlobalVars.ScreenHeight.ToString();
            WinUserLabel.Text = WinUserLabel.Text + FileSystemAccessManager.SystemUserName;
        }

       public void PrintToLog(string item, bool PrintTime = false)
        {
            if (PrintTime)
                item = item + DateTime.Now.ToString("h:mm:ss tt");
            Log.Items.Add(item);
        }

        private void ViewProcBtn_Click(object sender, EventArgs e)
        {
            ProcessList.Items.Clear();
            foreach (string pname in ProcManager.ViewProcesses())
            {
                ProcessList.Items.Add(pname);

            }
        }

        private void KillProcBtn_Click(object sender, EventArgs e)
        {
            ProcManager.KillAllActive(GlobalVars.ProcessExceptions);
            ProcessList.Items.Clear();
            foreach (string pname in ProcManager.ViewProcesses()) ProcessList.Items.Add(pname);

        }
    }
}
