namespace Client.UserControls
{
    partial class UCPrikazRacuna
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
            dgvRacuni = new DataGridView();
            colIdRacun = new DataGridViewTextBoxColumn();
            colOpis = new DataGridViewTextBoxColumn();
            dgvStavkeRacuna = new DataGridView();
            colRb = new DataGridViewTextBoxColumn();
            colLek = new DataGridViewTextBoxColumn();
            colKolicina = new DataGridViewTextBoxColumn();
            colIznos = new DataGridViewTextBoxColumn();
            colPopust = new DataGridViewTextBoxColumn();
            colKonacnaCena = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            label10 = new Label();
            tbStatusRacuna = new TextBox();
            label9 = new Label();
            tbNacinPlacanja = new TextBox();
            label8 = new Label();
            tbPdv = new TextBox();
            tbDatumIzdavanja = new TextBox();
            label6 = new Label();
            tbRokPlacanja = new TextBox();
            label7 = new Label();
            tbIzdao = new TextBox();
            label4 = new Label();
            tbPrimio = new TextBox();
            label3 = new Label();
            tbUkupno = new TextBox();
            label5 = new Label();
            label11 = new Label();
            tbBrojRacuna = new TextBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            tbPakovanje = new TextBox();
            lbl10 = new Label();
            tbKolPoPak = new TextBox();
            lbl9 = new Label();
            tbDatumIsteka = new TextBox();
            lbl3 = new Label();
            tbMinStanje = new TextBox();
            lbl8 = new Label();
            tbSifraLeka = new TextBox();
            lbl7 = new Label();
            tbStanjeUMag = new TextBox();
            lbl6 = new Label();
            tbStatusLeka = new TextBox();
            lbl4 = new Label();
            tbCena = new TextBox();
            lbl5 = new Label();
            tbIndikacija = new TextBox();
            lbl1 = new Label();
            tbRezimIzdavanja = new TextBox();
            lbl2 = new Label();
            tbJacinaLeka = new TextBox();
            label14 = new Label();
            tbProizvodjacLeka = new TextBox();
            label13 = new Label();
            tbNazivLeka = new TextBox();
            label12 = new Label();
            btnKreirajRacun = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRacuni).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStavkeRacuna).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRacuni
            // 
            dgvRacuni.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRacuni.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRacuni.Columns.AddRange(new DataGridViewColumn[] { colIdRacun, colOpis });
            dgvRacuni.Location = new Point(49, 96);
            dgvRacuni.Name = "dgvRacuni";
            dgvRacuni.Size = new Size(397, 568);
            dgvRacuni.TabIndex = 0;
            dgvRacuni.CellContentClick += dgvRacuni_CellContentClick;
            dgvRacuni.SelectionChanged += dgvRacuni_SelectionChanged;
            // 
            // colIdRacun
            // 
            colIdRacun.FillWeight = 10F;
            colIdRacun.HeaderText = "Id";
            colIdRacun.Name = "colIdRacun";
            colIdRacun.ReadOnly = true;
            // 
            // colOpis
            // 
            colOpis.HeaderText = "Opis";
            colOpis.Name = "colOpis";
            colOpis.ReadOnly = true;
            // 
            // dgvStavkeRacuna
            // 
            dgvStavkeRacuna.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStavkeRacuna.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavkeRacuna.Columns.AddRange(new DataGridViewColumn[] { colRb, colLek, colKolicina, colIznos, colPopust, colKonacnaCena });
            dgvStavkeRacuna.Location = new Point(28, 263);
            dgvStavkeRacuna.Name = "dgvStavkeRacuna";
            dgvStavkeRacuna.Size = new Size(814, 305);
            dgvStavkeRacuna.TabIndex = 1;
            dgvStavkeRacuna.SelectionChanged += dgvStavkeRacuna_SelectionChanged;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(49, 72);
            label1.Name = "label1";
            label1.Size = new Size(64, 21);
            label1.TabIndex = 2;
            label1.Text = "Računi :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(28, 241);
            label2.Name = "label2";
            label2.Size = new Size(101, 19);
            label2.TabIndex = 3;
            label2.Text = "Stavke računa :";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(tbStatusRacuna);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(tbNacinPlacanja);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(tbPdv);
            groupBox1.Controls.Add(tbDatumIzdavanja);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(tbRokPlacanja);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(tbIzdao);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbPrimio);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(28, 48);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(805, 190);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Opis računa";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(494, 151);
            label10.Name = "label10";
            label10.Size = new Size(78, 15);
            label10.TabIndex = 13;
            label10.Text = "Status računa";
            // 
            // tbStatusRacuna
            // 
            tbStatusRacuna.Location = new Point(595, 148);
            tbStatusRacuna.Name = "tbStatusRacuna";
            tbStatusRacuna.Size = new Size(180, 23);
            tbStatusRacuna.TabIndex = 12;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(28, 151);
            label9.Name = "label9";
            label9.Size = new Size(85, 15);
            label9.TabIndex = 11;
            label9.Text = "Način plaćanja";
            // 
            // tbNacinPlacanja
            // 
            tbNacinPlacanja.Location = new Point(115, 148);
            tbNacinPlacanja.Name = "tbNacinPlacanja";
            tbNacinPlacanja.Size = new Size(180, 23);
            tbNacinPlacanja.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(28, 113);
            label8.Name = "label8";
            label8.Size = new Size(27, 15);
            label8.TabIndex = 9;
            label8.Text = "Pdv";
            // 
            // tbPdv
            // 
            tbPdv.Location = new Point(115, 110);
            tbPdv.Name = "tbPdv";
            tbPdv.Size = new Size(180, 23);
            tbPdv.TabIndex = 8;
            // 
            // tbDatumIzdavanja
            // 
            tbDatumIzdavanja.Location = new Point(595, 32);
            tbDatumIzdavanja.Name = "tbDatumIzdavanja";
            tbDatumIzdavanja.Size = new Size(180, 23);
            tbDatumIzdavanja.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(494, 70);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 6;
            label6.Text = "Rok plaćanja";
            // 
            // tbRokPlacanja
            // 
            tbRokPlacanja.Location = new Point(595, 70);
            tbRokPlacanja.Name = "tbRokPlacanja";
            tbRokPlacanja.Size = new Size(180, 23);
            tbRokPlacanja.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(494, 35);
            label7.Name = "label7";
            label7.Size = new Size(95, 15);
            label7.TabIndex = 4;
            label7.Text = "Datum izdavanja";
            // 
            // tbIzdao
            // 
            tbIzdao.Location = new Point(115, 32);
            tbIzdao.Name = "tbIzdao";
            tbIzdao.Size = new Size(180, 23);
            tbIzdao.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 73);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 2;
            label4.Text = "Račun primio ";
            // 
            // tbPrimio
            // 
            tbPrimio.Location = new Point(115, 70);
            tbPrimio.Name = "tbPrimio";
            tbPrimio.Size = new Size(180, 23);
            tbPrimio.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 35);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 0;
            label3.Text = "Račun izdao ";
            // 
            // tbUkupno
            // 
            tbUkupno.Location = new Point(710, 585);
            tbUkupno.Name = "tbUkupno";
            tbUkupno.Size = new Size(132, 23);
            tbUkupno.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(649, 588);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 6;
            label5.Text = "Ukupno :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(242, 19);
            label11.Name = "label11";
            label11.Size = new Size(89, 21);
            label11.TabIndex = 15;
            label11.Text = "Broj računa";
            // 
            // tbBrojRacuna
            // 
            tbBrojRacuna.Location = new Point(337, 19);
            tbBrojRacuna.Name = "tbBrojRacuna";
            tbBrojRacuna.Size = new Size(180, 23);
            tbBrojRacuna.TabIndex = 14;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(tbUkupno);
            groupBox2.Controls.Add(groupBox1);
            groupBox2.Controls.Add(tbBrojRacuna);
            groupBox2.Controls.Add(dgvStavkeRacuna);
            groupBox2.Location = new Point(490, 96);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(866, 629);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Račun";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(tbPakovanje);
            groupBox3.Controls.Add(lbl10);
            groupBox3.Controls.Add(tbKolPoPak);
            groupBox3.Controls.Add(lbl9);
            groupBox3.Controls.Add(tbDatumIsteka);
            groupBox3.Controls.Add(lbl3);
            groupBox3.Controls.Add(tbMinStanje);
            groupBox3.Controls.Add(lbl8);
            groupBox3.Controls.Add(tbSifraLeka);
            groupBox3.Controls.Add(lbl7);
            groupBox3.Controls.Add(tbStanjeUMag);
            groupBox3.Controls.Add(lbl6);
            groupBox3.Controls.Add(tbStatusLeka);
            groupBox3.Controls.Add(lbl4);
            groupBox3.Controls.Add(tbCena);
            groupBox3.Controls.Add(lbl5);
            groupBox3.Controls.Add(tbIndikacija);
            groupBox3.Controls.Add(lbl1);
            groupBox3.Controls.Add(tbRezimIzdavanja);
            groupBox3.Controls.Add(lbl2);
            groupBox3.Controls.Add(tbJacinaLeka);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(tbProizvodjacLeka);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(tbNazivLeka);
            groupBox3.Controls.Add(label12);
            groupBox3.Location = new Point(1377, 96);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(352, 629);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Informacije o leku :";
            // 
            // tbPakovanje
            // 
            tbPakovanje.Location = new Point(147, 517);
            tbPakovanje.Name = "tbPakovanje";
            tbPakovanje.Size = new Size(180, 23);
            tbPakovanje.TabIndex = 39;
            // 
            // lbl10
            // 
            lbl10.AutoSize = true;
            lbl10.Location = new Point(18, 520);
            lbl10.Name = "lbl10";
            lbl10.Size = new Size(61, 15);
            lbl10.TabIndex = 38;
            lbl10.Text = "Pakovanje";
            // 
            // tbKolPoPak
            // 
            tbKolPoPak.Location = new Point(147, 477);
            tbKolPoPak.Name = "tbKolPoPak";
            tbKolPoPak.Size = new Size(180, 23);
            tbKolPoPak.TabIndex = 37;
            // 
            // lbl9
            // 
            lbl9.AutoSize = true;
            lbl9.Location = new Point(18, 480);
            lbl9.Name = "lbl9";
            lbl9.Size = new Size(124, 15);
            lbl9.TabIndex = 36;
            lbl9.Text = "Količina po pakovanju";
            // 
            // tbDatumIsteka
            // 
            tbDatumIsteka.Location = new Point(147, 439);
            tbDatumIsteka.Name = "tbDatumIsteka";
            tbDatumIsteka.Size = new Size(180, 23);
            tbDatumIsteka.TabIndex = 35;
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Location = new Point(20, 244);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(37, 15);
            lbl3.TabIndex = 34;
            lbl3.Text = "Cena ";
            // 
            // tbMinStanje
            // 
            tbMinStanje.Location = new Point(147, 399);
            tbMinStanje.Name = "tbMinStanje";
            tbMinStanje.Size = new Size(180, 23);
            tbMinStanje.TabIndex = 33;
            // 
            // lbl8
            // 
            lbl8.AutoSize = true;
            lbl8.Location = new Point(18, 442);
            lbl8.Name = "lbl8";
            lbl8.Size = new Size(79, 15);
            lbl8.TabIndex = 32;
            lbl8.Text = "Datum isteka ";
            // 
            // tbSifraLeka
            // 
            tbSifraLeka.Location = new Point(147, 359);
            tbSifraLeka.Name = "tbSifraLeka";
            tbSifraLeka.Size = new Size(180, 23);
            tbSifraLeka.TabIndex = 31;
            // 
            // lbl7
            // 
            lbl7.AutoSize = true;
            lbl7.Location = new Point(18, 402);
            lbl7.Name = "lbl7";
            lbl7.Size = new Size(99, 15);
            lbl7.TabIndex = 30;
            lbl7.Text = "Minimalno stanje";
            // 
            // tbStanjeUMag
            // 
            tbStanjeUMag.Location = new Point(147, 321);
            tbStanjeUMag.Name = "tbStanjeUMag";
            tbStanjeUMag.Size = new Size(180, 23);
            tbStanjeUMag.TabIndex = 29;
            // 
            // lbl6
            // 
            lbl6.AutoSize = true;
            lbl6.Location = new Point(18, 364);
            lbl6.Name = "lbl6";
            lbl6.Size = new Size(54, 15);
            lbl6.TabIndex = 28;
            lbl6.Text = "Šifra leka";
            // 
            // tbStatusLeka
            // 
            tbStatusLeka.Location = new Point(147, 281);
            tbStatusLeka.Name = "tbStatusLeka";
            tbStatusLeka.Size = new Size(180, 23);
            tbStatusLeka.TabIndex = 27;
            // 
            // lbl4
            // 
            lbl4.AutoSize = true;
            lbl4.Location = new Point(18, 284);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(63, 15);
            lbl4.TabIndex = 26;
            lbl4.Text = "Status leka";
            // 
            // tbCena
            // 
            tbCena.Location = new Point(147, 241);
            tbCena.Name = "tbCena";
            tbCena.Size = new Size(180, 23);
            tbCena.TabIndex = 25;
            // 
            // lbl5
            // 
            lbl5.AutoSize = true;
            lbl5.Location = new Point(18, 324);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(105, 15);
            lbl5.TabIndex = 24;
            lbl5.Text = "Stanje u magacinu";
            // 
            // tbIndikacija
            // 
            tbIndikacija.Location = new Point(147, 203);
            tbIndikacija.Name = "tbIndikacija";
            tbIndikacija.Size = new Size(180, 23);
            tbIndikacija.TabIndex = 23;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Location = new Point(18, 166);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(91, 15);
            lbl1.TabIndex = 22;
            lbl1.Text = "Režim izdavanja";
            // 
            // tbRezimIzdavanja
            // 
            tbRezimIzdavanja.Location = new Point(147, 163);
            tbRezimIzdavanja.Name = "tbRezimIzdavanja";
            tbRezimIzdavanja.Size = new Size(180, 23);
            tbRezimIzdavanja.TabIndex = 21;
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Location = new Point(18, 206);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(57, 15);
            lbl2.TabIndex = 20;
            lbl2.Text = "Indikacija";
            // 
            // tbJacinaLeka
            // 
            tbJacinaLeka.Location = new Point(147, 123);
            tbJacinaLeka.Name = "tbJacinaLeka";
            tbJacinaLeka.Size = new Size(180, 23);
            tbJacinaLeka.TabIndex = 19;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(18, 126);
            label14.Name = "label14";
            label14.Size = new Size(39, 15);
            label14.TabIndex = 18;
            label14.Text = "Jačina";
            // 
            // tbProizvodjacLeka
            // 
            tbProizvodjacLeka.Location = new Point(147, 85);
            tbProizvodjacLeka.Name = "tbProizvodjacLeka";
            tbProizvodjacLeka.Size = new Size(180, 23);
            tbProizvodjacLeka.TabIndex = 17;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(18, 88);
            label13.Name = "label13";
            label13.Size = new Size(65, 15);
            label13.TabIndex = 16;
            label13.Text = "Proizvođač";
            // 
            // tbNazivLeka
            // 
            tbNazivLeka.Location = new Point(147, 45);
            tbNazivLeka.Name = "tbNazivLeka";
            tbNazivLeka.Size = new Size(180, 23);
            tbNazivLeka.TabIndex = 15;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(18, 48);
            label12.Name = "label12";
            label12.Size = new Size(36, 15);
            label12.TabIndex = 14;
            label12.Text = "Naziv";
            // 
            // btnKreirajRacun
            // 
            btnKreirajRacun.Location = new Point(172, 684);
            btnKreirajRacun.Name = "btnKreirajRacun";
            btnKreirajRacun.Size = new Size(126, 34);
            btnKreirajRacun.TabIndex = 18;
            btnKreirajRacun.Text = "Kreiraj Račun";
            btnKreirajRacun.UseVisualStyleBackColor = true;
            // 
            // UCPrikazRacuna
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnKreirajRacun);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(label1);
            Controls.Add(dgvRacuni);
            Name = "UCPrikazRacuna";
            Size = new Size(1745, 863);
            ((System.ComponentModel.ISupportInitialize)dgvRacuni).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStavkeRacuna).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRacuni;
        private DataGridView dgvStavkeRacuna;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn colIdRacun;
        private DataGridViewTextBoxColumn colOpis;
        private DataGridViewTextBoxColumn colRb;
        private DataGridViewTextBoxColumn colLek;
        private DataGridViewTextBoxColumn colKolicina;
        private DataGridViewTextBoxColumn colIznos;
        private DataGridViewTextBoxColumn colPopust;
        private DataGridViewTextBoxColumn colKonacnaCena;
        private GroupBox groupBox1;
        private Label label3;
        private TextBox tbIzdao;
        private Label label4;
        private TextBox tbPrimio;
        private TextBox tbDatumIzdavanja;
        private Label label6;
        private TextBox tbRokPlacanja;
        private Label label7;
        private TextBox tbUkupno;
        private Label label5;
        private Label label8;
        private TextBox tbPdv;
        private Label label10;
        private TextBox tbStatusRacuna;
        private Label label9;
        private TextBox tbNacinPlacanja;
        private Label label11;
        private TextBox tbBrojRacuna;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox tbNazivLeka;
        private Label label12;
        private TextBox tbPakovanje;
        private Label lbl10;
        private TextBox tbKolPoPak;
        private Label lbl9;
        private TextBox tbDatumIsteka;
        private Label lbl3;
        private TextBox tbMinStanje;
        private Label lbl8;
        private TextBox tbSifraLeka;
        private Label lbl7;
        private TextBox tbStanjeUMag;
        private Label lbl6;
        private TextBox tbStatusLeka;
        private Label lbl4;
        private TextBox tbCena;
        private Label lbl5;
        private TextBox tbIndikacija;
        private Label lbl1;
        private TextBox tbRezimIzdavanja;
        private Label lbl2;
        private TextBox tbJacinaLeka;
        private Label label14;
        private TextBox tbProizvodjacLeka;
        private Label label13;
        private Button btnKreirajRacun;
    }
}
