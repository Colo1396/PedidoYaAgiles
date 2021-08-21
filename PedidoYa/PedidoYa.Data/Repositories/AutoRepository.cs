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
    public class AutoRepository : IAutoRepository
    {
        private MySQLConfiguration _connectionString;
        public AutoRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Auto>> GetAllAutos()
        {
            var db = dbConnection();

            var sql = @"select idAuto, marca,modelo,color,anio from auto";

            return await db.QueryAsync<Auto>(sql, new { });
        }

        public async Task<Auto> GetAuto(int idAuto)
        {
            var db = dbConnection();

            var sql = @"select 
                        idAuto, 
                        marca,
                        modelo,
                        color,
                        anio 
                        from auto 
                        where idAuto = @IdAuto";

            return await db.QueryFirstOrDefaultAsync<Auto>(sql, new { IdAuto=idAuto });
        }

        public async Task<bool> InsertAuto(Auto auto)
        {
            var db = dbConnection();

            var sql = @"insert into auto (marca,modelo,color,anio) values (@Marca,@Modelo,@Color,@anio)";

            var result= await db.ExecuteAsync(sql, new { auto.marca, auto.modelo, auto.color, auto.anio});
            return result > 0;
        }

        public async Task<bool> UpdatetAuto(Auto auto)
        {
            var db = dbConnection();

            var sql = @"update auto 
                             set marca= @Marca,
                             modelo= @Modelo,
                             color=@Color,
                             anio=@anio
                        where idAuto = @IdAuto";

            var result = await db.ExecuteAsync(sql, new { auto.marca, auto.modelo, auto.color, auto.anio, auto.idAuto });
            return result > 0;
        }

        public async Task<bool> DeleteAuto(Auto auto)
        {
            var db = dbConnection();

            var sql = @"Delete
                        from auto 
                        where idAuto = @IdAuto";

            var result = await db.ExecuteAsync(sql, new { IdAuto = auto.idAuto });
            return result > 0;
        }
    }
}
