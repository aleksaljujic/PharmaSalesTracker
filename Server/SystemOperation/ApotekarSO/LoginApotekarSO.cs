using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Server.SystemOperation.ApotekarSO
{
    public class LoginApotekarSO : SystemOperationBase
    {
        private string korisnickoIme;
        private string sifra;

        public Apotekar Result { get; private set; }

        public LoginApotekarSO(string korisnickoIme, string sifra)
        {
            this.korisnickoIme = korisnickoIme;
            this.sifra = sifra;
        }

        protected override void ExecuteOperation()
        {
            Apotekar filter = new Apotekar
            {
                FilterKorisnickoIme = korisnickoIme,
                FilterSifra = sifra
            };

            List<IEntity> results = broker.GetByFilter(filter);
            Result = (Apotekar)results.FirstOrDefault();
        }
    }
}
