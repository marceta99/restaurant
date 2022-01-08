using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public enum Valuta
    {
        RSD,EUR,USD
    }
    [Serializable]
    public class StavkaCenovnika 
    {
        public int StavkaID { get; set; }

        public string NazivStavke { get; set; }

        public double CenaStavkeSaPDV { get; set; }
        public double CenaStavkeBezPDV { get; set; }

        public Valuta Valuta { get; set; }

        public Kategorija Kategorija { get; set; }

        public override string ToString()
        {
            return NazivStavke;
        }
        public override bool Equals(object obj)
        {
            if(obj is StavkaCenovnika sc)
            {
                return sc.StavkaID == this.StavkaID;
            }
            return false;
        }

    }
}
