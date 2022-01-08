using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic
{
    public class Controller
    {
        private static Controller _instance;
        private bool _isKonobar;
        private bool _isMenadzer;
        private Controller()
        {
           
        }
        public static Controller Instance
        {
            get 
            {
                if(_instance == null)
                {
                    _instance = new Controller();
                }
                return _instance;
            }
        }

        public bool IsKonobar {
            get
            {
                return _isKonobar;
            }
        }
        public bool IsMenadzer
        {
            get
            {
                return _isMenadzer; 
            }
        }


        public Korisnik Login(string korisnickoIme, string sifra)
        {
            Broker broker = new Broker();

            try
            {
                broker.OpenConnection();

                List<Korisnik> korisnici = broker.VratiSveKorisnike();

                foreach (var korisnik in korisnici)
                {
                    if (korisnik.KorisnickoIme == korisnickoIme && korisnik.Sifra == sifra)
                    {
                        _isKonobar = korisnik.Uloga == Uloga.Konobar ? true : false;
                        _isMenadzer = !_isKonobar;
                        return korisnik;
                    }
                }
                return null;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        #region Stolovi
        public List<Sto> VratiSveStolove()
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            List<Sto> stolovi = broker.VratiSveStolove();
            broker.CloseConnection();

            return stolovi;             
        }
        public List<Sto> VratiSveStoloveSaStatusomPorudzbine(StatusPorudzbine status)
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            List<Sto> stolovi = broker.VratiSveStoloveSaStatusomPorudzbine(status);
            broker.CloseConnection();

            return stolovi;
        }
        public void ObrisiSto(Sto sto)
        {
            Broker broker = new Broker();
            broker.OpenConnection();

            try
            {
                broker.ObrisiSto(sto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void DodajNoviSto(Sto sto)
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            broker.DodajNoviSto(sto);

            broker.CloseConnection();
        }
        public void IzmeniSto(Sto sto)
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            broker.IzmeniSto(sto);

            broker.CloseConnection();
        }

        public void RezervisiSto(Sto sto)
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            broker.RezervisiSto(sto);

            broker.CloseConnection();
        }
        public void OslobodiSto(Sto sto)
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            broker.OslobodiSto(sto);

            broker.CloseConnection();
        }
        public bool DaLiJeRezervisan(Sto sto)
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            bool daLiJeRezervisan = broker.DaLiJeRezervisanSto(sto);

            broker.CloseConnection();

            return daLiJeRezervisan; 
        }

        
        #endregion

        #region Stavke Cenovnika
        public void DodajNovuStavku(StavkaCenovnika stavka)
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            broker.DodajNovuStavku(stavka);

            broker.CloseConnection();
        }
        public void ObrisiStavku(StavkaCenovnika stavka)
        {
            Broker broker = new Broker();
            broker.OpenConnection();

            broker.ObrisiStaku(stavka);

            broker.CloseConnection();
        }
        public void IzmeniStavku(StavkaCenovnika stavka)
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            broker.PromeniStavku(stavka);

            broker.CloseConnection();
        }
        public List<StavkaCenovnika> VratiSveStavke()
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            List<StavkaCenovnika> stavke = broker.VratiSveStavke();
            
            broker.CloseConnection();
            return stavke;

        }
        public List<StavkaCenovnika> VratiSveStavkeIzKategorije(Kategorija k)
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            List<StavkaCenovnika> stavke = broker.VratiSveStavkeIZKategorije(k);

            broker.CloseConnection();
            return stavke;

        }
        public List<Kategorija> VratiSveKategorije()
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            List<Kategorija> kategorije = broker.VratiSveKategorije();

            broker.CloseConnection();
            return kategorije;

        }

        public Array VratiSveValute()
        {
            return Enum.GetValues(typeof(Valuta));
        }

        #endregion

        #region Porudzbine
        public void DodajNovuPorudzbinu(Porudzbina porudzbina)
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            int idNovePorudzbine = broker.DodajNovuPorudzbinu(porudzbina);
            porudzbina.PorudzbinaID = idNovePorudzbine; 
            broker.CloseConnection();

            broker.OpenConnection();

            foreach (var narucenaStavka in porudzbina.NaruceneStavke)
            {
                Porucivanje porucivanje = new Porucivanje
                {
                    Porudzbina = porudzbina,
                    BrojPorcija = narucenaStavka.BrojNarucenihPorcija,
                    StavkaCenovnika = narucenaStavka.StavkaCenovnika
                };
                broker.DodajNovoPorucivanje(porucivanje);
            }

            broker.CloseConnection();
        }

        public List<Porudzbina> VratiSvePorudzbine()
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            List<Porudzbina> svePorudzbine = broker.VratiSvePorudzbine();

            foreach(var porudzbina in svePorudzbine)
            {
                porudzbina.NaruceneStavke = broker.VratiNaruceneStavkeIzPorudzbine(porudzbina.PorudzbinaID);
            }

            broker.CloseConnection();
            return svePorudzbine;
        }

        public void ObrisiPorudzbinu(Porudzbina porudzbina)
        {

            Broker broker = new Broker();

            broker.OpenConnection();

            broker.ObrisiPorucivanje(porudzbina);


            broker.CloseConnection();

            broker.OpenConnection();

            broker.ObrisiPorudzbinu(porudzbina);

            broker.CloseConnection();


        }

        public void DodajBrojPorcijaStarojStavci(Porucivanje porucivanje)
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            broker.DodajBrojPorcijaStaojStavciStareStavkeUPorudzbini(porucivanje);


            broker.CloseConnection();
        }

        public void PromeniPorudzbinu(Porudzbina porudzbina)
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            broker.PromeniPorudzbinu(porudzbina);


            broker.CloseConnection();

        }
        public void DodajNovoPorucivanje(Porucivanje porucivanje)
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            broker.DodajNovoPorucivanje(porucivanje);

            broker.CloseConnection();
        }

        public void ObrisiPorucivanjeZaStavku(Porucivanje porucivanje)
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            broker.ObrisiPorucivanjeZaStavku(porucivanje);

            broker.CloseConnection();
        }
        public List<Porudzbina> VratiSvePorudzbineSaStola(Sto sto)
        {
            Broker broker = new Broker();

            broker.OpenConnection();

            List<Porudzbina>listaPorudzina = broker.VratiSvePorudzbineSaStola(sto);

            broker.CloseConnection();

            return listaPorudzina;
        }

        #endregion
    }
}
