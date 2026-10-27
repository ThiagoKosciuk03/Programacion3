using Programacion3.Models;

namespace Programacion3.Data
{
    public interface IProductoRepository
    {
        List<Producto> ObtenerTodos();
        Producto? ObtenerPorId(int id);
    }
}
