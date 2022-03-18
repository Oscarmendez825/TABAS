using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Modelo de la entidad BagCart
/// </summary>

namespace REST.Models
{
    public class BagCart
    {
        //Primary Key
        public int identificador_BC { get; set; }

        //Forean Key from Usuario Model
        public int cedulaTrab { get; set; }

        //Entity Attributes
        public string marca { get; set; } 
        public int anno { get; set; }
        public int numSello { get; set; }
    }
}
