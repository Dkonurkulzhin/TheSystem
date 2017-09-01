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
    public partial class ProductAddForm : Form
    {
        public ProductManagmentForm parentForm;
        public bool productIsNew = false;

        public ProductAddForm()
        {
            InitializeComponent();
        }

        public void LoadProductData(Product product)
        {
            if (product != null)
            {
                textBox1.Text = product.name;
                numericUpDown1.Value = product.price;
                numericUpDown2.Value = product.cost;
                numericUpDown3.Value = product.stock;
                textBox2.Text = product.imgPath;
                checkBox1.Checked = product.notifyWhenLow;
            }
        }

        private void ProductAddForm_Load(object sender, EventArgs e)
        {
            if (productIsNew)
            {
                this.Text = "Добавление продукта";
                button1.Text = "Добавить";
            }
            else
            {
                this.Text = "Редактирование продукта";
                button1.Text = "Сохранить";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                //if (ProductManager.IsUnique(textBox1.Text))
                //{
            Product newProduct = new Product();
            newProduct.name = textBox1.Text;
            newProduct.price = (long)numericUpDown1.Value;
            newProduct.cost = (long)numericUpDown2.Value;
            newProduct.stock = Decimal.ToInt32(numericUpDown3.Value);
            newProduct.imgPath = @textBox2.Text;
            newProduct.notifyWhenLow = checkBox1.Checked;
            Program.xmlmanager.SerializeProductData(newProduct, newProduct.name);
            parentForm.RefreshProductList();

            this.Close();

                //}
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox2.Text = openFileDialog1.FileName;
        }
    }
}
