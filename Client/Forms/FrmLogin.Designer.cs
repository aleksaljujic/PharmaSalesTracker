namespace Client
{
    partial class FrmLogin
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
            lbUsername = new Label();
            lbPassword = new Label();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.Location = new Point(37, 34);
            lbUsername.Margin = new Padding(2, 0, 2, 0);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(87, 15);
            lbUsername.TabIndex = 0;
            lbUsername.Text = "korisničko ime:";
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Location = new Point(37, 68);
            lbPassword.Margin = new Padding(2, 0, 2, 0);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(32, 15);
            lbPassword.TabIndex = 1;
            lbPassword.Text = "šifra:";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(193, 33);
            tbUsername.Margin = new Padding(2, 1, 2, 1);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(169, 23);
            tbUsername.TabIndex = 2;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(193, 67);
            tbPassword.Margin = new Padding(2, 1, 2, 1);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(169, 23);
            tbPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(171, 119);
            btnLogin.Margin = new Padding(2, 1, 2, 1);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(81, 30);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Prijavi se";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 175);
            Controls.Add(btnLogin);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(lbPassword);
            Controls.Add(lbUsername);
            Margin = new Padding(2, 1, 2, 1);
            Name = "FrmLogin";
            Text = "FrmLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbUsername;
        private Label lbPassword;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Button btnLogin;
    }
}