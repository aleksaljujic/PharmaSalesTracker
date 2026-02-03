using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Server.SystemOperation.Smena
{
    public class DodajSmenuSO : SystemOperationBase
    {
        private int idApotekar;

        public ApotekarSmena Result { get; private set; }

        public DodajSmenuSO(int idApotekar)
        {
            this.idApotekar = idApotekar;
        }
        protected override void ExecuteOperation()
        {
            DateTime danas = DateTime.Now;

            ApotekarSmena filter = new ApotekarSmena
            {
                FilterIdApotekar = idApotekar,
                FilterDatum = danas.Date
            };

            List<IEntity> postojeceSmene = broker.GetByFilter(filter);

            if (postojeceSmene.Count > 0)
            {
                throw new Exception("Apotekar je već prijavljen na smenu danas!");
            }

            TimeSpan trenutnoVreme = danas.TimeOfDay;
            int idSmena;

            if (trenutnoVreme >= new TimeSpan(8, 0, 0) && trenutnoVreme < new TimeSpan(16, 0, 0))
            {
                idSmena = 1;
            }
            else if (trenutnoVreme >= new TimeSpan(16, 0, 0) || trenutnoVreme < new TimeSpan(0, 0, 0))
            {
                idSmena = 2;
            }
            else
            {
                idSmena = 3;
            }

            ApotekarSmena novaSmena = new ApotekarSmena
            {
                IdApotekar = idApotekar,
                IdSmena = idSmena,
                Datum = danas.Date
            };

            broker.Add(novaSmena);
        }
    }
}
