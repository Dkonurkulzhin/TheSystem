namespace Drone
{
    partial class DebugForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.WinUserLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Log = new System.Windows.Forms.ListBox();
            this.ProcessList = new System.Windows.Forms.ListBox();
            this.ViewProcBtn = new System.Windows.Forms.Button();
            this.KillProcBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.WinUserLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 76);
            this.panel1.TabIndex = 0;
            // 
            // WinUserLabel
            // 
            this.WinUserLabel.AutoSize = true;
            this.WinUserLabel.Location = new System.Drawing.Point(5, 21);
            this.WinUserLabel.Name = "WinUserLabel";
            this.WinUserLabel.Size = new System.Drawing.Size(114, 13);
            this.WinUserLabel.TabIndex = 1;
            this.WinUserLabel.Text = "Current windows user: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ScreenResolution:";
            // 
            // Log
            // 
            this.Log.FormattingEnabled = true;
            this.Log.Location = new System.Drawing.Point(3, 17);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(405, 225);
            this.Log.TabIndex = 1;
            // 
            // ProcessList
            // 
            this.ProcessList.FormattingEnabled = true;
            this.ProcessList.Location = new System.Drawing.Point(19, 37);
            this.ProcessList.Name = "ProcessList";
            this.ProcessList.Size = new System.Drawing.Size(116, 277);
            this.ProcessList.TabIndex = 2;
            // 
            // ViewProcBtn
            // 
            this.ViewProcBtn.Location = new System.Drawing.Point(19, 8);
            this.ViewProcBtn.Name = "ViewProcBtn";
            this.ViewProcBtn.Size = new System.Drawing.Size(116, 23);
            this.ViewProcBtn.TabIndex = 3;
            this.ViewProcBtn.Text = "View active";
            this.ViewProcBtn.UseVisualStyleBackColor = true;
            this.ViewProcBtn.Click += new System.EventHandler(this.ViewProcBtn_Click);
            // 
            // KillProcBtn
            // 
            this.KillProcBtn.Location = new System.Drawing.Point(19, 316);
            this.KillProcBtn.Name = "KillProcBtn";
            this.KillProcBtn.Size = new System.Drawing.Size(116, 23);
            this.KillProcBtn.TabIndex = 4;
            this.KillProcBtn.Text = "Kill all active";
            this.KillProcBtn.UseVisualStyleBackColor = true;
            this.KillProcBtn.Click += new System.EventHandler(this.KillProcBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.Log);
            this.panel2.Location = new System.Drawing.Point(13, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 248);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.ViewProcBtn);
            this.panel3.Controls.Add(this.ProcessList);
            this.panel3.Controls.Add(this.KillProcBtn);
            this.panel3.Location = new System.Drawing.Point(435, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(154, 342);
            this.panel3.TabIndex = 6;
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(601, 366);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DebugForm";
            this.Text = "DebugForm";
            this.Load += new System.EventHandler(this.DebugForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox Log;
        private System.Windows.Forms.ListBox ProcessList;
        private System.Windows.Forms.Button ViewProcBtn;
        private System.Windows.Forms.Button KillProcBtn;
        private System.Windows.Forms.Label WinUserLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}