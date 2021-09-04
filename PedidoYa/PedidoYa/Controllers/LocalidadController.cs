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
    public class LocalidadController : ControllerBase
    {
        private readonly ILocalidadRepository _localidadRepository;

        public LocalidadController(ILocalidadRepository localidadRepository)
        {
            _localidadRepository = localidadRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllLocalidades()
        {
            return Ok(await _localidadRepository.GetAllLocalidad());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocalidadForId(int id)
        {
            return Ok(await _localidadRepository.GetLocalidad(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocalidad([FromBody] Localidad localidad)
        {
            if (localidad == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _localidadRepository.InsertLocalidad(localidad);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateLocalidad([FromBody] Localidad localidad)
        {
            if (localidad == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _localidadRepository.UpdatetLocalidad(localidad);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalidad(int id)
        {
            await _localidadRepository.DeleteLocalidad(new Localidad() { idLocalidad = id });

            return NoContent();
        }
    }
}
