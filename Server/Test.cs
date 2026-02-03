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
                    Console.WriteLine("✅ USPEH: Kupci učitani:");
                    
                    // Koristiš svoju ReadType metodu da izvučeš objekat iz Result-a
                    List<Kupac> kupci = serializer.ReadType<List<Kupac>>(response.Result);
                    Console.WriteLine($"Broj kupaca: {kupci.Count}");
                    foreach (Kupac k in kupci)
                    {
                        Console.WriteLine($"Kupac: {k.DisplayValue}");
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

    }
}
