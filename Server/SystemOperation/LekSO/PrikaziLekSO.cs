using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Server.SystemOperation.LekSO
{
    internal class PrikaziLekSO : SystemOperationBase
    {
        public Lek Result { get; private set; }
        private int idLek;

        public PrikaziLekSO(int idLek)
        {
            this.idLek = idLek;
        }
        protected override void ExecuteOperation()
        {
            Lek filter = new Lek
            {
                FilterIdLek = idLek,
                UseJoin = true
            };
            List<IEntity> entities = broker.GetByFilter(filter);
            Result = entities.Cast<Lek>().FirstOrDefault();
        }
    }
}
