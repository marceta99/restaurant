using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.StavkeCenovnikaSO
{
    public class DodajNovuStavkuSO : OpstaSistemskaOperacija
    {
        private StavkaCenovnika _stavka;
        public DodajNovuStavkuSO(StavkaCenovnika stavkaCenovnika)
        {
            _stavka = stavkaCenovnika;
        }

        protected override void Execute()
        {
            broker.Insert(_stavka);
        }
    }
}
