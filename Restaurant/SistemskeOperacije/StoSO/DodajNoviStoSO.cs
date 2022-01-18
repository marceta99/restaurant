using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class DodajNoviStoSO : OpstaSistemskaOperacija
    {
        private Sto _sto;
        public DodajNoviStoSO(Sto sto)
        {
            _sto = sto; 
        }

        protected override void Execute()
        {
            broker.Insert(_sto);
        }
    }
}
