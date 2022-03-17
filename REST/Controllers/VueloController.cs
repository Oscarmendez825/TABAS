using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VueloController : ControllerBase
    {
        // private string path = @"C:\Users\Familia\Documents\Gabo\Pruebas\REST\RestAPI\REST\DB\VUELOS.json";
        //private string path2 = @"C:\Users\Familia\Documents\Gabo\Pruebas\REST\RestAPI\REST\DB\BAGCART.json";
        //private string path3 = @"C:\Users\Familia\Documents\Gabo\Pruebas\REST\RestAPI\REST\DB\AVION.json";

        private string path = @"C:\Users\omend\Documents\GitHub\TABAS\REST\DB\VUELOS.json";
        private string path2 = @"C:\Users\omend\Documents\GitHub\TABAS\REST\DB\BAGCART.json";
        private string path3 = @"C:\Users\omend\Documents\GitHub\TABAS\REST\DB\AVION.json";

        // GET: api/<VueloController>
        [HttpGet("Vuelos")]
        public string getVuelos()
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                return json;
            }
        }

        // GET api/<VueloController>/5
        [HttpGet("{numVuelo}")]
        public string getVuelo(string numVuelo)
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
        public Estado agregarVuelo(Vuelo vuelo)
        {
            String jsonEscribir = "";
            Estado estadotp = new Estado();
            bool flag1 = false;
            bool flag2 = false;
            using (StreamReader jsonStream = System.IO.File.OpenText(path2))
            {
                var json = jsonStream.ReadToEnd();
                var bagcarts = JsonConvert.DeserializeObject<List<BagCart>>(json);
                foreach (BagCart bagcarttp in bagcarts)
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
                foreach (Vuelo vuelotp in vuelos)
                {
                    if ((vuelotp.BC_ID == vuelo.BC_ID) || (flag1 == false) || (flag2 == false))
                    {
                        estadotp.estado = "ERROR";
                        return estadotp;
                    }
                }

                vuelos.Add(vuelo);
                string json2 = JsonConvert.SerializeObject(vuelos);
                jsonEscribir = json2;
            }
            System.IO.File.WriteAllText(path, jsonEscribir);
            estadotp.estado = "OK";
            return estadotp;
        }


        [HttpPost ("AsignarBCVuelo")]
        public Estado asignarBagCart(Vuelo vuelo)
        {
            bool flag = false;
            Estado estadotp = new();
            string jsonEscribir = "";
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var vuelos = JsonConvert.DeserializeObject<List<Vuelo>>(json);
                foreach (Vuelo vuelotp in vuelos)
                {
                    if ((vuelotp.numVuelo == vuelo.numVuelo))
                    {
                        vuelotp.BC_ID = vuelo.BC_ID;
                        flag = true;
                        break;
                    }
                }
                string json2 = JsonConvert.SerializeObject(vuelos);
                jsonEscribir = json2;
            }
            if (flag == true)
            {
                System.IO.File.WriteAllText(path, jsonEscribir);
                estadotp.estado = "OK";
                return estadotp;
            }
            else
            {
                estadotp.estado = "ERROR";
                return estadotp;
            }

        }
    }

}
        
        
 
