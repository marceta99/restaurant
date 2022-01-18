using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.PorudzbineOS
{
    public class VratiSvePorudzbineSaStolaSO : OpstaSistemskaOperacija
    {
        private Sto _sto;
        public List<Porudzbina> Rezultat { get; set; }
        public VratiSvePorudzbineSaStolaSO(Sto sto)
        {
            _sto = sto;
        }
        protected override void Execute()
        {
            Rezultat = broker.VratiSvePorudzbineSaStola(_sto);
        }
    }
}
