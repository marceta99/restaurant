using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class StavkaCenovnika : IDomainObjekat
    {
        public int StavkaID { get; set; }

        public string NazivStavke { get; set; }

        public double CenaStavkeSaPDV { get; set; }
        public double CenaStavkeBezPDV { get; set; }

        public Valuta Valuta { get; set; }

        public Kategorija Kategorija { get; set; }

        public string ImeTabele =>"Stavka_Cenovnika";

        public string InsertVrednosti => $"'{NazivStavke}','{CenaStavkeSaPDV}','{CenaStavkeBezPDV}','{Kategorija.KategorijaID}'";

        public string Id => "stavka_cenovnika_id";

        public string Where { get; set; }
        public string Set { get ; set ; }
        public string JoinTableName { get ; set; }
        public string JoinFirst { get; set; }
        public string JoinSecond { get ; set; }
        public string JoinSecondTableName { get ; set ; }
        public string JoinJoinON { get ; set; }

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

        public IDomainObjekat ProctiajRedTabele(SqlDataReader reader)
        {
            StavkaCenovnika s = new StavkaCenovnika
            {
                StavkaID = (int)reader["stavka_cenovnika_id"],
                CenaStavkeBezPDV = (double)reader["cena_bez_poreza"],
                CenaStavkeSaPDV = (double)reader["cena_sa_porezom"],
                NazivStavke = (string)reader["naziv_stavke"],
                Valuta = Valuta.RSD,
                Kategorija = new Kategorija
                {
                    KategorijaID =(int)reader["kategorija_id"],
                    NazivKategorije = (string)reader["naziv_kategorije"]
                }
                //Kategorija = VratiKategoriju((int)reader["kategorija_id"])

            };
            return s;
        }
    }
}
