// Class where ill implement all methods to interact with postgres db.
using Dapper;
using demoCRUD.Models;
using Npgsql;
using System.Numerics;

namespace demoCRUD.Repository
{
    public class DAL
    {
        private readonly string connectionString;
        public DAL(IConfiguration configuration)
        {
            connectionString=configuration.GetConnectionString("PostgresConnection");
        }
        //public IEnumerable<Emp> getAll()
        //{
        //    using (var connection = new NpgsqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        return connection.Query<Emp>("SELECT * from showAll()").ToList();
        //    }
        //}
        public IEnumerable<Emp> getAll(string Search)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<Emp>("SELECT * from searchAll(@searchterm)", new {searchterm=Search}).ToList();
            }
        }
        public void Add(string name, string email, string phone)
        {
            using(var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute("CALL addemp(@pname,@pemail,@pphone)", new { pname = name, pemail = email, pphone=phone });
            }
        }
        public void updatemp(int id,string name,string email,string phone)
        {
            using( var connection = new NpgsqlConnection( connectionString))
            {
                connection.Open();
                connection.Execute("CALL updatemp(@pid,@pname,@pemail,@pphone)", new { pid = id, pname = name, pemail = email, pphone = phone });
            }
        }
        public void deletemp(int iD)
        {
            using(var connection =new NpgsqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute("Delete from master where id=@id", new { id = iD });
            }
        }

    }
}
