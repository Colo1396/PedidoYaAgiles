using Microsoft.AspNetCore.Mvc;
using PedidoYa.Data.Repositories;
using PedidoYa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PedidoYa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaRepository _categoriaRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
   
        [HttpGet]
        public List<Categoria> Get()
        {
            return _categoriaRepository.GetAllCategorias();
        }

        [HttpPost]
        public bool Post([FromBody] Categoria categoria)
        {
            return _categoriaRepository.InsertCategoria(categoria);
        }

        [HttpPut]
        public bool Put([FromBody] Categoria categoria)
        {
            return _categoriaRepository.UpdateCategoria(categoria);
        }
   
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _categoriaRepository.DeleteCategoria(id);
        }
    }
}
