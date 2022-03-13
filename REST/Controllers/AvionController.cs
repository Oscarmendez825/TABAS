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
        //private string path = @"C:\Users\Familia\Documents\Gabo\Pruebas\REST\RestAPI\REST\DB\AVIONES.json";

        // GET: api/<AvionController>
        [HttpGet("Aviones")]
        public string GetUsuarios()
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
        public void Post([FromBody] string value)
        {
        }


    }
}
