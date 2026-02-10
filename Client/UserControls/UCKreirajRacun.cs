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
    public partial class UCKreirajRacun : UserControl
    {
        public UCKreirajRacun()
        {
            InitializeComponent();
            FillComboBox();
        }

        public void FillComboBox()
        {
            // APOTEKARI
            ApotekarController.Instance.GetApotekare();
            cbApotekari.DataSource = ApotekarController.Instance.Apotekari;
            cbApotekari.DisplayMember = "Ime";  // ili bilo koje postojeće polje
            cbApotekari.ValueMember = "IdApotekar";

            // KUPCI
            KupacController.Instance.GetKupce();
            cbKupci.DataSource = KupacController.Instance.Kupci;
            cbKupci.DisplayMember = "Ime";
            cbKupci.ValueMember = "IdKupac";

            // LEKOVI
            LekController.Instance.GetLekove();
            cbLekovi.DataSource = LekController.Instance.Lekovi;
            cbLekovi.DisplayMember = "NazivINN";  // ili šta god imaš u Lek klasi
            cbLekovi.ValueMember = "IdLek";

            // Ostalo ostaje isto
            string[] nacinPlacanja = ["Gotovina", "Kartica", "Virman"];
            string[] statusPlacanja = ["Placen", "Neplacen", "Storniran"];
            string[] popust = ["0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50"];
            string[] kolicina = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10"];

            cbNacinPlacanja.Items.AddRange(nacinPlacanja);
            cbStatusRacuna.Items.AddRange(statusPlacanja);
            cbPopust.Items.AddRange(popust);
            cbKolicina.Items.AddRange(kolicina);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnKreirajRacun_Click(object sender, EventArgs e)
        {
            Racun novRacun = new Racun
            {
                IdApotekar = cbApotekari.SelectedIndex + 1,
                IdKupac = cbKupci.SelectedIndex + 1,
                DatumIzdavanja = DateTime.Now,
                RokPlacanja = dtpRokPlacanja.Value,
                NacinPlacanja = cbNacinPlacanja.SelectedItem?.ToString(),
                StatusRacuna = cbStatusRacuna.SelectedItem?.ToString(),
            };

            RacunController.Instance.KreirajRacun(novRacun);
            RacunController.Instance.GetRacune();
            Racun racun = RacunController.Instance.Racuni.LastOrDefault();
            dgvRacun.Rows.Add(racun.IdRacun, racun.DatumIzdavanja, racun.RokPlacanja, racun.Pdv, racun.NacinPlacanja, racun.StatusRacuna, racun.BrojRacuna);
        }

        private void FillTableStavkeRacuna()
        {
            Racun racun = RacunController.Instance.Racuni.LastOrDefault();
            StavkaRacunaController.Instance.GetStavkeRacuna(racun.IdRacun);

            List<StavkaRacuna> stavkeRacuna = StavkaRacunaController.Instance.StavkeRacuna;
            dgvStavkeRacuna.Rows.Clear();
            foreach (var s in stavkeRacuna)
            {
                dgvStavkeRacuna.Rows.Add(s.Rb, s.LekDisplayValue, s.Kolicina, s.Iznos, s.PopustProcenat, s.KonacnaCena);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            RacunController.Instance.GetRacune();
            Racun racun = RacunController.Instance.Racuni.LastOrDefault();

            if (racun == null)
            {
                MessageBox.Show("Nema kreiranog računa! Prvo kreirajte račun.");
                return;
            }

            // Proveri da li je lek izabran
            if (cbLekovi.SelectedValue == null)
            {
                MessageBox.Show("Izaberite lek!");
                return;
            }

            // Kastuj SelectedItem da dobiješ celu
            Lek odabraniLek = (Lek)cbLekovi.SelectedItem;

            StavkaRacuna novaStavka = new StavkaRacuna
            {
                IdRacun = racun.IdRacun,
                IdLek = odabraniLek.IdLek,
                CenaLeka = odabraniLek.Cena,  // ⚠️ OVO TI NEDOSTAJE!
                Kolicina = int.Parse(cbKolicina.Text),  // ⚠️ Ispravio cbPopust -> cbKolicina
                PopustProcenat = float.Parse(cbPopust.Text)
            };

            StavkaRacunaController.Instance.KreirajStavkuRacuna(novaStavka);
            FillTableStavkeRacuna();
        }

        private void cbLekovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lek trenutniLek = LekController.Instance.Lekovi[cbLekovi.SelectedIndex];
            tbCenaLeka.Text = (trenutniLek.Cena).ToString();
        }
    }
}
