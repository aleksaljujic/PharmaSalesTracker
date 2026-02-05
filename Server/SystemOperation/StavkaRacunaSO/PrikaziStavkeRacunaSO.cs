using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Server.SystemOperation.StavkaRacunaSO
{
    internal class PrikaziStavkeRacunaSO : SystemOperationBase
    {
        public List<StavkaRacuna> Result { get; private set; }
        public int idRacun { get; private set; }

        public PrikaziStavkeRacunaSO(int idRacun)
        {
            this.idRacun = idRacun;
            Result = new List<StavkaRacuna>();
        }
        protected override void ExecuteOperation()
        {
            StavkaRacuna filter = new StavkaRacuna
            {
                FilterIdRacun = idRacun,
                UseJoin = true
            };
            List<IEntity> entities = broker.GetByFilter(filter);
            Result = entities.Cast<StavkaRacuna>().ToList();
        }
    }
}
