using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Communication
{
    public class JsonNetworkSerializer
    {
        private readonly Socket socket;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public JsonNetworkSerializer(Socket socket)
        {
            this.socket = socket;
            stream = new NetworkStream(socket);
            reader = new StreamReader(stream, Encoding.UTF8);
            writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
        }

        public void Send(Object obj)
        {
            try
            {
                string json = JsonSerializer.Serialize(obj);
                writer.WriteLine(json);
            }
            catch (Exception ex)
            {
                throw new Exception("Greška prilikom slanja podataka: " + ex.Message);
            }
        }

        public T Receive<T>()
        {
            try
            {
                string json = reader.ReadLine();

                if(json == null)
                {
                    throw new Exception("Konekcija je zatvorena ili nisu poslati podaci.");
                }

                return JsonSerializer.Deserialize<T>(json);
            }
            catch (JsonException ex)
            {
                throw new Exception("Greška pri deserijalizaciji podataka: " + ex.Message, ex);
            }
        }

        public T ReadType<T>(object data) where T : class
        {
            try
            {
                if (data == null)
                {
                    return null;
                }

                if(data is JsonElement jsonElement)
                {
                    string json = jsonElement.GetRawText();
                    return JsonSerializer.Deserialize<T>(json);
                }
                return JsonSerializer.Deserialize<T>(data.ToString());
            }
            catch (JsonException ex)
            {
                throw new Exception("Greška pri konverziji podataka: " + ex.Message, ex);
            }
        }

        public void Close()
        {
            try
            {
                writer?.Close();
                reader?.Close();
                stream?.Close();
                socket?.Close();
            }
            catch (Exception)
            {
                //throw new Exception("Greška prilikom zatvaranja konekcije: " + ex.Message);
            }
        }
    }
}
