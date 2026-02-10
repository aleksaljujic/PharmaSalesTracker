using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Communication;
using Common.Domain;

namespace Client.GUIController
{
    internal class StavkaRacunaController
    {
        public List<StavkaRacuna> StavkeRacuna;
        private static StavkaRacunaController instance;
        public static StavkaRacunaController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StavkaRacunaController();
                }
                return instance;
            }
        }
        public StavkaRacunaController()
        {
            StavkeRacuna = new List<StavkaRacuna>();
        }

        public void GetStavkeRacuna(int idRacun)
        {
            Response response = Communication.Instance.PrikaziStavkeRacuna(idRacun);
            if (response.IsSuccess)
            {
                List<StavkaRacuna> stavke = Communication.Instance.ReadType<List<StavkaRacuna>>(response.Result);
                this.StavkeRacuna = stavke;
            }
            else
            {
                throw new Exception(response.ExceptionMessage);
            }
        }

        public void KreirajStavkuRacuna(StavkaRacuna stavka)
        {
            Response response = Communication.Instance.KreirajStavkuRacuna(stavka);
            if (response.IsSuccess)
            {
                MessageBox.Show("Uspešno kreirana stavka računa!", "Uspeh");
            }
            else
            {
                MessageBox.Show(response.ExceptionMessage, "Greška");
            }
        }
    }
}
