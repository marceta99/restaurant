using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.PorudzbineOS
{
    public class DodajNovuPorudzbinuSO : OpstaSistemskaOperacija
    {
        Porudzbina _porudzbina;
        public DodajNovuPorudzbinuSO(Porudzbina porudzbina)
        {
            _porudzbina = porudzbina;
        }
        protected override void Execute()
        {
            int idNovePorudzbine = broker.DodajNovuPorudzbinu(_porudzbina);
            _porudzbina.PorudzbinaID = idNovePorudzbine;

            foreach (var narucenaStavka in _porudzbina.NaruceneStavke)
            {
                Porucivanje porucivanje = new Porucivanje
                {
                    Porudzbina = _porudzbina,
                    BrojPorcija = narucenaStavka.BrojNarucenihPorcija,
                    StavkaCenovnika = narucenaStavka.StavkaCenovnika
                };
                broker.DodajNovoPorucivanje(porucivanje);
            }
        }
    }
}
