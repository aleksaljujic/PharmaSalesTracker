using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Common.Communication;

namespace Server
{
    public class ClientHandler
    {
        private Socket clienSocket;
        private Server server;
        private JsonNetworkSerializer serializer;
        private Controller controller;
        private string clientInfo;

        public ClientHandler(Socket clientSocket, Server server)
        {
            this.clienSocket = clientSocket;
            this.server = server;
            this.serializer = new JsonNetworkSerializer(clienSocket);
            this.controller = new Controller();

            this.clientInfo = $"[{DateTime.Now:HH:mm:ss}] Klijent: {clientSocket.RemoteEndPoint}";
        }
        public void HandleRequest(object? obj)
        {
            try
            {
                while (true)
                {
                    Request request = serializer.Receive<Request>();
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Primljen zahtev tipa: {request.Operation}");

                    Response response = controller.ProcessRequest(request);

                    serializer.Send(response);
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Poslat odgovor za zahtev tipa: {request.Operation}");


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kijent prekinuo vezu: {ex.Message}");
            }
            finally
            {
                CloseSocket();
                server.RemoveClient(this);
            }
        }

        public void CloseSocket()
        {
            try
            {
                serializer?.Close();
                clienSocket?.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greška prilikom zatvaranja konekcije: {ex.Message}");
            }
        }

        public string GetInfo()
        {
            return clientInfo;
        }
    }
}
