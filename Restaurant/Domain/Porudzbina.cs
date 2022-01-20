using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]

    public class Porudzbina : IDomainObjekat
    {

        public int PorudzbinaID { get; set; }
        public double UkupnaVrednost { get; set; }
        public DateTime Datum { get; set; }

        public Sto Sto { get; set; }

        public List<NarucenaStavka> NaruceneStavke { get; set; }

        public StatusPorudzbine StatusPorudzbine { get; set; }

        public string ImeTabele => "Porudzbina";

        public string InsertVrednosti => $"'{UkupnaVrednost}','{Datum.ToString("yyyy-MM-dd HH:mm:ss")}','{Sto.StoID}','{(int)StatusPorudzbine.Kreirana}'";

        public string Id => "porudzbina_id";

        public string Where { get; set; }
        public string Set { get; set; }
        public string JoinTableName { get; set; }
        public string JoinFirst { get; set; }
        public string JoinSecond { get; set; }
        public string JoinSecondTableName { get; set; }
        public string JoinJoinON { get; set; }

        //public string Where => $" porudzbina_id ='{PorudzbinaID}'";
        //public string Set => $" ukupna_vrednost = '{UkupnaVrednost}' , status_porudzbine ='{(int)StatusPorudzbine}' ";

        public IDomainObjekat ProctiajRedTabele(SqlDataReader reader)
        {
            Porudzbina p = new Porudzbina
            {
                PorudzbinaID = (int)reader["porudzbina_id"],
                UkupnaVrednost = (double)reader["ukupna_vrednost"],
                Datum = (DateTime)reader["datum"],
                Sto = new Sto
                {
                    StoID = (int)reader["sto_id"],
                    BrojStola=(int)reader["broj_stola"],
                    BrojStolica=(int)reader["broj_stolica"],
                    Rezervisan = ((int)reader["rezervisan"]) == 1 ? true : false
                },
                
                //Sto = VratiStoSaId((int)reader["sto_id"]),
                //NaruceneStavke = VratiNaruceneStavkeIzPorudzbine((int)reader["porudzbina_id"]),
                StatusPorudzbine = (StatusPorudzbine)((int)reader["status_porudzbine"])

            };
            return p;
        }
    }
}
