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
    public partial class CashBoxSettingsForm : Form
    {
        public CashBoxSettingsForm()
        {
            InitializeComponent();
        }

        private void CashBoxSettingsForm_Load(object sender, EventArgs e)
        {
            updateForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinancialManager.ClearCash();
            updateForm();
           
        }

        private void updateForm()
        {
            textBox1.Text = FinancialManager.GetCashString();
        }
    }
}
