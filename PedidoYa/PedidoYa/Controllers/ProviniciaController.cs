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
    public class ProvinciaController : ControllerBase
    {
        private readonly IProvinciaRepository _provinciaRepository;

        public ProvinciaController(IProvinciaRepository provinciaRepository)
        {
            _provinciaRepository = provinciaRepository;
        }

        /// <summary>
        /// Traer todas las Provincias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProvincias()
        {
            return Ok(await _provinciaRepository.GetAllProvincias());
        }


        /// <summary>
        /// Traer la provincia con id igual a:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProvinciaForId(int id)
        {
            return Ok(await _provinciaRepository.GetProvincia(id));
        }

        /// <summary>
        /// Crear una nueva provincia
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProvincia([FromBody] Provincia provincia)
        {
            if (provincia == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _provinciaRepository.InsertProvincia(provincia);

            return Created("created", created);
        }


        /// <summary>
        /// Actualizar la provincia con id:
        /// </summary>
        /// <param name="provincia"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProvincia([FromBody] Provincia provincia)
        {
            if (provincia == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _provinciaRepository.UpdatetProvincia(provincia);

            return NoContent();
        }

        /// <summary>
        /// Borrar la provincia con id:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvincia(int id)
        {
            await _provinciaRepository.DeleteProvincia(new Provincia() { idProvincia = id });

            return NoContent();
        }








    }
}
