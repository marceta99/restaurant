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
            broker.PromeniStavku(_stavka);
        }
    }
}
