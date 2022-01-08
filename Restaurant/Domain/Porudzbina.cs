using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]

    public class Porudzbina
    {

        public int PorudzbinaID { get; set; }
        public double UkupnaVrednost { get; set; }
        public DateTime Datum { get; set; }

        public Sto Sto { get; set; }

        public List<NarucenaStavka> NaruceneStavke { get; set; }

        public StatusPorudzbine StatusPorudzbine { get; set; }





    }
}
