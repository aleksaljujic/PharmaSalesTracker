namespace Client.UserControls
{
    partial class UCKreirajRacun
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
            groupBox1 = new GroupBox();
            btnKreirajRacun = new Button();
            tbNapomena = new TextBox();
            label10 = new Label();
            cbStatusRacuna = new ComboBox();
            label5 = new Label();
            cbNacinPlacanja = new ComboBox();
            label4 = new Label();
            dtpRokPlacanja = new DateTimePicker();
            label3 = new Label();
            cbKupci = new ComboBox();
            label2 = new Label();
            cbApotekari = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvStavkeRacuna = new DataGridView();
            colRb = new DataGridViewTextBoxColumn();
            colLek = new DataGridViewTextBoxColumn();
            colKolicina = new DataGridViewTextBoxColumn();
            colIznos = new DataGridViewTextBoxColumn();
            colPopust = new DataGridViewTextBoxColumn();
            colKonacnaCena = new DataGridViewTextBoxColumn();
            label12 = new Label();
            label11 = new Label();
            dgvRacun = new DataGridView();
            colRacunId = new DataGridViewTextBoxColumn();
            colDatumIzdavanja = new DataGridViewTextBoxColumn();
            colRokPlacanja = new DataGridViewTextBoxColumn();
            colPdv = new DataGridViewTextBoxColumn();
            colNacinPlacanja = new DataGridViewTextBoxColumn();
            colStatusRacuna = new DataGridViewTextBoxColumn();
            colBrRacuna = new DataGridViewTextBoxColumn();
            button1 = new Button();
            cbPopust = new ComboBox();
            label9 = new Label();
            cbKolicina = new ComboBox();
            label8 = new Label();
            tbCenaLeka = new TextBox();
            label7 = new Label();
            cbLekovi = new ComboBox();
            label6 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavkeRacuna).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRacun).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnKreirajRacun);
            groupBox1.Controls.Add(tbNapomena);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(cbStatusRacuna);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cbNacinPlacanja);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dtpRokPlacanja);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbKupci);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cbApotekari);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(35, 39);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(231, 588);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kreiraj Racun";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnKreirajRacun
            // 
            btnKreirajRacun.Location = new Point(47, 516);
            btnKreirajRacun.Name = "btnKreirajRacun";
            btnKreirajRacun.Size = new Size(114, 36);
            btnKreirajRacun.TabIndex = 20;
            btnKreirajRacun.Text = "Kreiraj račun";
            btnKreirajRacun.UseVisualStyleBackColor = true;
            btnKreirajRacun.Click += btnKreirajRacun_Click;
            // 
            // tbNapomena
            // 
            tbNapomena.Location = new Point(16, 367);
            tbNapomena.Multiline = true;
            tbNapomena.Name = "tbNapomena";
            tbNapomena.Size = new Size(200, 129);
            tbNapomena.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 349);
            label10.Name = "label10";
            label10.Size = new Size(72, 15);
            label10.TabIndex = 11;
            label10.Text = "Napomena :";
            // 
            // cbStatusRacuna
            // 
            cbStatusRacuna.AutoCompleteCustomSource.AddRange(new string[] { "Plaćen", "Neplaćen", "Storniran" });
            cbStatusRacuna.FormattingEnabled = true;
            cbStatusRacuna.Location = new Point(16, 312);
            cbStatusRacuna.Name = "cbStatusRacuna";
            cbStatusRacuna.Size = new Size(154, 23);
            cbStatusRacuna.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 285);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 9;
            label5.Text = "Status računa :";
            // 
            // cbNacinPlacanja
            // 
            cbNacinPlacanja.AutoCompleteCustomSource.AddRange(new string[] { "Kartica", "Gotovina", "Virman" });
            cbNacinPlacanja.FormattingEnabled = true;
            cbNacinPlacanja.Location = new Point(16, 246);
            cbNacinPlacanja.Name = "cbNacinPlacanja";
            cbNacinPlacanja.Size = new Size(154, 23);
            cbNacinPlacanja.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 219);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 7;
            label4.Text = "Način plaćanja :";
            // 
            // dtpRokPlacanja
            // 
            dtpRokPlacanja.Location = new Point(16, 184);
            dtpRokPlacanja.Name = "dtpRokPlacanja";
            dtpRokPlacanja.Size = new Size(200, 23);
            dtpRokPlacanja.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 156);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 4;
            label3.Text = "Rok plaćanja :";
            // 
            // cbKupci
            // 
            cbKupci.FormattingEnabled = true;
            cbKupci.Location = new Point(16, 120);
            cbKupci.Name = "cbKupci";
            cbKupci.Size = new Size(154, 23);
            cbKupci.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 93);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 2;
            label2.Text = "Izaberi kupca :";
            // 
            // cbApotekari
            // 
            cbApotekari.FormattingEnabled = true;
            cbApotekari.Location = new Point(16, 57);
            cbApotekari.Name = "cbApotekari";
            cbApotekari.Size = new Size(154, 23);
            cbApotekari.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 30);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "Izaberi apotekara :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvStavkeRacuna);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(dgvRacun);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(cbPopust);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(cbKolicina);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(tbCenaLeka);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(cbLekovi);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(292, 39);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(841, 588);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Kreiraj Stavku Računa";
            // 
            // dgvStavkeRacuna
            // 
            dgvStavkeRacuna.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStavkeRacuna.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavkeRacuna.Columns.AddRange(new DataGridViewColumn[] { colRb, colLek, colKolicina, colIznos, colPopust, colKonacnaCena });
            dgvStavkeRacuna.Location = new Point(17, 264);
            dgvStavkeRacuna.Name = "dgvStavkeRacuna";
            dgvStavkeRacuna.Size = new Size(805, 305);
            dgvStavkeRacuna.TabIndex = 25;
            // 
            // colRb
            // 
            colRb.FillWeight = 20F;
            colRb.HeaderText = "Rb";
            colRb.Name = "colRb";
            colRb.ReadOnly = true;
            // 
            // colLek
            // 
            colLek.FillWeight = 200F;
            colLek.HeaderText = "Lek";
            colLek.Name = "colLek";
            colLek.ReadOnly = true;
            colLek.Resizable = DataGridViewTriState.True;
            // 
            // colKolicina
            // 
            colKolicina.FillWeight = 40F;
            colKolicina.HeaderText = "Kolicina";
            colKolicina.Name = "colKolicina";
            colKolicina.ReadOnly = true;
            // 
            // colIznos
            // 
            colIznos.FillWeight = 80F;
            colIznos.HeaderText = "Iznos";
            colIznos.Name = "colIznos";
            colIznos.ReadOnly = true;
            // 
            // colPopust
            // 
            colPopust.FillWeight = 50F;
            colPopust.HeaderText = "Popust";
            colPopust.Name = "colPopust";
            colPopust.ReadOnly = true;
            // 
            // colKonacnaCena
            // 
            colKonacnaCena.FillWeight = 80F;
            colKonacnaCena.HeaderText = "Konacna cena";
            colKonacnaCena.Name = "colKonacnaCena";
            colKonacnaCena.ReadOnly = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(17, 219);
            label12.Name = "label12";
            label12.Size = new Size(106, 21);
            label12.TabIndex = 24;
            label12.Text = "Stavke računa";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(17, 118);
            label11.Name = "label11";
            label11.Size = new Size(53, 21);
            label11.TabIndex = 21;
            label11.Text = "Račun";
            // 
            // dgvRacun
            // 
            dgvRacun.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRacun.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRacun.Columns.AddRange(new DataGridViewColumn[] { colRacunId, colDatumIzdavanja, colRokPlacanja, colPdv, colNacinPlacanja, colStatusRacuna, colBrRacuna });
            dgvRacun.Location = new Point(17, 145);
            dgvRacun.Name = "dgvRacun";
            dgvRacun.Size = new Size(805, 65);
            dgvRacun.TabIndex = 22;
            // 
            // colRacunId
            // 
            colRacunId.HeaderText = "RacunId";
            colRacunId.Name = "colRacunId";
            colRacunId.ReadOnly = true;
            // 
            // colDatumIzdavanja
            // 
            colDatumIzdavanja.HeaderText = "Datum Izdavanja";
            colDatumIzdavanja.Name = "colDatumIzdavanja";
            colDatumIzdavanja.ReadOnly = true;
            // 
            // colRokPlacanja
            // 
            colRokPlacanja.HeaderText = "Rok Placanja";
            colRokPlacanja.Name = "colRokPlacanja";
            colRokPlacanja.ReadOnly = true;
            // 
            // colPdv
            // 
            colPdv.HeaderText = "PDV";
            colPdv.Name = "colPdv";
            colPdv.ReadOnly = true;
            // 
            // colNacinPlacanja
            // 
            colNacinPlacanja.HeaderText = "Nacin Placanja";
            colNacinPlacanja.Name = "colNacinPlacanja";
            colNacinPlacanja.ReadOnly = true;
            // 
            // colStatusRacuna
            // 
            colStatusRacuna.HeaderText = "Status Racuna";
            colStatusRacuna.Name = "colStatusRacuna";
            colStatusRacuna.ReadOnly = true;
            // 
            // colBrRacuna
            // 
            colBrRacuna.HeaderText = "Broj računa";
            colBrRacuna.Name = "colBrRacuna";
            colBrRacuna.ReadOnly = true;
            // 
            // button1
            // 
            button1.Location = new Point(528, 44);
            button1.Name = "button1";
            button1.Size = new Size(158, 36);
            button1.TabIndex = 21;
            button1.Text = "Kreiraj stavku računa";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // cbPopust
            // 
            cbPopust.AutoCompleteCustomSource.AddRange(new string[] { "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60", "65", "70" });
            cbPopust.FormattingEnabled = true;
            cbPopust.Location = new Point(336, 66);
            cbPopust.Name = "cbPopust";
            cbPopust.Size = new Size(154, 23);
            cbPopust.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(266, 69);
            label9.Name = "label9";
            label9.Size = new Size(50, 15);
            label9.TabIndex = 17;
            label9.Text = "Popust :";
            // 
            // cbKolicina
            // 
            cbKolicina.AutoCompleteCustomSource.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbKolicina.FormattingEnabled = true;
            cbKolicina.Location = new Point(88, 66);
            cbKolicina.Name = "cbKolicina";
            cbKolicina.Size = new Size(154, 23);
            cbKolicina.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 69);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 15;
            label8.Text = "Količina :";
            // 
            // tbCenaLeka
            // 
            tbCenaLeka.Location = new Point(336, 27);
            tbCenaLeka.Name = "tbCenaLeka";
            tbCenaLeka.ReadOnly = true;
            tbCenaLeka.Size = new Size(100, 23);
            tbCenaLeka.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(266, 30);
            label7.Name = "label7";
            label7.Size = new Size(64, 15);
            label7.TabIndex = 13;
            label7.Text = "Cena leka :";
            // 
            // cbLekovi
            // 
            cbLekovi.FormattingEnabled = true;
            cbLekovi.Location = new Point(88, 27);
            cbLekovi.Name = "cbLekovi";
            cbLekovi.Size = new Size(154, 23);
            cbLekovi.TabIndex = 12;
            cbLekovi.SelectedIndexChanged += cbLekovi_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 30);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 11;
            label6.Text = "Izaberi lek :";
            // 
            // UCKreirajRacun
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "UCKreirajRacun";
            Size = new Size(1170, 644);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavkeRacuna).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRacun).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cbKupci;
        private Label label2;
        private ComboBox cbApotekari;
        private Label label1;
        private ComboBox cbStatusRacuna;
        private Label label5;
        private ComboBox cbNacinPlacanja;
        private Label label4;
        private DateTimePicker dtpRokPlacanja;
        private Label label3;
        private GroupBox groupBox2;
        private Label label7;
        private ComboBox cbLekovi;
        private Label label6;
        private ComboBox cbPopust;
        private Label label9;
        private ComboBox cbKolicina;
        private Label label8;
        private TextBox tbCenaLeka;
        private TextBox tbNapomena;
        private Label label10;
        private Button btnKreirajRacun;
        private Label label12;
        private Label label11;
        private DataGridView dataGridView2;
        private DataGridView dgvRacun;
        private Button button1;
        private DataGridView dgvStavkeRacuna;
        private DataGridViewTextBoxColumn colRb;
        private DataGridViewTextBoxColumn colLek;
        private DataGridViewTextBoxColumn colKolicina;
        private DataGridViewTextBoxColumn colIznos;
        private DataGridViewTextBoxColumn colPopust;
        private DataGridViewTextBoxColumn colKonacnaCena;
        private DataGridViewTextBoxColumn colRacunId;
        private DataGridViewTextBoxColumn colDatumIzdavanja;
        private DataGridViewTextBoxColumn colRokPlacanja;
        private DataGridViewTextBoxColumn colPdv;
        private DataGridViewTextBoxColumn colNacinPlacanja;
        private DataGridViewTextBoxColumn colStatusRacuna;
        private DataGridViewTextBoxColumn colBrRacuna;
    }
}
