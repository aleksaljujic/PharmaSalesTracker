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
            colIdKupac = new DataGridViewTextBoxColumn();
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
            gbDodajKupca = new GroupBox();
            gbKupacInfo = new GroupBox();
            btnUkloniKupca = new Button();
            tbPrikaziEmail = new TextBox();
            btnIzmeniKupca = new Button();
            label7 = new Label();
            cbPrikaziGrad = new ComboBox();
            tbPrikaziIme = new TextBox();
            label8 = new Label();
            label9 = new Label();
            tbPrikaziAdresa = new TextBox();
            tbPrikaziPrezime = new TextBox();
            label10 = new Label();
            label11 = new Label();
            tbPrikaziBrojTel = new TextBox();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvKupci).BeginInit();
            gbDodajKupca.SuspendLayout();
            gbKupacInfo.SuspendLayout();
            SuspendLayout();
            // 
            // dgvKupci
            // 
            dgvKupci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKupci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKupci.Columns.AddRange(new DataGridViewColumn[] { colIdKupac, colIme, colPrezime, colBrojTelefona, colEmail, colAdresa, colGrad });
            dgvKupci.Location = new Point(279, 52);
            dgvKupci.Name = "dgvKupci";
            dgvKupci.Size = new Size(661, 501);
            dgvKupci.TabIndex = 0;
            dgvKupci.SelectionChanged += dgvKupci_SelectionChanged;
            // 
            // colIdKupac
            // 
            colIdKupac.HeaderText = "Id";
            colIdKupac.Name = "colIdKupac";
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
            label1.Location = new Point(34, 31);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 1;
            label1.Text = "Ime:";
            label1.Click += label1_Click;
            // 
            // tbIme
            // 
            tbIme.Location = new Point(34, 49);
            tbIme.Name = "tbIme";
            tbIme.Size = new Size(121, 23);
            tbIme.TabIndex = 2;
            // 
            // tbPrezime
            // 
            tbPrezime.Location = new Point(34, 103);
            tbPrezime.Name = "tbPrezime";
            tbPrezime.Size = new Size(121, 23);
            tbPrezime.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 85);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 3;
            label2.Text = "Prezime:";
            // 
            // tbBrojTel
            // 
            tbBrojTel.Location = new Point(34, 156);
            tbBrojTel.Name = "tbBrojTel";
            tbBrojTel.Size = new Size(121, 23);
            tbBrojTel.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 138);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 5;
            label3.Text = "Broj telefona:";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(34, 214);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(121, 23);
            tbEmail.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 196);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 7;
            label4.Text = "Email:";
            // 
            // tbAdresa
            // 
            tbAdresa.Location = new Point(34, 265);
            tbAdresa.Name = "tbAdresa";
            tbAdresa.Size = new Size(121, 23);
            tbAdresa.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 247);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 9;
            label5.Text = "Adresa:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 300);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 11;
            label6.Text = "Grad:";
            // 
            // cbGrad
            // 
            cbGrad.FormattingEnabled = true;
            cbGrad.Location = new Point(34, 330);
            cbGrad.Name = "cbGrad";
            cbGrad.Size = new Size(121, 23);
            cbGrad.TabIndex = 12;
            // 
            // btnDodajKupca
            // 
            btnDodajKupca.Location = new Point(34, 379);
            btnDodajKupca.Name = "btnDodajKupca";
            btnDodajKupca.Size = new Size(121, 35);
            btnDodajKupca.TabIndex = 13;
            btnDodajKupca.Text = "Dodaj Kupca";
            btnDodajKupca.UseVisualStyleBackColor = true;
            btnDodajKupca.Click += btnDodajKupca_Click;
            // 
            // gbDodajKupca
            // 
            gbDodajKupca.Controls.Add(tbEmail);
            gbDodajKupca.Controls.Add(btnDodajKupca);
            gbDodajKupca.Controls.Add(label1);
            gbDodajKupca.Controls.Add(cbGrad);
            gbDodajKupca.Controls.Add(tbIme);
            gbDodajKupca.Controls.Add(label6);
            gbDodajKupca.Controls.Add(label2);
            gbDodajKupca.Controls.Add(tbAdresa);
            gbDodajKupca.Controls.Add(tbPrezime);
            gbDodajKupca.Controls.Add(label5);
            gbDodajKupca.Controls.Add(label3);
            gbDodajKupca.Controls.Add(tbBrojTel);
            gbDodajKupca.Controls.Add(label4);
            gbDodajKupca.Location = new Point(962, 52);
            gbDodajKupca.Name = "gbDodajKupca";
            gbDodajKupca.Size = new Size(200, 501);
            gbDodajKupca.TabIndex = 14;
            gbDodajKupca.TabStop = false;
            gbDodajKupca.Text = "Dodaj Kupca";
            gbDodajKupca.Enter += groupBox1_Enter;
            // 
            // gbKupacInfo
            // 
            gbKupacInfo.Controls.Add(btnUkloniKupca);
            gbKupacInfo.Controls.Add(tbPrikaziEmail);
            gbKupacInfo.Controls.Add(btnIzmeniKupca);
            gbKupacInfo.Controls.Add(label7);
            gbKupacInfo.Controls.Add(cbPrikaziGrad);
            gbKupacInfo.Controls.Add(tbPrikaziIme);
            gbKupacInfo.Controls.Add(label8);
            gbKupacInfo.Controls.Add(label9);
            gbKupacInfo.Controls.Add(tbPrikaziAdresa);
            gbKupacInfo.Controls.Add(tbPrikaziPrezime);
            gbKupacInfo.Controls.Add(label10);
            gbKupacInfo.Controls.Add(label11);
            gbKupacInfo.Controls.Add(tbPrikaziBrojTel);
            gbKupacInfo.Controls.Add(label12);
            gbKupacInfo.Location = new Point(51, 52);
            gbKupacInfo.Name = "gbKupacInfo";
            gbKupacInfo.Size = new Size(200, 501);
            gbKupacInfo.TabIndex = 15;
            gbKupacInfo.TabStop = false;
            gbKupacInfo.Text = "Informacije o Kupcu";
            // 
            // btnUkloniKupca
            // 
            btnUkloniKupca.Location = new Point(34, 439);
            btnUkloniKupca.Name = "btnUkloniKupca";
            btnUkloniKupca.Size = new Size(121, 35);
            btnUkloniKupca.TabIndex = 14;
            btnUkloniKupca.Text = "Ukloni Kupca";
            btnUkloniKupca.UseVisualStyleBackColor = true;
            btnUkloniKupca.Click += btnUkloniKupca_Click;
            // 
            // tbPrikaziEmail
            // 
            tbPrikaziEmail.Location = new Point(34, 214);
            tbPrikaziEmail.Name = "tbPrikaziEmail";
            tbPrikaziEmail.Size = new Size(121, 23);
            tbPrikaziEmail.TabIndex = 8;
            // 
            // btnIzmeniKupca
            // 
            btnIzmeniKupca.Location = new Point(34, 379);
            btnIzmeniKupca.Name = "btnIzmeniKupca";
            btnIzmeniKupca.Size = new Size(121, 35);
            btnIzmeniKupca.TabIndex = 13;
            btnIzmeniKupca.Text = "Izmeni Informacije";
            btnIzmeniKupca.UseVisualStyleBackColor = true;
            btnIzmeniKupca.Click += btnIzmeniKupca_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(34, 31);
            label7.Name = "label7";
            label7.Size = new Size(30, 15);
            label7.TabIndex = 1;
            label7.Text = "Ime:";
            // 
            // cbPrikaziGrad
            // 
            cbPrikaziGrad.FormattingEnabled = true;
            cbPrikaziGrad.Location = new Point(34, 330);
            cbPrikaziGrad.Name = "cbPrikaziGrad";
            cbPrikaziGrad.Size = new Size(121, 23);
            cbPrikaziGrad.TabIndex = 12;
            // 
            // tbPrikaziIme
            // 
            tbPrikaziIme.Location = new Point(34, 49);
            tbPrikaziIme.Name = "tbPrikaziIme";
            tbPrikaziIme.ReadOnly = true;
            tbPrikaziIme.Size = new Size(121, 23);
            tbPrikaziIme.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(34, 300);
            label8.Name = "label8";
            label8.Size = new Size(35, 15);
            label8.TabIndex = 11;
            label8.Text = "Grad:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(34, 85);
            label9.Name = "label9";
            label9.Size = new Size(52, 15);
            label9.TabIndex = 3;
            label9.Text = "Prezime:";
            // 
            // tbPrikaziAdresa
            // 
            tbPrikaziAdresa.Location = new Point(34, 265);
            tbPrikaziAdresa.Name = "tbPrikaziAdresa";
            tbPrikaziAdresa.Size = new Size(121, 23);
            tbPrikaziAdresa.TabIndex = 10;
            // 
            // tbPrikaziPrezime
            // 
            tbPrikaziPrezime.Location = new Point(34, 103);
            tbPrikaziPrezime.Name = "tbPrikaziPrezime";
            tbPrikaziPrezime.ReadOnly = true;
            tbPrikaziPrezime.Size = new Size(121, 23);
            tbPrikaziPrezime.TabIndex = 4;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(34, 247);
            label10.Name = "label10";
            label10.Size = new Size(46, 15);
            label10.TabIndex = 9;
            label10.Text = "Adresa:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(34, 138);
            label11.Name = "label11";
            label11.Size = new Size(77, 15);
            label11.TabIndex = 5;
            label11.Text = "Broj telefona:";
            // 
            // tbPrikaziBrojTel
            // 
            tbPrikaziBrojTel.Location = new Point(34, 156);
            tbPrikaziBrojTel.Name = "tbPrikaziBrojTel";
            tbPrikaziBrojTel.Size = new Size(121, 23);
            tbPrikaziBrojTel.TabIndex = 6;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(34, 196);
            label12.Name = "label12";
            label12.Size = new Size(39, 15);
            label12.TabIndex = 7;
            label12.Text = "Email:";
            // 
            // UCKupac
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gbKupacInfo);
            Controls.Add(gbDodajKupca);
            Controls.Add(dgvKupci);
            Name = "UCKupac";
            Size = new Size(1187, 593);
            ((System.ComponentModel.ISupportInitialize)dgvKupci).EndInit();
            gbDodajKupca.ResumeLayout(false);
            gbDodajKupca.PerformLayout();
            gbKupacInfo.ResumeLayout(false);
            gbKupacInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvKupci;
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
        private DataGridViewTextBoxColumn colIdKupac;
        private DataGridViewTextBoxColumn colIme;
        private DataGridViewTextBoxColumn colPrezime;
        private DataGridViewTextBoxColumn colBrojTelefona;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colAdresa;
        private DataGridViewTextBoxColumn colGrad;
        private GroupBox gbDodajKupca;
        private GroupBox gbKupacInfo;
        private Button btnUkloniKupca;
        private TextBox tbPrikaziEmail;
        private Button btnIzmeniKupca;
        private Label label7;
        private ComboBox cbPrikaziGrad;
        private TextBox tbPrikaziIme;
        private Label label8;
        private Label label9;
        private TextBox tbPrikaziAdresa;
        private TextBox tbPrikaziPrezime;
        private Label label10;
        private Label label11;
        private TextBox tbPrikaziBrojTel;
        private Label label12;
    }
}
