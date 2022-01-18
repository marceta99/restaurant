using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.StavkeCenovnikaSO
{
    public class ObrisiStavkuSO : OpstaSistemskaOperacija
    {
        private StavkaCenovnika _stavka;
        public ObrisiStavkuSO(StavkaCenovnika stavka)
        {
            _stavka = stavka;
        }

        protected override void Execute()
        {
            broker.ObrisiStaku(_stavka);
        }
    }
}

