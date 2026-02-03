using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Common.Communication;
using Common.Domain;

namespace Client.GUIController
{
    public class SmeneController
    {
        private Apotekar apotekar;
        public List<ApotekarSmena> smene;
        public bool prijavljen;

        private static SmeneController instance;

        public static SmeneController Instance
        {
            get
            {
                if (instance == null)
                    instance = new SmeneController();
                return instance;
            }
        }

        public SmeneController()
        {
            this.apotekar = MainCoordinator.Instance.GetUlogovanApotekar();
            prijavljen = false;
        }

        public void GetApotekarSmenaList()
        {
            Response response = Communication.Instance.ApotekarSmena(apotekar.IdApotekar);
            if (response.IsSuccess)
            {
                List<ApotekarSmena> apotekarSmena = Communication.Instance.ReadType<List<ApotekarSmena>>(response.Result);
                this.smene = apotekarSmena;
            }
            else
            {
                MessageBox.Show(response.ExceptionMessage, "Greška");
            }  
        }

        public void PrijaviSmenu()
        {
            Response response = Communication.Instance.PrijaviSmenu(apotekar.IdApotekar);
            if (prijavljen)
            {
                MessageBox.Show("Već ste prijavili smenu!", "Greška");
                return;
            }
            if (response.IsSuccess)
            {
                MessageBox.Show("Uspešno ste prijavili smenu!", "Uspeh");
                prijavljen = true;
            }
            else
            {
                MessageBox.Show(response.ExceptionMessage, "Greška");
            }
        }


    }
}
