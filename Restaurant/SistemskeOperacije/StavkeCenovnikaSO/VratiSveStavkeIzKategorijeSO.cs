using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.StavkeCenovnikaSO
{
    public class VratiSveStavkeIzKategorijeSO : OpstaSistemskaOperacija
    {
        private Kategorija _kategorija;
        public List<StavkaCenovnika> Rezultat { get; set; }

        public VratiSveStavkeIzKategorijeSO(Kategorija kategorija)
        {
            _kategorija = kategorija;
        }
        protected override void Execute()
        {
            Rezultat = broker.VratiSveStavkeIZKategorije(_kategorija);
        }
    }
}
