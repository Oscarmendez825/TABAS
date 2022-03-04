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
    public class MaletaController : ControllerBase
    {
        // GET: api/<MaletaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Todas las maletas" };
        }

        // GET api/<MaletaController>/5
        [HttpGet("{numero_maleta}")]
        public string Get(string numero_maleta)
        {
            return numero_maleta switch
            {
                "1" => "Maleta 1",
                "2" => "Maleta 2",
                "3" => "Maleta 4",
                "4" => "Maleta 4",
                _ => throw new NotSupportedException("Número de maleta invalida")
            };
        }

        // POST api/<MaletaController>
        [HttpPost]
        public string Post(Maleta maleta)
        {
            return maleta.numero_maleta;

        }

    }
}
