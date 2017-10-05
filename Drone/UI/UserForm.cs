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
            UIManager.OnUserStatsUpdated += SendUpdateUserStats;
        }

        private void UserAvatar_Click(object sender, EventArgs e)
        {

        }

        private void UserLogoutButton_Click(object sender, EventArgs e)
        {
            UIManager.PerformLogOut();
        }

        public void UpdateStats(object sender, EventArgs e)
        {
            //Invoke(new Action(UpdateUserStats));
           
        }

        private void SendUpdateUserStats(User user)
        {
            Invoke(new Action(delegate () { UpdateUserStats(user); }));

        }

        private void UpdateUserStats(User user)
        {
            UserBalanceLabel.Text = "Текущий баланс: " + user.balance.ToString();
            UserTimeLabel.Text = "Осталось времени: " + UIFunctions.FormatTime(SessionManager.secondsLeft);
            UserRatingLabel.Text = "Текущий тариф: " + SessionManager.GetCurrentRate(SessionManager.RateFormat.perHour) + " тг/час"; //SessionManager.currentRate.ToString()
            UserNameLabel.Text = user.name;
            UserLevelLabel.Text = user.level.ToString();
            label1.Text = UIManager.GetCurrentSessyionType();
            UserSettingButton.Enabled = (DateTime.Now.Hour >= 19 || DateTime.Now.Hour < 6);


        }

        private void UserSettingButton_Click(object sender, EventArgs e)
        {
            DialogResult askForBonus = MessageBox.Show("Со счета спишется 700тг, ночоной тариф действителен с 23:00 до 9:00. Задействовать ночной тариф?", 
                "Ночной тариф", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (askForBonus == DialogResult.Yes)
                UIManager.PerformNightBonusLogIn();
        }
    }
}
