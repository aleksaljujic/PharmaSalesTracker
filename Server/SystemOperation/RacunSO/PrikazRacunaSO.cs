using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Server.SystemOperation.RacunSO
{
    internal class PrikazRacunaSO : SystemOperationBase
    {
        public Racun Result { get; private set; }
        private int idRacun;

        public PrikazRacunaSO(int idRacun)
        {
            this.idRacun = idRacun;
        }

        protected override void ExecuteOperation()
        {
            Racun filter = new Racun
            {
                FilterIdRacun = idRacun,
                UseJoin = true
            };

            List<IEntity> entities = broker.GetByFilter(filter);
            Result = entities.Cast<Racun>().FirstOrDefault();
        }
    }
}
