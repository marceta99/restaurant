using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.StoSO
{
    public class OslobodiStoSO : OpstaSistemskaOperacija
    {
        private Sto _sto;
        public OslobodiStoSO(Sto sto)
        {
            _sto = sto; 
        }

        protected override void Execute()
        {
            _sto.Set = $" rezervisan = '{0}'";
            _sto.Where = $" sto_id = '{_sto.StoID}'";
            broker.Update(_sto);
        }
    }
}
