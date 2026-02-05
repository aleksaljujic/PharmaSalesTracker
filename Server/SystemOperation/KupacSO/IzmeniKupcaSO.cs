using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Server.SystemOperation.KupacSO
{
    public class IzmeniKupcaSO : SystemOperationBase
    {
        private Kupac kupac;
        public IzmeniKupcaSO(Kupac kupac)
        {
            this.kupac = kupac;
        }
        protected override void ExecuteOperation()
        {
            Console.WriteLine($"=== PRIMLJEN KUPAC ===");
            Console.WriteLine($"IdKupac: {kupac.IdKupac}");
            Console.WriteLine($"BrojTelefona: '{kupac.BrojTelefona}'");
            Console.WriteLine($"Email: '{kupac.Email}'");
            Console.WriteLine("====================");

            Kupac filter = new Kupac { IdKupac = kupac.IdKupac };
            List<IEntity> results = broker.GetByFilter(filter);

            if (results.Count == 0)
            {
                throw new Exception($"Kupac sa ID {kupac.IdKupac} ne postoji!");
            }

            Kupac postojeciKupac = (Kupac)results[0];

            Console.WriteLine($"=== STARI PODACI ===");
            Console.WriteLine($"BrojTelefona: '{postojeciKupac.BrojTelefona}'");
            Console.WriteLine($"Email: '{postojeciKupac.Email}'");
            Console.WriteLine("====================");

            if (!string.IsNullOrWhiteSpace(kupac.Ime))
                postojeciKupac.Ime = kupac.Ime;

            if (!string.IsNullOrWhiteSpace(kupac.Prezime))
                postojeciKupac.Prezime = kupac.Prezime;

            if (!string.IsNullOrWhiteSpace(kupac.Email))
                postojeciKupac.Email = kupac.Email;

            if (!string.IsNullOrWhiteSpace(kupac.BrojTelefona))
                postojeciKupac.BrojTelefona = kupac.BrojTelefona;

            if (!string.IsNullOrWhiteSpace(kupac.Adresa))
                postojeciKupac.Adresa = kupac.Adresa;

            broker.Update(postojeciKupac);

            Console.WriteLine("=== UPDATE ZAVRŠEN ===");
        }
    }
}
