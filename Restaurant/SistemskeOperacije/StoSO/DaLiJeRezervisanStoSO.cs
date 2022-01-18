using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.StoSO
{
    public class DaLiJeRezervisanStoSO : OpstaSistemskaOperacija
    {
        private Sto _sto;
        public bool Rezultat { get; private set; }
        public DaLiJeRezervisanStoSO(Sto sto)
        {
            _sto = sto; 
        }

        protected override void Execute()
        {
            Rezultat = broker.DaLiJeRezervisanSto(_sto); ;
        }
    }
}
