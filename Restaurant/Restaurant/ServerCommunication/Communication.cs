using Common;
using Domain;
using Restaurant.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
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
            try
            {
                _socket.Connect("127.0.0.1", 9000);
            }
            catch (SocketException ex)
            {
                throw new ServerCommunicationException();
            }
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

        private void SendRequest(Operation operation, object requestObject = null)
        {
            try
            {
                Request request = new Request
                {
                    Operation = operation,
                    RequestObject = requestObject
                };
                _formatter.Serialize(_stream, request);
            }
            catch (IOException ex)
            {
                throw new ServerCommunicationException();
            }
        }
        private T GetResponse<T>()
        {   
            Response response = (Response)_formatter.Deserialize(_stream);
            if (response.IsSuccesfull)
            {
                return (T)response.ResponseObject;
            }
            else
            {
                throw new Exception();
                //throw new SystemOperationException(response.Message);
            }
        }
        private void GetResponseNoReturn()
        {
            Response response = (Response)_formatter.Deserialize(_stream);
            if (!response.IsSuccesfull)
            {
                //throw new SystemOperationException(response.Message);
            }

        }



        public Korisnik Login(Korisnik korisnik)
        {
            SendRequest(Operation.Login, korisnik);
            return GetResponse<Korisnik>();
        }
       

        #region Stolovi
        public List<Sto> VratiSveStolove()
        {
            SendRequest(Operation.VratiSveStolove);
            return GetResponse<List<Sto>>();
        }

        public List<Sto> VratiSveStoloveSaStatusomPorudzbine(StatusPorudzbine status)
        {
            SendRequest(Operation.VratiSveStoloveSaStatusomPorudzbine,status);
            return GetResponse<List<Sto>>();
        }

        public void DodajNoviSto(Sto noviSto)
        {
                SendRequest(Operation.DodajNoviSto, noviSto);
                GetResponseNoReturn();
            
        }

        public void IzbrisiSto(Sto sto)
        {
            SendRequest(Operation.IzbrisiSto, sto);
            GetResponseNoReturn();
        }

        public void IzmeniSto(Sto sto)
        {
            SendRequest(Operation.IzmeniSto, sto);
            GetResponseNoReturn();
        }

        public bool DaLiJeRezervisan(Sto sto)
        {
            
            SendRequest(Operation.DaLiJeRezervisanSto, sto);
            return GetResponse<bool>();
        }

        public void RezervisiSto(Sto sto)
        {
            SendRequest(Operation.RezervisiSto, sto);
            GetResponseNoReturn();   
        }

        public void OslobodiSto(Sto sto)
        {
            SendRequest(Operation.OslobodiSto, sto);
            GetResponseNoReturn();
        }
        #endregion

        #region StavkeCenovnika

        public List<StavkaCenovnika> VratiSveStavke()
        {
            SendRequest(Operation.VratiSveStavke);
            return GetResponse<List<StavkaCenovnika>>();
        }

        public List<StavkaCenovnika> VratiSveStavkeIzKategorije(Kategorija k)
        {
            
            SendRequest(Operation.VratiSveStavkeIzKategorije,k);
            return GetResponse<List<StavkaCenovnika>>();
        }


        public Array VratiSveValute()
        {
            
            SendRequest(Operation.VratiSveValute);
            return GetResponse<Array>();
           
        }

        public List<Kategorija> VratiSveKategorije()
        {
            
            SendRequest(Operation.VratiSveKategorije);
            return GetResponse<List<Kategorija>>();
            
        }

        public void DodajNovuStavku(StavkaCenovnika stavka)
        {
            SendRequest(Operation.DodajNovuStavku, stavka);
            GetResponseNoReturn();
                
            
        }

        public void ObrisiStavku(StavkaCenovnika stavka)
        {
            SendRequest(Operation.ObrisiStavku, stavka);
            GetResponseNoReturn();
        }

        public void IzmeniStavku(StavkaCenovnika stavka)
        {

            SendRequest(Operation.IzmeniStavku, stavka);
            GetResponseNoReturn();

        }


        #endregion

        #region Porudzbine

        public void DodajNovuPorudzbinu(Porudzbina porudzbina)
        {
            
            SendRequest(Operation.DodajNovuPorudzbinu, porudzbina);
            GetResponseNoReturn();
            
        }

        public List<Porudzbina> VratiSvePorudzbine()
        {
           
            SendRequest(Operation.VratiSvePorudzbine);
            return GetResponse<List<Porudzbina>>();  
        }

        public List<Porudzbina> VratiSvePorudzbineSaStola(Sto sto)
        {
            SendRequest(Operation.VratiSvePorudzbineSaStola,sto);
            return GetResponse<List<Porudzbina>>();
        }


        public void ObrisiPorudzbinu(Porudzbina porudzbina)
        {
  
            SendRequest(Operation.ObrisiPorudzbinu, porudzbina);
            GetResponseNoReturn();
        }

        public void DodajBrojPorcijaStarojStavci(Porucivanje porucivanje)
        {

            SendRequest(Operation.DodajBrojPorcijaStarojStavci, porucivanje);
            GetResponseNoReturn();
        }

        public void ObrisiPorucivanjeZaStavku(Porucivanje porucivanje)
        {

            SendRequest(Operation.ObrisiPorucivanjeZaStavku, porucivanje);
            GetResponseNoReturn();
        }

        public void DodajNovoPorucivanje(Porucivanje porucivanje)
        {
            SendRequest(Operation.DodajNovoPorucivanje, porucivanje);
            GetResponseNoReturn();
        }

        public void PromeniPorudzbinu(Porudzbina porudzbina)
        {
            SendRequest(Operation.PromeniPorudzbinu, porudzbina);
            GetResponseNoReturn();

        }



        #endregion
    }
}
