using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Server.SystemOperation.LekSO
{
    internal class PrikaziLekoveSO : SystemOperationBase
    {
        public List<Lek> Result { get; private set; }

        public PrikaziLekoveSO()
        {
            Result = new List<Lek>();
        }
        protected override void ExecuteOperation()
        {
            Lek filter = new Lek();
            List<IEntity> entities = broker.GetAll(filter);
            Result = entities.Cast<Lek>().ToList();
        }
    }
}
