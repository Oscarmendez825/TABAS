using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvionController : ControllerBase
    {
        private string path = @"C:\Users\omend\Documents\GitHub\REST\RestAPI\REST\DB\AVIONES.json";


        /// <summary>
        /// Get de aviones
        /// </summary>
        /// <returns>Se retorna el JSON de aviones de la base de datos</returns>


        [HttpGet("Aviones")]
        public string GetAviones()
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                return json;
            }
        }

        // GET api/<AvionController>/5
        [HttpGet("{placaAvion}")]
        public string GetAvion(string placa)
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var aviones = JsonConvert.DeserializeObject<List<Avion>>(json);
                foreach(Avion aviontp in aviones)
                {
                    if(aviontp.placaAvion == Int32.Parse(placa))
                    {
                        return JsonConvert.SerializeObject(aviontp);
                    }
                }
            }

            return "ERROR";
        }

        // POST api/<AvionController>
        [HttpPost]
        public Estado AgregarAvion(Avion avion)
        {
            string jsonEscribir = "";
            Estado estadotp = new Estado();
            using(StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var aviones = JsonConvert.DeserializeObject<List<Avion>>(json);
                foreach(Avion aviontp in aviones)
                {
                    if(aviontp.placaAvion == avion.placaAvion)
                    {
                        estadotp.estado = "ERROR";
                        return estadotp;
                    }
                }
                aviones.Add(avion);
                string json2 = JsonConvert.SerializeObject(aviones);
                jsonEscribir = json2;
            }
            System.IO.File.WriteAllText(path, jsonEscribir);
            estadotp.estado = "OK";
            return estadotp;
        }


    }
}
