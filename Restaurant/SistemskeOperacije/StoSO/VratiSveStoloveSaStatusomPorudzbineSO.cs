using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiSveStoloveSaStatusomPorudzbineSO : OpstaSistemskaOperacija
    {
        private StatusPorudzbine _status;
        public List<Sto> Rezultat { get; private set; }

        public VratiSveStoloveSaStatusomPorudzbineSO(StatusPorudzbine status)
        {
            _status = status;
        }

        protected override void Execute()
        {
            Sto sto = new Sto()
            {
                JoinTableName = "Porudzbina",
                JoinFirst = "sto_id",
                JoinSecond = "sto_id",
                Where = $"druga.status_porudzbine = '{(int)_status}'"
            };
            Rezultat = broker.SelectJoin(sto).OfType<Sto>().ToList();
        }
    }
}
