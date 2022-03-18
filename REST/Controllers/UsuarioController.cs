using Microsoft.AspNetCore.Mvc;
using REST.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private string path = @"C:\Users\omend\Documents\GitHub\TABAS\REST\DB\TRABAJADORES.json";

       

        /// <summary>
        /// Get de trabajdores totales
        /// </summary>
        /// <returns>Se retorna el json con todos los trabajadores</returns>

        [HttpGet("Trabajadores")]
        public string getTrabajadores()
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el archivo y se retorna el json
                return json;
            }
        }

        /// <summary>
        /// Get de trabajadores específicos según su cédula
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns>Se retorna el jso ncon el trabajador deseado</returns>

        // GET api/<ValuesController>/Trabajadores/{cedula}
        [HttpGet("Trabajadores/{cedula}")]
        public string getTrabajador(string cedula)
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();//Se lee el json
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json); //Se crea una lista de trabajadores
                foreach (Usuario usuariotp in usuarios)
                {
                    if (usuariotp.Cedula == Int32.Parse(cedula)) //Se valida la cedula
                    {
                        return JsonConvert.SerializeObject(usuariotp); //Se retorna el json
                    }
                }
            }
            return "ERROR";
        }

        /// <summary>
        /// Post de trabajadores
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Se retorna el estado de aceptación del post</returns>

        // POST api/<ValuesController>
        [HttpPost]
        public Estado addTrabajador(Usuario usuario)
        {
            //Inicialización de parametros
            string jsonEscribir = "";
            Estado estadotp = new Estado();
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el archivo
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json); //Se crea una variable con los usuarios
                foreach (Usuario usuariotp in usuarios)
                {
                    if (usuariotp.Cedula == usuario.Cedula) //Se valida que no esté repetido
                    {
                        estadotp.estado = "ERROR";
                        return estadotp; //Se retorna el estado
                    }
                }
                usuarios.Add(usuario); //Se añade el usuario
                string json2 = JsonConvert.SerializeObject(usuarios);
                jsonEscribir = json2; //Se escribe en el json
            }
            System.IO.File.WriteAllText(path, jsonEscribir);
            estadotp.estado = "OK";
            return estadotp;//Se retorna el estado
        }

        /// <summary>
        /// Post para inicio de sesión de trabajadores
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Se retorna el estado de aceptación del mismo</returns>

        //POST: api/<ValuesController>/IniciarSesion
        [HttpPost("IniciarSesion")]
        public Estado IniciarSesion(Usuario usuario)
        {
            //Inicialización del estado
            Estado estadotp = new Estado();
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd(); //Se lee el json
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json); //Se crea una variable con todos los usuarios
                foreach (Usuario usuariotp in usuarios)
                {
                    if (usuariotp.Cedula == usuario.Cedula) //Se valida que la cédula sea igual
                    {
                        if (usuariotp.contrasena == usuario.contrasena) //Se valida que la contraseña concuerde
                        {
                            estadotp.estado = "OK";
                            return estadotp; //Se retorna el estado
                        }
                    }
                }
            }
            estadotp.estado = "ERROR";
            return estadotp;//Se retorna el estado
        }


    }
}
