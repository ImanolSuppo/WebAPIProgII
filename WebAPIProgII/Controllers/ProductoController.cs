using Microsoft.AspNetCore.Mvc;
using WebAPIProgII.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIProgII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private static readonly List<Producto> lst = new List<Producto>();
        // GET: api/<ProductoController>
        [HttpGet]
        public IActionResult Get()
        {
            if (lst.Count != 0)
            {
                return Ok(lst);
            }
            return NotFound("No hay Productos Registradas!");
        }

        // GET api/<ProductoController>/5
        [HttpGet("{código}")]
        public IActionResult Get(int código)
        {
            foreach (Producto x in lst)
            {
                if (x.Codigo.Equals(código))
                {
                    return Ok(x);
                }
            }
            return NotFound("Producto no registrada!");
        }

        // POST api/<ProductoController>
        [HttpPost]
        public IActionResult Post([FromBody] Producto value)
        {
            if (value == null || value.Codigo == 0)
                return BadRequest("Error, objeto Temperara incorrecto");
            lst.Add(value);
            return Ok(value);
        }

        // PUT api/<ProductoController>/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Producto producto)
        {
            foreach (Producto x in lst)
            {
                if (x.Codigo.Equals(producto.Codigo))
                {
                    x.Nombre = producto.Nombre;
                    x.Precio = producto.Precio;
                    return Ok(x);
                }
            }
            return NotFound("Producto no registrada!");
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{codigo}")]
        public IActionResult Delete(int codigo)
        {
            foreach (Producto x in lst)
            {
                if (x.Codigo.Equals(codigo))
                {
                    lst.Remove(x);
                    return Ok(x);
                }
            }
            return NotFound("Producto no registrada!");
        }
    }
}
