namespace Drone
{
    partial class UserForm
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
            this.UserAvatar = new System.Windows.Forms.PictureBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UserLevelLabel = new System.Windows.Forms.Label();
            this.UserSettingButton = new System.Windows.Forms.Button();
            this.UserLogoutButton = new System.Windows.Forms.Button();
            this.UserLevelProgressbar = new System.Windows.Forms.ProgressBar();
            this.UserFinancialPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.UserBalanceLabel = new System.Windows.Forms.Label();
            this.UserTimeLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.UserRatingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UserAvatar)).BeginInit();
            this.UserFinancialPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserAvatar
            // 
            this.UserAvatar.Location = new System.Drawing.Point(12, 35);
            this.UserAvatar.Name = "UserAvatar";
            this.UserAvatar.Size = new System.Drawing.Size(128, 128);
            this.UserAvatar.TabIndex = 0;
            this.UserAvatar.TabStop = false;
            this.UserAvatar.Click += new System.EventHandler(this.UserAvatar_Click);
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserNameLabel.Location = new System.Drawing.Point(12, 7);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(341, 23);
            this.UserNameLabel.TabIndex = 1;
            this.UserNameLabel.Text = "User";
            this.UserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserLevelLabel
            // 
            this.UserLevelLabel.AutoSize = true;
            this.UserLevelLabel.Font = new System.Drawing.Font("Sitka Small", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLevelLabel.Location = new System.Drawing.Point(160, 35);
            this.UserLevelLabel.Name = "UserLevelLabel";
            this.UserLevelLabel.Size = new System.Drawing.Size(80, 28);
            this.UserLevelLabel.TabIndex = 2;
            this.UserLevelLabel.Text = "Level 1";
            // 
            // UserSettingButton
            // 
            this.UserSettingButton.Location = new System.Drawing.Point(588, 12);
            this.UserSettingButton.Name = "UserSettingButton";
            this.UserSettingButton.Size = new System.Drawing.Size(111, 34);
            this.UserSettingButton.TabIndex = 3;
            this.UserSettingButton.Text = "Profile settings";
            this.UserSettingButton.UseVisualStyleBackColor = true;
            // 
            // UserLogoutButton
            // 
            this.UserLogoutButton.Location = new System.Drawing.Point(763, 12);
            this.UserLogoutButton.Name = "UserLogoutButton";
            this.UserLogoutButton.Size = new System.Drawing.Size(116, 34);
            this.UserLogoutButton.TabIndex = 4;
            this.UserLogoutButton.Text = "Log out";
            this.UserLogoutButton.UseVisualStyleBackColor = true;
            this.UserLogoutButton.Click += new System.EventHandler(this.UserLogoutButton_Click);
            // 
            // UserLevelProgressbar
            // 
            this.UserLevelProgressbar.Location = new System.Drawing.Point(155, 66);
            this.UserLevelProgressbar.Name = "UserLevelProgressbar";
            this.UserLevelProgressbar.Size = new System.Drawing.Size(394, 23);
            this.UserLevelProgressbar.TabIndex = 5;
            this.UserLevelProgressbar.Value = 50;
            // 
            // UserFinancialPanel
            // 
            this.UserFinancialPanel.Controls.Add(this.label1);
            this.UserFinancialPanel.Controls.Add(this.UserBalanceLabel);
            this.UserFinancialPanel.Controls.Add(this.UserTimeLabel);
            this.UserFinancialPanel.Location = new System.Drawing.Point(588, 64);
            this.UserFinancialPanel.Name = "UserFinancialPanel";
            this.UserFinancialPanel.Size = new System.Drawing.Size(291, 99);
            this.UserFinancialPanel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Текущий тариф:";
            // 
            // UserBalanceLabel
            // 
            this.UserBalanceLabel.AutoSize = true;
            this.UserBalanceLabel.Location = new System.Drawing.Point(10, 13);
            this.UserBalanceLabel.Name = "UserBalanceLabel";
            this.UserBalanceLabel.Size = new System.Drawing.Size(52, 13);
            this.UserBalanceLabel.TabIndex = 1;
            this.UserBalanceLabel.Text = "Balance: ";
            // 
            // UserTimeLabel
            // 
            this.UserTimeLabel.AutoSize = true;
            this.UserTimeLabel.Location = new System.Drawing.Point(10, 37);
            this.UserTimeLabel.Name = "UserTimeLabel";
            this.UserTimeLabel.Size = new System.Drawing.Size(81, 13);
            this.UserTimeLabel.TabIndex = 0;
            this.UserTimeLabel.Text = "Time remaining:";
            // 
            // UserRatingLabel
            // 
            this.UserRatingLabel.AutoSize = true;
            this.UserRatingLabel.Location = new System.Drawing.Point(162, 99);
            this.UserRatingLabel.Name = "UserRatingLabel";
            this.UserRatingLabel.Size = new System.Drawing.Size(49, 13);
            this.UserRatingLabel.TabIndex = 8;
            this.UserRatingLabel.Text = "Newbiee";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(904, 178);
            this.Controls.Add(this.UserRatingLabel);
            this.Controls.Add(this.UserFinancialPanel);
            this.Controls.Add(this.UserSettingButton);
            this.Controls.Add(this.UserLevelProgressbar);
            this.Controls.Add(this.UserLogoutButton);
            this.Controls.Add(this.UserLevelLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.UserAvatar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(500, 20);
            this.Name = "UserForm";
            this.Text = "UserStat";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UserAvatar)).EndInit();
            this.UserFinancialPanel.ResumeLayout(false);
            this.UserFinancialPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox UserAvatar;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label UserLevelLabel;
        private System.Windows.Forms.Button UserSettingButton;
        private System.Windows.Forms.Button UserLogoutButton;
        private System.Windows.Forms.ProgressBar UserLevelProgressbar;
        private System.Windows.Forms.Panel UserFinancialPanel;
        private System.Windows.Forms.Label UserBalanceLabel;
        private System.Windows.Forms.Label UserTimeLabel;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label UserRatingLabel;
    }
}