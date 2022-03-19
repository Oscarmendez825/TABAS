/// <summary>
/// Modelo de la entidad avión
/// </summary>

namespace REST.Models
{
    public class Avion
    {
        //Primary Key
        public int placaAvion { get; set; }

        //Entity Attributes
        public string Aerolinea { get; set; }
        public string Modelo { get; set; }
        public int CapacidadAvion { get; set; }
        public int SeccionesBod { get; set; }
        public string TipoAvion { get; set; }
    }
}
