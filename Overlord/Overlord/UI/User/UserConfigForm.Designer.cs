﻿namespace Overlord
{
    partial class UserConfigForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Info = new System.Windows.Forms.GroupBox();
            this.ExpLabel = new System.Windows.Forms.Label();
            this.RegisteredLabel = new System.Windows.Forms.Label();
            this.RateLabel = new System.Windows.Forms.Label();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.BalanceLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AddGroupButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.DeleteGroupButton = new System.Windows.Forms.Button();
            this.AddGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EditGroupButton = new System.Windows.Forms.Button();
            this.StartingLevelNum = new System.Windows.Forms.NumericUpDown();
            this.GroupNameLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.Info.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.AddGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartingLevelNum)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.HoverSelection = true;
            this.listView1.Location = new System.Drawing.Point(15, 19);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(343, 286);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(160, 82);
            this.listBox1.TabIndex = 5;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            // 
            // button3
            // 
            this.button3.Image = global::Overlord.Properties.Resources.adduser;
            this.button3.Location = new System.Drawing.Point(12, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 46);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::Overlord.Properties.Resources.remveuser;
            this.button2.Location = new System.Drawing.Point(365, 191);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 47);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Info);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 321);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пользовтели";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Info
            // 
            this.Info.Controls.Add(this.ExpLabel);
            this.Info.Controls.Add(this.RegisteredLabel);
            this.Info.Controls.Add(this.RateLabel);
            this.Info.Controls.Add(this.LevelLabel);
            this.Info.Controls.Add(this.BalanceLabel);
            this.Info.Controls.Add(this.NameLabel);
            this.Info.Location = new System.Drawing.Point(365, 20);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(155, 165);
            this.Info.TabIndex = 1;
            this.Info.TabStop = false;
            this.Info.Text = "Информация";
            // 
            // ExpLabel
            // 
            this.ExpLabel.AutoSize = true;
            this.ExpLabel.Location = new System.Drawing.Point(8, 76);
            this.ExpLabel.Name = "ExpLabel";
            this.ExpLabel.Size = new System.Drawing.Size(37, 13);
            this.ExpLabel.TabIndex = 5;
            this.ExpLabel.Text = "Опыт:";
            // 
            // RegisteredLabel
            // 
            this.RegisteredLabel.AutoSize = true;
            this.RegisteredLabel.Location = new System.Drawing.Point(8, 112);
            this.RegisteredLabel.Name = "RegisteredLabel";
            this.RegisteredLabel.Size = new System.Drawing.Size(99, 13);
            this.RegisteredLabel.TabIndex = 4;
            this.RegisteredLabel.Text = "Зарегестрирован:";
            // 
            // RateLabel
            // 
            this.RateLabel.AutoSize = true;
            this.RateLabel.Location = new System.Drawing.Point(6, 94);
            this.RateLabel.Name = "RateLabel";
            this.RateLabel.Size = new System.Drawing.Size(43, 13);
            this.RateLabel.TabIndex = 3;
            this.RateLabel.Text = "Тариф:";
            // 
            // LevelLabel
            // 
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.Location = new System.Drawing.Point(7, 58);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(54, 13);
            this.LevelLabel.TabIndex = 2;
            this.LevelLabel.Text = "Уровень:";
            // 
            // BalanceLabel
            // 
            this.BalanceLabel.AutoSize = true;
            this.BalanceLabel.Location = new System.Drawing.Point(7, 39);
            this.BalanceLabel.Name = "BalanceLabel";
            this.BalanceLabel.Size = new System.Drawing.Size(50, 13);
            this.BalanceLabel.TabIndex = 1;
            this.BalanceLabel.Text = "Баланс: ";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(7, 20);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(0, 13);
            this.NameLabel.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EditGroupButton);
            this.groupBox2.Controls.Add(this.AddGroupBox);
            this.groupBox2.Controls.Add(this.DeleteGroupButton);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 388);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(529, 143);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Группы";
            // 
            // AddGroupButton
            // 
            this.AddGroupButton.Location = new System.Drawing.Point(6, 87);
            this.AddGroupButton.Name = "AddGroupButton";
            this.AddGroupButton.Size = new System.Drawing.Size(179, 23);
            this.AddGroupButton.TabIndex = 6;
            this.AddGroupButton.Text = "Добавить";
            this.AddGroupButton.UseVisualStyleBackColor = true;
            this.AddGroupButton.Click += new System.EventHandler(this.AddGroupButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(69, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(108, 20);
            this.textBox2.TabIndex = 7;
            // 
            // DeleteGroupButton
            // 
            this.DeleteGroupButton.Location = new System.Drawing.Point(100, 110);
            this.DeleteGroupButton.Name = "DeleteGroupButton";
            this.DeleteGroupButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteGroupButton.TabIndex = 8;
            this.DeleteGroupButton.Text = "Удалить";
            this.DeleteGroupButton.UseVisualStyleBackColor = true;
            // 
            // AddGroupBox
            // 
            this.AddGroupBox.Controls.Add(this.GroupNameLabel);
            this.AddGroupBox.Controls.Add(this.StartingLevelNum);
            this.AddGroupBox.Controls.Add(this.label1);
            this.AddGroupBox.Controls.Add(this.AddGroupButton);
            this.AddGroupBox.Controls.Add(this.textBox2);
            this.AddGroupBox.Location = new System.Drawing.Point(181, 23);
            this.AddGroupBox.Name = "AddGroupBox";
            this.AddGroupBox.Size = new System.Drawing.Size(191, 116);
            this.AddGroupBox.TabIndex = 9;
            this.AddGroupBox.TabStop = false;
            this.AddGroupBox.Text = "Добавить группу";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Начальный уровень";
            // 
            // EditGroupButton
            // 
            this.EditGroupButton.Location = new System.Drawing.Point(15, 110);
            this.EditGroupButton.Name = "EditGroupButton";
            this.EditGroupButton.Size = new System.Drawing.Size(75, 23);
            this.EditGroupButton.TabIndex = 10;
            this.EditGroupButton.Text = "Изменить";
            this.EditGroupButton.UseVisualStyleBackColor = true;
            // 
            // StartingLevelNum
            // 
            this.StartingLevelNum.Location = new System.Drawing.Point(120, 45);
            this.StartingLevelNum.Name = "StartingLevelNum";
            this.StartingLevelNum.Size = new System.Drawing.Size(57, 20);
            this.StartingLevelNum.TabIndex = 9;
            // 
            // GroupNameLabel
            // 
            this.GroupNameLabel.AutoSize = true;
            this.GroupNameLabel.Location = new System.Drawing.Point(6, 22);
            this.GroupNameLabel.Name = "GroupNameLabel";
            this.GroupNameLabel.Size = new System.Drawing.Size(57, 13);
            this.GroupNameLabel.TabIndex = 10;
            this.GroupNameLabel.Text = "Название";
            // 
            // UserConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 539);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "UserConfigForm";
            this.Text = "Управление пользователями";
            this.Load += new System.EventHandler(this.UserConfigForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            this.Info.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.AddGroupBox.ResumeLayout(false);
            this.AddGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartingLevelNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox Info;
        private System.Windows.Forms.Label RateLabel;
        private System.Windows.Forms.Label LevelLabel;
        private System.Windows.Forms.Label BalanceLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label RegisteredLabel;
        private System.Windows.Forms.Label ExpLabel;
        private System.Windows.Forms.Button DeleteGroupButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button AddGroupButton;
        private System.Windows.Forms.Button EditGroupButton;
        private System.Windows.Forms.GroupBox AddGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label GroupNameLabel;
        private System.Windows.Forms.NumericUpDown StartingLevelNum;
    }
}