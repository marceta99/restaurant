using DatabaseBroker;
using Domain;
using SistemskeOperacije;
using SistemskeOperacije.LoginSO;
using SistemskeOperacije.PorudzbineOS;
using SistemskeOperacije.StavkeCenovnikaSO;
using SistemskeOperacije.StoSO;
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
        private static object _lockObject = new object(); //ovaj lock objekat ce da obezbedi thread safety ovog singletona
        private Controller()
        {   
        }
        public static Controller Instance
        {
            get 
            {
                if (_instance == null) //ovo se zove Double-checked locking i omoguava thread safety singletona u C#
                {
                    lock (_lockObject) //dodali smo jos jedan if gore zbog performansi jer necemo da se stalno koristi ovaj lock
                    {                           //vec samo prvi put kada je instanca null .
                        if (_instance == null)
                        {
                            _instance = new Controller();
                        }
                    }
                }
                return _instance;
            }
        }

        public Korisnik Login(string korisnickoIme, string sifra)
        {
            OpstaSistemskaOperacija so = new LoginSO(korisnickoIme,sifra);
            so.ExecuteTemplate();
            return ((LoginSO)so).Rezultat;

            
        }

        #region Stolovi
        public List<Sto> VratiSveStolove()
        {
            OpstaSistemskaOperacija so = new VratiSveStoloveSO();
            so.ExecuteTemplate();
            return ((VratiSveStoloveSO)so).Rezultat;
        }
        public List<Sto> VratiSveStoloveSaStatusomPorudzbine(StatusPorudzbine status)
        {
            OpstaSistemskaOperacija so = new VratiSveStoloveSaStatusomPorudzbineSO(status);
            so.ExecuteTemplate();
            return ((VratiSveStoloveSaStatusomPorudzbineSO)so).Rezultat;
        }
        public void ObrisiSto(Sto sto)
        {
            OpstaSistemskaOperacija so = new ObrisiStoSO(sto);
            so.ExecuteTemplate();
        }

        public void DodajNoviSto(Sto sto)
        {
            OpstaSistemskaOperacija so = new DodajNoviStoSO(sto);
            so.ExecuteTemplate();
        }
        public void IzmeniSto(Sto sto)
        {
            OpstaSistemskaOperacija so = new IzmeniStoSO(sto);
            so.ExecuteTemplate();
        }

        public void RezervisiSto(Sto sto)
        {
            OpstaSistemskaOperacija so = new RezervisiStoSO(sto);
            so.ExecuteTemplate();
        }
        public void OslobodiSto(Sto sto)
        {
            OpstaSistemskaOperacija so = new OslobodiStoSO(sto);
            so.ExecuteTemplate();
        }
        public bool DaLiJeRezervisan(Sto sto)
        {
            OpstaSistemskaOperacija so = new DaLiJeRezervisanStoSO(sto);
            so.ExecuteTemplate();
            return ((DaLiJeRezervisanStoSO)so).Rezultat;
        }

        
        #endregion

        #region Stavke Cenovnika
        public void DodajNovuStavku(StavkaCenovnika stavka)
        {
            OpstaSistemskaOperacija so = new DodajNovuStavkuSO(stavka);
            so.ExecuteTemplate();
        }
        public void ObrisiStavku(StavkaCenovnika stavka)
        {
            OpstaSistemskaOperacija so = new ObrisiStavkuSO(stavka);
            so.ExecuteTemplate();
        }
        public void IzmeniStavku(StavkaCenovnika stavka)
        {
            OpstaSistemskaOperacija so = new PromeniStavkuSO(stavka);
            so.ExecuteTemplate();
        }
        public List<StavkaCenovnika> VratiSveStavke()
        {

            OpstaSistemskaOperacija so = new VratiSveStavkeSO();
            so.ExecuteTemplate();
            return ((VratiSveStavkeSO)so).Rezultat;
        }
        public List<StavkaCenovnika> VratiSveStavkeIzKategorije(Kategorija k)
        {
            OpstaSistemskaOperacija so = new VratiSveStavkeIzKategorijeSO(k);
            so.ExecuteTemplate();
            return ((VratiSveStavkeIzKategorijeSO)so).Rezultat;

        }
        public List<Kategorija> VratiSveKategorije()
        {
            OpstaSistemskaOperacija so = new VratiSveKategorijeSO();
            so.ExecuteTemplate();
            return ((VratiSveKategorijeSO)so).Rezultat;
        }
        public Array VratiSveValute()
        {
            return Enum.GetValues(typeof(Valuta));
        }

        #endregion

        #region Porudzbine
        public void DodajNovuPorudzbinu(Porudzbina porudzbina)
        {
            OpstaSistemskaOperacija so = new DodajNovuPorudzbinuSO(porudzbina);
            so.ExecuteTemplate();
        }

        public List<Porudzbina> VratiSvePorudzbine()
        {
            OpstaSistemskaOperacija so = new VratiSvePorudzbineSO();
            so.ExecuteTemplate();
            return ((VratiSvePorudzbineSO)so).Rezultat;
        }

        public void ObrisiPorudzbinu(Porudzbina porudzbina)
        {

            OpstaSistemskaOperacija so = new ObrisiPorudzbinuSO(porudzbina);
            so.ExecuteTemplate();
        }

        public void DodajBrojPorcijaStarojStavci(Porucivanje porucivanje)
        {
            OpstaSistemskaOperacija so = new DodajBrojPorcijaStarojStavciSO(porucivanje);
            so.ExecuteTemplate();
        }

        public void PromeniPorudzbinu(Porudzbina porudzbina)
        {
            OpstaSistemskaOperacija so = new PromeniPorudzbinuSO(porudzbina);
            so.ExecuteTemplate();

        }
        public void DodajNovoPorucivanje(Porucivanje porucivanje)
        {
            OpstaSistemskaOperacija so = new DodajNovoPorucivanjeSO(porucivanje);
            so.ExecuteTemplate();
        }

        public void ObrisiPorucivanjeZaStavku(Porucivanje porucivanje)
        {
            OpstaSistemskaOperacija so = new ObrisiPorucivanjeZaStavkuSO(porucivanje);
            so.ExecuteTemplate();
        }
        public List<Porudzbina> VratiSvePorudzbineSaStola(Sto sto)
        {
            OpstaSistemskaOperacija so = new VratiSvePorudzbineSaStolaSO(sto);
            so.ExecuteTemplate();
            return ((VratiSvePorudzbineSaStolaSO)so).Rezultat;
        }

        #endregion
    }
}
