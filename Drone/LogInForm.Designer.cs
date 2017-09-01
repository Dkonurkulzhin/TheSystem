namespace Drone
{
    partial class LogInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            this.button1 = new System.Windows.Forms.Button();
            this.UsernameInput = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button1.ForeColor = System.Drawing.SystemColors.Menu;
            this.button1.Location = new System.Drawing.Point(58, 123);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Вход";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UsernameInput
            // 
            this.UsernameInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.UsernameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsernameInput.ForeColor = System.Drawing.SystemColors.Menu;
            this.UsernameInput.Location = new System.Drawing.Point(99, 23);
            this.UsernameInput.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.UsernameInput.Name = "UsernameInput";
            this.UsernameInput.Size = new System.Drawing.Size(119, 27);
            this.UsernameInput.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.ErrorLabel);
            this.panel1.Controls.Add(this.PasswordLabel);
            this.panel1.Controls.Add(this.UsernameLabel);
            this.panel1.Controls.Add(this.PasswordInput);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.UsernameInput);
            this.panel1.Location = new System.Drawing.Point(443, 424);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 172);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // PasswordInput
            // 
            this.PasswordInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PasswordInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordInput.Location = new System.Drawing.Point(99, 57);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.PasswordChar = '*';
            this.PasswordInput.Size = new System.Drawing.Size(119, 27);
            this.PasswordInput.TabIndex = 3;
            this.PasswordInput.UseSystemPasswordChar = true;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.ForeColor = System.Drawing.SystemColors.Menu;
            this.UsernameLabel.Location = new System.Drawing.Point(32, 26);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(59, 19);
            this.UsernameLabel.TabIndex = 4;
            this.UsernameLabel.Text = "Логин";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.ForeColor = System.Drawing.SystemColors.Menu;
            this.PasswordLabel.Location = new System.Drawing.Point(22, 60);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(71, 19);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "Пароль";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(20, 100);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 19);
            this.ErrorLabel.TabIndex = 6;
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1305, 745);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Russo One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "LogInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogInForm";
            this.Load += new System.EventHandler(this.LogInForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LogInForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox UsernameInput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Label ErrorLabel;
    }
}