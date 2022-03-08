using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TABAS.Models;
using Newtonsoft.Json;
using System.IO;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TABAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private string path = @"C:\Users\Familia\Documents\Gabo\Pruebas\TABAS\RestAPI\TABAS\DB\TRABAJADORES.json";

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Todos los usuarios" };
        }

        // GET api/<ValuesController>/
        [HttpGet("{cedula}")]
        public string Get(string cedula)
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
                foreach (Usuario usuariotp in usuarios)
                {
                    if (usuariotp.Cedula == Int32.Parse(cedula))
                    {
                        return JsonConvert.SerializeObject(usuariotp);
                    }
                }
            }
            return "ERROR";
        }


        // POST api/<ValuesController>
        [HttpPost]
        public string Post(Usuario usuario)
        {
            string jsonEscribir = "";
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
                usuarios.Add(usuario);
                string json2 = JsonConvert.SerializeObject(usuarios);
                jsonEscribir = json2;
            }
            System.IO.File.WriteAllText(path, jsonEscribir);
            return "OK";
        }
    }
}
