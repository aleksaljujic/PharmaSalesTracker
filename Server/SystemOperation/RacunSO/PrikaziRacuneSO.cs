using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Server.SystemOperation.RacunSO
{
    internal class PrikaziRacuneSO : SystemOperationBase
    {
        public List<Racun> Result { get; private set; }
        private int idRacun;
        public PrikaziRacuneSO()
        {
            Result = new List<Racun>();
        }
        protected override void ExecuteOperation()
        {
            Racun racunFilter = new Racun();
            List<IEntity> entities = broker.GetAll(racunFilter);
            Result = entities.Cast<Racun>().ToList();
        }
    }
}
