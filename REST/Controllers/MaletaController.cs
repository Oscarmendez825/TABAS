﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using REST.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaletaController : ControllerBase
    {

        //private string path = @"C:\Users\Familia\Documents\Gabo\Pruebas\REST\RestAPI\REST\DB\MALETAS.json";
       // private string path2 = @"C:\Users\Familia\Documents\Gabo\Pruebas\REST\RestAPI\REST\DB\TRABAJADORES.json";

        private string path = @"C:\Users\omend\Documents\GitHub\TABAS\REST\DB\MALETAS.json";
        private string path2 = @"C:\Users\omend\Documents\GitHub\TABAS\REST\DB\TRABAJADORES.json";

        // GET: api/<MaletaController>
        [HttpGet("Maletas")]
        public string GetUsuarios()
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                return json;
            }
        }

        // GET api/<MaletaController>/5
        [HttpGet("{numero_maleta}")]
        public string Get(string numero_maleta)
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var maletas = JsonConvert.DeserializeObject<List<Maleta>>(json);
                foreach (Maleta maletatp in maletas)
                {
                    if(maletatp.numero_maleta == Int32.Parse(numero_maleta))
                    {
                        return JsonConvert.SerializeObject(maletatp);
                    }
                }

            }

            return "ERROR";

        }

        // POST api/<MaletaController>
        [HttpPost]
        public Estado PostRegistrar(Maleta maleta)
        {
            Estado estadotp = new Estado();
            string jsonEscribir = "";
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var maletas = JsonConvert.DeserializeObject<List<Maleta>>(json);
                foreach (Maleta maletatp in maletas)
                {
                    if ((maletatp.numero_maleta == maleta.numero_maleta))
                    {
                        estadotp.estado = "ERROR";
                        return estadotp;
                    }
                }
                maletas.Add(maleta);
                string json2 = JsonConvert.SerializeObject(maletas);
                jsonEscribir = json2;
            }
            System.IO.File.WriteAllText(path, jsonEscribir);
            estadotp.estado = "OK";
            return estadotp;
        }

    }
}