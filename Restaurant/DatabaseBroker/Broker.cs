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
            if (_connection != null)
            {
                _connection.Close();
            }
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

        #region C
        public int Insert(IDomainObjekat obj)
        {
            SqlCommand command = new SqlCommand($"INSERT INTO {obj.ImeTabele} output inserted.{obj.Id} " +
                $" VALUES ({obj.InsertVrednosti})",_connection,_transaction);

            return (int)command.ExecuteScalar();
        }
        #endregion

        #region R
        public List<IDomainObjekat> Select(IDomainObjekat obj)
        {
            List<IDomainObjekat> rezultat = new List<IDomainObjekat>();

            SqlCommand command = new SqlCommand($"SELECT * FROM {obj.ImeTabele}", _connection, _transaction);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    rezultat.Add(obj.ProctiajRedTabele(reader));
                }
            }
            return rezultat;
        }
        public List<IDomainObjekat> SelectWhere(IDomainObjekat obj)
        {
            List<IDomainObjekat> rezultat = new List<IDomainObjekat>();
            SqlCommand command = new SqlCommand($"SELECT * FROM {obj.ImeTabele} WHERE " +
                $" {obj.Where}", _connection, _transaction);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    rezultat.Add(obj.ProctiajRedTabele(reader));
                }
            }
            return rezultat;
        }

        public List<IDomainObjekat> SelectJoin(IDomainObjekat obj)
        {
            List<IDomainObjekat> rezultat = new List<IDomainObjekat>();
            SqlCommand command = new SqlCommand($"SELECT * FROM {obj.ImeTabele} prva JOIN {obj.JoinTableName} druga ON" +
                $" prva.{obj.JoinFirst}=druga.{obj.JoinSecond}  WHERE " +
                $" {obj.Where}", _connection, _transaction);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    rezultat.Add(obj.ProctiajRedTabele(reader));
                }
            }
            return rezultat;
        }
        public List<IDomainObjekat> SelectJoinJoin(IDomainObjekat obj)
        {
            List<IDomainObjekat> rezultat = new List<IDomainObjekat>();
            SqlCommand command = new SqlCommand($"SELECT * FROM {obj.ImeTabele} prva JOIN {obj.JoinTableName} druga ON" +
                $" prva.{obj.JoinFirst}=druga.{obj.JoinSecond} " +
                $"JOIN {obj.JoinSecondTableName} treca ON {obj.JoinJoinON} WHERE " +
                $" prva.{obj.Where}", _connection, _transaction);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    rezultat.Add(obj.ProctiajRedTabele(reader));
                }
            }
            return rezultat;
        }
        public List<IDomainObjekat> SelectJoinWithoutWhere(IDomainObjekat obj)
        {
            List<IDomainObjekat> rezultat = new List<IDomainObjekat>();
            SqlCommand command = new SqlCommand($"SELECT * FROM {obj.ImeTabele} prva JOIN {obj.JoinTableName} druga ON" +
                $" prva.{obj.JoinFirst}=druga.{obj.JoinSecond} ", _connection, _transaction);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    rezultat.Add(obj.ProctiajRedTabele(reader));
                }
            }
            return rezultat;
        }


        #endregion

        #region U
        public void Update(IDomainObjekat obj)
        {
            SqlCommand command = new SqlCommand($"UPDATE {obj.ImeTabele} SET {obj.Set}" +
               $" WHERE {obj.Where}", _connection, _transaction);

            command.ExecuteNonQuery();
        }
        #endregion

        #region D
        public void Delete(IDomainObjekat obj)
        {
            SqlCommand command = new SqlCommand($"DELETE FROM {obj.ImeTabele} WHERE " +
                $" {obj.Where}", _connection, _transaction);

            command.ExecuteNonQuery();
        }
        #endregion
        


    }
}
