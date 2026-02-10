namespace Client.Forms
{
    partial class FrmMain
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
            menuStrip1 = new MenuStrip();
            početnaToolStripMenuItem = new ToolStripMenuItem();
            računiToolStripMenuItem = new ToolStripMenuItem();
            lekoviToolStripMenuItem = new ToolStripMenuItem();
            kupciToolStripMenuItem = new ToolStripMenuItem();
            gradoviToolStripMenuItem = new ToolStripMenuItem();
            smeneToolStripMenuItem = new ToolStripMenuItem();
            odjaviSeToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            footer = new ToolStripStatusLabel();
            panelMain = new Panel();
            kreirajRačunToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { početnaToolStripMenuItem, računiToolStripMenuItem, lekoviToolStripMenuItem, kupciToolStripMenuItem, gradoviToolStripMenuItem, smeneToolStripMenuItem, odjaviSeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // početnaToolStripMenuItem
            // 
            početnaToolStripMenuItem.Name = "početnaToolStripMenuItem";
            početnaToolStripMenuItem.Size = new Size(62, 20);
            početnaToolStripMenuItem.Text = "Početna";
            početnaToolStripMenuItem.Click += početnaToolStripMenuItem_Click;
            // 
            // računiToolStripMenuItem
            // 
            računiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kreirajRačunToolStripMenuItem });
            računiToolStripMenuItem.Name = "računiToolStripMenuItem";
            računiToolStripMenuItem.Size = new Size(55, 20);
            računiToolStripMenuItem.Text = "Računi";
            računiToolStripMenuItem.Click += računiToolStripMenuItem_Click;
            // 
            // lekoviToolStripMenuItem
            // 
            lekoviToolStripMenuItem.Name = "lekoviToolStripMenuItem";
            lekoviToolStripMenuItem.Size = new Size(53, 20);
            lekoviToolStripMenuItem.Text = "Lekovi";
            // 
            // kupciToolStripMenuItem
            // 
            kupciToolStripMenuItem.Name = "kupciToolStripMenuItem";
            kupciToolStripMenuItem.Size = new Size(49, 20);
            kupciToolStripMenuItem.Text = "Kupci";
            kupciToolStripMenuItem.Click += kupciToolStripMenuItem_Click;
            // 
            // gradoviToolStripMenuItem
            // 
            gradoviToolStripMenuItem.Name = "gradoviToolStripMenuItem";
            gradoviToolStripMenuItem.Size = new Size(60, 20);
            gradoviToolStripMenuItem.Text = "Gradovi";
            // 
            // smeneToolStripMenuItem
            // 
            smeneToolStripMenuItem.Name = "smeneToolStripMenuItem";
            smeneToolStripMenuItem.Size = new Size(55, 20);
            smeneToolStripMenuItem.Text = "Smene";
            // 
            // odjaviSeToolStripMenuItem
            // 
            odjaviSeToolStripMenuItem.Name = "odjaviSeToolStripMenuItem";
            odjaviSeToolStripMenuItem.Size = new Size(67, 20);
            odjaviSeToolStripMenuItem.Text = "Odjavi se";
            odjaviSeToolStripMenuItem.Click += odjaviSeToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(32, 32);
            statusStrip1.Items.AddRange(new ToolStripItem[] { footer });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // footer
            // 
            footer.Name = "footer";
            footer.Size = new Size(39, 17);
            footer.Text = "Status";
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 24);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(800, 404);
            panelMain.TabIndex = 6;
            // 
            // kreirajRačunToolStripMenuItem
            // 
            kreirajRačunToolStripMenuItem.Name = "kreirajRačunToolStripMenuItem";
            kreirajRačunToolStripMenuItem.Size = new Size(180, 22);
            kreirajRačunToolStripMenuItem.Text = "Kreiraj račun";
            kreirajRačunToolStripMenuItem.Click += kreirajRačunToolStripMenuItem_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelMain);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmMain";
            Text = "Main";
            WindowState = FormWindowState.Maximized;
            Load += FrmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem računiToolStripMenuItem;
        private ToolStripMenuItem lekoviToolStripMenuItem;
        private ToolStripMenuItem kupciToolStripMenuItem;
        private ToolStripMenuItem gradoviToolStripMenuItem;
        private ToolStripMenuItem smeneToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel footer;
        private Panel panelMain;
        private ToolStripMenuItem odjaviSeToolStripMenuItem;
        private ToolStripMenuItem početnaToolStripMenuItem;
        private ToolStripMenuItem kreirajRačunToolStripMenuItem;
    }
}