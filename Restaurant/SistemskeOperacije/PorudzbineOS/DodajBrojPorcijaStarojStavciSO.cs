using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.PorudzbineOS
{
    public class DodajBrojPorcijaStarojStavciSO : OpstaSistemskaOperacija
    {
        Porucivanje _porucivanje;
        public DodajBrojPorcijaStarojStavciSO(Porucivanje porucivanje)
        {
            _porucivanje = porucivanje; 
        }
        protected override void Execute()
        {
            
            _porucivanje.Set= $" broj_porcija = '{_porucivanje.BrojPorcija}'" ;
            _porucivanje.Where = $"porudzbina_id = '{_porucivanje.Porudzbina.PorudzbinaID}' AND " +
                $" stavka_cenovnika_id ='{_porucivanje.StavkaCenovnika.StavkaID}'";
            broker.Update(_porucivanje);
        }
    }
}
