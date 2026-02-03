using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private Socket serverSocket;
        private List<ClientHandler> handlers;
        private object lockObject;
        private volatile bool isRunning;
        public delegate void BrojKlijenata(int brojac);
        public event BrojKlijenata OnBrojKlijenata;

        public Server()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            handlers = new List<ClientHandler>();
            lockObject = new object();
            isRunning = false;
        }

        public void Start()
        {
            if (isRunning)
            {
                Console.WriteLine("Server je već pokrenut!");
                return;
            }

            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                string ip = ConfigurationManager.AppSettings["ip"] ?? "127.0.0.1";
                int port = int.Parse(ConfigurationManager.AppSettings["port"] ?? "9999");

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(10);

                isRunning = true;

                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Server pokrenut na {ip}:{port}");

                Thread acceptThread = new Thread(AcceptClients);
                acceptThread.IsBackground = true;
                acceptThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greška pri pokretanju servera: {ex.Message}");
                isRunning = false;
            }
        }

        private void AcceptClients(object? obj)
        {
            try
            {
                while (isRunning)
                {
                    Socket clientSocket = serverSocket.Accept();
                    string info = $"[{DateTime.Now:HH:mm:ss}] Klijent: {clientSocket.RemoteEndPoint}";

                    ClientHandler handler = new ClientHandler(clientSocket, this);
                    AddClient(handler);

                    Thread clientThread = new Thread(handler.HandleRequest);
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }
            catch (SocketException se)
            {
                if (isRunning)
                {
                    Console.WriteLine($"SocketException: {se.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greška pri prihvatanju klijenata: {ex.Message}");
            }
        }

        public void Stop()
        {
            if (!isRunning)
            {
                Console.WriteLine("Server nije pokrenut!");
                return;
            }
            isRunning = false;
            try
            {
                List<ClientHandler> clientsCopy;
                lock (lockObject)
                {
                    clientsCopy = new List<ClientHandler>(handlers);
                    handlers.Clear();
                }

                foreach (var handler in clientsCopy)
                {
                    handler.CloseSocket();
                }
                serverSocket?.Close();
                serverSocket = null;
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Server je zaustavljen.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greška pri zaustavljanju servera: {ex.Message}");
            }
        }

        internal void AddClient(ClientHandler handler)
        {
            int count;
            lock (lockObject)
            {
                handlers.Add(handler);
                count = handlers.Count;
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Ukupan broj povezanih klijenata: {handlers.Count}");
            }
            OnBrojKlijenata?.Invoke(count);
        }

        internal void RemoveClient(ClientHandler handler)
        {
            int count;
            lock (lockObject)
            {
                handlers.Remove(handler);
                count = handlers.Count;
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Klijent je diskonektovan. Ukupan broj povezanih klijenata: {handlers.Count}");
            }
            OnBrojKlijenata?.Invoke(count);
        }

        public List<String> VratiListuKlijenata()
        {
            lock (lockObject)
            {
                List<string> result = new List<string>();

                foreach (var handler in handlers)
                {
                    result.Add(handler.GetInfo());
                }

                return result;
            }
        }
    }
}
