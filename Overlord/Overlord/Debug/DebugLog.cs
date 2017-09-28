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
    public partial class DebugLog : Form
    {
        private int MaxLines;

        private int i;
        public DebugLog(int maxLines)
        {
            InitializeComponent();
            MaxLines = maxLines;
        }

        private void DebugLog_Load(object sender, EventArgs e)
        {

        }

        public void AddLineToLog(string line)
        {
            listBox1.Items.Add(line);
            if (listBox1.Items.Count >= MaxLines)
            {
                listBox1.Items.RemoveAt(0);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

     
    }
}
