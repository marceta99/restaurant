using ApplicationLogic;
using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject
{
   public class ClientHandler
    {
        private Socket klijentskiSocket;
        private bool _kraj;
        private List<ClientHandler> _clients;
        public ClientHandler(Socket klijentskiSocket, List<ClientHandler> clients)
        {
            this.klijentskiSocket = klijentskiSocket;
            this._clients = clients;
        }

        public void HandleRequest()
        {
            NetworkStream stream = new NetworkStream(klijentskiSocket);
            BinaryFormatter formatter = new BinaryFormatter();
            _kraj = false;

            try
            {
                while (!_kraj)
                {
                    Request request = (Request)formatter.Deserialize(stream);
                    Response response = new Response();

                    switch (request.Operation)
                    {
                        case Operation.Login:
                            try
                            {
                                Korisnik k = (Korisnik)request.RequestObject;
                                response.ResponseObject = Controller.Instance.Login(k.KorisnickoIme, k.Sifra);
                                response.Message = "Korisnik je ulogovan";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.VratiSveStolove:
                            try
                            {
                                response.ResponseObject = Controller.Instance.VratiSveStolove();
                                response.Message = "Vraćeni su svi stolovi";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.VratiSveStoloveSaStatusomPorudzbine:
                            try
                            {
                                response.ResponseObject = Controller.Instance.VratiSveStoloveSaStatusomPorudzbine((StatusPorudzbine)request.RequestObject);
                                response.Message = "Vraćeni su svi stolovi";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.DodajNoviSto:
                            try
                            {
                                Controller.Instance.DodajNoviSto((Sto)request.RequestObject);
                                response.Message = "Dodat novi sto";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.IzmeniSto:
                            try
                            {
                                Controller.Instance.IzmeniSto((Sto)request.RequestObject);
                                response.Message = "sto izmenjen";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.IzbrisiSto:
                            try
                            {
                                Controller.Instance.ObrisiSto((Sto)request.RequestObject);
                                response.Message = "Obrisan sto";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.DaLiJeRezervisanSto:
                            try
                            {
                                response.ResponseObject = Controller.Instance.DaLiJeRezervisan((Sto)request.RequestObject);
                                response.Message = "Rezervisan ili ne";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.RezervisiSto:
                            try
                            {
                                Controller.Instance.RezervisiSto((Sto)request.RequestObject);
                                response.Message = "Rezervisan sto";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.OslobodiSto:
                            try
                            {
                                Controller.Instance.OslobodiSto((Sto)request.RequestObject);
                                response.Message = "Oslobodjen sto";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.VratiSveStavke:
                            try
                            {
                                response.ResponseObject = Controller.Instance.VratiSveStavke();
                                response.Message = "Vraćeni su sve stavke";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.VratiSveStavkeIzKategorije:
                            try
                            {
                                response.ResponseObject = Controller.Instance.VratiSveStavkeIzKategorije((Kategorija)request.RequestObject);
                                response.Message = "Vraćeni su stavke iz kategorije";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.VratiSveKategorije:
                            try
                            {
                                response.ResponseObject = Controller.Instance.VratiSveKategorije();
                                response.Message = "Vraćeni su sve kategorije";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.VratiSveValute:
                            try
                            {
                                response.ResponseObject = Controller.Instance.VratiSveValute();
                                response.Message = "Vraćeni su sve valute";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.DodajNovuStavku:
                            try
                            {
                                Controller.Instance.DodajNovuStavku((StavkaCenovnika)request.RequestObject);
                                response.Message = "Dodata nova stavku";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.ObrisiStavku:
                            try
                            {
                                Controller.Instance.ObrisiStavku((StavkaCenovnika)request.RequestObject);
                                response.Message = "Obrisana stavka";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.IzmeniStavku:
                            try
                            {
                                Controller.Instance.IzmeniStavku((StavkaCenovnika)request.RequestObject);
                                response.Message = "stavka izmenjena";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.DodajNovuPorudzbinu:
                            try
                            {
                                Controller.Instance.DodajNovuPorudzbinu((Porudzbina)request.RequestObject);
                                response.Message = "Dodata nova porudzbina";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.DodajNovoPorucivanje:
                            try
                            {
                                Controller.Instance.DodajNovoPorucivanje((Porucivanje)request.RequestObject);
                                response.Message = "Dodato novo porucivanje";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.VratiSvePorudzbine:
                            try
                            {
                                response.ResponseObject = Controller.Instance.VratiSvePorudzbine();
                                response.Message = "Vraćene su sve porudzbine";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.VratiSvePorudzbineSaStola:
                            try
                            {
                                response.ResponseObject = Controller.Instance.VratiSvePorudzbineSaStola((Sto)request.RequestObject);
                                response.Message = "Vraćene su sve porudzbine sa stola";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.ObrisiPorudzbinu:
                            try
                            {
                                Controller.Instance.ObrisiPorudzbinu((Porudzbina)request.RequestObject);
                                response.Message = "Obrisana porudzbina";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.DodajBrojPorcijaStarojStavci:
                            try
                            {
                                Controller.Instance.DodajBrojPorcijaStarojStavci((Porucivanje)request.RequestObject);
                                response.Message = "porcuvianje izmenjeno";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.ObrisiPorucivanjeZaStavku:
                            try
                            {
                                Controller.Instance.ObrisiPorucivanjeZaStavku((Porucivanje)request.RequestObject);
                                response.Message = "porcuvianje obrisano";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.PromeniPorudzbinu:
                            try
                            {
                                Controller.Instance.PromeniPorudzbinu((Porudzbina)request.RequestObject);
                                response.Message = "porudzbina izmenjena";
                                response.IsSuccesfull = true;
                            }
                            catch (Exception ex)
                            {
                                response.IsSuccesfull = false;
                                response.Message = ex.Message;
                            }
                            formatter.Serialize(stream, response);
                            break;
                        case Operation.KrajKlijenta:
                            CloseSocket();
                            break;
                        default:
                            break;
                    }




                }
            }catch(IOException ex)
            {
                Debug.WriteLine(">>>" + ex.Message);
            }
            finally
            {
                if (klijentskiSocket != null)
                {
                    CloseSocket();  //u svakom slucaju trebamo da zatvorimo sokete i ako je pukla greska i ako se zavrsilo okej     
                }
                
            }
        }

        internal void CloseSocket()
        {
            if (klijentskiSocket != null) //ako je klijentski soket vec zatvoren ne zatvaraj ga vise puta
            {
                _clients.Remove(this); //sklanjamo klijenta iz liste prijavljenih klijenata 
                _kraj = true;
                klijentskiSocket.Shutdown(SocketShutdown.Both);
                klijentskiSocket.Close();
                klijentskiSocket = null;
            }
        }
    }
}
