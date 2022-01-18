using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Sto : IDomainObjekat
    {   
        public int StoID { get; set; }
        public int BrojStola { get; set; }
        public int BrojStolica { get; set; }
        public bool Rezervisan { get; set; }
        public string ImeTabele => "Sto";
        public string InsertVrednosti => $"'{BrojStola}','{BrojStolica}','{(Rezervisan ? 1 : 0)}'"; 

        public override string ToString()
        {
            return BrojStola.ToString();
        }
    }
}
