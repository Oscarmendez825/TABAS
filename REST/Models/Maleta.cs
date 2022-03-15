using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Models
{
    public class Maleta
    {
        //Primary Key
        public int numero_maleta { get; set; }

        //Forean Keys
        public int cedulaUsuario { get; set; }

        public int BC_ID { get; set; }

        //Entity attributes
        public int peso { get; set; }
        public string color { get; set; }
        public bool aceptada { get; set; }
        public int costo { get; set; }
        



    }
}
