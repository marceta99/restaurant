using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
   public class Kategorija
    {

        public int KategorijaID { get; set; }

        public string NazivKategorije { get; set; }

        public override string ToString()
        {
            return NazivKategorije; 
        }
        public override bool Equals(object obj)
        {
            if(obj is Kategorija k) 
            {
                return k.KategorijaID == this.KategorijaID;
            }
            return false;
        }

    }
}
