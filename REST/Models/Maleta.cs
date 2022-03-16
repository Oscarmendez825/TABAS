namespace REST.Models
{
    public class Maleta
    {
        //Primary Key
        public int numero_maleta { get; set; }

        //Forean Keys
        public int cedulaUsuario { get; set; }
        public int bagcartId { get; set; }
        public int numVuelo { get; set; }

        //Entity attributes
        public int peso { get; set; }
        public string color { get; set; }
        public bool aceptada { get; set; }
        public int costo { get; set; }  //Costo en dolares
        public int scanId { get; set; } //Id del trabajador que escaneo y asigno la maleta

        /// <summary>
        /// Calcula el costo de la maleta segun su peso
        /// </summary>
        public void calcCosto()
        {
            int nuevoCosto = 35; //Costo inicial

            if (this.peso > 25) {
                nuevoCosto += 80;  //Cargo por sobrepeso         
            }
            if (this.peso > 150)
            {
                nuevoCosto += 250; //Cargo adicional por bodegaje y peso industrial
            }
            this.costo = nuevoCosto;
        }

        /// <summary>
        /// Establece el estado de la maleta como aceptada o no despues de su scan
        /// </summary>
        public void estadoAceptacion()
        {
            Random rand = new();

            if (rand.Next(0, 2) != 0)
            {
                this.aceptada = true;
            }

        }
    }
}
