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
            Porucivanje porucivanje = new Porucivanje
            {
                Where = $" porudzbina_id ='{_porudzbina.PorudzbinaID}'"
            };
            broker.Delete(porucivanje);
            _porudzbina.Where = $" porudzbina_id ='{_porudzbina.PorudzbinaID}'";
            broker.Delete(_porudzbina);
            
        }
    }
}
