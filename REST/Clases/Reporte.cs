/// <summary>
/// Creación del modelo de los reportes con la información necesaria para estos
/// </summary>

namespace REST.Clases
{
    public class Reporte
    {
        public int numVuelo { get; set; }
        public int placaAvion { get; set; }
        public int capacidad { get; set; }
        public int tMaletasV { get; set; }
        public int tMaletasBC { get; set; }
        public int tMaletasRe { get; set; }
        public int BCId { get; set; }

    }
}
