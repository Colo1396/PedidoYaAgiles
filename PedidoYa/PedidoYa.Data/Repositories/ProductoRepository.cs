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
    public class ProductoRepository : IProductoRepository
    {   
        //Mysql
        private MySQLConfiguration _connectionString;
        public ProductoRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        //Metodos
        public async Task<bool> DeleteProducto(Producto producto)
        {
            var db = dbConnection();

            var sql = @"Delete
                        from producto 
                        where idProducto = @IdProducto";

            var result = await db.ExecuteAsync(sql, new { IdProducto = producto.idProducto });
            return result > 0;
        }

        public List<Producto> GetAllProductos()
        {
            var db = dbConnection();

            var sql = @"select idProducto, nombre, descripcion, foto, precio, visible, idComercio from producto";

            return db.Query<Producto>(sql, new { }).ToList();
        }

        public async Task<IEnumerable<Producto>> GetAllProductosXComercio(int idComercio)
        {
            var db = dbConnection();

            var sql = @"select idProducto, nombre, descripcion, foto, precio, visible, idComercio from producto where idComercio = @IdComercio";

            return await db.QueryAsync<Producto>(sql, new { IdComercio = idComercio });
        }

        public async Task<Producto> GetProductoForId(int idProducto)
        {
            var db = dbConnection();

            var sql = @"select idProducto, nombre, descripcion, foto, precio, visible, idComercio from producto
                        where idProducto = @IdProducto";

            return await db.QueryFirstOrDefaultAsync<Producto>(sql, new { IdProducto = idProducto });
        }

        public async Task<bool> InsertProducto(Producto producto,int idComercio)
        {
            var db = dbConnection();

            var sql = @"insert into producto (nombre, descripcion, foto, precio, visible, idComercio) 
                        values (@Nombre,@Descripcion,@Foto,@Precio,@Visible, @IdComercio)";

            var result = await db.ExecuteAsync(sql, new { producto.nombre, producto.descripcion, producto.foto, producto.precio, producto.visible, IdComercio= idComercio });
            return result > 0;
        }

        public async Task<bool> InsertProducto(Producto producto)
        {
            var db = dbConnection();

            var sql = @"insert into producto (nombre, descripcion, foto, precio, visible) 
                        values (@Nombre,@Descripcion,@Foto,@Precio,@Visible)";

            var result = await db.ExecuteAsync(sql, new { producto.nombre, producto.descripcion, producto.foto, producto.precio, producto.visible });
            return result > 0;
        }

        public async Task<bool> UpdatetProducto(Producto producto)
        {
            var db = dbConnection();

            var sql = @"update producto 
                             set nombre= @Nombre,
                             descripcion= @Descripcion,
                             foto=@Foto,
                             precio=@Precio,
                             visible=@Visible
                        where idProducto = @IdProducto";

            var result = await db.ExecuteAsync(sql, new { producto.nombre, producto.descripcion, producto.foto, producto.precio, producto.visible, producto.idProducto });
            return result > 0;
        }

        public async Task<bool> UpdatetProducto(Producto producto,int idComercio)
        {
            var db = dbConnection();

            var sql = @"update producto 
                             set nombre= @Nombre,
                             descripcion= @Descripcion,
                             foto=@Foto,
                             precio=@Precio,
                             visible=@Visible,
                             idComercio=@IdComercio
                        where idProducto = @IdProducto";

            var result = await db.ExecuteAsync(sql, new { producto.nombre, producto.descripcion, producto.foto, producto.precio, producto.visible, producto.idProducto, @IdComercio=idComercio });
            return result > 0;
        }


    }
}
