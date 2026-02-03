using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Forms;
using Common.Domain;

namespace Client.GUIController
{
    internal class MainCoordinator
    {
        // Singleton
        private static MainCoordinator instance;
        private Apotekar ulogovanApotekar;
        private FrmMain frmMain;
        private FrmLogin frmLogin;
        public static MainCoordinator Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainCoordinator();
                return instance;
            }
        }

        //private MainCoordinator()
        //{
        //    // Kreiraj sve kontrolere
        //    kupacGuiController = new KupacController();
        //    lekGuiController = new LekController();
        //    // ...
        //}


        // ✅ Glavna forma
        //private FrmMain frmMain;

        // ✅ Kontroleri za sve operacije
        //private KupacGuiController kupacGuiController;
        //private LekGuiController lekGuiController;
        // ...

        // ✅ Prikazuje glavnu formu
        //internal void ShowFrmMain(Apotekar apotekar)
        //{
        //    this.ulogovanApotekar = apotekar;

        //    frmMain = new FrmMain();
        //    frmMain.Text = $"Apoteka - {apotekar.Ime} {apotekar.Prezime}";
        //    frmMain.ShowDialog();
        //}

        // ✅ Navigacija - prikazuje formu za kupce
        public void ShowUCKupac()
        {
            // Ovde bi učitao User Control ili otvorio formu
            // frmMain.LoadUserControl(new UCKupac());
        }

        // ✅ Getter za ulogovanog korisnika
        public Apotekar GetUlogovanApotekar()
        {
            return ulogovanApotekar;
        }

        public void setUlogovanApotekar(Apotekar apotekar)
        {
            ulogovanApotekar = apotekar;
        }

        internal void ShowFrmMain(Apotekar ulogovanApotekar)
        {
            this.ulogovanApotekar = ulogovanApotekar;

            frmMain = new FrmMain();
            frmMain.Text = $"Apoteka - {ulogovanApotekar.Ime} {ulogovanApotekar.Prezime}";
            frmMain.ShowDialog();
        }
        internal void ShowFrmLogin()
        {
            frmLogin = new FrmLogin();
            frmLogin.Show();
        }
        internal void CloseMainForm()
        {
            frmMain.Close();
        }
        internal void CloseLoginForm()
        {
            frmLogin.Close();
        }
    }
}
