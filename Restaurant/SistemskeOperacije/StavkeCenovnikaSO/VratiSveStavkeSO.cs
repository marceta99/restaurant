using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.StavkeCenovnikaSO
{
    public class VratiSveStavkeSO : OpstaSistemskaOperacija
    {
        public List<StavkaCenovnika> Rezultat { get; set; }

        protected override void Execute()
        {
            Rezultat = broker.VratiSveStavke();
        }
    }
}
