using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.StavkeCenovnikaSO
{
    public class VratiSveKategorijeSO : OpstaSistemskaOperacija
    {
        public List<Kategorija> Rezultat { get; set; }
        protected override void Execute()
        {
            Rezultat = broker.VratiSveKategorije();
        }
    }
}
