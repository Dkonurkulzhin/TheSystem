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
    public partial class ConsoleSettingsForm : Form
    {
        private int itemToEditIndex = -1;
        public ConsoleSettingsForm()
        {
           
            InitializeComponent();
        }


        private void UpdateList()
        {
            listBox1.Items.Clear();
            
            foreach (string name in GlobalVars.Settings.Consoles_Labels)
                listBox1.Items.Add(name);
        }

        private void ConsoleSettingsForm_Load(object sender, EventArgs e)
        {
            
            UpdateList();
            numericUpDown1.Value = GlobalVars.Settings.Consoles_amount;
            numericUpDown1.ValueChanged += new EventHandler(SetConsoleCount);
        }

        private void SetConsoleCount(object sender, EventArgs e)
        {
            int newAmount = (int)numericUpDown1.Value;
          
          
                int prevAmount = (GlobalVars.Settings.Consoles_amount);
                if (newAmount > prevAmount)
                {
                    string[] names = new string[newAmount];
                    for (int i = 0; i < prevAmount; i++)
                        names[i] = GlobalVars.Settings.Consoles_Labels[i];
                    for (int i = prevAmount; i < newAmount; i++)
                        names[i] = "Консоль " + (i + 1).ToString();
                    GlobalVars.Settings.Consoles_Labels = names;
                }
                else
                {
                    string[] names = new string[newAmount];
                    for (int i = 0; i < newAmount; i++)
                        names[i] = GlobalVars.Settings.Consoles_Labels[i];
                    GlobalVars.Settings.Consoles_Labels = names;
                }
                UpdateList();
           GlobalVars.Settings.Consoles_amount = newAmount;
           GlobalVars.SaveSettings();
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
                textBox1.ReadOnly = false;
                itemToEditIndex = listBox1.SelectedIndex;
            }
            else
            {
                textBox1.ReadOnly = true;
                itemToEditIndex = -1;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (itemToEditIndex >= 0 && itemToEditIndex < GlobalVars.Settings.Consoles_amount)
                if (textBox1.Text != null && textBox1.Text != "")
                {
                    GlobalVars.Settings.Consoles_Labels[itemToEditIndex] = textBox1.Text;
                    GlobalVars.SaveSettings();
                    textBox1.Text = "";
                    UpdateList();
                    textBox1.ReadOnly = true;
                }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
