using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Porucivanje
    {

        public Porudzbina Porudzbina { get; set; }

        public StavkaCenovnika StavkaCenovnika { get; set; }

        public int BrojPorcija { get; set; }


    }
}
