using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.GUIControler;
using Client.GUIController;
using Client.UserControls;

namespace Client.Forms
{
    public partial class FrmMain : Form
    {
        FrmLogin frmLogin;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var apotekar = MainCoordinator.Instance.GetUlogovanApotekar();
            LoadUserControl(new UCDashboard());
        }

        private void LoadUserControl(UserControl userControl)
        {
            panelMain.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(userControl);
        }

        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Da li želite da se odjavite?",
                "Potvrda",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void kupciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCKupac());
        }

        private void početnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCDashboard());
        }

        private void računiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCPrikazRacuna());
        }

        private void kreirajRačunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCKreirajRacun());
        }
    }
}
