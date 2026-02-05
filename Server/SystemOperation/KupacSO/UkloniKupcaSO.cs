using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Server.SystemOperation.KupacSO
{
    public class UkloniKupcaSO : SystemOperationBase
    {
        private Kupac kupac;

        public UkloniKupcaSO(int idKupca)
        {
            this.kupac = new Kupac 
            { 
                IdKupac = idKupca 
            };
        }

        protected override void ExecuteOperation()
        {
            broker.Delete(kupac);
        }
    }
}
