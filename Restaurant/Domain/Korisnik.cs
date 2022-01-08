using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Korisnik
    {
        public int KorisnikID { get; set; }
        public string KorisnickoIme { get; set; }

        public string Sifra { get; set; }

        public string Email { get; set; }

        public Uloga Uloga { get; set; }
    }
}
