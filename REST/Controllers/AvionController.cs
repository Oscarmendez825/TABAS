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
                var json = jsonStream.ReadToEnd(); //Se lee el Json de la base de datos
                return json;
            }
        }

        /// <summary>
        /// Get de un avión específica¿o a partir de su placa
        /// </summary>
        /// <param name="placa"></param>
        /// <returns>Avion de la placa especificada</returns>
       
        [HttpGet("{placaAvion}")]
        public string GetAvion(string placa)
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el documento
                var aviones = JsonConvert.DeserializeObject<List<Avion>>(json); //Se crea una variable con todos los aviones para ser validados
                foreach(Avion aviontp in aviones)
                {
                    if(aviontp.placaAvion == Int32.Parse(placa)) //Se valida que la placa concuerde
                    {
                        return JsonConvert.SerializeObject(aviontp); //Se retorna el Json del avion 
                    }
                }
            }

            return "ERROR";
        }

        /// <summary>
        /// Post de aviones mediante un json
        /// </summary>
        /// <param name="avion"></param>
        /// <returns>Se retorna un estado de aceptación o no de la acción</returns>
        /// 
        [HttpPost]
        public Estado AgregarAvion(Avion avion)
        {
            //Inicialización de variables necesarias

            string jsonEscribir = ""; 
            Estado estadotp = new Estado();
            using(StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el archivo
                var aviones = JsonConvert.DeserializeObject<List<Avion>>(json); //Se crea una variable con todos los aviones
                foreach(Avion aviontp in aviones)
                {
                    if(aviontp.placaAvion == avion.placaAvion) //Validación de que no se repita la placa del avion
                    {
                        estadotp.estado = "ERROR";
                        return estadotp;
                    }
                }
                aviones.Add(avion); //Se agrega el avion
                string json2 = JsonConvert.SerializeObject(aviones);
                jsonEscribir = json2;
            }
            System.IO.File.WriteAllText(path, jsonEscribir);
            estadotp.estado = "OK";
            return estadotp; //Se retorna el estado de la solicitud
        }


    }
}
