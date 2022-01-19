using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.StavkeCenovnikaSO
{
    public class PromeniStavkuSO : OpstaSistemskaOperacija
    {
        private StavkaCenovnika _stavka;
        public PromeniStavkuSO(StavkaCenovnika stavka)
        {
            _stavka = stavka;
        }
        protected override void Execute()
        {
            
            _stavka.Set = $" naziv_stavke = '{_stavka.NazivStavke}' , cena_sa_porezom= '{_stavka.CenaStavkeSaPDV}' ," +
                $" cena_bez_poreza ='{_stavka.CenaStavkeBezPDV}' , kategorija_id = '{_stavka.Kategorija.KategorijaID}'";
            _stavka.Where = $" stavka_cenovnika_id = '{_stavka.StavkaID}'";
            broker.Update(_stavka);
        }
    }
}
