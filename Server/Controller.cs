using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Common.Communication;
using Common.Domain;
using Server.SystemOperation.ApotekarSO;
using Server.SystemOperation.KupacSO;
using Server.SystemOperation.Smena;

namespace Server
{
    public class Controller
    {
        public Response ProcessRequest(Request request)
        {
            Response response = new Response();

            try
            {
                switch (request.Operation)
                {
                    case Operation.LoginApotekar:
                        response = LoginApotekar(request);
                        break;
                    case Operation.PrikaziSmenuZaApotekara:
                        response = PrikaziSmene(request);
                        break;
                    case Operation.DodajSmenuZaApotekara:
                        response = DodajSmenu(request);
                        break;
                    case Operation.PrikaziKupce:
                        response = PrikaziKupce(request);
                        break;
                    case Operation.DodajKupca:
                        response = DodajKupca(request);
                        break;
                    default:
                        response.ExceptionMessage = "Nepoznata operacija";
                        response.ExceptionType = "InvalidOperationException";
                        break;
                }
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }

            return response;
        }

        private Response DodajSmenu(Request request)
        {
            Response response = new Response();
            try
            {
                JsonElement jsonElement = (JsonElement)request.Argument;
                int idApotekar = jsonElement.GetInt32();
                DodajSmenuSO so = new DodajSmenuSO(idApotekar);
                so.Execute();
                response.Result = "Smena uspešno dodata.";
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }
            return response;
        }

        private Response PrikaziKupce(Request request)
        {
            Response response = new Response();
            try
            {
                PrikaziKupceSO so = new PrikaziKupceSO();
                so.Execute();
                if (so.Result != null && so.Result.Count > 0)
                {
                    response.Result = so.Result;
                }
                else
                {
                    response.Result = new List<Kupac>();
                }
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }
            return response;
        }

        private Response PrikaziSmene(Request request)
        {
            Response response = new Response();

            try
            {
                JsonElement jsonElement = (JsonElement)request.Argument;
                int idApotekara = jsonElement.GetInt32();

                PrikaziSmeneSO so = new PrikaziSmeneSO(idApotekara);
                so.Execute();

                if (so.Result != null && so.Result.Count > 0)
                {
                    response.Result = so.Result;
                }
                else
                {
                    response.Result = new List<ApotekarSmena>();
                }
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }
            return response;
        }

        private Response LoginApotekar(Request request)
        {
            Response response = new Response();

            try
            {
                JsonElement jsonElement = (JsonElement)request.Argument;
                string korisnickoIme = jsonElement.GetProperty("KorisnickoIme").GetString();
                string sifra = jsonElement.GetProperty("Sifra").GetString();

                LoginApotekarSO so = new LoginApotekarSO(korisnickoIme, sifra);
                so.Execute();

                if (so.Result != null)
                {
                    response.Result = so.Result;
                }
                else
                {
                    response.ExceptionMessage = "Neispravno korisničko ime ili lozinka.";
                    response.ExceptionType = "LoginException";
                } 
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }

            return response;
        }

        private Response DodajKupca(Request request)
        {
            Response response = new Response();

            try
            {
                JsonElement jsonElement = (JsonElement)request.Argument;
                Kupac kupac = JsonSerializer.Deserialize<Kupac>(jsonElement.GetRawText());

                DodajKupcaSO dodajKupcaSO = new DodajKupcaSO(kupac);
                dodajKupcaSO.Execute();

                response.Result = "Kupac uspešno dodat.";
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }
            return response;
        }
    }
}
