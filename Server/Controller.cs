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
using Server.SystemOperation.LekSO;
using Server.SystemOperation.LokacijaSO;
using Server.SystemOperation.RacunSO;
using Server.SystemOperation.Smena;
using Server.SystemOperation.StavkaRacunaSO;

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
                    case Operation.UkloniKupca:
                        response = UkloniKupca(request);
                        break;
                    case Operation.IzmeniKupca:
                        response = IzmeniKupca(request);
                        break;
                    case Operation.PrikaziApotekare:
                        response = PrikaziApotekare(request);
                        break;
                    case Operation.PrikaziGradove:
                        response = PrikaziGradove(request);
                        break;
                    case Operation.PrikaziLekove:
                        response = PrikaziLekove(request);
                        break;
                    case Operation.PrikaziRacune:
                        response = PrikaziRacune(request);
                        break;
                    case Operation.PrikaziStavkeRacuna:
                        response = PrikaziStavkeRacuna(request);
                        break;
                    case Operation.PrikaziRacun:
                        response = PrikaziRacun(request);
                        break;
                    case Operation.PrikaziLek:
                        response = PrikaziLek(request);
                        break;
                    case Operation.VratiLekID:
                        response = VratiLekID(request);
                        break;
                    case Operation.KreirajRacun:
                        response = KreirajRacun(request);
                        break;
                    case Operation.KreirajStavkuRacuna:
                        response = KreirajStavkuRacuna(request);
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

        private Response UkloniKupca(Request request)
        {
            Response response = new Response();
            try
            {
                JsonElement jsonElement = (JsonElement)request.Argument;
                int idKupac = jsonElement.GetInt32();
                UkloniKupcaSO ukloniKupcaSO = new UkloniKupcaSO(idKupac);
                ukloniKupcaSO.Execute();
                response.Result = "Kupac uspešno uklonjen.";
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }
            return response;
        }

        private Response IzmeniKupca(Request request)
        {
            Response response = new Response();
            try
            {
                JsonElement jsonElement = (JsonElement)request.Argument;
                Kupac kupac = JsonSerializer.Deserialize<Kupac>(jsonElement.GetRawText());
                IzmeniKupcaSO izmeniKupcaSO = new IzmeniKupcaSO(kupac);
                izmeniKupcaSO.Execute();
                response.Result = "Kupac uspešno izmenjen.";
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }
            return response;
        }

        private Response PrikaziApotekare(Request request)
        {
            Response response = new Response();
            try
            {
                PrikaziApotekareSO so = new PrikaziApotekareSO();
                so.Execute();
                if (so.Result != null && so.Result.Count > 0)
                {
                    response.Result = so.Result;
                }
                else
                {
                    response.Result = new List<Apotekar>();
                }
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }
            return response;
        }

        private Response PrikaziGradove(Request request)
        {
            Response response = new Response();
            try
            {
                PrikaziGradoveSO so = new PrikaziGradoveSO();
                so.Execute();
                if (so.Result != null && so.Result.Count > 0)
                {
                    response.Result = so.Result;
                }
                else
                {
                    response.Result = new List<Lokacija>();
                }
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }
            return response;
        }

        private Response PrikaziLekove(Request request)
        {
            Response response = new Response();
            try
            {
                PrikaziLekoveSO so = new PrikaziLekoveSO();
                so.Execute();
                if (so.Result != null && so.Result.Count > 0)
                {
                    response.Result = so.Result;
                }
                else
                {
                    response.Result = new List<Lek>();
                }
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }
            return response;
        }
        private Response PrikaziRacune(Request request)
        {
            Response response = new Response();
            try
            {
                PrikaziRacuneSO so = new PrikaziRacuneSO();
                so.Execute();
                if (so.Result != null && so.Result.Count > 0)
                {
                    response.Result = so.Result;
                }
                else
                {
                    response.Result = new List<Racun>();
                }
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }
            return response;
        }

        private Response PrikaziStavkeRacuna(Request request)
        {
            Response response = new Response();
            try
            {
                JsonElement jsonElement = (JsonElement)request.Argument;
                int idRacun = jsonElement.GetInt32();
                PrikaziStavkeRacunaSO so = new PrikaziStavkeRacunaSO(idRacun);
                so.Execute();
                if (so.Result != null && so.Result.Count > 0)
                {
                    response.Result = so.Result;
                }
                else
                {
                    response.Result = new List<StavkaRacuna>();
                }
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }
            return response;
        }

        private Response PrikaziRacun(Request request)
        {
            Response response = new Response();
            try
            {
                JsonElement jsonElement = (JsonElement)request.Argument;
                int idRacun = jsonElement.GetInt32();
                PrikazRacunaSO so = new PrikazRacunaSO(idRacun);
                so.Execute();
                if (so.Result != null)
                {
                    response.Result = so.Result;
                }
                else
                {
                    response.ExceptionMessage = "Račun nije pronađen.";
                    response.ExceptionType = "NotFoundException";
                }
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }
            return response;
        }
        private Response PrikaziLek(Request request)
        {
            Response response = new Response();
            try
            {
                JsonElement jsonElement = (JsonElement)request.Argument;
                int idLek = jsonElement.GetInt32();
                PrikaziLekSO so = new PrikaziLekSO(idLek);
                so.Execute();
                if (so.Result != null)
                {
                    response.Result = so.Result;
                }
                else
                {
                    response.ExceptionMessage = "Lek nije pronađen.";
                    response.ExceptionType = "NotFoundException";
                }
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }
            return response;
        }
        private Response VratiLekID(Request request)
        {
            Response response = new Response();
            try
            {
                JsonElement jsonElement = (JsonElement)request.Argument;
                int idRacun = jsonElement.GetProperty("IdRacun").GetInt32();
                int idStavka = jsonElement.GetProperty("IdStavkaRacuna").GetInt32();
                VratiLekIDSO so = new VratiLekIDSO(idRacun, idStavka);
                so.Execute();
                if (so.Result != null)
                {
                    response.Result = so.Result;
                }
                else
                {
                    response.ExceptionMessage = "Lek nije pronađen.";
                    response.ExceptionType = "NotFoundException";
                }
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }
            return response;
        }

        private Response KreirajRacun(Request request)
        {
            Response response = new Response();
            try
            {
                JsonElement jsonElement = (JsonElement)request.Argument;
                Racun racun = JsonSerializer.Deserialize<Racun>(jsonElement.GetRawText());
                KreirajRacunSO so = new KreirajRacunSO(racun);
                so.Execute();
                response.Result = "Račun uspešno kreiran.";
            }
            catch (Exception ex)
            {
                response.ExceptionMessage = ex.Message;
                response.ExceptionType = ex.GetType().Name;
            }
            return response;
        }

        private Response KreirajStavkuRacuna(Request request)
        {
            Response response = new Response();
            try
            {
                JsonElement jsonElement = (JsonElement)request.Argument;
                StavkaRacuna stavkaRacuna = JsonSerializer.Deserialize<StavkaRacuna>(jsonElement.GetRawText());
                KreirajStavkuRacunaSO so = new KreirajStavkuRacunaSO(stavkaRacuna);
                so.Execute();
                response.Result = "Stavka računa uspešno kreirana.";
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
