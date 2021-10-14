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

            var sql = @"select idComercio, nombre, direccion, localidad, telefono, calificacion, logo,descripcion, costoEnvio, horario, diasAbierto from comercio";

            return await db.QueryAsync<Comercio>(sql, new { });
        }
        //-------------------------------------------------------------------------------------------------------------------
        public List<Comercio> GetAllComerciosXLocalidadxCategoria(string localidad, int idCategoria)
        {
            var db = dbConnection();
            string filters = "";
            if(idCategoria != 0)
            filters += "and cxc.idCategoria = @IdCategoria";

            string sql = $@"select distinct c.* from comercio c left join comercioxcategoria cxc on c.idComercio = cxc.idComercio
                        where localidad = @Localidad {filters}";

            return db.Query<Comercio>(sql, new { Localidad = localidad, IdCategoria = idCategoria }).ToList();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public List<Comercio> GetAllComerciosXProducto(string localidad, string nombreProducto)
        {
            var db = dbConnection();

            string sql = $@"select distinct c.* from comercio c
                            inner join producto p on p.idComercio = c.idComercio
                            where c.localidad = @Localidad and p.nombre LIKE '%" + nombreProducto + "%'";

            return db.Query<Comercio>(sql, new { Localidad = localidad, NombreProducto = nombreProducto }).ToList();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Comercio GetComercioForId(int idComercio)
        {
            var db = dbConnection();

            var sql = @"select idComercio, nombre, direccion, localidad, telefono, calificacion, logo,descripcion, costoEnvio, horario, diasAbierto from comercio
                        where idComercio = @IdComercio";

            Comercio comercio = db.QueryFirstOrDefault<Comercio>(sql, new { IdComercio = idComercio });
            if (comercio != null)
            {
                sql = @"select c.* from categoria c inner join comercioxcategoria cxc on c.idCategoria = cxc.idCategoria where idComercio = @IdComercio";
                comercio.categorias = db.Query<Categoria>(sql, new { IdComercio = comercio.idComercio }).ToList();
            }
            return comercio;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool InsertComercio(Comercio comercio)
        {
            var db = dbConnection();

            var sql = @"insert into comercio (nombre, direccion, localidad, telefono, calificacion, logo,descripcion,idUsuario, costoEnvio, horario, diasAbierto) 
                        values (@Nombre,@Direccion,@Localidad,@Telefono,@Calificacion,@Logo,@Descripcion,@IdUsuario, @CostoEnvio, @Horario, @DiasAbierto); select LAST_INSERT_ID();";

            int result = db.ExecuteScalar<int>(sql, new { comercio.nombre, comercio.direccion, comercio.localidad, comercio.telefono, comercio.calificacion, comercio.logo,comercio.descripcion, IdUsuario=comercio.usuario.id,comercio.costoEnvio,comercio.horario,comercio.diasAbierto });
            if (result > 0) {
                comercio.idComercio = result;
                sql = @"delete from comercioxcategoria where idComercio = @IdComercio";
                db.Execute(sql, comercio);
                if(comercio.categorias !=null)
                comercio.categorias.ForEach(categoria=> {
                    sql = @"INSERT INTO comercioxcategoria (idCategoria, idComercio) VALUES(@IdCategoria, @IdComercio)";
                    db.Execute(sql, new { IdCategoria = categoria.IdCategoria, IdComercio = comercio.idComercio });
                });
            }
            return result > 0;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool UpdateComercio(Comercio comercio)
        {
            var db = dbConnection();

            var sql = @"update comercio 
                             set nombre= @Nombre,
                             direccion= @Direccion,
                             localidad=@Localidad,
                             telefono=@Telefono,
                             calificacion=@Calificacion,
                             logo=@Logo,
                             descripcion=@Descripcion,
                             costoEnvio=@CostoEnvio, 
                             horario=@Horario, 
                             diasAbierto=@DiasAbierto
                        where idComercio = @IdComercio";

            var result = db.Execute(sql, new { comercio.nombre, comercio.direccion, comercio.localidad, comercio.telefono, comercio.calificacion, comercio.logo, comercio.descripcion ,comercio.idComercio, comercio.costoEnvio, comercio.horario, comercio.diasAbierto });
            if (result > 0)
            {
                sql = @"delete from comercioxcategoria where idComercio = @IdComercio";
                db.Execute(sql, comercio);
                if (comercio.categorias != null)
                    comercio.categorias.ForEach(categoria => {
                        sql = @"INSERT INTO comercioxcategoria (idCategoria, idComercio) VALUES(@IdCategoria, @IdComercio)";
                        db.Execute(sql, new { IdCategoria = categoria.IdCategoria, IdComercio = comercio.idComercio });
                    });
            }
            return result > 0;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Comercio GetComercioXIdUsuario(int idUsuario)
        {
            var db = dbConnection();

            var sql = @"select idComercio, nombre, direccion, localidad, telefono, calificacion, logo,descripcion, costoEnvio, horario, diasAbierto from comercio
                        where idUsuario = @IdUsuario";

           /* var sql = @"select idComercio, nombre, direccion, localidad, telefono, calificacion, logo,descripcion from comercio c
                            inner join usuario u  on u.id = c.idUsuario                      
                        where u.id = @IdUsuario";*/
            Comercio comercio = db.QueryFirstOrDefault<Comercio>(sql, new { IdUsuario = idUsuario });
            if (comercio != null) {
                sql = @"select c.* from categoria c inner join comercioxcategoria cxc on c.idCategoria = cxc.idCategoria where idComercio = @IdComercio";
                comercio.categorias = db.Query<Categoria>(sql, new {IdComercio = comercio.idComercio }).ToList();
            }
            return comercio;
            
        }
    }
}
