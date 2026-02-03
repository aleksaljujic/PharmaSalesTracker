using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Client.GUIController;
using Common.Communication;
using Common.Domain;

namespace Client.GUIControler
{
    public class LoginController
    {
        private static LoginController instance;
        private FrmLogin frmLogin;

        public static LoginController Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoginController();
                return instance;
            }
        }

        internal void ShowFrmLogin()
        {
            try
            {
                Thread.Sleep(2000);

                
                frmLogin = new FrmLogin();
                Application.Run(frmLogin);
            }
            catch (SocketException)
            {
                MessageBox.Show("Nije moguće povezivanje sa serverom!");
            }
        }

        public void Login(object sender, EventArgs e)
        {
            try
            {               
                Communication.Instance.Connect();             
            }
            catch (SocketException)
            {
                MessageBox.Show("Nije moguće povezivanje sa serverom!");
                return;
            }

            // 1. Validacija
            if (!frmLogin.Validacija())
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }

            // 2. Uzmi podatke
            string username = frmLogin.GetUsername();
            string password = frmLogin.GetPassword();

            // 3. Kreiraj Apotekar objekat
            Apotekar apotekar = new Apotekar
            {
                KorisnickoIme = username,
                Sifra = password
            };

            // 4. Pošalji zahtev serveru
            Response response = Communication.Instance.Login(apotekar);

            // 5. Obrada odgovora
            if (response.IsSuccess)
            {
                // Deserijalizuj ulogovanog apotekara
                Apotekar ulogovan = Communication.Instance.ReadType<Apotekar>(response.Result);

                // Sakrij login formu
                frmLogin.Visible = false;
                MainCoordinator.Instance.setUlogovanApotekar(ulogovan);
                // Pređi na glavnu formu
                MainCoordinator.Instance.ShowFrmMain(ulogovan);
                MainCoordinator.Instance.CloseLoginForm();
            }
            else
            {
                MessageBox.Show(response.ExceptionMessage, "Greška");
            }
        }

        public void Logout()
        {
            Communication.Instance.Disconnect();
        }

    }
}
