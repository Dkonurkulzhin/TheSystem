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
    public partial class AddUserCashForm : Form
    {
        User userToPay;
        public AddUserCashForm()
        {
            InitializeComponent();
            
        }

        private void AddIncomming(int cash)
        {
            numericUpDown1.Value += cash;
        }

        private void UpdateUserList(string filter = "")
        {
            listView1.Clear();
            listView1.View = View.List;
            List<string> usersToShow = UserManager.GetUserList(filter);
            foreach (string user in usersToShow)
                listView1.Items.Add(user);
        }

      

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Value = numericUpDown1.Value;

        }

        private void PreCalculateNewCash(int cash)
        {
            if (userToPay == null)
                return;
            CurrentCashLabel.Text = "Текущий баланс: " + userToPay.balance.ToString();
            FinalCashLabel.Text = "Итоговый баланс: " + (userToPay.balance + cash).ToString();
        }
        
        private void CalculateShort(object sender, EventArgs e)
        {
            textBox1.Text = (numericUpDown2.Value - numericUpDown1.Value).ToString();
        }

        private void AddUserCashForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.ValueChanged += CalculateShort;
            numericUpDown2.ValueChanged += CalculateShort;
           
           
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                userToPay = UserManager.GetUserByName(listView1.SelectedItems[0].Text);
                PreCalculateNewCash((int)numericUpDown1.Value);
            }
            
        }

        private void AddCashToUser(int cash)
        {
            if (cash >=0)
            {
                userToPay.balance += cash;
                FinancialManager.AddFunds(cash);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox2.Text;
            if (filter.Length >= 3) UpdateUserList(filter);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddCashToUser((int)numericUpDown1.Value);
        }

        private void cash200_Click(object sender, EventArgs e)
        {
            AddIncomming(200);
        }

        private void cash500_Click(object sender, EventArgs e)
        {
            AddIncomming(500);
        }

        private void cash1000_Click(object sender, EventArgs e)
        {
            AddIncomming(1000);
        }

        private void cash2000_Click(object sender, EventArgs e)
        {
            AddIncomming(2000);
        }

        private void cash5000_Click(object sender, EventArgs e)
        {
            AddIncomming(5000);
        }

        private void cash10000_Click(object sender, EventArgs e)
        {
            AddIncomming(10000);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
