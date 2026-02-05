using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Server.SystemOperation.LekSO
{
    internal class VratiLekIDSO : SystemOperationBase
    {
        public int Result { get; private set; }
        private int idRacun;
        private int idStavkaRacuna;

        public VratiLekIDSO(int idRacun, int idStavkaRacuna)
        {
            this.idRacun = idRacun;
            this.idStavkaRacuna = idStavkaRacuna;
        }
        protected override void ExecuteOperation()
        {
            StavkaRacuna filter = new StavkaRacuna
            {
                FilterIdRacun = idRacun,
                UseJoin = true
            };
            List<IEntity> entities = broker.GetByFilter(filter);
            Result = entities.Cast<StavkaRacuna>().ElementAt(idStavkaRacuna-1).IdLek;
        }
    }
}
