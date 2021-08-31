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
    public class ComercioController : ControllerBase
    {
        private readonly IComercioRepository _comercioRepository;

        public ComercioController(IComercioRepository comercioRepository)
        {
            _comercioRepository = comercioRepository;
        }


        /// <summary>
        /// Traer todos los Comercio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllComercios()
        {
            return Ok(await _comercioRepository.GetAllComercios());
        }

        /// <summary>
        /// Traer todos los Comercio por localidad
        /// </summary>
        /// <returns></returns>
        [HttpGet("buscar/{localidad}")]
        public async Task<IActionResult> GetAllComerciosXLocalidad(string localidad)
        {
            return Ok(await _comercioRepository.GetAllComerciosXLocalidad(localidad));
        }


        /// <summary>
        /// Traer el Comercio con id igual a:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComercioForId(int id)
        {
            return Ok(await _comercioRepository.GetComercioForId(id));
        }

        /// <summary>
        /// Crear un nuevo Comercio
        /// </summary>
        /// <param name="comercio"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateComercio([FromBody] Comercio comercio)
        {
            if (comercio == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _comercioRepository.InsertComercio(comercio);

            return Created("created", created);
        }


        /// <summary>
        /// Actualizar el Comercio con id:
        /// </summary>
        /// <param name="comercio"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateComercio([FromBody] Comercio comercio)
        {
            if (comercio == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _comercioRepository.UpdatetComercio(comercio);

            return NoContent();
        }

        /// <summary>
        /// Borrar el Comercio con id:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComercio(int id)
        {
            await _comercioRepository.DeleteComercio(new Comercio() { idComercio = id });

            return NoContent();
        }


    }
}
