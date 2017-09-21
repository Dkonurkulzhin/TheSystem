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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == GlobalVars.settings.adminPassword)
            {
                ClientSettingsForm configForm = new ClientSettingsForm();
                configForm.Show();
                this.Close();
            }
            else
                MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
