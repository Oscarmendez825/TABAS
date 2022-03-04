using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TABAS.Models
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Cedula { get; set; }
        public string rol { get; set; }
        public string contrasena { get; set; }
    }
}

