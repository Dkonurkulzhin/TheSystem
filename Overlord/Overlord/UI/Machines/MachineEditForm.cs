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
    public partial class MachineEditForm : Form 
    {
        Machine machine;
        MachineConfigForm parentform;
        public MachineEditForm(Machine thismachine, MachineConfigForm thisparentform)
        {
            machine = thismachine;
            parentform = thisparentform;
            InitializeComponent();    
        }

        private void MachineEditForm_Load(object sender, EventArgs e)
        {
            IDText.Text = (machine.index + 1).ToString();
            LabelText.Text = machine.label;
            
            foreach (var item in GlobalVars.Settings.MacineGroups)
                comboBox1.Items.Add(item);

            LoadMachineGroup();
        }

        private void LabelText_TextChanged(object sender, EventArgs e)
        {
            machine.label = LabelText.Text;
            MachineManager.SaveMachine(machine);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            machine.group = comboBox1.SelectedItem.ToString();
            MachineManager.SaveMachine(machine);
            Console.WriteLine(comboBox1.SelectedItem.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadMachineGroup()
        {
            if (comboBox1.Items.Count > 0)
                foreach(var item in comboBox1.Items)
                {
                    Console.WriteLine(item.ToString() + " and " + machine.group);
                    if (item.ToString() == machine.group)
                        comboBox1.SelectedItem = item;
                } 
        }

        private void MachineEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.MainForm.UpdatePCList();
        }
    }
}
