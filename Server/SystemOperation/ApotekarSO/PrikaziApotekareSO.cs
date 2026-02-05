using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Server.SystemOperation.ApotekarSO
{
    internal class PrikaziApotekareSO : SystemOperationBase
    {
        public List<Apotekar> Result;

        protected override void ExecuteOperation()
        {
            Apotekar filter = new Apotekar();
            List<IEntity> entities = broker.GetAll(filter);
            Result = entities.Cast<Apotekar>().ToList();
        }
    }
}
