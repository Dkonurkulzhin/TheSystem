using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overlord
{
    public partial class ConsoleForm : Form
    {
        public ConsoleTimerForm[] ConsoleTimers = { };
        public ConsoleForm()
        {
            InitializeComponent();
        }

        private void ConsoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void ConsoleForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            ConsoleTimers = new ConsoleTimerForm[GlobalVars.Settings.Consoles_amount];
            for (int i = 0; i < ConsoleTimers.Length; i++)
            {
                ConsoleTimers[i] = new ConsoleTimerForm();
                ConsoleTimers[i].MdiParent = this;
                ConsoleTimers[i].Show();
                ConsoleTimers[i].Location = new Point(ConsoleTimers[i].Location.X, i *(ConsoleTimers[i].Height + 10));
                ConsoleTimers[i].ConsoleTag.Text = GlobalVars.Settings.Consoles_Labels[i];
                ConsoleTimers[i].parentForm = this;
                //this.Size = new Size(ConsoleTimers[i].Width, (ConsoleTimers[i].Height+10)*ConsoleTimers.Length);
            }

        }
    }
}
