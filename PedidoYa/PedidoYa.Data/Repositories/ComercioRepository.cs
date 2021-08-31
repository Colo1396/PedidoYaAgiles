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
    public class ComercioRepository : IComercioRepository
    {
        //Mysql
        private MySQLConfiguration _connectionString;
        public ComercioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        //Metodos
        public async Task<bool> DeleteComercio(Comercio comercio)
        {
            var db = dbConnection();

            var sql = @"Delete
                        from comercio 
                        where idComercio = @IdComercio";

            var result = await db.ExecuteAsync(sql, new { IdComercio = comercio.idComercio });
            return result > 0;
        }

        public async Task<IEnumerable<Comercio>> GetAllComercios()
        {
            var db = dbConnection();

            var sql = @"select idComercio, nombre, direccion, localidad, telefono, calificacion, logo from comercio";

            return await db.QueryAsync<Comercio>(sql, new { });
        }
        public async Task<IEnumerable<Comercio>> GetAllComerciosXLocalidad(string localidad)
        {
            var db = dbConnection();

            var sql = @"select idComercio, nombre, direccion, localidad, telefono, calificacion, logo from comercio
                        where localidad = @Localidad";

            return await db.QueryAsync<Comercio>(sql, new { Localidad = localidad });
        }

        public async Task<Comercio> GetComercioForId(int idComercio)
        {
            var db = dbConnection();

            var sql = @"select idComercio, nombre, direccion, localidad, telefono, calificacion, logo from comercio
                        where idComercio = @IdComercio";

            return await db.QueryFirstOrDefaultAsync<Comercio>(sql, new { IdComercio = idComercio });
        }

        public async Task<bool> InsertComercio(Comercio comercio)
        {
            var db = dbConnection();

            var sql = @"insert into comercio (nombre, direccion, localidad, telefono, calificacion, logo) 
                        values (@Nombre,@Direccion,@Localidad,@Telefono,@Calificacion,@Logo)";

            var result = await db.ExecuteAsync(sql, new { comercio.nombre, comercio.direccion, comercio.localidad, comercio.telefono, comercio.calificacion, comercio.logo });
            return result > 0;
        }

        public async Task<bool> UpdatetComercio(Comercio comercio)
        {
            var db = dbConnection();

            var sql = @"update comercio 
                             set nombre= @Nombre,
                             direccion= @Direccion,
                             localidad=@Localidad,
                             telefono=@Telefono,
                             calificacion=@Calificacion,
                             logo=@Logo
                        where idComercio = @IdComercio";

            var result = await db.ExecuteAsync(sql, new { comercio.nombre, comercio.direccion, comercio.localidad, comercio.telefono, comercio.calificacion, comercio.logo, comercio.idComercio });
            return result > 0;
        }


    }
}
