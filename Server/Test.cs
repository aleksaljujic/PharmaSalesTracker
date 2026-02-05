using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Common.Communication;
using Common.Domain;
using Server.SystemOperation.Smena;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Server
{
    public class Test
    {
        private Server server;
        private JsonNetworkSerializer serializer;
        private TcpClient client;

        public Test()
        {
            server = new Server();
        }
        public void PokretanjeServera()
        {
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║     APOTEKA SERVER - STARTED       ║");
            Console.WriteLine("╚════════════════════════════════════╝\n");

            
            server.Start();

            Console.WriteLine("\nServer uspeno pokrenut...\n");
        }

        public void ZaustavljanjeServera()
        {
            Console.WriteLine("\nPritisnite ENTER za zaustavljanje servera...\n");
            Console.ReadLine();

            server.Stop();

            Console.WriteLine("\nPritisnite bilo koji taster za izlaz...");
            Console.ReadKey();
        }

        public void SimulacijaKlijenta()
        {
            Console.WriteLine("--- SERVER JE PODIGNUT, ČEKAM KLIJENTA ---");
            Thread.Sleep(1000);

            try
            {
                Console.WriteLine("▶ KLIJENT: Pokušavam povezivanje...");
                TcpClient client = new TcpClient("127.0.0.1", 9999);
                Console.WriteLine("✔ KLIJENT: Povezan sa serverom.");

                NetworkStream stream = client.GetStream();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ KLIJENT: Greška prilikom povezivanja - {ex.Message}");
            }
        }
        public void SimulacijaLogin()
        {
            client = new TcpClient("127.0.0.1", 9999);
            NetworkStream stream = client.GetStream();
            if (client == null || !client.Connected)
            {
                Console.WriteLine("✘ Greška: Klijent nije povezan!");
                return;
            }

            Console.WriteLine("\n--- LOGIN FORMA ---");
            Console.Write("  Korisničko ime: ");
            string username = Console.ReadLine();
            Console.Write("  Lozinka: ");
            string password = Console.ReadLine();

            serializer = new JsonNetworkSerializer(client.Client);

            Request request = new Request
            {
                Operation = Operation.LoginApotekar,
                Argument = new
                {
                    KorisnickoIme = username,
                    Sifra = password
                }
            };

            try
            {
                // 1. Šaljemo zahtev serveru preko tvog JSON serializera
                serializer.Send(request);
                Console.WriteLine("  ⏳ Zahtev poslat, čekam odgovor...");

                // 2. Čekamo odgovor (Response)
                Response response = serializer.Receive<Response>();

                // 3. Obrada odgovora
                if (response.IsSuccess)
                {
                    // Koristiš svoju ReadType metodu da izvučeš objekat iz Result-a
                    Apotekar ulogovan = serializer.ReadType<Apotekar>(response.Result);
                    Console.WriteLine($"✅ USPEH: Dobrodošao {ulogovan.Ime} {ulogovan.Prezime}!");
                }
                else
                {
                    Console.WriteLine($"❌ NEUSPEH: {response.ExceptionMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ Greška u komunikaciji: {ex.Message}");
            }
        }

        public void TestPrikaziSmenePrekoServera(int idApotekar)
        {
            client = new TcpClient("127.0.0.1", 9999);
            NetworkStream stream = client.GetStream();
            if (client == null || !client.Connected)
            {
                Console.WriteLine("✘ Greška: Klijent nije povezan!");
                return;
            }

            serializer = new JsonNetworkSerializer(client.Client);

            Request request = new Request
            {
                Operation = Operation.PrikaziSmenuZaApotekara,
                Argument = idApotekar
            };

            try
            {
                // 1. Šaljemo zahtev serveru preko tvog JSON serializera
                serializer.Send(request);
                Console.WriteLine("  ⏳ Zahtev poslat, čekam odgovor...");

                // 2. Čekamo odgovor (Response)
                Response response = serializer.Receive<Response>();

                // 3. Obrada odgovora
                if (response.IsSuccess)
                {
                    // Koristiš svoju ReadType metodu da izvučeš objekat iz Result-a
                    List<ApotekarSmena> apotekarSmena = serializer.ReadType<List<ApotekarSmena>>(response.Result);
                    foreach(ApotekarSmena aps in apotekarSmena)
                    {
                        Console.WriteLine($"✅ USPEH: Datum: {aps.Datum}, Smena: {aps.NazivSmene} ({aps.PocetakSmene} - {aps.KrajSmene})");
                    }
                }
                else
                {
                    Console.WriteLine($"❌ NEUSPEH: {response.ExceptionMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ Greška u komunikaciji: {ex.Message}");
            }
        }

        public void TestPrikaziKupce()
        {
            client = new TcpClient("127.0.0.1", 9999);
            NetworkStream stream = client.GetStream();
            if (client == null || !client.Connected)
            {
                Console.WriteLine("✘ Greška: Klijent nije povezan!");
                return;
            }

            serializer = new JsonNetworkSerializer(client.Client);

            Request request = new Request
            {
                Operation = Operation.PrikaziKupce,
                Argument = 1
            };

            try
            {
                // 1. Šaljemo zahtev serveru preko tvog JSON serializera
                serializer.Send(request);
                Console.WriteLine("  ⏳ Zahtev poslat, čekam odgovor...");

                // 2. Čekamo odgovor (Response)
                Response response = serializer.Receive<Response>();
                Console.WriteLine("  ⏳ Odgovor primljen, obrađujem...");
                // 3. Obrada odgovora
                if (response.IsSuccess)
                {
                    Console.WriteLine("✅ USPEH: Kupac uspesno obrisan:");
                    
                    // Koristiš svoju ReadType metodu da izvučeš objekat iz Result-a
                    List<Kupac> kupci = serializer.ReadType<List<Kupac>>(response.Result);
                    Console.WriteLine($"Broj kupaca: {kupci.Count}");
                    foreach (Kupac k in kupci)
                    {
                        Console.WriteLine($"Kupac:{k.IdKupac} : {k.DisplayValue}");
                    }
                }
                else
                {
                    Console.WriteLine($"❌ NEUSPEH: {response.ExceptionMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ Greška u komunikaciji: {ex.Message}");
            }
        }

        public void TestDodajSmenu(int idApotekar)
        {
            client = new TcpClient("127.0.0.1", 9999);
            NetworkStream stream = client.GetStream();
            if (client == null || !client.Connected)
            {
                Console.WriteLine("✘ Greška: Klijent nije povezan!");
                return;
            }

            serializer = new JsonNetworkSerializer(client.Client);

            Request request = new Request
            {
                Operation = Operation.DodajSmenuZaApotekara,
                Argument = idApotekar
            };

            try
            {
                // 1. Šaljemo zahtev serveru preko tvog JSON serializera
                serializer.Send(request);
                Console.WriteLine("⏳ Zahtev poslat, čekam odgovor...");

                // 2. Čekamo odgovor (Response)
                Response response = serializer.Receive<Response>();

                // 3. Obrada odgovora
                if (response.IsSuccess)
                {
                   Console.WriteLine($"✅ USPEH: Smena uspešno dodata za apotekara ID: {idApotekar}");
                }
                else
                {
                    Console.WriteLine($"❌ NEUSPEH: {response.ExceptionMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ Greška u komunikaciji: {ex.Message}");
            }
        }

        public void TestPrikaziSmene(int idApotekara)
        {
            try
            {
                Console.WriteLine("=== TEST: PrikaziSmeneSO ===");


                PrikaziSmeneSO so = new PrikaziSmeneSO(idApotekara);
                so.Execute();

                Console.WriteLine($"Pronađeno smena: {so.Result.Count}");

                foreach (var smena in so.Result)
                {
                    Console.WriteLine($"Datum: {smena.Datum:dd.MM.yyyy}");
                    Console.WriteLine($"Apotekar: {smena.ApotekarIme} {smena.ApotekarPrezime}");
                    Console.WriteLine($"Smena: {smena.NazivSmene} ({smena.PocetakSmene} - {smena.KrajSmene})");
                    Console.WriteLine("---");
                }

                Console.WriteLine("TEST USPEŠAN!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GREŠKA: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }

            Console.ReadLine();
        }

        public void TestUkloniKupca()
        {
            client = new TcpClient("127.0.0.1", 9999);
            NetworkStream stream = client.GetStream();
            if (client == null || !client.Connected)
            {
                Console.WriteLine("✘ Greška: Klijent nije povezan!");
                return;
            }

            Console.WriteLine("\n--- DODAVANJE KUPCA ---");
            Console.Write(" Uneki Id Kupca: ");
            int idKupca = int.Parse(Console.ReadLine());

            serializer = new JsonNetworkSerializer(client.Client);

            Request request = new Request
            {
                Operation = Operation.UkloniKupca,
                Argument = idKupca
            };

            try
            {
                // 1. Šaljemo zahtev serveru preko tvog JSON serializera
                serializer.Send(request);
                Console.WriteLine("  ⏳ Zahtev poslat, čekam odgovor...");

                // 2. Čekamo odgovor (Response)
                Response response = serializer.Receive<Response>();

                // 3. Obrada odgovora
                if (response.IsSuccess)
                {
                    Console.WriteLine($"✅ USPEH: Uspesno uklonjen kupac: {idKupca}");
                }
                else
                {
                    Console.WriteLine($"❌ NEUSPEH: {response.ExceptionMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ Greška u komunikaciji: {ex.Message}");
            }
        }

        public void TestIzmeniKupca()
        {
            client = new TcpClient("127.0.0.1", 9999);
            NetworkStream stream = client.GetStream();
            if (client == null || !client.Connected)
            {
                Console.WriteLine("✘ Greška: Klijent nije povezan!");
                return;
            }

            Console.WriteLine("\n--- IZMEENA KUPCA ---");
            Console.Write(" Uneki Id Kupca: ");
            int idKupca = int.Parse(Console.ReadLine());
            Console.Write(" Nova email adresa: ");
            string email = Console.ReadLine();
            Console.Write(" Novi broj telefona: ");
            string brojTelefona = Console.ReadLine();

            serializer = new JsonNetworkSerializer(client.Client);

            Request request = new Request
            {
                Operation = Operation.IzmeniKupca,
                Argument = new Kupac
                {
                    IdKupac = idKupca,
                    Email = email,
                    BrojTelefona = brojTelefona
                }
            };

            try
            {
                // 1. Šaljemo zahtev serveru preko tvog JSON serializera
                serializer.Send(request);
                Console.WriteLine("  ⏳ Zahtev poslat, čekam odgovor...");

                // 2. Čekamo odgovor (Response)
                Response response = serializer.Receive<Response>();

                // 3. Obrada odgovora
                if (response.IsSuccess)
                {
                    Console.WriteLine($"✅ USPEH: Uspesno izmenjen kupac: {idKupca}");
                }
                else
                {
                    Console.WriteLine($"❌ NEUSPEH: {response.ExceptionMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ Greška u komunikaciji: {ex.Message}");
            }
        }

        public void TestDodajKupca()
        {
            client = new TcpClient("127.0.0.1", 9999);
            NetworkStream stream = client.GetStream();
            if (client == null || !client.Connected)
            {
                Console.WriteLine("✘ Greška: Klijent nije povezan!");
                return;
            }

            Console.WriteLine("\n--- DODAVANJE KUPCA ---");
            Console.Write(" Ime: ");
            string ime = Console.ReadLine();
            Console.Write(" Prezime: ");
            string prezime = Console.ReadLine();
            Console.Write(" broj telefona: ");
            string brojTelefona = Console.ReadLine();
            Console.Write(" adresa: ");
            string adresa = Console.ReadLine();
            Console.Write(" email: ");
            string email = Console.ReadLine();
            Console.Write(" sifra lokacije: ");
            string idLokacije = Console.ReadLine();

            Kupac noviKupac = new Kupac
            {
                Ime = ime,
                Prezime = prezime,
                BrojTelefona = brojTelefona,
                Adresa = adresa,
                Email = email,
                IdLokacija = int.Parse(idLokacije)
            };

            serializer = new JsonNetworkSerializer(client.Client);

            Request request = new Request
            {
                Operation = Operation.DodajKupca,
                Argument = noviKupac
            };

            try
            {
                // 1. Šaljemo zahtev serveru preko tvog JSON serializera
                serializer.Send(request);
                Console.WriteLine("  ⏳ Zahtev poslat, čekam odgovor...");

                // 2. Čekamo odgovor (Response)
                Response response = serializer.Receive<Response>();

                // 3. Obrada odgovora
                if (response.IsSuccess)
                {
                    Console.WriteLine($"✅ USPEH: Uspesno dodat kupac: {ime} {prezime}");
                }
                else
                {
                    Console.WriteLine($"❌ NEUSPEH: {response.ExceptionMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ Greška u komunikaciji: {ex.Message}");
            }
        }

        public void TestPrikaziApotekare()
        {
            client = new TcpClient("127.0.0.1", 9999);
            NetworkStream stream = client.GetStream();
            if (client == null || !client.Connected)
            {
                Console.WriteLine("✘ Greška: Klijent nije povezan!");
                return;
            }

            serializer = new JsonNetworkSerializer(client.Client);

            Request request = new Request
            {
                Operation = Operation.PrikaziApotekare,
                Argument = 1
            };

            try
            {
                // 1. Šaljemo zahtev serveru preko tvog JSON serializera
                serializer.Send(request);
                Console.WriteLine("  ⏳ Zahtev poslat, čekam odgovor...");
                // 2. Čekamo odgovor (Response)
                Response response = serializer.Receive<Response>();
                Console.WriteLine("  ⏳ Odgovor primljen, obrađujem...");
                // 3. Obrada odgovora
                if (response.IsSuccess)
                {
                    Console.WriteLine("✅ USPEH: Apotekari uspešno prikazani:");
                    // Koristiš svoju ReadType metodu da izvučeš objekat iz Result-a
                    List<Apotekar> apotekari = serializer.ReadType<List<Apotekar>>(response.Result);
                    Console.WriteLine($"Broj apotekara: {apotekari.Count}");
                    foreach (Apotekar a in apotekari)
                    {
                        Console.WriteLine($"Apotekar:{a.IdApotekar} : {a.DisplayValue}");
                    }
                }
                else
                {
                    Console.WriteLine($"❌ NEUSPEH: {response.ExceptionMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ Greška u komunikaciji: {ex.Message}");
            }
        }

        public void TestPrikaziGradove()
        {
            client = new TcpClient("127.0.0.1", 9999);
            NetworkStream stream = client.GetStream();
            if (client == null || !client.Connected)
            {
                Console.WriteLine("✘ Greška: Klijent nije povezan!");
                return;
            }

            serializer = new JsonNetworkSerializer(client.Client);

            Request request = new Request
            {
                Operation = Operation.PrikaziGradove,
                Argument = null
            };

            try
            {
                // 1. Šaljemo zahtev serveru preko tvog JSON serializera
                serializer.Send(request);
                Console.WriteLine("  ⏳ Zahtev poslat, čekam odgovor...");
                // 2. Čekamo odgovor (Response)
                Response response = serializer.Receive<Response>();
                Console.WriteLine("  ⏳ Odgovor primljen, obrađujem...");
                // 3. Obrada odgovora
                if (response.IsSuccess)
                {
                    Console.WriteLine("✅ USPEH: Grsdovi uspešno prikazani:");
                    // Koristiš svoju ReadType metodu da izvučeš objekat iz Result-a
                    List<Lokacija> gradovi = serializer.ReadType<List<Lokacija>>(response.Result);
                    Console.WriteLine($"-- {gradovi.Count}");
                    foreach(Lokacija g in gradovi)
                    {
                        Console.WriteLine($"-- {g.DisplayValue}");
                    }
                }
                else
                {
                    Console.WriteLine($"❌ NEUSPEH: {response.ExceptionMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ Greška u komunikaciji: {ex.Message}");
            }
        }

        public void TestPrikaziLekove()
        {
            client = new TcpClient("127.0.0.1", 9999);
            NetworkStream stream = client.GetStream();
            if (client == null || !client.Connected)
            {
                Console.WriteLine("✘ Greška: Klijent nije povezan!");
                return;
            }

            serializer = new JsonNetworkSerializer(client.Client);

            Request request = new Request
            {
                Operation = Operation.PrikaziLekove,
                Argument = null
            };

            try
            {
                // 1. Šaljemo zahtev serveru preko tvog JSON serializera
                serializer.Send(request);
                Console.WriteLine("  ⏳ Zahtev poslat, čekam odgovor...");
                // 2. Čekamo odgovor (Response)
                Response response = serializer.Receive<Response>();
                Console.WriteLine("  ⏳ Odgovor primljen, obrađujem...");
                // 3. Obrada odgovora
                if (response.IsSuccess)
                {
                    Console.WriteLine("✅ USPEH: Lekovi uspešno prikazani:");
                    // Koristiš svoju ReadType metodu da izvučeš objekat iz Result-a
                    List<Lek> lekovi = serializer.ReadType<List<Lek>>(response.Result);
                    Console.WriteLine($"-- {lekovi.Count}");
                    foreach (Lek l in lekovi)
                    {
                        Console.WriteLine($"-- {l.DisplayValue}");
                    }
                }
                else
                {
                    Console.WriteLine($"❌ NEUSPEH: {response.ExceptionMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ Greška u komunikaciji: {ex.Message}");
            }
        }

        public void TestPrikaziRacune()
        {
            client = new TcpClient("127.0.0.1", 9999);
            NetworkStream stream = client.GetStream();
            if (client == null || !client.Connected)
            {
                Console.WriteLine("✘ Greška: Klijent nije povezan!");
                return;
            }

            serializer = new JsonNetworkSerializer(client.Client);

            Request request = new Request
            {
                Operation = Operation.PrikaziRacune,
                Argument = null
            };

            try
            {
                // 1. Šaljemo zahtev serveru preko tvog JSON serializera
                serializer.Send(request);
                Console.WriteLine("  ⏳ Zahtev poslat, čekam odgovor...");
                // 2. Čekamo odgovor (Response)
                Response response = serializer.Receive<Response>();
                Console.WriteLine("  ⏳ Odgovor primljen, obrađujem...");
                // 3. Obrada odgovora
                if (response.IsSuccess)
                {
                    Console.WriteLine("✅ USPEH: Racuni uspešno prikazani:");
                    // Koristiš svoju ReadType metodu da izvučeš objekat iz Result-a
                    List<Racun> racuni = serializer.ReadType<List<Racun>>(response.Result);
                    Console.WriteLine($"-- {racuni.Count}");
                    foreach (Racun r in racuni)
                    {
                        Console.WriteLine($"-- {r.DisplayValue}");
                    }
                }
                else
                {
                    Console.WriteLine($"❌ NEUSPEH: {response.ExceptionMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ Greška u komunikaciji: {ex.Message}");
            }
        }

        public void TestPrikaziStavkeRacuna(int idRacun = 3)
        {
            client = new TcpClient("127.0.0.1", 9999);
            NetworkStream stream = client.GetStream();
            if (client == null || !client.Connected)
            {
                Console.WriteLine("✘ Greška: Klijent nije povezan!");
                return;
            }

            serializer = new JsonNetworkSerializer(client.Client);

            Request request = new Request
            {
                Operation = Operation.PrikaziStavkeRacuna,
                Argument = idRacun
            };

            try
            {
                // 1. Šaljemo zahtev serveru preko tvog JSON serializera
                serializer.Send(request);
                Console.WriteLine("  ⏳ Zahtev poslat, čekam odgovor...");
                // 2. Čekamo odgovor (Response)
                Response response = serializer.Receive<Response>();
                Console.WriteLine("  ⏳ Odgovor primljen, obrađujem...");
                // 3. Obrada odgovora
                if (response.IsSuccess)
                {
                    Console.WriteLine($"✅ USPEH: Stavke za racun sa brojem {idRacun} uspešno prikazani:");
                    // Koristiš svoju ReadType metodu da izvučeš objekat iz Result-a
                    List<StavkaRacuna> stavke = serializer.ReadType<List<StavkaRacuna>>(response.Result);
                    Console.WriteLine($"-- {stavke.Count}");
                    Console.WriteLine("-- Rb |        Lek        |  Kolicina |      Iznos       |   Popust  |  Konacna cena |");
                    foreach (StavkaRacuna s in stavke)
                    {
                        Console.WriteLine($"-- {s.Rb} | {s.LekDisplayValue} | {s.Kolicina} | {s.Iznos} | {s.PopustProcenat} | {s.KonacnaCena}");
                    }
                }
                else
                {
                    Console.WriteLine($"❌ NEUSPEH: {response.ExceptionMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ Greška u komunikaciji: {ex.Message}");
            }
        }

        public void TestPrikaziRacun(int idRacun = 3)
        {
            client = new TcpClient("127.0.0.1", 9999);
            NetworkStream stream = client.GetStream();
            if (client == null || !client.Connected)
            {
                Console.WriteLine("✘ Greška: Klijent nije povezan!");
                return;
            }

            serializer = new JsonNetworkSerializer(client.Client);

            Request request = new Request
            {
                Operation = Operation.PrikaziRacun,
                Argument = idRacun
            };

            try
            {
                // 1. Šaljemo zahtev serveru preko tvog JSON serializera
                serializer.Send(request);
                Console.WriteLine("  ⏳ Zahtev poslat, čekam odgovor...");
                // 2. Čekamo odgovor (Response)
                Response response = serializer.Receive<Response>();
                Console.WriteLine("  ⏳ Odgovor primljen, obrađujem...");
                // 3. Obrada odgovora
                if (response.IsSuccess)
                {
                    Console.WriteLine($"✅ USPEH: Racun sa brojem {idRacun} uspešno prikazan:");
                    // Koristiš svoju ReadType metodu da izvučeš objekat iz Result-a
                    Racun racun = serializer.ReadType<Racun>(response.Result);
                    Console.WriteLine($"Racun ID: {racun.DisplayValue}");
                }
                else
                {
                    Console.WriteLine($"❌ NEUSPEH: {response.ExceptionMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ Greška u komunikaciji: {ex.Message}");
            }
        }

        public void TestPrikaziLek(int idLek = 3)
        {
            client = new TcpClient("127.0.0.1", 9999);
            NetworkStream stream = client.GetStream();
            if (client == null || !client.Connected)
            {
                Console.WriteLine("✘ Greška: Klijent nije povezan!");
                return;
            }

            serializer = new JsonNetworkSerializer(client.Client);

            Request request = new Request
            {
                Operation = Operation.PrikaziLek,
                Argument = idLek
            };

            try
            {
                // 1. Šaljemo zahtev serveru preko tvog JSON serializera
                serializer.Send(request);
                Console.WriteLine("  ⏳ Zahtev poslat, čekam odgovor...");
                // 2. Čekamo odgovor (Response)
                Response response = serializer.Receive<Response>();
                Console.WriteLine("  ⏳ Odgovor primljen, obrađujem...");
                // 3. Obrada odgovora
                if (response.IsSuccess)
                {
                    Console.WriteLine($"✅ USPEH: Lek sa brojem {idLek} uspešno prikazan:");
                    // Koristiš svoju ReadType metodu da izvučeš objekat iz Result-a
                    Lek lek = serializer.ReadType<Lek>(response.Result);
                    Console.WriteLine($"Racun ID: {lek.DisplayValue}");
                }
                else
                {
                    Console.WriteLine($"❌ NEUSPEH: {response.ExceptionMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ Greška u komunikaciji: {ex.Message}");
            }
        }

        public void TestPrikaziLekID(int idRacun = 1, int idStavkaRacuna = 1)
        {
            client = new TcpClient("127.0.0.1", 9999);
            NetworkStream stream = client.GetStream();
            if (client == null || !client.Connected)
            {
                Console.WriteLine("✘ Greška: Klijent nije povezan!");
                return;
            }

            serializer = new JsonNetworkSerializer(client.Client);

            Request request = new Request
            {
                Operation = Operation.VratiLekID,
                Argument = new
                {
                    IdRacun = idRacun,
                    IdStavkaRacuna = idStavkaRacuna
                }
            };

            try
            {
                // 1. Šaljemo zahtev serveru preko tvog JSON serializera
                serializer.Send(request);
                Console.WriteLine("  ⏳ Zahtev poslat, čekam odgovor...");
                // 2. Čekamo odgovor (Response)
                Response response = serializer.Receive<Response>();
                Console.WriteLine("  ⏳ Odgovor primljen, obrađujem...");
                // 3. Obrada odgovora
                if (response.IsSuccess)
                {
                    Console.WriteLine($"✅ USPEH: ID Leka za Racun {idRacun} iz stavke {idStavkaRacuna}:");
                    // Koristiš svoju ReadType metodu da izvučeš objekat iz Result-a
                    int lekId = serializer.ReadValueType<int>(response.Result);
                    Console.WriteLine($"Lek ID: {lekId}");
                }
                else
                {
                    Console.WriteLine($"❌ NEUSPEH: {response.ExceptionMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✘ Greška u komunikaciji: {ex.Message}");
            }
        }

    }
}
