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
    public partial class CashBoxControlForm : Form
    {

        private string[] Operationtypes = {"выплата зп","уборка","снятие кассы","закуп продуктов","закуп средств","прочее"};
        public CashBoxControlForm()
        {
            InitializeComponent();
        }
       


        private void CashBoxControlForm_Load(object sender, EventArgs e)
        {
            foreach (var operation in Operationtypes)
                comboBox1.Items.Add(operation);
            textBox1.Text = FinancialManager.getCurrentCash().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0 && comboBox1.SelectedIndex >= 0)
            {
                FinancialManager.WithdrawFunds((long)numericUpDown1.Value, true,
                    "Снятие кассы: " + numericUpDown1.Value.ToString() + FinancialManager.getCurrency() +
                    ", причина: " + comboBox1.SelectedItem.ToString() + "  " + textBox2.Text + "; " +
                    "В кассе: " + FinancialManager.GetCashString()
                    );
                
            }
            else
                MessageBox.Show("Уажите сумму и причину снятия денег");
        }

        private void updateForm()
        {
            textBox1.Text = FinancialManager.GetCashString();
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown2.Value != 0)
            {
                FinancialManager.AddFunds((long)numericUpDown2.Value, true,
                     "Пополнение кассы: " + numericUpDown2.Value.ToString() + FinancialManager.getCurrency() +
                    "  " + textBox3.Text + "; " + "В кассе:" + FinancialManager.GetCashString()
                );
               
                   
                updateForm();
            }
            else
                MessageBox.Show("Укажите пополняему сумму");
        }
    }
}
