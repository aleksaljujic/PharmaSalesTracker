using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Server.SystemOperation.RacunSO
{
    public class KreirajRacunSO : SystemOperationBase
    {
        public int IdRacun;
        public DateTime DatumIzdavanja;
        public DateTime? RokPlacanja;
        public float? Pdv;
        public float UkupanIznos;
        public int? IdApotekar;
        public int? IdKupac;
        public string NacinPlacanja;
        public string StatusRacuna;
        public string Napomena;
        public string BrojRacuna;

        public KreirajRacunSO(Racun racun)
        {
            this.DatumIzdavanja = DateTime.UtcNow;
            this.RokPlacanja = racun.RokPlacanja;
            this.Pdv = 20;
            this.UkupanIznos = 0;
            this.IdApotekar = racun.IdApotekar;
            this.IdKupac = racun.IdKupac;
            this.NacinPlacanja = racun.NacinPlacanja;
            this.StatusRacuna = racun.StatusRacuna;
            this.Napomena = racun.Napomena;
        }
        protected override void ExecuteOperation()
        {
            List<Racun> racuni = broker.GetAll(new Racun()).Cast<Racun>().ToList();
            int newId = racuni.Count > 0 ? racuni.Max(r => r.IdRacun) + 1 : 1;
            this.BrojRacuna = $"RAC-{DateTime.Now.Year}-{newId.ToString("D5")}";
            // VALIDACIJA UNOSA
            

            // 2. Validacija roka plaćanja
            if (RokPlacanja.HasValue && RokPlacanja.Value < DatumIzdavanja)
            {
                throw new Exception("Rok plaćanja ne može biti pre datuma izdavanja!");
            }

            // 3. Validacija PDV-a
            if (Pdv.HasValue && (Pdv.Value < 0 || Pdv.Value > 100))
            {
                throw new Exception("PDV mora biti između 0 i 100%!");
            }

            // 4. Validacija ukupnog iznosa
            //if (UkupanIznos <= 0)
            //{
            //    throw new Exception("Ukupan iznos mora biti veći od 0!");
            //}

            // 5. Validacija ID-eva (provera da li postoje u bazi)
            if (IdApotekar.HasValue)
            {
                var apotekar = broker.GetFirstId(new Apotekar { IdApotekar = IdApotekar.Value });
                if (apotekar == null)
                {
                    throw new Exception($"Apotekar sa ID {IdApotekar.Value} ne postoji!");
                }
            }

            if (IdKupac.HasValue)
            {
                var kupac = broker.GetFirstId(new Kupac { IdKupac = IdKupac.Value });
                if (kupac == null)
                {
                    throw new Exception($"Kupac sa ID {IdKupac.Value} ne postoji!");
                }
            }

            // 6. Validacija načina plaćanja
            string[] dozvoljeniNacini = { "Gotovina", "Kartica", "Virman" };
            if (string.IsNullOrWhiteSpace(NacinPlacanja) || !dozvoljeniNacini.Contains(NacinPlacanja))
            {
                throw new Exception("Način plaćanja mora biti: Gotovina, Kartica ili Virman!");
            }

            // 7. Validacija statusa računa
            string[] dozvoljeniStatusi = { "Placen", "Neplacen", "Storniran" };
            if (string.IsNullOrWhiteSpace(StatusRacuna) || !dozvoljeniStatusi.Contains(StatusRacuna))
            {
                throw new Exception("Status računa mora biti: Plaćen, Neplaćen ili Storniran!");
            }

            // 8. Validacija broja računa (jedinstveni broj)
            if (string.IsNullOrWhiteSpace(BrojRacuna))
            {
                throw new Exception("Broj računa je obavezan!");
            }

            // Provera da li broj računa već postoji
            var postojeciRacun = broker.GetAll(new Racun())
                .Cast<Racun>()
                .FirstOrDefault(r => r.BrojRacuna == BrojRacuna);

            if (postojeciRacun != null)
            {
                throw new Exception($"Račun sa brojem '{BrojRacuna}' već postoji!");
            }

            // 9. Validacija napomene (opcionalno, ali bez opasnih karaktera)
            if (!string.IsNullOrWhiteSpace(Napomena) && Napomena.Length > 500)
            {
                throw new Exception("Napomena ne sme biti duža od 500 karaktera!");
            }

            // AKO JE SVE VALIDNO - KREIRANJE RAČUNA
            Racun racun = new Racun
            {
                DatumIzdavanja = DatumIzdavanja,
                RokPlacanja = RokPlacanja,
                Pdv = Pdv,
                UkupanIznos = UkupanIznos,
                IdApotekar = IdApotekar,
                IdKupac = IdKupac,
                NacinPlacanja = NacinPlacanja,
                StatusRacuna = StatusRacuna,
                Napomena = Napomena,
                BrojRacuna = BrojRacuna
            };

            broker.Add(racun);
        }
    }
}
