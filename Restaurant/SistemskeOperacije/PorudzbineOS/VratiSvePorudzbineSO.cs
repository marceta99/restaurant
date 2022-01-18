using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.PorudzbineOS
{
    public class VratiSvePorudzbineSO : OpstaSistemskaOperacija
    {
        public List<Porudzbina> Rezultat { get; set; }
        protected override void Execute()
        {
            List<Porudzbina> svePorudzbine = broker.VratiSvePorudzbine();

            foreach (var porudzbina in svePorudzbine)
            {
                porudzbina.NaruceneStavke = broker.VratiNaruceneStavkeIzPorudzbine(porudzbina.PorudzbinaID);
            }
            Rezultat = svePorudzbine;
        }
    }
}
