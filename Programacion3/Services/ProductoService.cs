using Programacion3.Data;
using Programacion3.Models;

namespace Programacion3.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public List<Producto> ObtenerTodos()
        {
            return _productoRepository.ObtenerTodos();
        }

        public Producto? ObtenerPorId(int id)
        {
            return _productoRepository.ObtenerPorId(id);
        }
    }
}