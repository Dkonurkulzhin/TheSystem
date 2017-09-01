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
    public partial class ProductManagmentForm : Form
    {
        ProductAddForm prodaddform = new ProductAddForm();

        
        public string SelectedProduct;
        public ProductManagmentForm()
        {
            InitializeComponent();
        }

        private void ProductManagmentForm_Load(object sender, EventArgs e)
        {
            RefreshProductList();
            prodaddform.parentForm = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenEditForm(true);
        }


        public void RefreshProductList()
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            foreach (var product in ProductManager.ListAllProducts())
            {
                treeView1.Nodes.Add(product.Substring(0, product.Length - 4));
                Console.WriteLine("product has been found: " + product);
            }
            treeView1.EndUpdate();
        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            if (Program.xmlmanager.DeserializeProductData(SelectedProduct).stock != 0)
            {
                MessageBox.Show("Cannot delete unempty stock");
                return;
            }
            if (!Program.xmlmanager.DeleteProductData(SelectedProduct))
            {
                MessageBox.Show("Cannot delete this: " + SelectedProduct);
                return;
            }
            RefreshProductList();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedProduct = e.Node.Text;
        }

        void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
                OpenEditForm();
                Product productToEdit = Program.xmlmanager.DeserializeProductData(e.Node.Text);
                prodaddform.LoadProductData(productToEdit);
          //  }
        }

        private void OpenEditForm(bool isNew = false)
        {
            if (prodaddform == null)
            {
                prodaddform = new ProductAddForm();
                prodaddform.parentForm = this;
                prodaddform.productIsNew = isNew;
            }
            else
            {
                prodaddform.Close();
                prodaddform = new ProductAddForm();
                prodaddform.parentForm = this;
                prodaddform.productIsNew = isNew;
            }
            prodaddform.Show();
          
        }

       
    }
}
