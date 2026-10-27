using Microsoft.AspNetCore.Mvc;
using Programacion3.Models;
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
            var productos = _productoService.ObtenerTodos();
            return Ok(productos);
        }
    }
}