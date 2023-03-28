using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPIProgII.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIProgII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturaController : ControllerBase
    {
        private static readonly List<Temperatura> lst = new List<Temperatura>();
        // GET: api/<TemperaturaController>
        [HttpGet]
        public IActionResult Get()
        {
            if (lst.Count!=0)
            {
                return Ok(lst);
            }
            return NotFound("No hay Temperaturas Registradas!");
        }

        // GET api/<TemperaturaController>/5
        [HttpGet("{IOT}")]
        public IActionResult Get(int IOT)
        {
            foreach (Temperatura x in lst)
            {
                if (x.IOT.Equals(IOT))
                {
                    return Ok(x);
                }
            }
            return NotFound("Temperatura no registrada!");
        }

        // POST api/<TemperaturaController>
        [HttpPost]
        public IActionResult Post([FromBody] Temperatura value)
        {
            if (value == null || value.IOT==0)
                return BadRequest("Error, objeto Temperara incorrecto");
            lst.Add(value);
            return Ok(value);
        }
    }

}
