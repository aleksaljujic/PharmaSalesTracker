using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Server.SystemOperation.LokacijaSO
{
    internal class PrikaziGradoveSO : SystemOperationBase
    {
        public List<Lokacija> Result { get; private set; }
        protected override void ExecuteOperation()
        {
            Lokacija filter = new Lokacija();
            List<IEntity> entities = broker.GetAll(filter);
            Result = entities.Cast<Lokacija>().ToList();
        }
    }
}
