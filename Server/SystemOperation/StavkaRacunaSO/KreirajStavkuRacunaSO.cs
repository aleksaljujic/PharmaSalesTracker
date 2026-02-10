using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Microsoft.Identity.Client;
using Server.SystemOperation.LekSO;

namespace Server.SystemOperation.StavkaRacunaSO
{
    public class KreirajStavkuRacunaSO : SystemOperationBase
    {
        private int rb;
        private float cena;
        private int kolicina;
        private float iznoz;
        private int idRacuna;
        private int idLek;
        private float? popustProcenat;
        private float? konacnaCena;

        public KreirajStavkuRacunaSO(StavkaRacuna stavkaRacuna)
        {
            this.kolicina = stavkaRacuna.Kolicina;
            this.idRacuna = stavkaRacuna.IdRacun;
            this.idLek = stavkaRacuna.IdLek;
            this.popustProcenat = stavkaRacuna.PopustProcenat;
        }
        protected override void ExecuteOperation()
        {
            List<StavkaRacuna> stavke = broker.GetByFilter(new StavkaRacuna { FilterIdRacun = idRacuna }).Cast<StavkaRacuna>().ToList();
            this.rb = stavke.Count > 0 ? stavke.Max(s => s.Rb) + 1 : 1;

            // 5. Validacija popusta
            if (popustProcenat < 0 || popustProcenat > 100 || popustProcenat==null)
            {
                throw new Exception("Popust mora biti između 0 i 100%!");
            }

            // 7. Provera da li račun postoji
            var racun = broker.GetFirstId(new Racun { IdRacun = idRacuna });
            if (racun == null)
            {
                throw new Exception($"Račun sa ID {idRacuna} ne postoji!");
            }

            // 8. Provera da li lek postoji
            var lek = broker.GetFirstId(new Lek { IdLek = idLek });
            if (lek == null)
            {
                throw new Exception($"Lek sa ID {idLek} ne postoji!");
            }
            Lek filter = new Lek{
                IdLek = idLek
            };

            // 9. Provera da li lek ima dovoljno na stanju
            List<IEntity> lekSaStanjem = broker.GetByFilter(filter);
            Lek lekSS = lekSaStanjem.Cast<Lek>().FirstOrDefault();
            if (lekSS.StanjeMagacin < kolicina)
            {
                throw new Exception($"Nedovoljno leka na stanju! Dostupno: {lekSS.StanjeMagacin}, traženo: {kolicina}");
            }

            this.cena = lekSS.Cena;
            this.iznoz = lekSS.Cena * kolicina;
            this.konacnaCena = (lekSS.Cena * kolicina) * (1 - popustProcenat / 100);

            if (cena <= 0)
            {
                throw new Exception("Cena mora biti veća od 0!");
            }

            // 3. Validacija količine
            if (kolicina <= 0)
            {
                throw new Exception("Količina mora biti veća od 0!");
            }

            // 4. Validacija iznosa
            if (iznoz <= 0)
            {
                throw new Exception("Iznos mora biti veći od 0!");
            }

            // 6. Validacija konačne cene
            if (konacnaCena < 0)
            {
                throw new Exception("Konačna cena ne može biti negativna!");
            }

            // 10. Logička validacija - da li je izračunat iznos tačan
            float ocekivaniIznos = cena * kolicina;
            if (Math.Abs(iznoz - ocekivaniIznos) > 0.01f) // Tolerancija za float
            {
                throw new Exception($"Iznos nije tačno izračunat! Očekivano: {ocekivaniIznos:F2}, dobijeno: {iznoz:F2}");
            }

            // 12. Provera da li stavka sa istim RB već postoji za ovaj račun
            var postojeceStavke = broker.GetAll(new StavkaRacuna())
                .Cast<StavkaRacuna>()
                .Where(s => s.IdRacun == idRacuna && s.Rb == rb);

            if (postojeceStavke.Any())
            {
                throw new Exception($"Stavka sa rednim brojem {rb} već postoji na ovom računu!");
            }

            // AKO JE SVE VALIDNO - KREIRANJE STAVKE
            StavkaRacuna stavka = new StavkaRacuna
            {
                Rb = rb,
                Cena = cena,
                Kolicina = kolicina,
                Iznos = iznoz,
                IdRacun = idRacuna,
                IdLek = idLek,
                PopustProcenat = popustProcenat,
                KonacnaCena = konacnaCena
            };

            broker.Add(stavka);

            lekSS.StanjeMagacin -= kolicina;
            broker.Update(lekSS);
        }
    }
}
