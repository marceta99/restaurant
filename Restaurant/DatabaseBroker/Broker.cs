using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBroker
{
    public class Broker
    {
        private SqlConnection _connection;
        private SqlTransaction _transaction;

        public Broker()
        {
            _connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestoranBaza;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");
        }
        #region Connection 
        public void OpenConnection()
        {
            _connection.Open();
        }
        public void CloseConnection()
        {
            _connection.Close();
        }
        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }
        public void Commit()
        {
            _transaction.Commit();
        }
        public void RollBack()
        {
            _transaction.Rollback();
        }
        #endregion

        #region LoginKorisnici
        public List<Korisnik> VratiSveKorisnike()
        {
            List<Korisnik> korisnici = new List<Korisnik>();

            SqlCommand command = new SqlCommand("SELECT * FROM Korisnik", _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Korisnik k = new Korisnik
                    {
                        KorisnikID  = (int)reader["korisnik_id"],
                        KorisnickoIme = (string)reader["korisnicko_ime"],
                        Sifra = (string)reader["sifra"],
                        Email = (string)reader["email"],
                        Uloga = (Uloga)((int)reader["uloga_id"])
                    };
                    korisnici.Add(k);
                }
            }
            return korisnici; 
        }
        #endregion

        #region Stolovi
        public List<Sto> VratiSveStolove()
        {
            List<Sto> stolovi = new List<Sto>();

            SqlCommand command = new SqlCommand("SELECT * FROM Sto", _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Sto s = new Sto
                    {
                        StoID = (int)reader["sto_id"],
                        BrojStola = (int)reader["broj_stola"],
                        BrojStolica = (int)reader["broj_stolica"],
                        Rezervisan = ((int)reader["rezervisan"]) == 1 ? true : false  
                    };
                    stolovi.Add(s);
                }
            }
            return stolovi;
        }
        public Sto VratiStoSaId(int id)
        {
            Sto s = null; 

            SqlCommand command = new SqlCommand("SELECT * FROM Sto WHERE " +
                $"sto_id = {id}", _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();
     
                s = new Sto
                {
                    StoID = (int)reader["sto_id"],
                    BrojStola = (int)reader["broj_stola"],
                    BrojStolica = (int)reader["broj_stolica"],
                    Rezervisan = ((int)reader["rezervisan"]) == 1 ? true : false
                };
                    
                
            }
            return s;
        }

        public void ObrisiSto(Sto sto)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Sto WHERE " +
                $" sto_id='{sto.StoID}'",_connection);

            command.ExecuteNonQuery();
            
        }

        public void DodajNoviSto(Sto sto)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Sto VALUES " +
                $" ('{sto.BrojStola}','{sto.BrojStolica}'," +
                $"'{(sto.Rezervisan ? 1:0)}')",_connection);

            command.ExecuteNonQuery();
        }

        public void IzmeniSto(Sto sto)
        {
            SqlCommand command = new SqlCommand("UPDATE Sto SET " +
                $" broj_stola = '{sto.BrojStola}' , broj_stolica= '{sto.BrojStolica}'" +
                $" WHERE sto_id = '{sto.StoID}'", _connection);

            command.ExecuteNonQuery();
        }

        public void RezervisiSto(Sto sto)
        {

            SqlCommand command = new SqlCommand("UPDATE Sto SET " +
                $" rezervisan = '{1}'" +
                $" WHERE sto_id = '{sto.StoID}'", _connection);

            command.ExecuteNonQuery();
        }
        public void OslobodiSto(Sto sto)
        {

            SqlCommand command = new SqlCommand("UPDATE Sto SET " +
                $" rezervisan = '{0}'" +
                $" WHERE sto_id = '{sto.StoID}'", _connection);

            command.ExecuteNonQuery();
        }

        public bool DaLiJeRezervisanSto(Sto sto)
        {
            bool rezervisan = false;

            SqlCommand command = new SqlCommand($"SELECT rezervisan FROM Sto WHERE sto_id = {sto.StoID}", _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                int pomocni = (int)reader["rezervisan"];
                rezervisan = (pomocni == 0) ? false : true; 
            }
            return rezervisan ; 
           
        }

        public List<Sto> VratiSveStoloveSaStatusomPorudzbine(StatusPorudzbine status)
        {
            List<Sto> stolovi = new List<Sto>();

            SqlCommand command = new SqlCommand("SELECT * FROM Sto s JOIN Porudzbina p ON s.sto_id = p.sto_id " +
                $" WHERE p.status_porudzbine = '{(int)status}'", _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Sto s = new Sto
                    {
                        StoID = (int)reader["sto_id"],
                        BrojStola = (int)reader["broj_stola"],
                        BrojStolica = (int)reader["broj_stolica"],
                        Rezervisan = ((int)reader["rezervisan"]) == 1 ? true : false
                    };
                    stolovi.Add(s);
                }
            }
            return stolovi;
        }
            
        #endregion

        #region StavkeCenovnika
        public void DodajNovuStavku(StavkaCenovnika stavka)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Stavka_Cenovnika VALUES " +
                $" ('{stavka.NazivStavke}','{stavka.CenaStavkeSaPDV}'," +
                $"'{stavka.CenaStavkeBezPDV}','{stavka.Kategorija.KategorijaID}')", _connection);

            command.ExecuteNonQuery();
        }
        public void ObrisiStaku(StavkaCenovnika stavka)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Stavka_Cenovnika WHERE " +
                $" stavka_cenovnika_id ='{stavka.StavkaID}'", _connection);

            command.ExecuteNonQuery();
        }

        public void PromeniStavku(StavkaCenovnika stavka)
        {
            SqlCommand command = new SqlCommand("UPDATE Stavka_Cenovnika SET " +
                $" naziv_stavke = '{stavka.NazivStavke}' , cena_sa_porezom= '{stavka.CenaStavkeSaPDV}' ," +
                $"cena_bez_poreza ='{stavka.CenaStavkeBezPDV}' , kategorija_id = '{stavka.Kategorija.KategorijaID}' " +
                $" WHERE stavka_cenovnika_id = '{stavka.StavkaID}'", _connection);

            command.ExecuteNonQuery();
        }
        
        public List<StavkaCenovnika> VratiSveStavke()
        {
            List<StavkaCenovnika> stavke = new List<StavkaCenovnika>();

            SqlCommand command = new SqlCommand("SELECT * FROM Stavka_Cenovnika", _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {

                    StavkaCenovnika s = new StavkaCenovnika
                    {
                        StavkaID = (int)reader["stavka_cenovnika_id"],
                        CenaStavkeBezPDV = (double)reader["cena_bez_poreza"],
                        CenaStavkeSaPDV = (double)reader["cena_sa_porezom"],
                        NazivStavke = (string)reader["naziv_stavke"],
                        Valuta = Valuta.RSD,
                        Kategorija = VratiKategoriju((int)reader["kategorija_id"])

                    };
                    stavke.Add(s);
                }
            }
            return stavke;
        }

        public Kategorija VratiKategoriju(int idKategorije)
        {
            Kategorija k = null; 
            SqlCommand command = new SqlCommand("SELECT * FROM Kategorija WHERE " +
                $" kategorija_id='{idKategorije}'", _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {

                reader.Read();
                k = new Kategorija
                {
                    KategorijaID = (int)reader["kategorija_id"],
                    NazivKategorije = (string)reader["naziv_kategorije"]
                };
            }
            return k;
        }

        public List<Kategorija> VratiSveKategorije()
        {
            List<Kategorija> kategorije = new List<Kategorija>();

            SqlCommand command = new SqlCommand("SELECT * FROM Kategorija ", _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {

                    Kategorija k = new Kategorija
                    {
                        KategorijaID = (int)reader["kategorija_id"],
                        NazivKategorije = (string)reader["naziv_kategorije"]

                    };
                    kategorije.Add(k);
                }
            }

            return kategorije;
        }

        public List<StavkaCenovnika> VratiSveStavkeIZKategorije(Kategorija kategorija)
        {
            List<StavkaCenovnika> stavke = new List<StavkaCenovnika>();


            SqlCommand command = new SqlCommand("SELECT * FROM Stavka_Cenovnika WHERE " +
                $" kategorija_id='{kategorija.KategorijaID}'", _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    StavkaCenovnika s = new StavkaCenovnika
                    {
                        StavkaID = (int)reader["stavka_cenovnika_id"],
                        CenaStavkeBezPDV = (double)reader["cena_bez_poreza"],
                        CenaStavkeSaPDV = (double)reader["cena_sa_porezom"],
                        NazivStavke = (string)reader["naziv_stavke"],
                        Valuta = Valuta.RSD,
                        Kategorija = VratiKategoriju((int)reader["kategorija_id"])

                    };
                    stavke.Add(s);
                }
            }

            return stavke;
        }

        public StavkaCenovnika VratiStavkuSaID(int id)
        {
            StavkaCenovnika s = null;
            SqlCommand command = new SqlCommand("SELECT * FROM Stavka_Cenovnika WHERE " +
                $" stavka_cenovnika_id ='{id}'", _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {

                reader.Read();
                s = new StavkaCenovnika
                {
                    StavkaID = (int)reader["stavka_cenovnika_id"],
                    CenaStavkeBezPDV = (double)reader["cena_bez_poreza"],
                    CenaStavkeSaPDV = (double)reader["cena_sa_porezom"],
                    NazivStavke = (string)reader["naziv_stavke"],
                    Valuta = Valuta.RSD,
                    Kategorija = VratiKategoriju((int)reader["kategorija_id"])
                };
            }
            return s;
        }

        #endregion

        #region Porudzbina

        public int DodajNovuPorudzbinu(Porudzbina porudzbina)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = _connection;
            command.Transaction = _transaction;

            command.CommandText = $"insert into Porudzbina output inserted.porudzbina_id" +
                $" values (@UkVred, @Datum, @StoId,@StatusPorudzbine )";

            command.Parameters.AddWithValue("@UkVred", porudzbina.UkupnaVrednost);
            command.Parameters.AddWithValue("@Datum", porudzbina.Datum);
            command.Parameters.AddWithValue("@StoId", porudzbina.Sto.StoID);
            command.Parameters.AddWithValue("@StatusPorudzbine", StatusPorudzbine.Kreirana);

            return (int)command.ExecuteScalar();
        }
        public void DodajNovoPorucivanje(Porucivanje porucivanje)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = _connection;
            command.Transaction = _transaction;

            command.CommandText = $"insert into Porucivanje values (@PorudzbinaId, @StavkaId, @brPorcija )";

            command.Parameters.AddWithValue("@PorudzbinaId", porucivanje.Porudzbina.PorudzbinaID);
            command.Parameters.AddWithValue("@StavkaId",porucivanje.StavkaCenovnika.StavkaID );
            command.Parameters.AddWithValue("@brPorcija", porucivanje.BrojPorcija);

            command.ExecuteNonQuery();
        }

        public List<Porudzbina> VratiSvePorudzbine()
        {
            List<Porudzbina> porudzbine = new List<Porudzbina>();

            SqlCommand command = new SqlCommand("SELECT * FROM Porudzbina", _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {

                    Porudzbina p = new Porudzbina
                    {
                        PorudzbinaID = (int)reader["porudzbina_id"],
                        UkupnaVrednost = (double)reader["ukupna_vrednost"],
                        Datum = (DateTime)reader["datum"],
                        Sto = VratiStoSaId( (int)reader["sto_id"] ),
                        NaruceneStavke = VratiNaruceneStavkeIzPorudzbine((int)reader["porudzbina_id"]),
                        StatusPorudzbine = (StatusPorudzbine)((int)reader["status_porudzbine"])
                        
                    };
                    porudzbine.Add(p);
                }
            }
            return porudzbine;
        }
        public List<NarucenaStavka> VratiNaruceneStavkeIzPorudzbine(int idPorudzbine)
        {
            List<NarucenaStavka> naruceneStavkeIzPorudzbine = new List<NarucenaStavka>();

            SqlCommand command = new SqlCommand("SELECT * FROM Porucivanje p JOIN Stavka_Cenovnika sc " +
                $" ON p.stavka_cenovnika_id = sc.stavka_cenovnika_id " +
                $" WHERE p.porudzbina_id = {idPorudzbine}", _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
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
                           Kategorija = VratiKategoriju((int)reader["kategorija_id"])
                       }

                    };
                    naruceneStavkeIzPorudzbine.Add(ns);
                }
            }
            return naruceneStavkeIzPorudzbine;

        }

        public void ObrisiPorudzbinu(Porudzbina porudzbina)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Porudzbina WHERE " +
                $" porudzbina_id ='{porudzbina.PorudzbinaID}'", _connection);

            command.ExecuteNonQuery();
        }
        public void ObrisiPorucivanje(Porudzbina porudzbina)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Porucivanje WHERE " +
                $" porudzbina_id ='{porudzbina.PorudzbinaID}'", _connection);

            command.ExecuteNonQuery();
        }

        public void PromeniPorudzbinu(Porudzbina porudzbina)
        {
            SqlCommand command = new SqlCommand("UPDATE Porudzbina SET " +
                $" ukupna_vrednost = '{porudzbina.UkupnaVrednost}' , status_porudzbine ='{(int)porudzbina.StatusPorudzbine}' " +
                $" WHERE porudzbina_id = '{porudzbina.PorudzbinaID}'", _connection);

            command.ExecuteNonQuery();
        }
        public void DodajBrojPorcijaStaojStavciStareStavkeUPorudzbini(Porucivanje porucivanje)
        {
            SqlCommand command = new SqlCommand("UPDATE Porucivanje SET " +
                $" broj_porcija = '{porucivanje.BrojPorcija}' " +
                $" WHERE porudzbina_id = '{porucivanje.Porudzbina.PorudzbinaID}' AND " +
                $" stavka_cenovnika_id ={porucivanje.StavkaCenovnika.StavkaID}", _connection);

            command.ExecuteNonQuery();
        }
        
        public void ObrisiPorucivanjeZaStavku(Porucivanje porucivanje)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Porucivanje WHERE " +
                $" porudzbina_id ='{porucivanje.Porudzbina.PorudzbinaID}' AND " +
                $" stavka_cenovnika_id = {porucivanje.StavkaCenovnika.StavkaID}", _connection);

            command.ExecuteNonQuery();
        }

        public List<Porudzbina> VratiSvePorudzbineSaStola(Sto sto)
        {
            List<Porudzbina> porudzbine = new List<Porudzbina>();

            SqlCommand command = new SqlCommand($"SELECT * FROM Porudzbina WHERE sto_id= {sto.StoID}", _connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {

                    Porudzbina p = new Porudzbina
                    {
                        PorudzbinaID = (int)reader["porudzbina_id"],
                        UkupnaVrednost = (double)reader["ukupna_vrednost"],
                        Datum = (DateTime)reader["datum"],
                        Sto = VratiStoSaId((int)reader["sto_id"]),
                        NaruceneStavke = VratiNaruceneStavkeIzPorudzbine((int)reader["porudzbina_id"]),
                        StatusPorudzbine = (StatusPorudzbine)((int)reader["status_porudzbine"])

                    };
                    porudzbine.Add(p);
                }
            }
            return porudzbine;
        }

        public void OslobodiStoNaplacenePorudzbine(Porudzbina porudzbina)
        {
            SqlCommand command = new SqlCommand("UPDATE Porudzbina SET " +
                $" sto_id = '{0}' " +
                $" WHERE porudzbina_id = '{porudzbina.PorudzbinaID}'", _connection);

            command.ExecuteNonQuery();
        }

        #endregion
    }
}
