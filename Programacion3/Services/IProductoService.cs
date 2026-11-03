using Programacion3.Models;

namespace Programacion3.Services
{
    public interface IProductoService
    {
        List<Producto> ObtenerTodos();
        Producto? ObtenerPorId(int id);
    }
}
