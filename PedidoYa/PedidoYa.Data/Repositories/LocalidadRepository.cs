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
    public class LocalidadRepository : ILocalidadRepository
    {
        private MySQLConfiguration _connectionString;
        public LocalidadRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        public LocalidadRepository()
        {
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteLocalidad(Localidad localidad)
        {
            var db = dbConnection();

            var sql = @"Delete
                        from localidad 
                        where idLocalidad = @IdLocalidad";

            var result = await db.ExecuteAsync(sql, new { IdLocalidad = localidad.idLocalidad });
            return result > 0;
        }

        public async Task<IEnumerable<Localidad>> GetAllLocalidad()
        {
            var db = dbConnection();

            var sql = @"SELECT idlocalidad, nombre, idprovincia FROM localidad";

            return await db.QueryAsync<Localidad>(sql, new { });
        }

        public async Task<Localidad> GetLocalidad(int idLocalidad)
        {
            var db = dbConnection();

            var sql = @"SELECT idlocalidad, nombre, idprovincia FROM localidad
                        where idlocalidad = @IdLocalidad";

            return await db.QueryFirstOrDefaultAsync<Localidad>(sql, new { IdLocalidad = idLocalidad });
        }

        public async Task<bool> InsertLocalidad(Localidad localidad)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO localidad (nombre, idprovincia) VALUES (@Nombre, @IdProvincia)";

            var result = await db.ExecuteAsync(sql, new { localidad.nombre, localidad.provincia.idProvincia });
            return result > 0;
        }

        public async Task<bool> UpdatetLocalidad(Localidad localidad)
        {
            var db = dbConnection();

            var sql = @"update localidad 
                             set nombre= @Nombre,
                             idprovincia= @IdProvincia
                        where idLocalidad = @IdLocalidad";

            var result = await db.ExecuteAsync(sql, new { localidad.idLocalidad,localidad.nombre, localidad.provincia.idProvincia });
            return result > 0;
        }

       
    }
}
