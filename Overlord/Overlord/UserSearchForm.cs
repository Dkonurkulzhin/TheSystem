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
    public partial class UserSearchForm : Form
    {
        List<string> AllUsers = Program.uscon.ListUsers("");
        int MachineID;
        public UserSearchForm(int machineID)
        {
            InitializeComponent();
            MachineID = machineID;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox1.Text;
            if (filter.Length >= 3) UpdateUserList(filter);
        }


        private void UpdateUserList(string filter)
        {
            listView1.Clear();
            listView1.View = View.List;
            List<string> usersToShow = Program.uscon.ListUsers(filter);
            foreach (string user in usersToShow)
                listView1.Items.Add(user);
        }

        private void UserSearchForm_Load(object sender, EventArgs e)
        {

            textBox1.KeyDown += new KeyEventHandler(EnterPressed);
            //        tb.KeyDown += new KeyEventHandler(tb_KeyDown);

            //        static void tb_KeyDown(object sender, KeyEventArgs e)
            //        {
            //            if (e.KeyCode == Keys.Enter)
            //            {
            //    //enter key is down
            //}
            //        }
        }

        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox1.Text != "")
            {
                if (AllUsers.Contains(textBox1.Text))
                {
                    LogInUser(textBox1.Text);
                }
            }
        }

        private User GetUserByName(string name)
        {
            return Program.uscon.LoadUser(name);
        }

        private void LogInUser(string username)
        {
            User user = Program.uscon.LoadUser(username);
            if (user == null)
                return;

            if (MachineManager.LogInUser(MachineID, GetUserByName(user.name)))
            {
               DialogResult res =  MessageBox.Show("Пополнить счет?", "Недостаточно средств", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             
            }
            ClientCommunicationManager.SendUserObject(user, MachineManager.Machines[MachineID].IP);
            MessageBox.Show("User found:" + user.name);
            Program.MainForm.UpdatePCList();
            this.Close();
            
        }
            

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null)
                LogInUser(listView1.SelectedItems[0].Text);
               
        }
    }
}
