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
            foreach (var product in ProductManager.GetProductNameList())
            {
                treeView1.Nodes.Add(product);
                Console.WriteLine("product has been found: " + product);
            }
            treeView1.EndUpdate();
        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            var deleteResult = ProductManager.DeleteProduct(SelectedProduct);
            MessageBox.Show(deleteResult.Item2, "Удаление", MessageBoxButtons.OK, 
               (deleteResult.Item1)?  MessageBoxIcon.Error : MessageBoxIcon.None);
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
                Product productToEdit = ProductManager.GetProductByName(e.Node.Text);
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
