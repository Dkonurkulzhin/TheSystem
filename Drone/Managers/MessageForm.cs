using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drone.Managers
{
    public partial class MessageForm : Form
    {
        private string MessageText;
        private Color TextColor;
        public MessageForm(string messageText, Color textColor)
        {
            InitializeComponent();
            MessageText = messageText;
            TextColor = textColor; 
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            label1.Text = MessageText;
            label1.ForeColor = TextColor;

        }
    }
}
