using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CommunicationHelper
    {
        private Socket _socket;
        private NetworkStream _stream;
        private BinaryFormatter _formatter;

        public CommunicationHelper(Socket socket)
        {
            _socket = socket;
            _stream = new NetworkStream(_socket);
            _formatter = new BinaryFormatter();
        }

        public void Send<T> (T obj) where T: class
        {
            _formatter.Serialize(_stream, obj);
        }
        public T Revice<T>() where T : class
        {
            return (T)_formatter.Deserialize(_stream);
        }




    }
}
