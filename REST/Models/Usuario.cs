using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

/// <summary>
/// Modelo de la entidad Usuario
/// </summary>

namespace REST.Models
{
    public class Usuario
    {
        //Primary keys
        public int Cedula { get; set; }

        //Entity attributes
        public string contrasena { get; set; }
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public string rol { get; set; } = "";
    
    }

}

