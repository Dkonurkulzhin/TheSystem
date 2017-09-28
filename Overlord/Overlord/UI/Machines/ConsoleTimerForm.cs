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
    public partial class ConsoleTimerForm : Form
    {
        public long RemainingTime;
        public long CurrentMinutes;
        public long EndMinutes;
        public bool SessionEnabled = false;
        public ConsoleForm parentForm;
        public ConsoleTimerForm()
        {
            InitializeComponent();
            
         //   timer.Start();
            CurrentMinutes = DateTime.Now.Minute + DateTime.Now.Hour * 60;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!SessionEnabled)
            {
                SessionEnabled = true;
                StartTimeLabel.Text = GetTimeFromMinutes(CurrentMinutes);
                EndMinutes = CurrentMinutes + (long)numericUpDown1.Value;
                EndTimeLabel.Text = GetTimeFromMinutes(EndMinutes);
                this.BackColor = Color.Red;
                UpdateRemainingTime();

                timer.Start();
                numericUpDown1.Value = 0;
            }
            else
            {
                EndMinutes = CurrentMinutes + RemainingTime+ (long)numericUpDown1.Value;
                EndTimeLabel.Text = GetTimeFromMinutes(EndMinutes);
                UpdateRemainingTime();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            CurrentMinutes = DateTime.Now.Minute + DateTime.Now.Hour * 60;
            UpdateRemainingTime();
            
        }

        private string GetTimeFromMinutes(long minutes)
        {
            double Hours = CurrentMinutes / 60;
            if (Math.Round(minutes - Math.Truncate(Hours) * 60) < 10)
                return Math.Truncate(Hours).ToString() + ":0" + Math.Round(minutes - Math.Truncate(Hours)*60).ToString();
            else
                return Math.Truncate(Hours).ToString() + ":" + Math.Round(minutes - Math.Truncate(Hours) * 60).ToString();

        }
        private void UpdateRemainingTime()
        {
            if (SessionEnabled)
            {
                RemainingTime = EndMinutes - CurrentMinutes;
                RemainingTimeLabel.Text = RemainingTime.ToString();
                if (RemainingTime <= 0)
                {
                    EndTimer();
                }
            }
            else
                timer.Stop();

        }

        private void EndTimer()
        {
            this.BackColor = Color.LightGreen;
            RemainingTime = 0;
            EndTimeLabel.Text = "--:--";
            StartTimeLabel.Text = "--:--";
            RemainingTimeLabel.Text = "--";
            SessionEnabled = false;
            timer.Stop();
            if (parentForm != null) parentForm.Show();
                MessageBox.Show(ConsoleTag.Text + " время истекло");
            
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            EndTimer();
        }
    }
}
