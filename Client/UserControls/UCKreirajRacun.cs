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
            cbApotekari.Items.Clear();

            ApotekarController.Instance.GetApotekare();
            List<Apotekar> apotekari = ApotekarController.Instance.Apotekari;

            foreach (var a in apotekari)
            {
                cbApotekari.Items.Add($"{a.Ime} {a.Prezime}");
            }

            cbKupci.Items.Clear();

            KupacController.Instance.GetKupce();
            List<Kupac> kupci = KupacController.Instance.Kupci;

            foreach (var k in kupci)
            {
                cbKupci.Items.Add($"{k.Ime} {k.Prezime}");
            }

            LekController.Instance.GetLekove();
            List<Lek> lekovi = LekController.Instance.Lekovi;

            foreach (var l in lekovi)
            {
                cbLekovi.Items.Add($"{l.NazivINN} , {l.Proizvodjac}");
            }
        }
    }
}
