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
            Porudzbina p = new Porudzbina
            {
                JoinTableName = "Sto",
                JoinFirst = "sto_id",
                JoinSecond = "sto_id",
                Where=$"prva.sto_id={_sto.StoID}"
            };
            List<Porudzbina> svePorudzbine = broker.SelectJoin(p).OfType<Porudzbina>().ToList();

            Porucivanje por = new Porucivanje
            {
                JoinTableName = "Stavka_Cenovnika",
                JoinFirst = "stavka_cenovnika_id",
                JoinSecond = "stavka_cenovnika_id",
                JoinSecondTableName = "Kategorija",
                JoinJoinON = "druga.kategorija_id=treca.kategorija_id"
            };
            foreach (var porudzbina in svePorudzbine)
            {
                por.Where = $"porudzbina_id = {porudzbina.PorudzbinaID}";
                porudzbina.NaruceneStavke = broker.SelectJoinJoin(por).OfType<NarucenaStavka>().ToList();
            }
            Rezultat = svePorudzbine;
        }
    }
}
