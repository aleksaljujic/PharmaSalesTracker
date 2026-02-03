namespace Server
{
    partial class FrmServer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbServer = new Label();
            btnPokreni = new Button();
            btnZaustavi = new Button();
            lbStatus = new Label();
            lbBrojac = new Label();
            tbBrojac = new TextBox();
            lbKlijenti = new Label();
            dgvKlijenti = new DataGridView();
            Client = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvKlijenti).BeginInit();
            SuspendLayout();
            // 
            // lbServer
            // 
            lbServer.AutoSize = true;
            lbServer.Font = new Font("Segoe UI", 30F);
            lbServer.Location = new Point(320, 9);
            lbServer.Name = "lbServer";
            lbServer.Size = new Size(157, 54);
            lbServer.TabIndex = 0;
            lbServer.Text = "SERVER";
            // 
            // btnPokreni
            // 
            btnPokreni.Font = new Font("Segoe UI", 15F);
            btnPokreni.Location = new Point(241, 395);
            btnPokreni.Name = "btnPokreni";
            btnPokreni.Size = new Size(157, 43);
            btnPokreni.TabIndex = 1;
            btnPokreni.Text = "Pokreni Server";
            btnPokreni.UseVisualStyleBackColor = true;
            btnPokreni.Click += btnPokreni_Click;
            // 
            // btnZaustavi
            // 
            btnZaustavi.Font = new Font("Segoe UI", 15F);
            btnZaustavi.Location = new Point(408, 395);
            btnZaustavi.Name = "btnZaustavi";
            btnZaustavi.Size = new Size(157, 43);
            btnZaustavi.TabIndex = 2;
            btnZaustavi.Text = "Zaustavi Server";
            btnZaustavi.UseVisualStyleBackColor = true;
            btnZaustavi.Click += btnZaustavi_Click;
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Font = new Font("Segoe UI", 15F);
            lbStatus.Location = new Point(241, 64);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(65, 28);
            lbStatus.TabIndex = 3;
            lbStatus.Text = "Status";
            // 
            // lbBrojac
            // 
            lbBrojac.AutoSize = true;
            lbBrojac.Font = new Font("Segoe UI", 12F);
            lbBrojac.Location = new Point(59, 116);
            lbBrojac.Name = "lbBrojac";
            lbBrojac.Size = new Size(205, 21);
            lbBrojac.TabIndex = 4;
            lbBrojac.Text = "Ukupno povezanih klijenata:";
            // 
            // tbBrojac
            // 
            tbBrojac.Enabled = false;
            tbBrojac.Font = new Font("Segoe UI", 15F);
            tbBrojac.Location = new Point(270, 107);
            tbBrojac.Name = "tbBrojac";
            tbBrojac.ReadOnly = true;
            tbBrojac.Size = new Size(100, 34);
            tbBrojac.TabIndex = 5;
            tbBrojac.Text = "0";
            tbBrojac.TextChanged += tbBrojac_TextChanged;
            // 
            // lbKlijenti
            // 
            lbKlijenti.AutoSize = true;
            lbKlijenti.Font = new Font("Segoe UI", 15F);
            lbKlijenti.Location = new Point(59, 144);
            lbKlijenti.Name = "lbKlijenti";
            lbKlijenti.Size = new Size(228, 28);
            lbKlijenti.TabIndex = 7;
            lbKlijenti.Text = "Lista povezanih klijenata:";
            // 
            // dgvKlijenti
            // 
            dgvKlijenti.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKlijenti.Columns.AddRange(new DataGridViewColumn[] { Client });
            dgvKlijenti.Location = new Point(59, 189);
            dgvKlijenti.Name = "dgvKlijenti";
            dgvKlijenti.ReadOnly = true;
            dgvKlijenti.Size = new Size(702, 182);
            dgvKlijenti.TabIndex = 9;
            // 
            // Client
            // 
            Client.HeaderText = "Klijent";
            Client.Name = "Client";
            Client.ReadOnly = true;
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 458);
            Controls.Add(dgvKlijenti);
            Controls.Add(lbKlijenti);
            Controls.Add(tbBrojac);
            Controls.Add(lbBrojac);
            Controls.Add(lbStatus);
            Controls.Add(btnZaustavi);
            Controls.Add(btnPokreni);
            Controls.Add(lbServer);
            Name = "FrmServer";
            Text = "Form1";
            Load += FrmServer_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKlijenti).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbServer;
        private Button btnPokreni;
        private Button btnZaustavi;
        private Label lbStatus;
        private Label lbBrojac;
        private TextBox tbBrojac;
        private Label lbKlijenti;
        private DataGridView dgvKlijenti;
        private DataGridViewTextBoxColumn Client;
    }
}
