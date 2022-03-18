using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST.Clases;
using REST.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private string path = @"C:\Users\omend\Documents\GitHub\TABAS\REST\DB\VUELOS.json";
        private string path2 = @"C:\Users\omend\Documents\GitHub\TABAS\REST\DB\MALETAS.json";
       
        /// <summary>
        /// Get de valores para el reporte
        /// </summary>
        /// <returns>S retorna un strin gcon los datos</returns>
        [HttpGet]
        public string getReporte()
        {
            List<Reporte> reportes = new List<Reporte>(); //Se crea una lista para los valores
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();//Se lee el archivo
                var vuelos = JsonConvert.DeserializeObject<List<Vuelo>>(json);
                foreach (Vuelo vuelotp in vuelos)
                {
                    //Se dan valores a los atributos del reporte
                    Reporte reporte = new Reporte();
                    reporte.numVuelo = vuelotp.numVuelo;
                    reporte.capacidad = vuelotp.capacidad;
                    reporte.placaAvion = vuelotp.placaAvion;
                    reporte.tMaletasV = vuelotp.numMaletas;
                    reporte.BCId = vuelotp.BC_ID;
                    reportes.Add(reporte);
                }
            }

            // SE CALCULA EL TOTAL DE MALETAS EN BC
            // SE CALCULA EL TOTAL DE MALETAS RECHAZADAS
            using (StreamReader jsonStream = System.IO.File.OpenText(path2))
            {
                //Inicialización de parametros
                var json = jsonStream.ReadToEnd();
                var maletas = JsonConvert.DeserializeObject<List<Maleta>>(json);
                int contador = 0;
                int contadorRechazadas = 0;
                foreach (Reporte reportetp in reportes)
                {
                    foreach (Maleta maletatp in maletas)
                    {
                        if (maletatp.bagcartId == reportetp.BCId) { //Se valida el id del bagcart
                            contador++;
                            if (maletatp.aceptada == false) { //Se valida el estado de aceptación de la maleta
                                contadorRechazadas++; 
                            }
                        }
                        reportetp.tMaletasBC = contador; //Se le da valor a las maletas en bagcarts
                        reportetp.tMaletasRe = contadorRechazadas; //Se le da valor a las maletas rechazadas
                    }
                }
                
            }
            string json2 = JsonConvert.SerializeObject(reportes);
            return json2; //Se escribe y retorna el json
        }
        
    }
}
