using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ServerCommunication
{
    public class Communication
    {

        private Socket _socket;
        private BinaryFormatter _formatter;
        private NetworkStream _stream;

        private static Communication _instance; 

        private Communication()
        {
        }

        public static Communication Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Communication();
                }
                return _instance; 
            }
        }

        public void Connect()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect("127.0.0.1", 9000);
            //CommunicationHelper helper = new CommunicationHelper(_socket); da iskorisitm ovaj helper za slanje requesta 
            _stream = new NetworkStream(_socket); //i primanje responsa svugde dole gde imam serijilizaciju i desesrilizaicu
            _formatter = new BinaryFormatter(); //i i sto taj helper da iskoristim i kod servera za isto to

        }
        public void CloseConnection()
        {
            Request request = new Request()
            {
                Operation = Operation.KrajKlijenta
            };
            _formatter.Serialize(_stream, request);
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Dispose();


        }



        public Korisnik Login(Korisnik korisnik)
        {
            Request r = new Request
            {
                Operation = Operation.Login, 
                RequestObject = korisnik 
            };
            _formatter.Serialize(_stream, r);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (response.IsSuccesfull)
            {
                return (Korisnik)response.ResponseObject;
            }else
            {
                throw new Exception("Greska pri logovanju");
            }


        }
       

        #region Stolovi
        public List<Sto> VratiSveStolove()
        {
            Request request = new Request
            {
                Operation = Operation.VratiSveStolove
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (response.IsSuccesfull)
            {
                return (List<Sto>)response.ResponseObject;
            }
            else
            {
                throw new Exception("Greska pri vraćanju stolova");
            }
        }

        public List<Sto> VratiSveStoloveSaStatusomPorudzbine(StatusPorudzbine status)
        {
            Request request = new Request
            {
                Operation = Operation.VratiSveStoloveSaStatusomPorudzbine,
                RequestObject = status
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (response.IsSuccesfull)
            {
                return (List<Sto>)response.ResponseObject;
            }
            else
            {
                throw new Exception("Greska pri vraćanju stolova");
            }
        }

        public void DodajNoviSto(Sto noviSto)
        {
            
                Request request = new Request
                {
                    Operation = Operation.DodajNoviSto,
                    RequestObject = noviSto
                };
                _formatter.Serialize(_stream, request);

                Response response = (Response)_formatter.Deserialize(_stream);
                if (!response.IsSuccesfull)
                {
                    throw new Exception("Greska pri dodavanju stolova");
                }
            
        }

        public void IzbrisiSto(Sto sto)
        {
            {
                Request request = new Request
                {
                    Operation = Operation.IzbrisiSto,
                    RequestObject = sto
                };
                _formatter.Serialize(_stream, request);

                Response response = (Response)_formatter.Deserialize(_stream);
                if (!response.IsSuccesfull)
                {
                    throw new Exception("Greska pri brisanju stolova");
                }
            }
        }

        public void IzmeniSto(Sto sto)
        {
            {
                Request request = new Request
                {
                    Operation = Operation.IzmeniSto,
                    RequestObject = sto
                };
                _formatter.Serialize(_stream, request);

                Response response = (Response)_formatter.Deserialize(_stream);
                if (!response.IsSuccesfull)
                {
                    throw new Exception("Greska pri izmeni stolova");
                }
            }
        }

        public bool DaLiJeRezervisan(Sto sto)
        {
            Request request = new Request
            {
                Operation = Operation.DaLiJeRezervisanSto,
                RequestObject = sto
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (response.IsSuccesfull)
            {
                return (bool)response.ResponseObject;
            }
            else
            {
                throw new Exception("Greska pri operaciji provere");
            }
        }

        public void RezervisiSto(Sto sto)
        {
            
            Request request = new Request
            {
                Operation = Operation.RezervisiSto,
                RequestObject = sto
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (!response.IsSuccesfull)
            {
                throw new Exception("Greska pri rezervaciji stolova");
            }
            
        }

        public void OslobodiSto(Sto sto)
        {
            Request request = new Request
            {
                Operation = Operation.OslobodiSto,
                RequestObject = sto
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (!response.IsSuccesfull)
            {
                throw new Exception("Greska pri oslobadjanju stola");
            }
        }
        #endregion

        #region StavkeCenovnika

        public List<StavkaCenovnika> VratiSveStavke()
        {
            Request request = new Request
            {
                Operation = Operation.VratiSveStavke
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (response.IsSuccesfull)
            {
                return (List<StavkaCenovnika>)response.ResponseObject;
            }
            else
            {
                throw new Exception("Greska pri vraćanju stavki cenovnika");
            }
        }

        public List<StavkaCenovnika> VratiSveStavkeIzKategorije(Kategorija k)
        {
            Request request = new Request
            {
                Operation = Operation.VratiSveStavkeIzKategorije,
                RequestObject = k
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (response.IsSuccesfull)
            {
                return (List<StavkaCenovnika>)response.ResponseObject;
            }
            else
            {
                throw new Exception("Greska pri vraćanju stavki cenovnika");
            }
        }


        public Array VratiSveValute()
        {
            Request request = new Request
            {
                Operation = Operation.VratiSveValute
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (response.IsSuccesfull)
            {
                return (Array)response.ResponseObject;
            }
            else
            {
                throw new Exception("Greska pri vraćanju valuta");
            }
        }

        public List<Kategorija> VratiSveKategorije()
        {
            Request request = new Request
            {
                Operation = Operation.VratiSveKategorije
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (response.IsSuccesfull)
            {
                return (List<Kategorija>)response.ResponseObject;
            }
            else
            {
                throw new Exception("Greska pri vraćanju stavki cenovnika");
            }
        }

        public void DodajNovuStavku(StavkaCenovnika stavka)
        {
            
                Request request = new Request
                {
                    Operation = Operation.DodajNovuStavku,
                    RequestObject = stavka
                };
                _formatter.Serialize(_stream, request);

                Response response = (Response)_formatter.Deserialize(_stream);
                if (!response.IsSuccesfull)
                {
                    throw new Exception("Greska pri dodavanju stavke");
                }
            
        }

        public void ObrisiStavku(StavkaCenovnika stavka)
        {
            {
                Request request = new Request
                {
                    Operation = Operation.ObrisiStavku,
                    RequestObject = stavka
                };
                _formatter.Serialize(_stream, request);

                Response response = (Response)_formatter.Deserialize(_stream);
                if (!response.IsSuccesfull)
                {
                    throw new Exception("Greska pri brisanju stavke");
                }
            }
        }

        public void IzmeniStavku(StavkaCenovnika stavka)
        {
            
            Request request = new Request
            {
                Operation = Operation.IzmeniStavku,
                RequestObject = stavka
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (!response.IsSuccesfull)
            {
                throw new Exception("Greska pri izmeni stavki");
            }
            
        }


        #endregion

        #region Porudzbine

        public void DodajNovuPorudzbinu(Porudzbina porudzbina)
        {
            Request request = new Request
            {
                Operation = Operation.DodajNovuPorudzbinu,
                RequestObject = porudzbina
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (!response.IsSuccesfull)
            {
                throw new Exception("Greska pri dodavanju porudzbine");
            }
        }

        public List<Porudzbina> VratiSvePorudzbine()
        {
            Request request = new Request
            {
                Operation = Operation.VratiSvePorudzbine
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (response.IsSuccesfull)
            {
                return (List<Porudzbina>)response.ResponseObject;
            }
            else
            {
                throw new Exception("Greska pri vraćanju porudzbina");
            }
        }

        public List<Porudzbina> VratiSvePorudzbineSaStola(Sto sto)
        {
            Request request = new Request
            {
                Operation = Operation.VratiSvePorudzbineSaStola,
                RequestObject= sto
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (response.IsSuccesfull)
            {
                return (List<Porudzbina>)response.ResponseObject;
            }
            else
            {
                throw new Exception("Greska pri vraćanju porudzbina");
            }
        }


        public void ObrisiPorudzbinu(Porudzbina porudzbina)
        {
            {
                Request request = new Request
                {
                    Operation = Operation.ObrisiPorudzbinu,
                    RequestObject = porudzbina
                };
                _formatter.Serialize(_stream, request);

                Response response = (Response)_formatter.Deserialize(_stream);
                if (!response.IsSuccesfull)
                {
                    throw new Exception("Greska pri brisanju porudzbine");
                }
            }
        }

        public void DodajBrojPorcijaStarojStavci(Porucivanje porucivanje)
        {

            Request request = new Request
            {
                Operation = Operation.DodajBrojPorcijaStarojStavci,
                RequestObject = porucivanje
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (!response.IsSuccesfull)
            {
                throw new Exception("Greska pri izmeni porucivanja");
            }
        }

        public void ObrisiPorucivanjeZaStavku(Porucivanje porucivanje)
        {

            Request request = new Request
            {
                Operation = Operation.ObrisiPorucivanjeZaStavku,
                RequestObject = porucivanje
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (!response.IsSuccesfull)
            {
                throw new Exception("Greska pri brisanju porucivanja");
            }
        }

        public void DodajNovoPorucivanje(Porucivanje porucivanje)
        {
            Request request = new Request
            {
                Operation = Operation.DodajNovoPorucivanje,
                RequestObject = porucivanje
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (!response.IsSuccesfull)
            {
                throw new Exception("Greska pri dodavanju porucivanja");
            }
        }

        public void PromeniPorudzbinu(Porudzbina porudzbina)
        {

            Request request = new Request
            {
                Operation = Operation.PromeniPorudzbinu,
                RequestObject = porudzbina
            };
            _formatter.Serialize(_stream, request);

            Response response = (Response)_formatter.Deserialize(_stream);
            if (!response.IsSuccesfull)
            {
                throw new Exception("Greska pri izmeni porudzbine");
            }

        }



        #endregion
    }
}
