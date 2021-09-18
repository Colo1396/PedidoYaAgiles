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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Traer todos los Usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsuario()
        {
            return Ok(await _usuarioRepository.GetAllUsuario());
        }

        /// <summary>
        /// Traer el Usuario con id igual a:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioForId(int id)
        {
            return Ok(await _usuarioRepository.GetUsuarioForId(id));
        }

        /// <summary>
        /// Traer el id del Usuario al ingresar usuario y contraseña. Devuelve 0 si no existe usuario.
        /// </summary>
        /// <returns></returns>
        [HttpPost("login")]
        public int LoginController([FromBody] Login login)
        {
            
            return _usuarioRepository.Login(login.username, login.password);
        }

        /// <summary>
        /// Crear un nuevo Usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public int CreateUsuario([FromBody] Usuario usuario)
        {

            int created = _usuarioRepository.InsertUsuario(usuario);

            return created;
        }


        /// <summary>
        /// Actualizar el Usuario con id:
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _usuarioRepository.UpdatetUsuario(usuario);

            return NoContent();
        }

        /// <summary>
        /// Borrar el Usuario con id:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _usuarioRepository.DeleteUsuario(new Usuario() { id = id });

            return NoContent();
        }

        public struct Login
        {
            public string username { get; set; }
            public string password { get; set; }
            
        }
    }
        
}
