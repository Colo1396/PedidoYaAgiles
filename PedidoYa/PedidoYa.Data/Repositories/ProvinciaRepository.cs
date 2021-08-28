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
    public class ProvinciaRepository : IProvinciaRepository
    {

        private MySQLConfiguration _connectionString;
        public ProvinciaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }




        public async Task<IEnumerable<Provincia>> GetAllProvincias()
        {
            var db = dbConnection();
            var sql = @"select idprovincia ,nombre from provincia ";
            return await db.QueryAsync<Provincia>(sql, new { });
        }

        public async Task<Provincia> GetProvincia(int idProvincia)
        {
            var db = dbConnection();
            var sql= @"select idprovincia,nombre 
                        from provincia 
                        where idprovincia = @IdProvincia";
            return await db.QueryFirstOrDefaultAsync<Provincia>(sql, new { IdProvincia = idProvincia });

        }

        public async Task<bool> InsertProvincia(Provincia provincia)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO provincia (nombre) VALUES (@Nombre)";

            var result = await db.ExecuteAsync(sql, new { provincia.nombre});
            return result > 0;
        }

        public async Task<bool> UpdatetProvincia(Provincia provincia)
        {
       
            var db = dbConnection();

            var sql = @"update provincia 
                             set nombre= @Nombre
                        where idprovincia = @IdProvincia";

            var result = await db.ExecuteAsync(sql, new { provincia.nombre, provincia.idProvincia });
            return result > 0;
        }
        public async Task<bool> DeleteProvincia(Provincia provincia)
        {
            var db = dbConnection();

            var sql = @"Delete
                        from provincia 
                        where idprovincia = @IdProvincia";

            var result = await db.ExecuteAsync(sql, new { IdProvincia = provincia.idProvincia });
            return result > 0;
        }
    }
}
