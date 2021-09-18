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
        private readonly IUsuarioRepository _usuarioRepository;

        public ComercioController(IComercioRepository comercioRepository,IUsuarioRepository usuarioRepository)
        {
            _comercioRepository = comercioRepository;
            _usuarioRepository = usuarioRepository;
        }

        //-------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Traer todos los Comercio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllComercios()
        {
            return Ok(await _comercioRepository.GetAllComercios());
        }
        //-------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Traer todos los Comercio por localidad
        /// </summary>
        /// <returns></returns>
        [HttpGet("buscar/{localidad}")]
        public async Task<IActionResult> GetAllComerciosXLocalidad(string localidad)
        {
            return Ok(await _comercioRepository.GetAllComerciosXLocalidad(localidad));
        }
        //-------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Traer todos los Comercio por id Usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet("buscarXIdUsuario/{idUsuario}")]
        public async Task<IActionResult> GetComercioXIdUsuario(int idUsuario)
        {
           Comercio comercio = await _comercioRepository.GetComercioXIdUsuario(idUsuario);
           comercio.usuario=await _usuarioRepository.GetUsuarioForId(idUsuario);
            return Ok(comercio);

        }
        //-------------------------------------------------------------------------------------------------------------------
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
        //-------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Crear un nuevo Comercio
        /// </summary>
        /// <param name="comercio"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateComercio([FromBody] Comercio comercio)
        {
            
            
            if (comercio == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (comercio.logo == null || comercio.logo == "")
                comercio.logo = "https://dry-thicket-39505.herokuapp.com/img/comercio/default.png";

            var created = _comercioRepository.InsertComercio(comercio);

            return Created("created", created);
        }

        //-------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Crear un nuevo Comercio
        /// </summary>
        /// <param name="comercio"></param>
        /// <returns></returns>
        [HttpPost("ComercioAndUsuario")]
        public IActionResult CreateComercioAndUsuario([FromBody] Comercio comercio)
        {
            if (comercio == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (comercio.usuario == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (comercio.logo == null || comercio.logo == "")
                comercio.logo = "https://dry-thicket-39505.herokuapp.com/img/comercio/default.png";

            comercio.usuario.id = _usuarioRepository.InsertUsuario(comercio.usuario);

            if ( _comercioRepository.InsertComercio(comercio))
                return Created("created", true);
            else
                return Created("created", false);
        }
        //-------------------------------------------------------------------------------------------------------------------

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
        //-------------------------------------------------------------------------------------------------------------------
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
        //-------------------------------------------------------------------------------------------------------------------

    }
}
