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
    public partial class ClientSettingsForm : Form
    {
        public ClientSettingsForm()
        {
            InitializeComponent();
        }

      

        private void ClientSettingsForm_Load(object sender, EventArgs e)
        {
            PCNumberNum.Value = GlobalVars.settings.pcNumber;
            //maskedTextBox1.Mask = "###.###.###.###";
            maskedTextBox1.ValidatingType = typeof(System.Net.IPAddress);
            maskedTextBox1.Text = GlobalVars.settings.serverIP;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UIManager.ExitShell();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UIManager.ExitShell();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User admin = new User();
            admin.name = "Администратор";
            Program.LogIn(admin);
        }

        private void PCNumberNum_ValueChanged(object sender, EventArgs e)
        {
            GlobalVars.settings.pcNumber = (int)PCNumberNum.Value;
            GlobalVars.SaveSettings();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void maskedTextBox1_Validated(object sender, EventArgs e)
        {
            GlobalVars.settings.serverIP = maskedTextBox1.Text;
            GlobalVars.SaveSettings();
            Console.WriteLine("new server IP: " + maskedTextBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.PerformUpdate();
        }
    }
}
