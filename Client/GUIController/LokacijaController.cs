using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Communication;
using Common.Domain;

namespace Client.GUIController
{
    public class LokacijaController
    {
        public List<Lokacija> Gradovi;
        private static LokacijaController instance;
        public static LokacijaController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LokacijaController();
                }
                return instance;
            }
        }
        public LokacijaController()
        {
            Gradovi = new List<Lokacija>();
        }

        public void GetGradove()
        {
            Response response = Communication.Instance.PrikaziGradove();

            if (response.IsSuccess)
            {
                List<Lokacija> gradovi = Communication.Instance.ReadType<List<Lokacija>>(response.Result);
                this.Gradovi = gradovi;
            }
            else
            {
                throw new Exception(response.ExceptionMessage);
            }
        }
    }
}
