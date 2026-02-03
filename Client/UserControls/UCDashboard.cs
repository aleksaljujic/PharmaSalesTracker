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
    public partial class UCDashboard : UserControl
    {
        private Apotekar apotekar;
        public UCDashboard()
        {
            InitializeComponent();
            this.apotekar = MainCoordinator.Instance.GetUlogovanApotekar();
            lblDobrodosli.Text = $"Dobrodošli, {apotekar.Ime} {apotekar.Prezime}!";

            SmeneController.Instance.GetApotekarSmenaList();
            FillTable();
        }

        private void FillTable()
        {
            List<ApotekarSmena> smene = SmeneController.Instance.smene;

            foreach (var smena in smene)
            {
                string smenaInfo = $"{smena.NazivSmene} ({smena.PocetakSmene} - {smena.KrajSmene})";
                dgvSmena.Rows.Add(
                    smena.Datum,
                    smenaInfo);
            }
        }

        private void lblDobrodosli_Click(object sender, EventArgs e)
        {

        }

        private void btnPrijaviSmenu_Click(object sender, EventArgs e)
        {
            SmeneController.Instance.PrijaviSmenu();
            SmeneController.Instance.GetApotekarSmenaList();
            dgvSmena.Rows.Clear();
            FillTable();
        }

        //private void UCDashboard_Load(object sender, EventArgs e)
        //{
        //    // Učitaj podatke za Dashboard
        //    lblDobrodosli.Text = $"Dobrodošli, {MainCoordinator.Instance.GetUlogovanApotekar().Ime}!";
        //}
    }
}
