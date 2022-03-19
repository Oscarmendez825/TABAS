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

        private string path = @"C:\Users\omend\Documents\GitHub\TABAS\REST\DB\VUELOS.json";
        private string path2 = @"C:\Users\omend\Documents\GitHub\TABAS\REST\DB\BAGCART.json";
        private string path3 = @"C:\Users\omend\Documents\GitHub\TABAS\REST\DB\AVIONES.json";

        /// <summary>
        /// Get de vuelos totales
        /// </summary>
        /// <returns> Se retorna el json de vuelos totales</returns>
        
        [HttpGet("Vuelos")]
        public string getVuelos()
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                return json;
            }
        }

        /// <summary>
        /// Get de un vuelo específico mediante su número de vuelo
        /// </summary>
        /// <param name="numVuelo"></param>
        /// <returns>Se retorna el json con el vuelo deseado</returns>
        
        [HttpGet("{numVuelo}")]
        public string getVuelo(string numVuelo)
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el archivo
                var vuelos = JsonConvert.DeserializeObject<List<Vuelo>>(json); //Se crea una variable con todos los vuelos
                foreach (Vuelo vuelotp in vuelos)
                {
                    if (vuelotp.numVuelo == Int32.Parse(numVuelo)) //Se busca el vuelo según su llave
                    {
                        return JsonConvert.SerializeObject(vuelotp); //Se retorna el json con el vuelo solicitado
                    }
                }
            }
            return "ERROR";
        }

        /// <summary>
        /// Post de Vuelos 
        /// </summary>
        /// <param name="vuelo"></param>
        /// <returns>Se retorna el estado de aceptación de la solicitud</returns>
        
        [HttpPost]
        public Estado agregarVuelo(Vuelo vuelo)
        {
            //Inicialización de parámetros
            String jsonEscribir = "";
            Estado estadotp = new Estado();
            bool flag1 = false;
            bool flag2 = false;
            using (StreamReader jsonStream = System.IO.File.OpenText(path2))
            {
                var json = jsonStream.ReadToEnd();//Se lee el archivo
                var bagcarts = JsonConvert.DeserializeObject<List<BagCart>>(json); //Se crea una lista con todos los bagcarts
                foreach (BagCart bagcarttp in bagcarts)
                {
                    if (bagcarttp.identificador_BC == vuelo.BC_ID) //Se validan que sean iguales
                    {
                        flag1 = true; //Se hace true el flag
                    }
                }
            }

            using (StreamReader jsonStream = System.IO.File.OpenText(path3))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el archivo
                var aviones = JsonConvert.DeserializeObject<List<Avion>>(json); //Se crea una lista con todos los aviones
                foreach (Avion aviontp in aviones)
                {
                    if (aviontp.placaAvion == vuelo.placaAvion) //Se valida que las placas de aviones sean iguales
                    {
                        flag2 = true;//Se hace true el flag
                    }
                }
            }

            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el archivo
                var vuelos = JsonConvert.DeserializeObject<List<Vuelo>>(json); //Se crea una lista de todos los vuelos
                foreach (Vuelo vuelotp in vuelos)
                {
                    if ((vuelotp.BC_ID == vuelo.BC_ID) || (flag1 == false) || (flag2 == false)) //Se valida que no se repitan y que el estado de los flags
                    {
                        estadotp.estado = "ERROR";
                        return estadotp; //Se retorna el estado de la solicitud
                    }
                }

                vuelos.Add(vuelo); //Se añade el vuelo
                string json2 = JsonConvert.SerializeObject(vuelos);
                jsonEscribir = json2;
            }
            System.IO.File.WriteAllText(path, jsonEscribir);
            estadotp.estado = "OK";
            return estadotp;//Se retorna el estado de la solicitud
        }



        [HttpPost ("AsignarBCVuelo")]
        public Estado asignarBagCart(Vuelo vuelo)
        {
            //Inicialización de parámetros
            bool flag = false;
            Estado estadotp = new();
            string jsonEscribir = "";
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el archivo
                var vuelos = JsonConvert.DeserializeObject<List<Vuelo>>(json); //Se crea la variable con los vuelos totales
                foreach (Vuelo vuelotp in vuelos)
                {
                    if ((vuelotp.numVuelo == vuelo.numVuelo)) //Se valida el número de vuelo
                    {
                        vuelotp.BC_ID = vuelo.BC_ID; //Se le da el valor al id del bagcart
                        flag = true;
                        break;
                    }
                }
                string json2 = JsonConvert.SerializeObject(vuelos);
                jsonEscribir = json2; //Se escribe en el json
            }
            if (flag == true) //Se valida el flag
            {
                System.IO.File.WriteAllText(path, jsonEscribir);
                estadotp.estado = "OK";
                return estadotp; //Se retorna el estado
            }
            else
            {
                estadotp.estado = "ERROR";
                return estadotp;//Se retorna el estado
            }

        }
    }

}
        
        
 
