using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Models
{
    public class Vuelo
    {
        //Primary Key
        public int numVuelo { get; set; }

        //Forean Keys
        public int BC_ID { get; set; }
        public int placaAvion { get; set; }

        //Entity Attributes
        public int capacidad { get; set; } 
        public int numMaletas { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }

        

    }
}
