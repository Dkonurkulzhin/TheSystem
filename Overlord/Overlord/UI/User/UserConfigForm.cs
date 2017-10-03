using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Overlord
{
    public partial class UserConfigForm : Form
    {
        //Thread searchThread = new Thread(UpdateListView);
        UserAddForm userAddForm;
        int lastSearchFilterLength = 0;
        

        public UserConfigForm()
        {
            InitializeComponent();
        }

        private void DoUpdate(String filter)
        {
            
            // this code can only be reached
            // by the user interface thread
            this.textBox1.Text = filter;
        }


        private void UserConfigForm_Load(object sender, EventArgs e)
        {
            listBox1.MouseDown += new MouseEventHandler(listBox1_MouseDown);
            
            UpdateUserList("");



            //Thread st = new Thread(TestThread);
            //st.Start();
            // UpdateList();
            //  UpdateListView();

        }

        public void UpdateInfo(User user)
        {
            if (user == null)
                return;
            NameLabel.Text = user.name;
            BalanceLabel.Text = "Баланс: " + user.balance.ToString();
            LevelLabel.Text = "Уровень: " + user.level.ToString();
            ExpLabel.Text = "Опыт: " + user.exp.ToString();
            RateLabel.Text = "Тариф: " + UserManager.GetCurrentRate(user, UserManager.RateFormat.perHour).ToString() + "в час";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            listView1.View = View.List;
            List<string> users = UserManager.GetUserList();
            foreach (string user in users)
                if (user.Contains(textBox1.Text))
                    listView1.Items.Add(user);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null)
            {
                DialogResult = MessageBox.Show("Удалить пользователя " + listView1.SelectedItems[0].Text + "?"
                    , "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (DialogResult == DialogResult.Yes)
                {
                    MessageBox.Show(UserManager.DeleteUser(listView1.SelectedItems[0].Text) ? "Пользовтель удален" : "Пользовтель не найден", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateUserList(textBox1.Text);
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
           UpdateUserList(textBox1.Text);

        }

        private void UpdateUserList(string filter)
        {
            listView1.Clear();
            listView1.View = View.List;
            List<string> users = UserManager.GetUserList(filter);
            foreach (string user in users)
                listView1.Items.Add(user);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (userAddForm != null)
                userAddForm.Close();
            userAddForm = new UserAddForm(this);
            userAddForm.Show();

        }

        private void UpdateUserGroups()
        {
            foreach(string userGroup in GlobalVars.Settings.UserGroups)
            {
                listBox1.Items.Add(userGroup);
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
     
          
        }

        private void editGroup(object sender, EventArgs e)
        {

        }

        private void deleteGroup(object sender, EventArgs e)
        {

        }

        private void addGroup(object sender, EventArgs e)
        {

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
           
         
        }

        private ContextMenu ShowContexMenu()
        {
            ContextMenu groupMenu = new ContextMenu();

            if (listBox1.SelectedIndex == ListBox.NoMatches)
            {
                MenuItem add = new MenuItem();
                add.Text = "Создать";
                add.Click += new EventHandler(addGroup);
                groupMenu.MenuItems.Add(add);
            }
            else
            {
                MenuItem edit = new MenuItem();
                edit.Text = "Изменить";
                edit.Click += new EventHandler(editGroup);
                groupMenu.MenuItems.Add(edit);

                MenuItem delete = new MenuItem();
                delete.Text = "Удалить";
                delete.Click += new EventHandler(deleteGroup);
                groupMenu.MenuItems.Add(delete);
            }
            return groupMenu;
            
        }

        void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.Button.ToString());
            if (e.Button == MouseButtons.Right)
            {
                int index = this.listBox1.IndexFromPoint(e.X, e.Y);
                if (index != ListBox.NoMatches)
                {

                }

            }

            Console.WriteLine(e.Button.ToString());
            if (e.Button == MouseButtons.Right)
            {
                int index = listBox1.IndexFromPoint(e.X, e.Y);
                if (index != ListBox.NoMatches)
                {
                    listBox1.SelectedIndex = index;
                    ShowContexMenu().Show(this, new Point(e.X, e.Y + listBox1.Location.Y));
                }
                else
                {
                    listBox1.SelectedIndex = ListBox.NoMatches;
                    ShowContexMenu().Show(this, new Point(e.X, e.Y + listBox1.Location.Y));
                }
                //if (listBox1.SelectedItem != null && listBox1.IndexFromPoint(e.X, e.Y) != ListBox.NoMatches)
                //{
                //    ShowContexMenu().Show(this, new Point(e.X, e.Y + listBox1.Location.Y));
                //}

                // groupMenu.Show(this, new Point(e.X, e.Y + listBox1.Location.Y));
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedUsername;
            
            if (listView1.SelectedItems.Count > 0)
            {
                selectedUsername = listView1.SelectedItems[0].Text;
                UpdateInfo(UserManager.GetUserByName(selectedUsername));
            }
        }
    }
}
