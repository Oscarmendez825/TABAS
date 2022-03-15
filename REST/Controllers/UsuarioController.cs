using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using REST.Models;
using Newtonsoft.Json;
using System.IO;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private string path = @"C:\Users\omend\Documents\GitHub\TABAS\REST\DB\TRABAJADORES.json";

        /**
         * Metodo que retorna la informacion de todos los usuarios
         */

        // GET: api/<ValuesController>/Trabajadores
        [HttpGet("Trabajadores")]
        public string GetUsuarios()
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                return json;
            }
        }

        /**
         * Metodo utilizado para solicitar la informacion de un trabajador
         */

        // GET api/<ValuesController>/Trabajadores/{cedula}
        [HttpGet("Trabajadores/{cedula}")]
        public string GetUsuario(string cedula)
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

        /**
         * Metodo utilizado para registrar un nuevo trabajador
         */

        // POST api/<ValuesController>
        [HttpPost]
        public Estado PostRegistrar(Usuario usuario)
        {
            string jsonEscribir = "";
            Estado estadotp = new Estado();
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
                foreach (Usuario usuariotp in usuarios)
                {
                    if (usuariotp.Cedula == usuario.Cedula)
                    {
                        estadotp.estado = "ERROR";
                        return estadotp;
                    }
                }
                usuarios.Add(usuario);
                string json2 = JsonConvert.SerializeObject(usuarios);
                jsonEscribir = json2;
            }
            System.IO.File.WriteAllText(path, jsonEscribir);
            estadotp.estado = "OK";
            return estadotp;
        }

        /**
         * Metodo utilizado para el inicio de sesion de un trabajador
         */

        //POST: api/<ValuesController>/IniciarSesion
        [HttpPost("IniciarSesion")]
        public Estado PostIniciarSesion(Usuario usuario)
        {
            Estado estadotp = new Estado();
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
                foreach (Usuario usuariotp in usuarios)
                {
                    if (usuariotp.Cedula == usuario.Cedula)
                    {
                        if (usuariotp.contrasena == usuario.contrasena)
                        {
                            estadotp.estado = "OK";
                            return estadotp;
                        }
                    }
                }
            }
            estadotp.estado = "ERROR";
            return estadotp;
        }


    }
}
