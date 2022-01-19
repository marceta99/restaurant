using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public string Id => "sto_id";

        //public string Where => $"sto_id = '{StoID}'";
        public string Where { get; set; }
        public string Set { get; set; }
        public string JoinTableName { get; set; }
        public string JoinFirst { get; set; }
        public string JoinSecond { get ; set; }
        public string JoinSecondTableName { get ; set; }
        public string JoinJoinON { get; set; }

        //public string Set => $" broj_stola = '{BrojStola}' , broj_stolica= '{BrojStolica}'";

        public IDomainObjekat ProctiajRedTabele(SqlDataReader reader)
        {
            Sto s = new Sto
            {
                StoID = (int)reader["sto_id"],
                BrojStola = (int)reader["broj_stola"],
                BrojStolica = (int)reader["broj_stolica"],
                Rezervisan = ((int)reader["rezervisan"]) == 1 ? true : false
            };
            return s;
        }

        public override string ToString()
        {
            return BrojStola.ToString();
        }
    }
}
