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
    public partial class StockControlForm : Form
    {
        private string[] selectedItems;
        public StockControlForm()
        {
            InitializeComponent();
        }

        private void StockControlForm_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            listView1.Items.Clear();
            var imageList = new ImageList();
            foreach (var product in ProductManager.GetProductList())
            {
                try
                {
                    imageList.Images.Add(product.name, Image.FromFile(@product.imgPath));
                    Console.WriteLine("Image found" + @product.imgPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }


            }
            imageList.ImageSize = new Size(32, 32);
            listView1.LargeImageList = imageList;
            foreach (var product in ProductManager.GetProductList())
            {
                ListViewItem lst = new ListViewItem();
                lst.Text = product.name + " : " + product.stock.ToString() + "шт";
                if (product.stock <= 0)
                {
                    lst.ForeColor = Color.Red;
                }
                else
                {
                    lst.ForeColor = Color.Black;
                }
                lst.ImageKey = product.name;
                listView1.Items.Add(lst);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            selectedItems = new string[listView1.SelectedItems.Count];
            label1.Text = "Выбрано: ";
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                selectedItems[i] = listView1.SelectedItems[i].ImageKey;
                label1.Text += selectedItems[i] + ", ";

            }
            

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeStockAmount(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeStockAmount(-1);
        }
        private void ChangeStockAmount(int muliplier)
        {
            if (selectedItems != null && numericUpDown1.Value != 0)
                foreach (var item in selectedItems)
                {
                    ProductManager.EditProductStock(ProductManager.GetProductByName(item), (int)numericUpDown1.Value * muliplier);
                  
                }
                if (GlobalVars.Settings.Telegram_notifyStockEdit)
                    NotifyAboutEdit(muliplier);
            else
                label1.Text = "Ничего не выбрано";

            


                selectedItems = null;
            listView1.SelectedItems.Clear();
            UpdateList();
            numericUpDown1.Value = 0;
        }

        private void NotifyAboutEdit(int multiplier)
        {
            string messageToSend;
            if (multiplier >= 0)
                messageToSend = "Запасы пополнены: ";
            else
                messageToSend = "Из запасов изъято: ";
            if (selectedItems != null && numericUpDown1.Value != 0)
                foreach (var item in selectedItems)
                {
                    messageToSend += item;
                    messageToSend += " - ";
                    messageToSend += numericUpDown1.Value.ToString();
                    messageToSend += "шт/ ";
                    messageToSend += "всего в наличии: ";
                    messageToSend += ProductManager.GetProductByName(item).stock;
                    messageToSend += "шт; ";
                }
            TelegramManager.SendMessageToChat(messageToSend);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
