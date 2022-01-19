using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.StoSO
{
    public class IzmeniStoSO : OpstaSistemskaOperacija
    {
        private Sto _sto;
        public IzmeniStoSO(Sto sto)
        {
            _sto = sto;
        }

        protected override void Execute()
        {
            _sto.Set = $" broj_stola ='{_sto.BrojStola}' , broj_stolica='{_sto.BrojStolica}'";
            _sto.Where = $" sto_id = '{_sto.StoID}'";
            broker.Update(_sto);
        }
    }
}
