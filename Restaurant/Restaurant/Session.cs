using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Session
    {
        private static Session _instance;
        private static object lockObject = new object();
        private Session()
        {

        }
        public static Session Instance {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new Session();
                        }

                    }
                }
                return _instance;
            }
        
        }
        public Korisnik TrenutniKorisnik { get; set; }
    }
}
