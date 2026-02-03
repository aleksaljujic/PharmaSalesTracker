using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using DBBroker;

namespace Server.SystemOperation.Smena
{
    internal class PrikaziSmeneSO : SystemOperationBase
    {
        private int idApotekara;
        public List<ApotekarSmena> Result { get; private set; }

        public PrikaziSmeneSO(int idApotekara)
        {
            this.idApotekara = idApotekara;
        }

        protected override void ExecuteOperation()
        {
           ApotekarSmena filter = new ApotekarSmena
           {
               FilterIdApotekar = idApotekara,
               UseJoin = true
           };

            List<IEntity> result = broker.GetByFilter(filter);

            Result = result.Cast<ApotekarSmena>().ToList();
        }
    }
}
