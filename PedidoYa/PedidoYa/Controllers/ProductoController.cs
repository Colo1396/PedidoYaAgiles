using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidoYa.Data.Repositories;
using PedidoYa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoYa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        /// <summary>
        /// Traer todos los Producto
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Producto> GetAllProductos()
        {
            return _productoRepository.GetAllProductos();
        }


        /// <summary>
        /// Traer el Producto con id igual a:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("porid/{id}")]
        public async Task<IActionResult> GetProductoForId(int id)
        {
            return Ok(await _productoRepository.GetProductoForId(id));
        }

        /// <summary>
        /// Traer todos los Producto
        /// </summary>
        /// <param name="idComercio"></param>
        /// <returns></returns>
        [HttpGet("comercio/{idComercio}")]
        public async Task<IActionResult> GetAllProductosXComercio(int idComercio)
        {
            return Ok(await _productoRepository.GetAllProductosXComercio(idComercio));
        }

        /// <summary>
        /// Traer todos los Producto
        /// </summary>
        /// <param name="Nombre"></param>
        /// <returns></returns>
        [HttpGet("{Nombre}")]
        public async Task<IActionResult> GetAllProductosXNombre(string Nombre)
        {
            var rta = await _productoRepository.GetAllProductosXNombre(Nombre);
            return Ok(rta);
        }

        /* //-- inecesario por el momento ya que esta el otro metodo que graba con comercio
        /// <summary>
        /// Crear un nuevo Producto
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _productoRepository.InsertProducto(producto);

            return Created("created", created);
        }*/

        //--REVISAR
        /// <summary>
        /// Crear un nuevo Producto
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="idComercio"></param>
        /// <returns></returns>
        [HttpPost("{idComercio}")]
        public async Task<IActionResult> CreateProductoConIdComercio(int idComercio,[FromBody] Producto producto)
        {
            if (producto == null )
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (producto.foto == null || producto.foto == "")
                producto.foto = "https://dry-thicket-39505.herokuapp.com/img/comercio/default.png";

            var created = await _productoRepository.InsertProducto(producto, idComercio);

            return Created("created", created);
        }


        /// <summary>
        /// Actualizar el Producto con id:
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProducto([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            await _productoRepository.UpdatetProducto(producto);

            return NoContent();
        }

        /* --REVISAR
        /// <summary>
        /// Actualizar el Producto con id:
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="idComercio"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProducto([FromBody] Producto producto, int idComercio)
        {
            if (producto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productoRepository.UpdatetProducto(producto, idComercio);

            return NoContent();
        }*/

        /// <summary>
        /// Borrar el Producto con id:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            await _productoRepository.DeleteProducto(new Producto() { idProducto = id });

            return NoContent();
        }
    }
}
