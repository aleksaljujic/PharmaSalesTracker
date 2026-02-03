namespace Client.UserControls
{
    partial class UCKupac
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvKupci = new DataGridView();
            colIme = new DataGridViewTextBoxColumn();
            colPrezime = new DataGridViewTextBoxColumn();
            colBrojTelefona = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colAdresa = new DataGridViewTextBoxColumn();
            colGrad = new DataGridViewTextBoxColumn();
            label1 = new Label();
            tbIme = new TextBox();
            tbPrezime = new TextBox();
            label2 = new Label();
            tbBrojTel = new TextBox();
            label3 = new Label();
            tbEmail = new TextBox();
            label4 = new Label();
            tbAdresa = new TextBox();
            label5 = new Label();
            label6 = new Label();
            cbGrad = new ComboBox();
            btnDodajKupca = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKupci).BeginInit();
            SuspendLayout();
            // 
            // dgvKupci
            // 
            dgvKupci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKupci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKupci.Columns.AddRange(new DataGridViewColumn[] { colIme, colPrezime, colBrojTelefona, colEmail, colAdresa, colGrad });
            dgvKupci.Location = new Point(207, 76);
            dgvKupci.Name = "dgvKupci";
            dgvKupci.Size = new Size(667, 383);
            dgvKupci.TabIndex = 0;
            // 
            // colIme
            // 
            colIme.HeaderText = "Ime";
            colIme.Name = "colIme";
            colIme.ReadOnly = true;
            // 
            // colPrezime
            // 
            colPrezime.HeaderText = "Prezime";
            colPrezime.Name = "colPrezime";
            colPrezime.ReadOnly = true;
            // 
            // colBrojTelefona
            // 
            colBrojTelefona.HeaderText = "Broj Telefona";
            colBrojTelefona.Name = "colBrojTelefona";
            colBrojTelefona.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colAdresa
            // 
            colAdresa.HeaderText = "Adresa";
            colAdresa.Name = "colAdresa";
            colAdresa.ReadOnly = true;
            // 
            // colGrad
            // 
            colGrad.HeaderText = "Grad";
            colGrad.Name = "colGrad";
            colGrad.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 76);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 1;
            label1.Text = "Ime:";
            label1.Click += label1_Click;
            // 
            // tbIme
            // 
            tbIme.Location = new Point(41, 94);
            tbIme.Name = "tbIme";
            tbIme.Size = new Size(121, 23);
            tbIme.TabIndex = 2;
            // 
            // tbPrezime
            // 
            tbPrezime.Location = new Point(41, 148);
            tbPrezime.Name = "tbPrezime";
            tbPrezime.Size = new Size(121, 23);
            tbPrezime.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 130);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 3;
            label2.Text = "Prezime:";
            // 
            // tbBrojTel
            // 
            tbBrojTel.Location = new Point(41, 201);
            tbBrojTel.Name = "tbBrojTel";
            tbBrojTel.Size = new Size(121, 23);
            tbBrojTel.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 183);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 5;
            label3.Text = "Broj telefona:";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(41, 259);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(121, 23);
            tbEmail.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 241);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 7;
            label4.Text = "Email:";
            // 
            // tbAdresa
            // 
            tbAdresa.Location = new Point(41, 310);
            tbAdresa.Name = "tbAdresa";
            tbAdresa.Size = new Size(121, 23);
            tbAdresa.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 292);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 9;
            label5.Text = "Adresa:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(41, 345);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 11;
            label6.Text = "Grad:";
            // 
            // cbGrad
            // 
            cbGrad.FormattingEnabled = true;
            cbGrad.Location = new Point(41, 375);
            cbGrad.Name = "cbGrad";
            cbGrad.Size = new Size(121, 23);
            cbGrad.TabIndex = 12;
            // 
            // btnDodajKupca
            // 
            btnDodajKupca.Location = new Point(41, 424);
            btnDodajKupca.Name = "btnDodajKupca";
            btnDodajKupca.Size = new Size(121, 35);
            btnDodajKupca.TabIndex = 13;
            btnDodajKupca.Text = "Dodaj Kupca";
            btnDodajKupca.UseVisualStyleBackColor = true;
            btnDodajKupca.Click += btnDodajKupca_Click;
            // 
            // UCKupac
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnDodajKupca);
            Controls.Add(cbGrad);
            Controls.Add(label6);
            Controls.Add(tbAdresa);
            Controls.Add(label5);
            Controls.Add(tbEmail);
            Controls.Add(label4);
            Controls.Add(tbBrojTel);
            Controls.Add(label3);
            Controls.Add(tbPrezime);
            Controls.Add(label2);
            Controls.Add(tbIme);
            Controls.Add(label1);
            Controls.Add(dgvKupci);
            Name = "UCKupac";
            Size = new Size(905, 529);
            ((System.ComponentModel.ISupportInitialize)dgvKupci).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvKupci;
        private DataGridViewTextBoxColumn colIme;
        private DataGridViewTextBoxColumn colPrezime;
        private DataGridViewTextBoxColumn colBrojTelefona;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colAdresa;
        private DataGridViewTextBoxColumn colGrad;
        private Label label1;
        private TextBox tbIme;
        private TextBox tbPrezime;
        private Label label2;
        private TextBox tbBrojTel;
        private Label label3;
        private TextBox tbEmail;
        private Label label4;
        private TextBox tbAdresa;
        private Label label5;
        private Label label6;
        private ComboBox cbGrad;
        private Button btnDodajKupca;
    }
}
