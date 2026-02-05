using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Communication;
using Common.Domain;

namespace Client.GUIController
{
    internal class ApotekarController
    {
        public List<Apotekar> Apotekari;

        private static ApotekarController instance;

        public static ApotekarController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApotekarController();
                }
                return instance;
            }
        }
        public ApotekarController()
        {
            this.Apotekari = new List<Apotekar>();
        }

        public void GetApotekare()
        {
            Response response = Communication.Instance.PrikaziApotekare();
            if (response.IsSuccess)
            {
                List<Apotekar> apotekari = Communication.Instance.ReadType<List<Apotekar>>(response.Result);
                this.Apotekari = apotekari;
            }
            else
            {
                throw new Exception(response.ExceptionMessage);
            }
        }
    }
}
