using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Korisnik : IDomainObjekat
    {
        public int KorisnikID { get; set; }
        public string KorisnickoIme { get; set; }

        public string Sifra { get; set; }

        public string Email { get; set; }

        public Uloga Uloga { get; set; }

        public string ImeTabele => "Korisnik";

        public string InsertVrednosti { get; set; }

        public string Id{get ; set;}

        public string Where { get; set; }
        public string Set { get; set; }
        public string JoinTableName { get; set; }
        public string JoinFirst { get; set; }
        public string JoinSecond { get; set; }
        public string JoinSecondTableName { get; set; }
        public string JoinJoinON { get; set; }

        public IDomainObjekat ProctiajRedTabele(SqlDataReader reader)
        {
            Korisnik k = new Korisnik
            {
                KorisnikID = (int)reader["korisnik_id"],
                KorisnickoIme = (string)reader["korisnicko_ime"],
                Sifra = (string)reader["sifra"],
                Email = (string)reader["email"],
                Uloga = (Uloga)((int)reader["uloga_id"])
            };
            return k; 
        }
    }
}
