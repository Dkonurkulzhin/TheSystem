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
    public partial class TelegramSettingsForm : Form
    {
        public TelegramSettingsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobalVars.Settings.Telegram_BotAPIkey = textBox1.Text;
            GlobalVars.Settings.Telegram_ChatID = (long)numericUpDown1.Value;
            GlobalVars.Settings.Telegram_notifyProducts = checkBox1.Checked;
            GlobalVars.Settings.Telegram_notifyEnd = checkBox2.Checked;
            GlobalVars.Settings.Telegram_notifyStockEdit = checkBox3.Checked;
            GlobalVars.SaveSettings();
            GlobalVars.LoadSettings();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TelegramSettingsForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = GlobalVars.Settings.Telegram_BotAPIkey;
            numericUpDown1.Value = (decimal)GlobalVars.Settings.Telegram_ChatID;
            checkBox1.Checked = GlobalVars.Settings.Telegram_notifyProducts;
            checkBox2.Checked = GlobalVars.Settings.Telegram_notifyEnd;
            checkBox3.Checked = GlobalVars.Settings.Telegram_notifyStockEdit;
        }

       
    }
}
