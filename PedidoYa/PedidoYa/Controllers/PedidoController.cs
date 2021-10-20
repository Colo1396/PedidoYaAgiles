﻿using Microsoft.AspNetCore.Http;
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
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        /// <summary>
        /// Traer todos los Pedidos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Pedido> GetAllPedido()
        {
            return _pedidoRepository.GetAllPedido();
        }
        
        /// <summary>
        /// Traer el Pedidos con id igual a:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("porid/{id}")]
        public async Task<IActionResult> GetPedidoForId(int id)
        {
            return Ok(await _pedidoRepository.GetPedidoForId(id));
        }
        
        /// <summary>
        /// Crear un nuevo Pedido
        /// </summary>
        /// <param name="pedido"></param>
        /// <param name="idComercio"></param>
        /// <returns></returns>
        [HttpPost("{idComercio}")]
        public async Task<IActionResult> InsertPedido(int idComercio, [FromBody] Pedido pedido)
        {
            if (pedido == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _pedidoRepository.InsertPedido(pedido, idComercio);

            return Created("created", created);
        }

        
        /// <summary>
        /// Actualizar el Pedido con id y comercio:
        /// </summary>
        /// <param name="pedido"></param>
        /// <param name="idComercio"></param>
        /// <returns></returns>
        [HttpPut("UpdatetPedido/{idComercio}")]
        public async Task<IActionResult> UpdatetPedido([FromBody] Pedido pedido, int idComercio)
        {
            if (pedido == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _pedidoRepository.UpdatetPedido(pedido, idComercio);

            return NoContent();
        }
       
        /// <summary>
        /// Actualizar el Pedido con id y estado:
        /// </summary>
        /// <param name="pedido"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdatetEstadoPedido([FromBody] Pedido pedido, string estado)
        {
            if (pedido == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _pedidoRepository.UpdatetEstadoPedido(pedido, estado);

            return NoContent();
        }

        /// <summary>
        /// Borrar el Pedido con id:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            await _pedidoRepository.DeletePedido(new Pedido() { idPedido = id });

            return NoContent();
        }
        

    }
}