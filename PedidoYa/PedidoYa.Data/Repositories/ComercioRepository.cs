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
        //-------------------------------------------------------------------------------------------------------------------
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
        //-------------------------------------------------------------------------------------------------------------------
        public async Task<IEnumerable<Comercio>> GetAllComercios()
        {
            var db = dbConnection();

            var sql = @"select idComercio, nombre, direccion, localidad, telefono, calificacion, logo,descripcion from comercio";

            return await db.QueryAsync<Comercio>(sql, new { });
        }
        //-------------------------------------------------------------------------------------------------------------------
        public async Task<IEnumerable<Comercio>> GetAllComerciosXLocalidad(string localidad)
        {
            var db = dbConnection();

            var sql = @"select idComercio, nombre, direccion, localidad, telefono, calificacion, logo,descripcion from comercio
                        where localidad = @Localidad";

            return await db.QueryAsync<Comercio>(sql, new { Localidad = localidad });
        }
        //-------------------------------------------------------------------------------------------------------------------
        public async Task<Comercio> GetComercioForId(int idComercio)
        {
            var db = dbConnection();

            var sql = @"select idComercio, nombre, direccion, localidad, telefono, calificacion, logo,descripcion from comercio
                        where idComercio = @IdComercio";

            return await db.QueryFirstOrDefaultAsync<Comercio>(sql, new { IdComercio = idComercio });
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool InsertComercio(Comercio comercio)
        {
            var db = dbConnection();

            var sql = @"insert into comercio (nombre, direccion, localidad, telefono, calificacion, logo,descripcion,idUsuario) 
                        values (@Nombre,@Direccion,@Localidad,@Telefono,@Calificacion,@Logo,@Descripcion,@IdUsuario); select LAST_INSERT_ID();";

            int result = db.ExecuteScalar<int>(sql, new { comercio.nombre, comercio.direccion, comercio.localidad, comercio.telefono, comercio.calificacion, comercio.logo,comercio.descripcion, IdUsuario=comercio.usuario.id });
            if (result > 0) {
                comercio.idComercio = result;
                sql = @"delete from comercioxcategoria where idComercio = @IdComercio";
                db.Execute(sql, comercio);
                comercio.categorias.ForEach(categoria=> {
                    sql = @"INSERT INTO comercioxcategoria (idCategoria, idComercio) VALUES(@IdCategoria, @IdComercio)";
                    db.Execute(sql, new { IdCategoria = categoria.IdCategoria, IdComercio = comercio.idComercio });
                });
            }
            return result > 0;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public async Task<bool> UpdatetComercio(Comercio comercio)
        {
            var db = dbConnection();

            var sql = @"update comercio 
                             set nombre= @Nombre,
                             direccion= @Direccion,
                             localidad=@Localidad,
                             telefono=@Telefono,
                             calificacion=@Calificacion,
                             logo=@Logo,
                             descripcion=@Descripcion
                        where idComercio = @IdComercio";

            var result = await db.ExecuteAsync(sql, new { comercio.nombre, comercio.direccion, comercio.localidad, comercio.telefono, comercio.calificacion, comercio.logo, comercio.descripcion ,comercio.idComercio });
            return result > 0;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public async Task<Comercio> GetComercioXIdUsuario(int idUsuario)
        {
            var db = dbConnection();

            var sql = @"select idComercio, nombre, direccion, localidad, telefono, calificacion, logo,descripcion from comercio
                        where idUsuario = @IdUsuario";

           /* var sql = @"select idComercio, nombre, direccion, localidad, telefono, calificacion, logo,descripcion from comercio c
                            inner join usuario u  on u.id = c.idUsuario                      
                        where u.id = @IdUsuario";*/

            return await db.QueryFirstOrDefaultAsync<Comercio>(sql, new { IdUsuario = idUsuario });
            
        }
    }
}
