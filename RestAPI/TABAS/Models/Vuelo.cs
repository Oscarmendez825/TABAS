using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TABAS.Models
{
    public class Vuelo
    {
        public int capacidad { get; set; }
        public int numVuelo { get; set; }
        public string tipoAvion { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }

        public int BC_ID { get; set; }

    }
}
