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
    public class BagCartController : ControllerBase
    {
        // GET: api/<BagCartController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "All BagCarts" };
        }

        // GET api/<BagCartController>/5
        [HttpGet("{identificador_BC}")]
        public string Get(string identificador_BC)
        {
            return identificador_BC switch
            {
                "1" => "BagCart 1",
                "2" => "BagCart 2",
                "3" => "BagCart 4",
                "4" => "BagCart 4",
                _ => throw new NotSupportedException("BagCart invalida")
            };
        }

        // POST api/<BagCartController>
        [HttpPost]
        public string Post( BagCart bagcart)
        {
            return bagcart.identificador_BC;
        }

    }
}
