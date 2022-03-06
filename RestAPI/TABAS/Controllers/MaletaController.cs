using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TABAS.Models;
using System.IO;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TABAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaletaController : ControllerBase
    {

        private string path = @"C:\Users\omend\Documents\GitHub\TABAS\RestAPI\TABAS\DB\MALETAS.json";
        private string path2 = @"C:\Users\omend\Documents\GitHub\TABAS\RestAPI\TABAS\DB\TRABAJADORES.json";
        // GET: api/<MaletaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Todas las maletas" };
        }

        // GET api/<MaletaController>/5
        [HttpGet("{numero_maleta}")]
        public string Get(string numero_maleta)
        {
            return numero_maleta switch
            {
                "1" => "Maleta 1",
                "2" => "Maleta 2",
                "3" => "Maleta 4",
                "4" => "Maleta 4",
                _ => throw new NotSupportedException("Número de maleta invalida")
            };
        }

        /**
           * Metodo crear una nueva maleta
           */

        // POST api/<MaletaController>
        [HttpPost]
        public string PostRegistrar(Maleta maleta)
        {
            string jsonEscribir = "";
            bool flag = false;
            using (StreamReader jsonStream = System.IO.File.OpenText(path2))
            {
                var json = jsonStream.ReadToEnd();
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
                foreach (Usuario usuariotp in usuarios)
                {
                    if (usuariotp.Cedula == maleta.cedulaUsuario) 
                    {
                        flag = true;
                    }
                }
            }
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var maletas = JsonConvert.DeserializeObject<List<Maleta>>(json);
                foreach (Maleta maletatp in maletas)
                {
                    if ((maletatp.numero_maleta == maleta.numero_maleta) || (flag == false))
                    {
                        return "ERROR";
                    }
                }
                maletas.Add(maleta);
                string json2 = JsonConvert.SerializeObject(maletas);
                jsonEscribir = json2;
            }
            System.IO.File.WriteAllText(path, jsonEscribir);
            return "OK";
        }

    }
}
