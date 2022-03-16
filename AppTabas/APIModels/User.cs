namespace AppTabas.APIModels
{
    /// <summary>
    /// This class represents a user of the app.
    /// It is used for JSON serialization.
    /// </summary>
    public class User
    {
        public int Cedula;
        public string contrasena;
        public string Nombre = "";
        public string Apellido = "";
        public string rol = "";

        /// <summary>
        /// Constructor for the User class
        /// </summary>
        /// <param name="Cedula"> The user's id </param>
        /// <param name="password"> The user's password </param>
        public User(int Cedula, string password)
        {
            this.Cedula = Cedula;
            this.contrasena = password;
        }
    }
}