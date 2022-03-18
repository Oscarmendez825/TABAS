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

        //private string path = @"C:\Users\Familia\Documents\Gabo\Pruebas\REST\RestAPI\REST\DB\BAGCART.json";
        //private string path2 = @"C:\Users\Familia\Documents\Gabo\Pruebas\REST\RestAPI\REST\DB\TRABAJADORES.json";

        private string path = @"C:\Users\dani_\Documents\GitHub\TABAS\REST\DB\BAGCART.json";
        private string path2 = @"C:\Users\dani_\Documents\GitHub\TABAS\REST\DB\TRABAJADORES.json";

        // GET: api/<BagCartController>
        [HttpGet("Bagcarts")]
        public string GetBagCarts()
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                return json;
            }
        }

        // GET api/<BagCartController>/5
        [HttpGet("{identificador_BC}")]
        public string GetBagCart(string identificador_BC)
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
        public Estado agregarBagCart(BagCart bagcart)
        {
            string jsonEscribir = "";
            Estado estadotp = new Estado();
            bool flag = false;
            using(StreamReader jsonStream = System.IO.File.OpenText(path2))
            {
                var json = jsonStream.ReadToEnd();

                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
                foreach(Usuario usuariotp in usuarios)
                {
                    if(usuariotp.Cedula == bagcart.cedulaTrab)
                    {
                        flag = true;
                    }
                }  
            }
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var bagcarts = JsonConvert.DeserializeObject<List<BagCart>>(json);
                foreach(BagCart bagcarttp in bagcarts)
                {
                    if((bagcarttp.identificador_BC == bagcart.identificador_BC) || (flag == false))
                    {
                        estadotp.estado = "ERROR";
                        return estadotp;
                    }
                }

                bagcarts.Add(bagcart);
                string json2 = JsonConvert.SerializeObject(bagcarts);
                jsonEscribir = json2;
            }

            System.IO.File.WriteAllText(path, jsonEscribir);
            estadotp.estado = "OK";
            return estadotp; ;
        }

    }
}
