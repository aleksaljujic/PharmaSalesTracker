using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Communication;
using Common.Domain;

namespace Client.GUIController
{
    internal class KupacController
    {
        public List<Kupac> Kupci;
        private static KupacController instance;
        public static KupacController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KupacController();
                }
                return instance;
            }
        }
        public KupacController()
        {
            this.Kupci = new List<Kupac>();
        }
        public void GetKupce()
        {
            Response response = Communication.Instance.PrikaziKupce();
            if (response.IsSuccess)
            {
                List<Kupac> kupci = Communication.Instance.ReadType<List<Kupac>>(response.Result);
                this.Kupci = kupci;
            }
            else
            {
                throw new Exception(response.ExceptionMessage);
            }
        }

        public void DodajKupca(Kupac kupac)
        {
            Response response = Communication.Instance.DodajKupca(kupac);
        }

        public void UkloniKupca(int idKupca)
        {
            Response response = Communication.Instance.UkloniKupca(idKupca);
        }

        public void IzmeniKupca(Kupac kupac)
        {
            Response response = Communication.Instance.IzmeniKupca(kupac);
        }
    }
}
