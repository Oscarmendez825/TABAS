using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        private string path = @"C:\Users\Familia\Documents\Gabo\Pruebas\TABAS\RestAPI\TABAS\DB\VUELOS.json";
        private string path2 = @"C:\Users\Familia\Documents\Gabo\Pruebas\TABAS\RestAPI\TABAS\DB\BAGCART.json";

        //private string path = @"C:\Users\omend\Documents\GitHub\TABAS\RestAPI\TABAS\DB\VUELOS.json";
        //private string path2 = @"C:\Users\omend\Documents\GitHub\TABAS\RestAPI\TABAS\DB\BAGCART.json";

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
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var vuelos = JsonConvert.DeserializeObject<List<Vuelo>>(json);
                foreach (Vuelo vuelotp in vuelos)
                {
                    if (vuelotp.numVuelo == Int32.Parse(numVuelo))
                    {
                        return JsonConvert.SerializeObject(vuelotp);
                    }
                }
            }
            return "ERROR";
        }


        // POST api/<VueloController>
        [HttpPost]
        public string Post(Vuelo vuelo)
        {
            String jsonEscribir = "";
            bool flag = false;
            using (StreamReader jsonStream = System.IO.File.OpenText(path2))
            {
                var json = jsonStream.ReadToEnd();
                var bagcarts = JsonConvert.DeserializeObject<List<BagCart>>(json);
                foreach(BagCart bagcarttp in bagcarts)
                {
                    if (bagcarttp.identificador_BC == vuelo.BC_ID)
                    {
                        flag = true;
                    }
                }
            }

            using(StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var vuelos = JsonConvert.DeserializeObject<List<Vuelo>>(json);
                foreach(Vuelo vuelotp in vuelos)
                {
                    if((vuelotp.BC_ID == vuelo.BC_ID) || (flag == false))
                    {
                        return "ERROR";
                    }
                }

                vuelos.Add(vuelo);
                string json2 = JsonConvert.SerializeObject(vuelos);
                jsonEscribir = json2;
            }
            System.IO.File.WriteAllText(path, jsonEscribir);
            return "OK";
        }

    }

}
        
        
 
