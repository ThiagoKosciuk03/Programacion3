using Microsoft.AspNetCore.Mvc;
using Programacion3.Models;

namespace Programacion3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController: ControllerBase
    {
        private static readonly Producto[] Productos = new[]
        {
    new Producto { Id = 1, Nombre = "Lapiz", Precio = 100.00M, Stock =4},
    new Producto { Id = 2, Nombre = "Goma", Precio = 50.00M, Stock =6},
    new Producto { Id = 3, Nombre = "Regla", Precio = 500.00M, Stock =7},
    new Producto { Id = 4, Nombre = "Marcador", Precio = 200.00M, Stock =8},

        };

        [HttpGet(Name = "ListaDeProductos")]
        public IActionResult ObtenerTodos()
        {
            return Ok(Productos);
        }
    }
}
