using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
   public class Kategorija : IDomainObjekat
    {

        public int KategorijaID { get; set; }

        public string NazivKategorije { get; set; }

        public string ImeTabele => "Kategorija";

        public string InsertVrednosti { get; set; }

        public string Id => "kategorija_id";

        public string Where => $"kategorija_id = '{KategorijaID}'";

        string IDomainObjekat.Where { get; set; }
        public string Set { get; set; }
        public string JoinTableName { get; set; }
        public string JoinFirst { get; set; }
        public string JoinSecond { get; set; }
        public string JoinSecondTableName { get; set; }
        public string JoinJoinON { get; set; }

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

        public IDomainObjekat ProctiajRedTabele(SqlDataReader reader)
        {
            Kategorija k = new Kategorija
            {
                KategorijaID = (int)reader["kategorija_id"],
                NazivKategorije = (string)reader["naziv_kategorije"]
            };
            return k;
        }
    }
}
