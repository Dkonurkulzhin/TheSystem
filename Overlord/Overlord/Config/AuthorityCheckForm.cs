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
    public partial class AuthorityCheckForm : Form
    {
        public AuthorityCheckForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == GlobalVars.Settings.Administration_AdminPassword)
            {
                Program.MainForm.ConfigureAdminRights(true);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void AuthorityCheckForm_Load(object sender, EventArgs e)
        {
            if (!button1.Focus())
                button1.Focus();
        }
    }
}
