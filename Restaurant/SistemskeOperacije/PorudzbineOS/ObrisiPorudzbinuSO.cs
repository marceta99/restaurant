using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.PorudzbineOS
{
    public class ObrisiPorudzbinuSO : OpstaSistemskaOperacija
    {
        private Porudzbina _porudzbina;
        public ObrisiPorudzbinuSO(Porudzbina porudzbina)
        {
            _porudzbina = porudzbina;
        }
        protected override void Execute()
        {
            broker.ObrisiPorucivanje(_porudzbina);
            broker.ObrisiPorudzbinu(_porudzbina);
        }
    }
}
