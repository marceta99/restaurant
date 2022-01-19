using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Porucivanje :IDomainObjekat
    {

        public Porudzbina Porudzbina { get; set; }

        public StavkaCenovnika StavkaCenovnika { get; set; }

        public int BrojPorcija { get; set; }

        public string ImeTabele => "Porucivanje";

        public string InsertVrednosti => $"'{Porudzbina.PorudzbinaID}','{StavkaCenovnika.StavkaID}','{BrojPorcija}'";

        public string Id => "porudzbina_id";

        public string Where { get; set; }
        public string Set { get; set; }
        public string JoinTableName { get; set; }
        public string JoinFirst { get; set; }
        public string JoinSecond { get; set; }
        public string JoinSecondTableName { get ; set; }
        public string JoinJoinON { get ; set ; }

        public IDomainObjekat ProctiajRedTabele(SqlDataReader reader)
        {
            NarucenaStavka ns = new NarucenaStavka
            {
                BrojNarucenihPorcija = (int)reader["broj_porcija"],
                StavkaCenovnika = new StavkaCenovnika
                {
                    StavkaID = (int)reader["stavka_cenovnika_id"],
                    CenaStavkeBezPDV = (double)reader["cena_bez_poreza"],
                    CenaStavkeSaPDV = (double)reader["cena_sa_porezom"],
                    NazivStavke = (string)reader["naziv_stavke"],
                    Valuta = Valuta.RSD,
                    Kategorija = new Kategorija
                    {
                        KategorijaID = (int)reader["kategorija_id"],
                        NazivKategorije = (string)reader["naziv_kategorije"]
                    }
                    //Kategorija = VratiKategoriju((int)reader["kategorija_id"])
                }

            };
            return ns;
        }
    }
}
