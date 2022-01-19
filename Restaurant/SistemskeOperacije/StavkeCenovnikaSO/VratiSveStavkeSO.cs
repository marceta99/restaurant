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
            StavkaCenovnika stavka = new StavkaCenovnika();
            stavka.JoinTableName = "Kategorija";
            stavka.JoinFirst = "kategorija_id";
            stavka.JoinSecond = "kategorija_id";
            Rezultat = broker.SelectJoinWithoutWhere(stavka).OfType<StavkaCenovnika>().ToList();
        }
    }
}
