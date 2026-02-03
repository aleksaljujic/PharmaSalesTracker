using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Common.Domain;
using DBBroker;
using Microsoft.IdentityModel.Protocols;

namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST DBBroker");

            string connString = ConfigurationManager.ConnectionStrings["ApotekaDB"].ConnectionString;

            TestKonekciju(connString);
            Console.WriteLine("--------------------------------\n");
            TestGetAll(connString);
            Console.WriteLine("--------------------------------\n");
            TestLogin(connString);
            Console.WriteLine("--------------------------------\n");
            TestAdd(connString);
            Console.WriteLine("--------------------------------\n");

            Console.WriteLine("Svi testovi zavrseni");
            Console.WriteLine("\nPritisnite bilo koji taster...");
            Console.ReadKey();

        }

        private static void TestAdd(string connString)
        {
            Console.WriteLine("▶ TEST 4: Add - Dodavanje novog apotekara");
            Console.Write("  Ime: ");
            string ime = Console.ReadLine();
            Console.Write("  Prezime: ");
            string prezime = Console.ReadLine();
            Console.Write("  Korisničko ime: ");
            string username = Console.ReadLine();
            Console.Write("  Lozinka: ");
            string password = Console.ReadLine();

            try
            {
                using (Broker broker = new Broker(connString))
                {
                    broker.OpenConnection();
                    broker.BeginTransaction();

                    Apotekar noviApotekar = new Apotekar
                    {
                        Ime = ime,
                        Prezime = prezime,
                        KorisnickoIme = username,
                        Sifra = password
                    };

                    Console.WriteLine($"  📝 SQL: INSERT INTO {noviApotekar.TableName} ({noviApotekar.Columns}) VALUES ({noviApotekar.ValuesClause})");

                    broker.Add(noviApotekar);

                    Console.WriteLine("  ⏳ Pre Commit-a...");
                    broker.Commit();
                    Console.WriteLine("  ✅ Commit završen");

                    // ODMAH PROVERI da li je dodat
                    Console.WriteLine("\n  🔍 Proveravamo da li je u bazi...");
                    Apotekar filter = new Apotekar { FilterKorisnickoIme = username };
                    List<IEntity> results = broker.GetByFilter(filter);

                    if (results.Count > 0)
                    {
                        Console.WriteLine($"  ✅ POTVRĐENO: {username} je u bazi!");
                    }
                    else
                    {
                        Console.WriteLine($"  ❌ PROBLEM: {username} NIJE u bazi nakon Commit-a!");
                    }

                    broker.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška prilikom dodavanja apotekara: " + ex.Message);
            }
        }

        private static void TestLogin(string connString)
        {
            Console.WriteLine("▶ TEST 3: Login (GetByCondition)");
            Console.Write("  Korisničko ime: ");
            string username = Console.ReadLine();
            Console.Write("  Lozinka: ");
            string password = Console.ReadLine();

            try
            {
                using(Broker broker = new Broker(connString))
                {
                    broker.OpenConnection();
                    Apotekar filter = new Apotekar
                    {
                        FilterKorisnickoIme = username,
                        FilterSifra = password
                    };
                    List<IEntity> results = broker.GetByFilter(filter);
                    if(results.Count > 0)
                    {
                        Apotekar apotekar = (Apotekar)results[0];
                        Console.WriteLine($"  ✅ Uspešna prijava! Dobrodošao, {apotekar.Ime} {apotekar.Prezime}\n");
                    }
                    else
                    {
                        Console.WriteLine("  ❌ Neuspešna prijava! Pogrešno korisničko ime ili lozinka\n");
                    }
                    broker.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška prilikom prijave: " + ex.Message);
            }
        }

        private static void TestGetAll(string connString)
        {
            Console.WriteLine("▶ TEST 2: GetAll metoda - Prikaz svih apotekara");
            try
            {
                using (Broker broker = new Broker(connString))
                {
                    broker.OpenConnection();
                    List<IEntity> result = broker.GetAll(new Apotekar());
                    Console.WriteLine($"  📊 Broj apotekara u bazi: {result.Count}");
                    if (result.Count > 0)
                    {
                        foreach (Apotekar a in result)
                        {
                            Console.WriteLine($"     • {a.Ime} {a.Prezime} (username: {a.KorisnickoIme})");
                        }
                        Console.WriteLine("  ✅ GetAll radi ispravno\n");
                    }
                    else
                    {
                        Console.WriteLine("  ⚠️ U bazi nema apotekara za prikaz\n");
                    }
                    broker.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška prilikom GetAll: " + ex.Message);
            }
        }

        private static void TestKonekciju(string connString)
        {
            Console.WriteLine("▶ TEST 1: Konekcija ka bazi");

            try
            {
                using (Broker broker = new Broker(connString))
                {
                    broker.OpenConnection();
                    Console.WriteLine("Konekcija uspesno otvorena.");
                    broker.CloseConnection();
                    Console.WriteLine("Konekcija uspesno zatvorena.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška prilikom konekcije: " + ex.Message);
            }
        }


    }
}
