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
    public class AutoController : ControllerBase
    {
        private readonly IAutoRepository _autoRepository;

        public AutoController(IAutoRepository autoRepository)
        {
            _autoRepository = autoRepository;
        }


        /// <summary>
        /// Traer todos los Autos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAutos()
        {
            return Ok(await _autoRepository.GetAllAutos());
        }


        /// <summary>
        /// Traer el auto con id igual a:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllAutosForId(int id)
        {
            return Ok(await _autoRepository.GetAuto(id));
        }

        /// <summary>
        /// Crear un nuevo Auto
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAuto([FromBody] Auto auto)
        {
            if (auto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _autoRepository.InsertAuto(auto);

            return Created("created", created);
        }


        /// <summary>
        /// Actualizar el Auto con id:
        /// </summary>
        /// <param name="auto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAuto([FromBody] Auto auto)
        {
            if (auto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           await _autoRepository.UpdatetAuto(auto);

            return NoContent();
        }

        /// <summary>
        /// Borrar el Auto con id:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteAuto(int id)
        {
            await _autoRepository.DeleteAuto(new Auto() { idAuto = id });

            return NoContent();
        }

    }
}
