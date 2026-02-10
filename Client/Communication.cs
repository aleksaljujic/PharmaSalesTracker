using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Common.Communication;
using Common.Domain;

namespace Client
{
    internal class Communication
    {
        // Singleton pattern
        private static Communication instance;
        public static Communication Instance
        {
            get
            {
                if (instance == null)
                    instance = new Communication();
                return instance;
            }
        }

        // Private konstruktor - ne može se kreirati direktno
        private Communication() { }

        // Privatni field-ovi
        private Socket socket;
        private JsonNetworkSerializer serializer;

        /// Povezuje se sa serverom
        public void Connect(string serverIP = "127.0.0.1", int port = 9999)
        {
            if (socket == null || !socket.Connected)
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(serverIP, port);
                serializer = new JsonNetworkSerializer(socket);
            }
        }

        /// <summary>
        /// Šalje Request i prima Response
        /// </summary>
        public Response SendRequest(Request request)
        {
            try
            {
                serializer.Send(request);
                return serializer.Receive<Response>();
            }
            catch (Exception ex)
            {
                return new Response
                {
                    ExceptionMessage = "Greška u komunikaciji: " + ex.Message,
                    ExceptionType = ex.GetType().Name
                };
            }
        }

        /// Helper metoda za deserijalizaciju Result-a
        public T ReadType<T>(object data) where T : class
        {
            if (data == null)
                return null;

            return serializer.ReadType<T>(data);
        }

        public T ReadValue<T>(object data) where T : struct
        {
            if (data == null)
                return default(T);
            return serializer.ReadValueType<T>(data);
        }

        /// Zatvara konekciju sa serverom
        public void Disconnect()
        {
            try
            {
                serializer?.Close();
                socket?.Close();
                socket = null;
            }
            catch (Exception ex)
            {
                // Ignoriši greške pri zatvaranju
                System.Diagnostics.Debug.WriteLine($"Greška pri zatvaranju: {ex.Message}");
            }
        }

        public Response Login(Apotekar apotekar)
        {
            Request request = new Request
            {
                Operation = Operation.LoginApotekar,
                Argument = apotekar
            };

            return SendRequest(request);
        }

        public Response ApotekarSmena(int idApotekar)
        {
            Request request = new Request
            {
                Operation = Operation.PrikaziSmenuZaApotekara,
                Argument = idApotekar
            };

            return SendRequest(request);
        }

        public Response PrijaviSmenu(int idApotekar)
        {
            Request request = new Request
            {
                Operation = Operation.DodajSmenuZaApotekara,
                Argument = idApotekar
            };
            return SendRequest(request);
        }

        public Response PrikaziKupce()
        {
            Request request = new Request
            {
                Operation = Operation.PrikaziKupce,
                Argument = null
            };
            return SendRequest(request);
        }

        public Response DodajKupca(Kupac kupac)
        {
            Request request = new Request
            {
                Operation = Operation.DodajKupca,
                Argument = kupac
            };
            return SendRequest(request);
        }

        public Response UkloniKupca(int idKupac)
        {
            Request request = new Request
            {
                Operation = Operation.UkloniKupca,
                Argument = idKupac
            };
            return SendRequest(request);
        }

        public Response IzmeniKupca(Kupac kupac)
        {
            Request request = new Request
            {
                Operation = Operation.IzmeniKupca,
                Argument = kupac
            };
            return SendRequest(request);
        }

        public Response PrikaziApotekare()
        {
            Request request = new Request
            {
                Operation = Operation.PrikaziApotekare,
                Argument = null
            };
            return SendRequest(request);
        }

        public Response PrikaziGradove()
        {
            Request request = new Request
            {
                Operation = Operation.PrikaziGradove,
                Argument = null
            };
            return SendRequest(request);
        }

        public Response PrikaziLekove()
        {
            Request request = new Request
            {
                Operation = Operation.PrikaziLekove,
                Argument = null
            };
            return SendRequest(request);
        }

        public Response PrikaziRacune()
        {
            Request request = new Request
            {
                Operation = Operation.PrikaziRacune,
                Argument = null
            };
            return SendRequest(request);
        }

        public Response PrikaziStavkeRacuna(int idRacun)
        {
            Request request = new Request
            {
                Operation = Operation.PrikaziStavkeRacuna,
                Argument = idRacun
            };
            return SendRequest(request);
        }

        internal Response PrikaziRacun(int idRacun)
        {
            Request request = new Request
            {
                Operation = Operation.PrikaziRacun,
                Argument = idRacun
            };
            return SendRequest(request);
        }

        public Response PrikaziLek(int idLek)
        {
            Request request = new Request
            {
                Operation = Operation.PrikaziLek,
                Argument = idLek
            };
            return SendRequest(request);
        }

        public Response VratiLekId(int idRacun, int idStavkaRacuna)
        {
            Request request = new Request
            {
                Operation = Operation.VratiLekID,
                Argument = new { IdRacun = idRacun, IdStavkaRacuna = idStavkaRacuna }
            };
            return SendRequest(request);
        }

        public Response KreirajRacun(Racun racun)
        {
            Request request = new Request
            {
                Operation = Operation.KreirajRacun,
                Argument = racun
            };
            return SendRequest(request);
        }

        public Response KreirajStavkuRacuna(StavkaRacuna stavka)
        {
            Request request = new Request
            {
                Operation = Operation.KreirajStavkuRacuna,
                Argument = stavka
            };
            return SendRequest(request);
        }
    }
}
