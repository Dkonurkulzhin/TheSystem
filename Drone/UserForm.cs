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
    public partial class UserForm: Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
           
        }

        private void UserAvatar_Click(object sender, EventArgs e)
        {

        }

        private void UserLogoutButton_Click(object sender, EventArgs e)
        {
            Program.LogOut();
        }

        public void UpdateStats(object sender, EventArgs e)
        {
            Invoke(new Action(UpdateBalance));
           
        }

        private void UpdateBalance()
        {
            UserBalanceLabel.Text = "Текущий баланс: " + SessionManager.currentBalance.ToString();
            UserTimeLabel.Text = "Осталось времени: " + UIFunctions.FormatTime(SessionManager.secondsLeft);
            UserRatingLabel.Text = "Текущий тариф: " + SessionManager.GetCurrentRate(SessionManager.RateFormat.perHour) + " тг/час"; //SessionManager.currentRate.ToString()
        }
    }
}
