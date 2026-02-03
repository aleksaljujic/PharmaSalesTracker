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
        private KupacController kupacController;
        public UCKupac()
        {
            InitializeComponent();

            string[] gradovi = { "Niš", "Beograd", "Novi Sad" };
            foreach (var grad in gradovi)
            {
                cbGrad.Items.Add(grad);
            }

            KupacController.Instance.GetKupce();
            FillTable();
        }

        public void FillTable()
        {
            List<Kupac> kupci = KupacController.Instance.Kupci;
            foreach (var kupac in kupci)
            {
                dgvKupci.Rows.Add(
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
                dgvKupci.Rows.Clear();
                KupacController.Instance.GetKupce();
                FillTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom dodavanja kupca: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
