using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.GUIController;
using Common.Domain;

namespace Client.UserControls
{
    public partial class UCKupac : UserControl
    {
        public UCKupac()
        {
            InitializeComponent();
            //dgvKupci.SelectionChanged += dgvKupci_SelectionChanged;

            FillComboBox();

            OsveziTabelu();
        }

       public void FillComboBox()
        {
            LokacijaController.Instance.GetGradove();
            List<Lokacija> gradovi = LokacijaController.Instance.Gradovi;
            foreach (Lokacija grad in gradovi)
            {
                cbGrad.Items.Add(grad.Naziv);
                cbPrikaziGrad.Items.Add(grad.Naziv);
            }
        }

        public void FillTable()
        {
            List<Kupac> kupci = KupacController.Instance.Kupci;
            foreach (var kupac in kupci)
            {
                dgvKupci.Rows.Add(
                    kupac.IdKupac,
                    kupac.Ime,
                    kupac.Prezime,
                    kupac.BrojTelefona,
                    kupac.Email,
                    kupac.Adresa,
                    kupac.NazivLokacije);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDodajKupca_Click(object sender, EventArgs e)
        {
            int gradIndex = cbGrad.SelectedIndex + 1;


            try
            {
                Kupac noviKupac = new Kupac
                {
                    Ime = tbIme.Text,
                    Prezime = tbPrezime.Text,
                    BrojTelefona = tbBrojTel.Text,
                    Email = tbEmail.Text,
                    Adresa = tbAdresa.Text,
                    IdLokacija = gradIndex
                };

                KupacController.Instance.DodajKupca(noviKupac);
                MessageBox.Show("Uspešno dodat kupac!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OsveziTabelu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom dodavanja kupca: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvKupci_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKupci.SelectedRows.Count == 1)
            {
                if (dgvKupci.SelectedRows.Count > 0 && dgvKupci.SelectedRows[0].Cells[0].Value != null)
                {
                    DataGridViewRow selectedRow = dgvKupci.SelectedRows[0];

                    tbPrikaziIme.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                    tbPrikaziPrezime.Text = selectedRow.Cells[2].Value?.ToString() ?? "";
                    tbPrikaziBrojTel.Text = selectedRow.Cells[3].Value?.ToString() ?? "";
                    tbPrikaziEmail.Text = selectedRow.Cells[4].Value?.ToString() ?? "";
                    tbPrikaziAdresa.Text = selectedRow.Cells[5].Value?.ToString() ?? "";

                    // Za ComboBox:
                    string grad = selectedRow.Cells[6].Value?.ToString();
                    if (grad != null) cbPrikaziGrad.SelectedItem = grad;
                }
            }
        }

        private void btnUkloniKupca_Click(object sender, EventArgs e)
        {
            KupacController.Instance.UkloniKupca(Convert.ToInt32(dgvKupci.SelectedRows[0].Cells[0].Value));
            MessageBox.Show("Uspešno uklonjen kupac!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OsveziTabelu();

        }

        private void btnIzmeniKupca_Click(object sender, EventArgs e)
        {
            Kupac izmenjenKupac = new Kupac
            {
                IdKupac = Convert.ToInt32(dgvKupci.SelectedRows[0].Cells[0].Value),
                Ime = tbPrikaziIme.Text,
                Prezime = tbPrikaziPrezime.Text,
                BrojTelefona = tbPrikaziBrojTel.Text,
                Email = tbPrikaziEmail.Text,
                Adresa = tbPrikaziAdresa.Text,
                IdLokacija = cbPrikaziGrad.SelectedIndex + 1
            };

            KupacController.Instance.IzmeniKupca(izmenjenKupac);
            MessageBox.Show("Uspešno izmenjen kupac!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OsveziTabelu();
        }

        public void OsveziTabelu()
        {
            dgvKupci.Rows.Clear();
            KupacController.Instance.GetKupce();
            FillTable();
        }
    }
}
