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
            broker.DodajBrojPorcijaStaojStavciStareStavkeUPorudzbini(_porucivanje);
        }
    }
}
