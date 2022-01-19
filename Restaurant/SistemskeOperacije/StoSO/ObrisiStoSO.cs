using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
   public class ObrisiStoSO : OpstaSistemskaOperacija
    {
        private Sto _sto;
        public ObrisiStoSO(Sto sto)
        {
            _sto = sto; 
        }

        protected override void Execute()
        {
            _sto.Where = $" sto_id = '{_sto.StoID}'";
            broker.Delete(_sto);
        }
    }
}
