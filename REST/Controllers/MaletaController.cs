using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaletaController : ControllerBase
    {

        private string path = @"C:\Users\dani_\Documents\GitHub\TABAS\REST\DB\MALETAS.json";

        /// <summary>
        /// Get de maletas totales
        /// </summary>
        /// <returns>Se retorna el json con el total de maletas</returns>
        /// 
        [HttpGet("Maletas")]
        public string GetMaletas()
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el archivo y se retorna el json
                return json;
            }
        }

        /// <summary>
        /// Get de una maleta en específico según su número de maleta
        /// </summary>
        /// <param name="numero_maleta"></param>
        /// <returns>Se retorna el json de la maleta deseada</returns>

 
        [HttpGet("{numero_maleta}")]
        public string GetMaleta(string numero_maleta)
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el archivo
                var maletas = JsonConvert.DeserializeObject<List<Maleta>>(json); //Se crea la variable con las maletas totales
                foreach (Maleta maletatp in maletas)
                {
                    if (maletatp.numero_maleta == Int32.Parse(numero_maleta)) //Se busca la maleta que coincida con el número deseado
                    {
                        return JsonConvert.SerializeObject(maletatp); //Se retorna el json con la maleta específica
                    }
                }
            }
            return "ERROR";
        }

        /// <summary>
        /// Metodo GET para conseguir el costo de una maleta
        /// </summary>
        /// <param name="numero_maleta"> El numero identificador de la maleta deseada </param>
        /// <returns></returns>
        [HttpGet("getCosto/{num_maleta}")]
        public int GetCosto(string numero_maleta)
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var maletas = JsonConvert.DeserializeObject<List<Maleta>>(json);
                foreach (Maleta maletatp in maletas)
                {
                    if (maletatp.numero_maleta == Int32.Parse(numero_maleta))
                    {
                        return maletatp.costo;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Post de maleta mediante un json
        /// </summary>
        /// <param name="maleta"></param>
        /// <returns>Se retorna el estado de aceptación del Post</returns>
        
        [HttpPost]
        public Estado addMaleta(Maleta maleta)
        {
            //Inicialización de constantes
            Estado estadotp = new();
            string jsonEscribir = "";
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el archivo
                var maletas = JsonConvert.DeserializeObject<List<Maleta>>(json); //Se crea la variable con las maletas totales
                foreach (Maleta maletatp in maletas)
                {
                    if ((maletatp.numero_maleta == maleta.numero_maleta)) //Se valida que la maleta no esté ya en la base de datos
                    {
                        estadotp.estado = "ERROR";
                        return estadotp; //Se retorna el estado
                    }
                }
                maleta.calcCosto(); //Se calcula el costo de la maleta
                maleta.estadoAceptacion(); //Se le da estado de aceptación a la maleta
                maletas.Add(maleta); //Se añade la maleta
                string json2 = JsonConvert.SerializeObject(maletas);
                jsonEscribir = json2;
            }
            System.IO.File.WriteAllText(path, jsonEscribir);
            estadotp.estado = "OK";
            return estadotp;//Se retorna el estado
        }

        /// <summary>
        /// Post para asignar una maleta a un bagcart
        /// </summary>
        /// <param name="maleta"></param>
        /// <returns>Se retorna el estado de la solicitud</returns>

        [HttpPost("AsignarBCMaleta")]
        public Estado asignarBagCart(Maleta maleta) {
            //Inicialización de constantes
            bool flag = false;
            Estado estadotp = new();
            string jsonEscribir = "";
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el archivo
                var maletas = JsonConvert.DeserializeObject<List<Maleta>>(json); //Se crea la variable con las maletas totales
                foreach (Maleta maletatp in maletas)
                {
                    if ((maletatp.numero_maleta == maleta.numero_maleta)) //Se agarra la maleta deseada
                    {
                        maletatp.bagcartId = maleta.bagcartId; //Se le asigna un bagcart 
                        maletatp.scanId = maleta.scanId;//Se le asigna un id del trabajador que realizó el scan
                        flag = true;
                        break;
                    }
                }
                string json2 = JsonConvert.SerializeObject(maletas);
                jsonEscribir = json2; //Se escribe el json
            }
            if (flag == true)
            {
                System.IO.File.WriteAllText(path, jsonEscribir);
                estadotp.estado = "OK";
                return estadotp; //Se retorna el estado de la solicitud
            }
            else {
                estadotp.estado = "ERROR";
                return estadotp; //Se retorna el estado de la solicitud
            }

        }
    }
    

}
