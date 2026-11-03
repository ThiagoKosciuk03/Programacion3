using Microsoft.AspNetCore.Mvc;
using Programacion3.Services;

namespace Programacion3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        
        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

       
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            try
            {
                var productos = _productoService.ObtenerTodos();
                return Ok(productos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error al consultar los productos.");
            }
        }

        
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            try
            {
                var producto = _productoService.ObtenerPorId(id);

                if (producto == null)
                {
                    return NotFound();
                }

                return Ok(producto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error al consultar el producto.");
            }
        }
    }
}