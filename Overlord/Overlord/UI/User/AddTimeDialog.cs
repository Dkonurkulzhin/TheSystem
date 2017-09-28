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
    public partial class AddTimeDialog : Form
    {
        private int price = 5;
        private long total;
        bool setTime;
       
        List<Machine> machines = new List<Machine>();
        Machine oneMachine;
        public AddTimeDialog(List<Machine> machinesToAdd, bool SetTime = true)
        {
            machines = machinesToAdd;
            setTime = SetTime;
            if (machines.Count <= 1)
                oneMachine = machines.First();
            InitializeComponent();
        }

        private void AddTimeDialog_Load(object sender, EventArgs e)
        {
           
            numericUpDown1.Maximum = GlobalVars.Settings.Machines_MaxAddTime;
            numericUpDown2.Maximum = numericUpDown1.Maximum * price;
            button1.Enabled = false;
            if (machines.Count <= 1)
                ShowOneMachineInfo();
            else
                ShowSeveralMachinesInfo();
            if (setTime)
            {
                numericUpDown1.Select();
                numericUpDown1.Select(0, numericUpDown1.Text.Length);
            }
            else
            {
                numericUpDown2.Select();
                numericUpDown2.Select(0, numericUpDown1.Text.Length);
            }

        }

        private void ShowOneMachineInfo()
        {
        
            textBox1.Text = oneMachine.time.ToString();
            textBox2.Text = oneMachine.balance.ToString();
            richTextBox1.Text = oneMachine.label + "(" + MachineManager.StatusLabels[oneMachine.status] + ")" + ", ";
            textBox3.Text = oneMachine.username;
            Text += oneMachine.username;
        }

        private void ShowSeveralMachinesInfo()
        {
            foreach (Machine item in machines)
            {
              
                richTextBox1.Text += item.label + "(" + MachineManager.StatusLabels[item.status] + ")" + ", ";
            }
            MachinesInfoGroup.Text = "Компьютеры";
            textBox1.Text = "-";
            textBox2.Text = "-";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Value = Math.Round(numericUpDown1.Value * price);
            UpdateTotal();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = Math.Round(numericUpDown2.Value / price);
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            total = (long)numericUpDown2.Value * machines.Count;
            

            totalText.Text = total.ToString();
            numericUpDown4.Value = total;


        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if ((long)numericUpDown4.Value - total < 0 || total <= 0)
            {
                button1.Enabled = false;
            }
            else
                button1.Enabled = true;
            cashbackText.Text = ((long)numericUpDown4.Value - total).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}

//