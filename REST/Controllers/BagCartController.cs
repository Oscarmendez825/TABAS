using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using REST.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BagCartController : ControllerBase
    {

        private string path = @"C:\Users\Familia\Documents\Gabo\Pruebas\REST\RestAPI\REST\DB\BAGCART.json";

        //private string path = @"C:\Users\omend\Documents\GitHub\REST\RestAPI\REST\DB\BAGCART.json";


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
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var bagcart = JsonConvert.DeserializeObject<List<BagCart>>(json);
                foreach (BagCart bagcarttp in bagcart)
                {
                    if(bagcarttp.identificador_BC == Int32.Parse(identificador_BC))
                    {
                        return JsonConvert.SerializeObject(bagcarttp);
                    }
                }

            }
            return "ERROR";

        }

        // POST api/<BagCartController>
        [HttpPost]
        public string Post( BagCart bagcart)
        {
            string jsonEscribir = "";
            using(StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var bagcarts = JsonConvert.DeserializeObject<List<BagCart>>(json);
                bagcarts.Add(bagcart);
                string json2 = JsonConvert.SerializeObject(bagcarts);
                jsonEscribir = json2;
            }
            System.IO.File.WriteAllText(path, jsonEscribir);
            return "OK";
        }

    }
}
