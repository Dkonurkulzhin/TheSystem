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
    public partial class MachineConfigForm : Form
    {
        private MachineEditForm machineEditForm;

        private Dictionary<string, float> GroupMultipliers;

        public MachineConfigForm()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PCconfigForm_Load(object sender, EventArgs e)
        {
            LoadList();
            UpdateGroupList();
            numericUpDown1.Value = GlobalVars.Settings.PC_amount;
            numericUpDown1.ValueChanged += new EventHandler(UpdateMachineCount);
            GroupMultipliers = MachineManager.GetMachineGroupPriceMultiplier();
        }


        private void LoadList()
        {
            listView1.Items.Clear();
            // var imageList = new ImageList();
            // imageList.ImageSize = new Size(32, 32);
            //listView1.LargeImageList = imageList;
            listView1.View = View.SmallIcon;

            foreach (string group in GlobalVars.Settings.MacineGroups)
            {
                ListViewGroup machineGroup = new ListViewGroup();
                machineGroup.Header = group;
                machineGroup.Name = group;
                listView1.Groups.Add(machineGroup);
            }
            listView1.ShowGroups = true;

            foreach (Machine machine in MachineManager.Machines)
            {
                ListViewItem item = new ListViewItem();
                item.Text = machine.label + "(" + (machine.index + 1).ToString() + ")";
            

                foreach (ListViewGroup group in listView1.Groups)
                {
                    if (machine.group == group.Header)
                        item.Group = group;

                }

                listView1.Items.Add(item);
            }

            //foreach(ListViewItem item in listView1.Items)
            //{
            //    item.Text += "(" + item.Index.ToString() + ")";
            //}
            
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems != null)
            {
                int currentindex;
                if (listView1.SelectedItems != null)
                    currentindex = listView1.SelectedItems[0].Index;
                else
                    currentindex = -1;
                if (e.Button == MouseButtons.Left && currentindex >= 0)
                {
                    if (machineEditForm != null)
                        machineEditForm.Close();
                    machineEditForm = new MachineEditForm(MachineManager.Machines[currentindex], this);
                    machineEditForm.Show();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
            {
                MessageBox.Show("Введите название группы", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox1.Text.Contains(" "))
            {
                MessageBox.Show("Название группы не должно содержать пробелы", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
               

            if (!GlobalVars.Settings.MacineGroups.Contains(textBox1.Text))
                GlobalVars.Settings.MacineGroups.Add(textBox1.Text);
            UpdateGroupList();
            GlobalVars.SaveSettings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() == GlobalVars.DefaultMachineGroup)
            {
                MessageBox.Show("Нельзя удалить стандартную группу", "Удаление",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (Machine machine in MachineManager.Machines)
            {
                if (listBox1.SelectedItem.ToString() == machine.group)
                {
                    MessageBox.Show("Нельзя удалить не пустую группу", "Удаление",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            GlobalVars.Settings.MacineGroups.Remove(listBox1.SelectedItem.ToString());
            int groupIndex = GlobalVars.Settings.MacineGroups.IndexOf(listBox1.SelectedItem.ToString());
            GlobalVars.Settings.MacineGroupsMultiplier.Remove(GlobalVars.Settings.MacineGroupsMultiplier[groupIndex]);
            UpdateGroupList();
            LoadList();
            GlobalVars.SaveSettings();
        }

        private void UpdateGroupList()
        {
            listBox1.Items.Clear();
            GroupMultipliers = MachineManager.GetMachineGroupPriceMultiplier();
            foreach (var group in GlobalVars.Settings.MacineGroups)
                listBox1.Items.Add(group);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сброс удалит настройки групп и названия компьютеров. Продолжить?", "Сброс", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MachineManager.InitMachines();
                MachineManager.SaveMachines();
                MachineManager.LoadMachines();
                LoadList();
            }
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void UpdateMachineCount(object sender, EventArgs e)
        {
            int oldCount = GlobalVars.Settings.PC_amount;
            GlobalVars.Settings.PC_amount = (int)numericUpDown1.Value;
            GlobalVars.SaveSettings();
            MachineManager.AddMachine(oldCount, GlobalVars.Settings.PC_amount);
            LoadList();

            Program.MainForm.UpdatePCList();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            ChangePriceSettings( ( (float)numericUpDown2.Value)/100);
        }

        private void ChangePriceSettings(float newMultiplier)
        {
           if (listBox1.SelectedIndex >= 0)
           {
                GroupMultipliers[listBox1.SelectedItem.ToString()] = newMultiplier;
                SaveGroupSettings();
           }
        }

        private void SaveGroupSettings()
        {
            GlobalVars.Settings.MacineGroups = GroupMultipliers.Keys.ToList();
            GlobalVars.Settings.MacineGroupsMultiplier = GroupMultipliers.Values.ToList();
            GlobalVars.SaveSettings();
            MachineManager.SaveMachines();
            MachineManager.LoadMachines();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PriceBox.Enabled = (listBox1.SelectedIndex >= 0);
            if (listBox1.SelectedIndex >= 0)
            {
                numericUpDown2.Value = (decimal)(100 * GroupMultipliers[listBox1.SelectedItem.ToString()]);
            }


        }
    }
}
