namespace AppTabas.APIModels
{
    /// <summary>
    /// This class represents a bag of the app.
    /// It is used for JSON serialization.
    /// </summary>
    public class Bag
    {
        public int numero_maleta { get; set; }
        public int cedulaUsuario { get; set; }
        public int bagcartId { get; set; }
        public int numVuelo { get; set; }
        public int peso { get; set; }
        public string color { get; set; }
        public bool aceptada { get; set; }
        public int costo { get; set; } 
        public int scanId { get; set; }

        public Bag(int numero_maleta, int bagcartId)
        {
            this.numero_maleta = numero_maleta; 
            this.bagcartId = bagcartId;     
        }
    }
}