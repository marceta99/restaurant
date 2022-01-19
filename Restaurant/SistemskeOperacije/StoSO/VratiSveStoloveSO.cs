using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiSveStoloveSO : OpstaSistemskaOperacija
    {
        public List<Sto> Rezultat{ get;private set; }
        protected override void Execute()
        {
            Rezultat = broker.Select(new Sto()).OfType<Sto>().ToList();
        }
    }
}
