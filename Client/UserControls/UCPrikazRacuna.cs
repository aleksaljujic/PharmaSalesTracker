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
    public partial class UCPrikazRacuna : UserControl
    {
        public UCPrikazRacuna()
        {
            InitializeComponent();
            PopuniRacune();
        }

        private void dgvRacuni_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void PopuniRacune()
        {
            RacunController.Instance.GetRacune();
            List<Racun> racuni = RacunController.Instance.Racuni;

            foreach (var r in racuni)
            {
                dgvRacuni.Rows.Add(r.IdRacun, r.DisplayValue);
            }
        }

        private void dgvRacuni_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRacuni.SelectedRows.Count == 0)
            {
                return;
            }
            int idRacun = (int)dgvRacuni.SelectedRows[0].Cells[0].Value;
            StavkaRacunaController.Instance.GetStavkeRacuna(idRacun);
            List<StavkaRacuna> stavkeRacuna = StavkaRacunaController.Instance.StavkeRacuna;

            RacunController.Instance.GetRacunById(idRacun);
            Racun racun = RacunController.Instance.TrenutniRacun;

            FillRacun(racun);

            dgvStavkeRacuna.Rows.Clear();
            foreach (var s in stavkeRacuna)
            {
                dgvStavkeRacuna.Rows.Add(s.Rb, s.LekDisplayValue, s.Kolicina, s.Iznos, s.PopustProcenat, s.KonacnaCena);
            }
        }

        private void dgvStavkeRacuna_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStavkeRacuna.SelectedRows.Count == 0)
            {
                return;
            }
            int idStavkaRacuna = (int)dgvStavkeRacuna.SelectedRows[0].Cells[0].Value;
            int idRacun = RacunController.Instance.TrenutniRacun.IdRacun;
            LekController.Instance.GetLekID(idRacun, idStavkaRacuna);
            int idLek = LekController.Instance.TrenutniLekID;

            LekController.Instance.GetLek(idLek);
            Lek lek = LekController.Instance.TrenutniLek;

            FillLek(lek);
        }

        private void FillLek(Lek lek)
        {
            tbNazivLeka.Clear();
            tbProizvodjacLeka.Clear();
            tbJacinaLeka.Clear();
            tbRezimIzdavanja.Clear();
            tbIndikacija.Clear();
            tbCena.Clear();
            tbStatusLeka.Clear();
            tbStanjeUMag.Clear();
            tbSifraLeka.Clear();
            tbMinStanje.Clear();
            tbDatumIsteka.Clear();
            tbKolPoPak.Clear();
            tbPakovanje.Clear();

            tbNazivLeka.Text = lek.NazivINN;
            tbProizvodjacLeka.Text = lek.Proizvodjac;
            tbJacinaLeka.Text = lek.Jacina;
            tbRezimIzdavanja.Text = lek.RezimIzdavanja;
            tbIndikacija.Text = lek.Indikacija;
            tbCena.Text = lek.Cena.ToString("F2") + " RSD";
            tbStatusLeka.Text = lek.AktivanLek ? "Aktivan" : "Neaktivan";
            tbStanjeUMag.Text = lek.StanjeMagacin.ToString();
            tbSifraLeka.Text = lek.SifraLeka;
            tbMinStanje.Text = lek.MinimalnoStanje.HasValue ? lek.MinimalnoStanje.Value.ToString() : "N/A";
            tbDatumIsteka.Text = lek.DatumIsteka.HasValue ? lek.DatumIsteka.Value.ToString("dd.MM.yyyy") : "N/A";
            tbKolPoPak.Text = lek.KolPoPakovanju.ToString();
            tbPakovanje.Text = lek.Pakovanje;

        }

        public void FillRacun(Racun racun)
        {
            tbBrojRacuna.Clear();
            tbDatumIzdavanja.Clear();
            tbIzdao.Clear();
            tbPrimio.Clear();
            tbRokPlacanja.Clear();
            tbStatusRacuna.Clear();
            tbUkupno.Clear();
            tbPdv.Clear();
            tbNacinPlacanja.Clear();

            tbBrojRacuna.Text = racun.IdRacun.ToString();
            tbDatumIzdavanja.Text = racun.DatumIzdavanja.ToString("dd.MM.yyyy");
            tbIzdao.Text = racun.ApotekarIme.ToString() + " " + racun.ApotekarPrezime.ToString();
            tbPrimio.Text = racun.KupacIme.ToString() + " " + racun.KupacPrezime.ToString();
            tbRokPlacanja.Text = racun.RokPlacanja.HasValue ? racun.RokPlacanja.Value.ToString("dd.MM.yyyy") : "N/A";
            tbStatusRacuna.Text = racun.StatusRacuna;
            tbUkupno.Text = racun.UkupanIznos.ToString("F2") + " RSD";
            tbPdv.Text = racun.Pdv + " %";
            tbNacinPlacanja.Text = racun.NacinPlacanja;

        }
    }
}
