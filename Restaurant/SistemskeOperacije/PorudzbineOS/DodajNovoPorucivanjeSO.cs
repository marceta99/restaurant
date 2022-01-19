using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.PorudzbineOS
{
    public class DodajNovoPorucivanjeSO : OpstaSistemskaOperacija
    {
        private Porucivanje _porucivanje;
        public DodajNovoPorucivanjeSO(Porucivanje porucivanje)
        {
            _porucivanje = porucivanje;
        }

        protected override void Execute()
        {
            broker.Insert(_porucivanje);
        }
    }
}
