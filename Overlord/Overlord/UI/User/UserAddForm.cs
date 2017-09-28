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
    public partial class UserAddForm : Form
    {

        User UserToEdit;
        bool UserIsNew;
        UserConfigForm ParentForm;

        public UserAddForm(UserConfigForm parentForm, User user = null)
        {
            UserToEdit = user;
            ParentForm = parentForm;
            InitializeComponent();
        }

        private void UserAddForm_Load(object sender, EventArgs e)
        {
            if (UserToEdit == null)
            {
                UserToEdit = new User();
                UserIsNew = true;
            }
            else
            {
                UserIsNew = false;
                LoadUserData();
                Text = "Изменить данные";
                textBox1.ReadOnly = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string text = textBox4.Text;
            if (!char.IsNumber(text.Last()))
            {
                text = text.Substring(0, text.Length - 1);
                textBox4.Text = text;
            }

                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserManager.GetUserList().Contains(textBox1.Text) && UserIsNew)
                MessageBox.Show("Пользоваетль с таким именем уже зарегестрирован", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ChangeUserData();
                UserManager.SaveUser(UserToEdit.name);

                this.Close();
            }
                
        }

        private void ChangeUserData()
        {
            UserToEdit.name = textBox1.Text;
            UserToEdit.personalName = textBox2.Text;
            UserToEdit.personalSurname = textBox3.Text;
            UserToEdit.phoneNumber = textBox4.Text;
            UserToEdit.email = textBox5.Text;
        }

        private void LoadUserData()
        {
            textBox1.Text = UserToEdit.name;
            textBox2.Text = UserToEdit.personalName;
            textBox3.Text = UserToEdit.personalSurname;
            textBox4.Text = UserToEdit.phoneNumber;
            textBox5.Text = UserToEdit.email;
        }
    }
}
