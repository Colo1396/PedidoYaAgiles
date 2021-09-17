using PedidoYa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Data.Repositories
{
    public interface ICategoriaRepository
    {
        List<Categoria> GetAllCategorias();
        bool InsertCategoria(Categoria categoria);
        bool UpdateCategoria(Categoria categoria);
        bool DeleteCategoria(int id);
    }
}
