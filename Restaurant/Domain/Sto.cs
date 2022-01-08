using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Sto
    {   
        public int StoID { get; set; }
        public int BrojStola { get; set; }
        public int BrojStolica { get; set; }
        public bool Rezervisan { get; set; }

        public override string ToString()
        {
            return BrojStola.ToString();
        }
    }
}
