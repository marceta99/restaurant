using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.PorudzbineOS
{
    public class ObrisiPorucivanjeZaStavkuSO : OpstaSistemskaOperacija
    {
        private Porucivanje _porucivanje;
        public ObrisiPorucivanjeZaStavkuSO(Porucivanje porucivanje)
        {
            _porucivanje = porucivanje; 
        }
        protected override void Execute()
        {
            broker.ObrisiPorucivanjeZaStavku(_porucivanje);
        }
    }
}
