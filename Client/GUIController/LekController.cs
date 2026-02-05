using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Communication;
using Common.Domain;

namespace Client.GUIController
{
    internal class LekController
    {
        public List<Lek> Lekovi;
        private static LekController instance;
        public int TrenutniLekID { get; set; }
        public Lek TrenutniLek { get; set; }
        public static LekController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LekController();
                }
                return instance;
            }
        }
        public LekController()
        {
            this.Lekovi = new List<Lek>();
        }

        public void GetLekove()
        {
            Response response = Communication.Instance.PrikaziLekove();
            if (response.IsSuccess)
            {
                List<Lek> lekovi = Communication.Instance.ReadType<List<Lek>>(response.Result);
                this.Lekovi = lekovi;
            }
            else
            {
                throw new Exception(response.ExceptionMessage);
            }
        }

        public void GetLek(int idLek)
        {
            Response response = Communication.Instance.PrikaziLek(idLek);

            if (response.IsSuccess)
            {
                Lek lek = Communication.Instance.ReadType<Lek>(response.Result);
                this.TrenutniLek = lek;
            }
            else
            {
                throw new Exception(response.ExceptionMessage);
            }
        }

        public void GetLekID(int idRacun, int idStavkaRacuna)
        {
            Response response = Communication.Instance.VratiLekId(idRacun, idStavkaRacuna);
            if (response.IsSuccess)
            {
                int id = Communication.Instance.ReadValue<int>(response.Result);
                this.TrenutniLekID = id;
            }
            else
            {
                throw new Exception(response.ExceptionMessage);
            }
        }
    }
}
