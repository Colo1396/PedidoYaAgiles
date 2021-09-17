using Dapper;
using MySql.Data.MySqlClient;
using PedidoYa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        //Mysql
        private MySQLConfiguration _connectionString;
        public CategoriaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        //-------------------------------------------------------------------------------------------------------------------

        public bool DeleteCategoria(int id)
        {
            var db = dbConnection();

            string sql = @"DELETE FROM categoria WHERE idCategoria = @IdCategoria";

            var result = db.Execute(sql, new { IdCategoria = id });
            return result > 0;
        }

        public List<Categoria> GetAllCategorias()
        {
            var db = dbConnection();

            string sql = @"select * from categoria";

            return db.Query<Categoria>(sql).ToList();
        }

        public bool InsertCategoria(Categoria categoria)
        {
            var db = dbConnection();

            string sql = @"INSERT INTO categoria (nombre) VALUES(@Nombre)";

            var result = db.Execute(sql, categoria);
            return result > 0;
        }

        public bool UpdateCategoria(Categoria categoria)
        {
            var db = dbConnection();

            string sql = @"UPDATE categoria SET nombre=@Nombre WHERE idCategoria=@IdCategoria";

            var result =  db.Execute(sql, categoria);
            return result > 0;
        }
    }
}
