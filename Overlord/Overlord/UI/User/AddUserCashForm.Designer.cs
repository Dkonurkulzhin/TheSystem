namespace Overlord
{
    partial class AddUserCashForm
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
            this.CurrentCashLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cash10000 = new System.Windows.Forms.Button();
            this.cash5000 = new System.Windows.Forms.Button();
            this.cash2000 = new System.Windows.Forms.Button();
            this.cash1000 = new System.Windows.Forms.Button();
            this.cash500 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cash200 = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.FinalCashLabel = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UserLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // CurrentCashLabel
            // 
            this.CurrentCashLabel.AutoSize = true;
            this.CurrentCashLabel.Location = new System.Drawing.Point(210, 198);
            this.CurrentCashLabel.Name = "CurrentCashLabel";
            this.CurrentCashLabel.Size = new System.Drawing.Size(94, 13);
            this.CurrentCashLabel.TabIndex = 0;
            this.CurrentCashLabel.Text = "Текущий баланс:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UserLabel);
            this.groupBox1.Controls.Add(this.cash10000);
            this.groupBox1.Controls.Add(this.cash5000);
            this.groupBox1.Controls.Add(this.cash2000);
            this.groupBox1.Controls.Add(this.cash1000);
            this.groupBox1.Controls.Add(this.cash500);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.cash200);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(210, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 179);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Оплата";
            // 
            // cash10000
            // 
            this.cash10000.Location = new System.Drawing.Point(126, 121);
            this.cash10000.Name = "cash10000";
            this.cash10000.Size = new System.Drawing.Size(50, 23);
            this.cash10000.TabIndex = 11;
            this.cash10000.Text = "10000";
            this.cash10000.UseVisualStyleBackColor = true;
            this.cash10000.Click += new System.EventHandler(this.cash10000_Click);
            // 
            // cash5000
            // 
            this.cash5000.Location = new System.Drawing.Point(69, 121);
            this.cash5000.Name = "cash5000";
            this.cash5000.Size = new System.Drawing.Size(50, 23);
            this.cash5000.TabIndex = 10;
            this.cash5000.Text = "5000";
            this.cash5000.UseVisualStyleBackColor = true;
            this.cash5000.Click += new System.EventHandler(this.cash5000_Click);
            // 
            // cash2000
            // 
            this.cash2000.Location = new System.Drawing.Point(13, 121);
            this.cash2000.Name = "cash2000";
            this.cash2000.Size = new System.Drawing.Size(50, 23);
            this.cash2000.TabIndex = 9;
            this.cash2000.Text = "2000";
            this.cash2000.UseVisualStyleBackColor = true;
            this.cash2000.Click += new System.EventHandler(this.cash2000_Click);
            // 
            // cash1000
            // 
            this.cash1000.Location = new System.Drawing.Point(126, 92);
            this.cash1000.Name = "cash1000";
            this.cash1000.Size = new System.Drawing.Size(50, 23);
            this.cash1000.TabIndex = 8;
            this.cash1000.Text = "1000";
            this.cash1000.UseVisualStyleBackColor = true;
            this.cash1000.Click += new System.EventHandler(this.cash1000_Click);
            // 
            // cash500
            // 
            this.cash500.Location = new System.Drawing.Point(69, 92);
            this.cash500.Name = "cash500";
            this.cash500.Size = new System.Drawing.Size(50, 23);
            this.cash500.TabIndex = 7;
            this.cash500.Text = "500";
            this.cash500.UseVisualStyleBackColor = true;
            this.cash500.Click += new System.EventHandler(this.cash500_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 152);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(89, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Сдача:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Внесено:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пополнение:";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(88, 65);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(89, 20);
            this.numericUpDown2.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(88, 42);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(89, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // cash200
            // 
            this.cash200.Location = new System.Drawing.Point(13, 92);
            this.cash200.Name = "cash200";
            this.cash200.Size = new System.Drawing.Size(50, 23);
            this.cash200.TabIndex = 0;
            this.cash200.Text = "200";
            this.cash200.UseVisualStyleBackColor = true;
            this.cash200.Click += new System.EventHandler(this.cash200_Click);
            // 
            // OkButton
            // 
            this.OkButton.Enabled = false;
            this.OkButton.Location = new System.Drawing.Point(210, 256);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(82, 38);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(312, 256);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(86, 38);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // FinalCashLabel
            // 
            this.FinalCashLabel.AutoSize = true;
            this.FinalCashLabel.Location = new System.Drawing.Point(210, 217);
            this.FinalCashLabel.Name = "FinalCashLabel";
            this.FinalCashLabel.Size = new System.Drawing.Size(99, 13);
            this.FinalCashLabel.TabIndex = 4;
            this.FinalCashLabel.Text = "Итоговый баланс:";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 39);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(192, 255);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(57, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(147, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Логин";
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Location = new System.Drawing.Point(10, 23);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(83, 13);
            this.UserLabel.TabIndex = 8;
            this.UserLabel.Text = "Пользователь:";
            // 
            // AddUserCashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 306);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.FinalCashLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CurrentCashLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddUserCashForm";
            this.Text = "Добавить средства";
            this.Load += new System.EventHandler(this.AddUserCashForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CurrentCashLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cash200;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button cash10000;
        private System.Windows.Forms.Button cash5000;
        private System.Windows.Forms.Button cash2000;
        private System.Windows.Forms.Button cash1000;
        private System.Windows.Forms.Button cash500;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label FinalCashLabel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UserLabel;
    }
}