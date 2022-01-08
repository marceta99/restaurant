using ApplicationLogic;
using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerProject
{
   public class Server
    {

        private Socket _serverskiSoket;
        private  List<ClientHandler> _clients = new List<ClientHandler>(); //svi prijavljeni klijenti

        public Server()
        {
            _serverskiSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool Start()
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000);
                _serverskiSoket.Bind(endPoint);
                _serverskiSoket.Listen(10);
                return true; 

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

        }

        public void Listen()
        {
            try
            {
                
                while (true)//da bi mogli da imamo koliko god kljenata povezanih sa jednim serverom
                {
                    Socket klijentskiSocket = _serverskiSoket.Accept();
                    ClientHandler handler = new ClientHandler(klijentskiSocket, _clients); //za svakog klijenta kreira se poseban klijen handler
                    _clients.Add(handler);                                                            //tj za svaki klijentski soket se kreira poseban handler
                    Thread nitKlijenta = new Thread(handler.HandleRequest);
                    nitKlijenta.IsBackground = true;
                    nitKlijenta.Start();
                }
                
            }catch(SocketException ex) //hvata gresku ako kliknemo stop i zatvorimo serverski soket a ovaj listen i dalje radi
            {
                Debug.WriteLine(">>>" + ex.Message);
            }
        }

        public void Stop()
        {
            _serverskiSoket.Dispose(); //ovo Dispose ce u sustini da pozove metodu _serverskiSocket.Close(); tako da i to moze
            //ovim gore smo isljucivali serverski osluskujuci soket

            //a ovim dole iskljucujemo sve klijentske sokete koji su kreirani na serveru 
            List<ClientHandler> pomocnaLista = new List<ClientHandler>();
            foreach(var handler in _clients)
            {
                pomocnaLista.Add(handler);
            }

            foreach(var handler in pomocnaLista)
            {
                handler.CloseSocket();
            }
        
        
        }

    }
}
