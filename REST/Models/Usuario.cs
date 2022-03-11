using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace REST.Models
{
    public class Usuario
    {
        public int Cedula { get; set; }
        public string contrasena { get; set; }
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public string rol { get; set; } = "";
    
    }

}

