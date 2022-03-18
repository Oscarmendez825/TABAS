using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BagCartController : ControllerBase
    {

        private string path = @"C:\Users\dani_\Documents\GitHub\TABAS\REST\DB\BAGCART.json";
        private string path2 = @"C:\Users\dani_\Documents\GitHub\TABAS\REST\DB\TRABAJADORES.json";

       
        /// <summary>
        /// Get total de BagCarts
        /// </summary>
        /// <returns>Se retornan todos los bagcarts de la base de datos</returns>
        [HttpGet("Bagcarts")]
        public string GetBagCarts()
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el archivo y se retorna el json
                return json;
            }
        }

        /// <summary>
        /// Get de un bagcart en específico mediante su identificador
        /// </summary>
        /// <param name="identificador_BC"></param>
        /// <returns>Se retorna el bagcart deseado según su identificador</returns>
        /// 
        [HttpGet("{identificador_BC}")]
        public string GetBagCart(string identificador_BC)
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el archivo
                var bagcart = JsonConvert.DeserializeObject<List<BagCart>>(json); //Se crea una variable que contiene todos los bagcarts
                foreach (BagCart bagcarttp in bagcart)
                {
                    if(bagcarttp.identificador_BC == Int32.Parse(identificador_BC)) //Se valida que ambos concuerden
                    {
                        return JsonConvert.SerializeObject(bagcarttp); //Se retorna el json del bagcart deseado
                    }
                }

            }
            return "ERROR";

        }

        /// <summary>
        /// Post de Bagcarts
        /// </summary>
        /// <param name="bagcart"></param>
        /// <returns>Se retorna el estado de acpetación o no de la solicitud</returns>
        
        [HttpPost]
        public Estado agregarBagCart(BagCart bagcart)
        {
            //Inicialización de constantes necesarias
            string jsonEscribir = "";
            Estado estadotp = new Estado();
            bool flag = false;
            using(StreamReader jsonStream = System.IO.File.OpenText(path2))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el archivo

                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json); //Se crea una variable que contiene todos los bagcarts
                foreach (Usuario usuariotp in usuarios)
                {
                    if(usuariotp.Cedula == bagcart.cedulaTrab) //Se valida que la cedula de los trabajadores concuerden
                    {
                        flag = true;
                    }
                }  
            }
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();//Se lee el archivo
                var bagcarts = JsonConvert.DeserializeObject<List<BagCart>>(json);//Se crea una variable que contiene todos los bagcarts
                foreach (BagCart bagcarttp in bagcarts)
                {
                    if((bagcarttp.identificador_BC == bagcart.identificador_BC) || (flag == false)) //Se valida que los id de los bagcarts concuerden y se valida el flag
                    {
                        estadotp.estado = "ERROR";
                        return estadotp; //Se retorna el estado del post
                    }
                }

                bagcarts.Add(bagcart); //Se añade el bagcart
                string json2 = JsonConvert.SerializeObject(bagcarts);
                jsonEscribir = json2; //Se escribe el json
            }

            System.IO.File.WriteAllText(path, jsonEscribir);
            estadotp.estado = "OK";
            return estadotp; ;//Se retorna el estado del post
        }

    }
}
