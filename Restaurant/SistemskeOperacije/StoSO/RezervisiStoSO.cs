using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.StoSO
{
    public class RezervisiStoSO : OpstaSistemskaOperacija
    {
        private Sto _sto;
        public RezervisiStoSO(Sto sto)
        {
            _sto = sto; 
        }

        protected override void Execute()
        {
            broker.RezervisiSto(_sto);
        }
    }
}
