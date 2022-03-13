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
    public class VueloController : ControllerBase
    {
        private string path = @"C:\Users\Familia\Documents\Gabo\Pruebas\REST\RestAPI\REST\DB\VUELOS.json";
        private string path2 = @"C:\Users\Familia\Documents\Gabo\Pruebas\REST\RestAPI\REST\DB\BAGCART.json";
        private string path3 = @"C:\Users\Familia\Documents\Gabo\Pruebas\REST\RestAPI\REST\DB\AVION.json";

        //private string path = @"C:\Users\omend\Documents\GitHub\REST\RestAPI\REST\DB\VUELOS.json";
        //private string path2 = @"C:\Users\omend\Documents\GitHub\REST\RestAPI\REST\DB\BAGCART.json";
        //private string path3 = @"C:\Users\omend\Documents\GitHub\REST\RestAPI\REST\DB\AVION.json";

        // GET: api/<VueloController>
        [HttpGet("Vuelos")]
        public string GetUsuarios()
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                return json;
            }
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
            bool flag1 = false;
            bool flag2 = false;
            using (StreamReader jsonStream = System.IO.File.OpenText(path2))
            {
                var json = jsonStream.ReadToEnd();
                var bagcarts = JsonConvert.DeserializeObject<List<BagCart>>(json);
                foreach(BagCart bagcarttp in bagcarts)
                {
                    if (bagcarttp.identificador_BC == vuelo.BC_ID)
                    {
                        flag1 = true;
                    }
                }
            }

            using (StreamReader jsonStream = System.IO.File.OpenText(path3))
            {
                var json = jsonStream.ReadToEnd();
                var aviones = JsonConvert.DeserializeObject<List<Avion>>(json);
                foreach (Avion aviontp in aviones)
                {
                    if (aviontp.placaAvion == vuelo.placaAvion)
                    {
                        flag2 = true;
                    }
                }
            }

            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var vuelos = JsonConvert.DeserializeObject<List<Vuelo>>(json);
                foreach(Vuelo vuelotp in vuelos)
                {
                    if((vuelotp.BC_ID == vuelo.BC_ID) || (flag1 == false) ||(flag2 == false))
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
        
        
 
