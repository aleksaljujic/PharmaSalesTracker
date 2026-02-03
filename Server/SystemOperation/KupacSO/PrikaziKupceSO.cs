using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Server.SystemOperation.KupacSO
{
    public class PrikaziKupceSO : SystemOperationBase
    {
        public List<Kupac> Result { get; private set; }

        protected override void ExecuteOperation()
        {
            Kupac filter = new Kupac 
            {
                UseJoin = true
            };

            List<IEntity> entities = broker.GetByFilter(filter);

            Result = entities.Cast<Kupac>().ToList();
        }
    }
}
