namespace Overlord
{
    partial class ProductManagmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.AddProductButton = new System.Windows.Forms.Button();
            this.DeleteProductButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(303, 335);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // AddProductButton
            // 
            this.AddProductButton.Location = new System.Drawing.Point(321, 12);
            this.AddProductButton.Name = "AddProductButton";
            this.AddProductButton.Size = new System.Drawing.Size(181, 23);
            this.AddProductButton.TabIndex = 1;
            this.AddProductButton.Text = "Добавить продукт";
            this.AddProductButton.UseVisualStyleBackColor = true;
            this.AddProductButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeleteProductButton
            // 
            this.DeleteProductButton.Location = new System.Drawing.Point(322, 42);
            this.DeleteProductButton.Name = "DeleteProductButton";
            this.DeleteProductButton.Size = new System.Drawing.Size(180, 23);
            this.DeleteProductButton.TabIndex = 2;
            this.DeleteProductButton.Text = "Удалить продукт";
            this.DeleteProductButton.UseVisualStyleBackColor = true;
            this.DeleteProductButton.Click += new System.EventHandler(this.DeleteProductButton_Click);
            // 
            // ProductManagmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 373);
            this.Controls.Add(this.DeleteProductButton);
            this.Controls.Add(this.AddProductButton);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductManagmentForm";
            this.Text = "Добавление продуктов";
            this.Load += new System.EventHandler(this.ProductManagmentForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button AddProductButton;
        private System.Windows.Forms.Button DeleteProductButton;

    }
}