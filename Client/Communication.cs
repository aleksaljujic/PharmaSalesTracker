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
    }
}
