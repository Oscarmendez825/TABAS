using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TABAS.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TABAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VueloController : ControllerBase
    {
        // GET: api/<VueloController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Todos los vuelos" };
        }

        // GET api/<VueloController>/5
        [HttpGet("{numVuelo}")]
        public string Get(string numVuelo)
        {
            return numVuelo switch
            {
                "1" => "Vuelo 1",
                "2" => "Vuelo 2",
                "3" => "Vuelo 3",
                "4" => "Vuelo 4",
                _ => throw new NotSupportedException("Vuelo invalida")
            };
        }

        // POST api/<VueloController>
        [HttpPost]
        public string Post(Vuelo vuelo )
        {
            return vuelo.numVuelo;
        }

    }
}
