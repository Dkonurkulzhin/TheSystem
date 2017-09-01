namespace Overlord
{
    partial class ConsoleTimerForm
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
            this.components = new System.ComponentModel.Container();
            this.StartButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.StartTimeLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.StopButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.EndTimeLabel = new System.Windows.Forms.Label();
            this.RemainingTimeLabel = new System.Windows.Forms.Label();
            this.ConsoleTag = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(235, 72);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(121, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Добавить";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.AutoSize = true;
            this.StartTimeLabel.Font = new System.Drawing.Font("Russo One", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartTimeLabel.Location = new System.Drawing.Point(77, 16);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(78, 35);
            this.StartTimeLabel.TabIndex = 1;
            this.StartTimeLabel.Text = "--:--";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(281, 42);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(53, 20);
            this.numericUpDown1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Время:";
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(235, 101);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(121, 23);
            this.StopButton.TabIndex = 4;
            this.StopButton.Text = "Стоп";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.RemainingTimeLabel);
            this.groupBox1.Controls.Add(this.EndTimeLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.StartTimeLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 137);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Время";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Начало:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Конец:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Осталось:";
            // 
            // EndTimeLabel
            // 
            this.EndTimeLabel.AutoSize = true;
            this.EndTimeLabel.Font = new System.Drawing.Font("Russo One", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EndTimeLabel.Location = new System.Drawing.Point(77, 53);
            this.EndTimeLabel.Name = "EndTimeLabel";
            this.EndTimeLabel.Size = new System.Drawing.Size(78, 35);
            this.EndTimeLabel.TabIndex = 5;
            this.EndTimeLabel.Text = "--:--";
            // 
            // RemainingTimeLabel
            // 
            this.RemainingTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemainingTimeLabel.AutoSize = true;
            this.RemainingTimeLabel.Font = new System.Drawing.Font("Russo One", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemainingTimeLabel.Location = new System.Drawing.Point(77, 88);
            this.RemainingTimeLabel.Name = "RemainingTimeLabel";
            this.RemainingTimeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RemainingTimeLabel.Size = new System.Drawing.Size(43, 35);
            this.RemainingTimeLabel.TabIndex = 6;
            this.RemainingTimeLabel.Text = "--";
            // 
            // ConsoleTag
            // 
            this.ConsoleTag.AutoSize = true;
            this.ConsoleTag.Font = new System.Drawing.Font("Russo One", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConsoleTag.Location = new System.Drawing.Point(6, -1);
            this.ConsoleTag.Name = "ConsoleTag";
            this.ConsoleTag.Size = new System.Drawing.Size(162, 35);
            this.ConsoleTag.TabIndex = 6;
            this.ConsoleTag.Text = "Консоль 1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(336, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "мин";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(167, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "мин";
            // 
            // ConsoleTimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(372, 184);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ConsoleTag);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.StartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConsoleTimerForm";
            this.Text = "ConsoleTimerForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label StartTimeLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label RemainingTimeLabel;
        private System.Windows.Forms.Label EndTimeLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label ConsoleTag;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}