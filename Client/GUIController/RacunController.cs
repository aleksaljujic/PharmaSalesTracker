using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Communication;
using Common.Domain;

namespace Client.GUIController
{
    public class RacunController
    {
        public List<Racun> Racuni;
        private static RacunController instance;
        public Racun TrenutniRacun;

        public static RacunController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RacunController();
                }
                return instance;
            }
        }
        public RacunController()
        {
            Racuni = new List<Racun>();
        }

        public void GetRacune()
        {
            Response response = Communication.Instance.PrikaziRacune();

            if (response.IsSuccess)
            {
                List<Racun> racuni = Communication.Instance.ReadType<List<Racun>>(response.Result);
                this.Racuni = racuni;
            }
            else
            {
                throw new Exception(response.ExceptionMessage);
            }
        }

        public void GetRacunById(int idRacun)
        {
            Response response = Communication.Instance.PrikaziRacun(idRacun);
            if (response.IsSuccess)
            {
                Racun racun = Communication.Instance.ReadType<Racun>(response.Result);
                this.TrenutniRacun = racun;
            }
            else
            {
                throw new Exception(response.ExceptionMessage);
            }
        }
    }
}
