using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Modelo de la entidad Vuelo
/// </summary>

namespace REST.Models
{
    public class Vuelo
    {
        //Primary Key
        public int numVuelo { get; set; } = 0;

        //Forean Keys
        public int BC_ID { get; set; } = 0;
        public int placaAvion { get; set; } = 0;

        //Entity Attributes
        public int capacidad { get; set; } = 0;
        public int numMaletas { get; set; } = 0;
        public string origen { get; set; } = "";
        public string destino { get; set; } = "";

        

    }
}
