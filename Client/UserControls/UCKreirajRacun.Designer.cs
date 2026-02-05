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
            cbLekovi = new ComboBox();
            label3 = new Label();
            cbKupci = new ComboBox();
            label2 = new Label();
            cbApotekari = new ComboBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbLekovi);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbKupci);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cbApotekari);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(35, 39);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(206, 451);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kreiraj Racun";
            // 
            // cbLekovi
            // 
            cbLekovi.FormattingEnabled = true;
            cbLekovi.Location = new Point(16, 197);
            cbLekovi.Name = "cbLekovi";
            cbLekovi.Size = new Size(154, 23);
            cbLekovi.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 170);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 4;
            label3.Text = "Izaberi lek :";
            // 
            // cbKupci
            // 
            cbKupci.FormattingEnabled = true;
            cbKupci.Location = new Point(16, 124);
            cbKupci.Name = "cbKupci";
            cbKupci.Size = new Size(154, 23);
            cbKupci.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 97);
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
            // UCRacun
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "UCRacun";
            Size = new Size(922, 572);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cbKupci;
        private Label label2;
        private ComboBox cbApotekari;
        private Label label1;
        private ComboBox cbLekovi;
        private Label label3;
    }
}
