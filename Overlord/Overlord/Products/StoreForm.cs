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
    public partial class StoreForm : Form
    {
        private long total = 0;
        private long puretotal = 0;
        private List<Product> productsToSale = new List<Product>();

        public StoreForm()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void StoreForm_Load(object sender, EventArgs e)
        {

            LoadImages();
            checkBox1.Checked = GlobalVars.Settings.Products_ShowOnlyAvailable;
        }

        private void LoadImages()
        {
            listView1.Items.Clear();
            var imageList = new ImageList();
            foreach (var product in ProductManager.AvailableProducts)
            {
                
                try
                {
                    if (product.imgPath != null && product.imgPath != "" && product.imgPath.Contains(@"\"))
                        imageList.Images.Add(product.name, Image.FromFile(@product.imgPath));
                    Console.WriteLine("Image found" + @product.imgPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
               
            }
            imageList.ImageSize = new Size(16, 16);
            listView1.LargeImageList = imageList;
            foreach (var product in ProductManager.AvailableProducts)
            {
                if (GlobalVars.Settings.Products_ShowOnlyAvailable)
                {
                    if (product.stock > 0)
                    {
                        ListViewItem lst = new ListViewItem();
                        lst.Text = product.name;
                        lst.ForeColor = Color.Black;
                        if (product.imgPath != null && product.imgPath != "" && product.imgPath.Contains(@"\"))
                            lst.ImageKey = product.name;
                        listView1.Items.Add(lst);
                    }
                }
                else
                {
                    ListViewItem lst = new ListViewItem();
                    if (product.stock <= 0)
                    {
                        lst.Text = product.name + " (нет в наличии)";
                        lst.ForeColor = Color.Red;
                    }
                    else
                    {
                        lst.Text = product.name;
                        lst.ForeColor = Color.Black;
                    }
                    if (product.imgPath != null && product.imgPath != "" && product.imgPath.Contains(@"\"))
                        lst.ImageKey = product.name;
                    listView1.Items.Add(lst);
                }
            }

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Product newProduct = ProductManager.GetSelectedProductByName(listView1.SelectedItems[0].ImageKey);

                productsToSale.Add(newProduct);
                listBox1.Items.Add(newProduct.name + " - " + newProduct.price.ToString() + " " + Program.cashbox.Currency);

                total += newProduct.price;
                puretotal += newProduct.cost;
                textBox1.Text = total.ToString() + " " + Program.cashbox.Currency;
                numericUpDown1.Value = (decimal)total;
            
            }
            catch (Exception)
            {
               
            }
            //MessageBox.Show(listView1.SelectedItems[0].Text);
          //  UpdateProductInfo();
        }

        // костыль!!! но это не точно
        private Product GetSelectedProductByName(string name)
        {
            Product productToAdd = ProductManager.AvailableProducts.Find(x => x.name == name);
            if (productToAdd != null)
                return productToAdd;
            else
                return null;
        }

        private void CloseTransaction()
        {
            foreach (var product in productsToSale)
            {
                product.stock--;
                ProductManager.UpdateStock(product);
            }
            Program.cashbox.AddFunds(total);
            UpdateProductInfo();
            ClearCart();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearCart();

        }

        private void ClearCart()
        {
            textBox1.Clear();
            productsToSale.Clear();
            total = 0;
            puretotal = 0;
            listBox1.Items.Clear();
            textBox2.Clear();
            numericUpDown1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseTransaction();
        }

        private void UpdateProductInfo()
        {
            ProductManager.UpdateAvailableProducts();
            LoadImages();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            Product currentProduct;
            if (listView1.SelectedItems != null)
            {
                try
                {
                    currentProduct = ProductManager.GetSelectedProductByName(listView1.SelectedItems[0].ImageKey);
                    ProductNameLabel.Text = currentProduct.name;
                    ProductPriceLabel.Text = currentProduct.price.ToString() + Program.cashbox.Currency;
                    ProductStockLabel.Text = currentProduct.stock.ToString();
                }
                catch (Exception)
                {

                }
            }
            else
            {
                ProductNameLabel.Text = "";
                ProductPriceLabel.Text = "";
                ProductStockLabel.Text = "";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVars.Settings.Products_ShowOnlyAvailable = checkBox1.Checked;
            GlobalVars.SaveSettings();
            LoadImages();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = (numericUpDown1.Value - total).ToString();
        }
    }
}
