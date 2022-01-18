using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.LoginSO
{
    public class LoginSO : OpstaSistemskaOperacija
    {
        private string _korisnickoIme;
        private string _sifra;

        public Korisnik Rezultat { get; set; }
        public LoginSO(string korisnickoIme, string sifra)
        {
            _korisnickoIme = korisnickoIme;
            _sifra = sifra;
        }

        protected override void Execute()
        {

            List<Korisnik> korisnici = broker.VratiSveKorisnike();
            Rezultat = null;
            foreach (var korisnik in korisnici)
            {
                if (korisnik.KorisnickoIme == _korisnickoIme && korisnik.Sifra == _sifra)
                {
                    Rezultat = korisnik;
                }
            }
            
        }
    }
}
