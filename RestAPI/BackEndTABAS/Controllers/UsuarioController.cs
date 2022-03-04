using BackEndTABAS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndTABAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/
        [HttpGet("{cedula}")]
        public string Get(string cedula)
        {
            return cedula switch { 
                "1" => "Usuario 1",
                "2" => "Usuario 2",
                "3" => "Usuario 3",
                "4" => "Usuario 4",
                _ => throw new NotSupportedException("Cedula invalida")
            };
        }

        // POST api/<ValuesController>
        [HttpPost]
        public string Post(Usuario usuario)
        {
            return usuario.Nombre; 
        }
    }
}

