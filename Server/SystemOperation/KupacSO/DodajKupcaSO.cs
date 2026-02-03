using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Server.SystemOperation.KupacSO
{
    public class DodajKupcaSO : SystemOperationBase
    {
        Kupac kupac;
        public Kupac Result { get; private set; }
        public DodajKupcaSO(Kupac kupac)
        {
            this.kupac = kupac;
        }
        protected override void ExecuteOperation()
        {
            broker.Add(kupac);
        }
    }
}
