using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST.Models;
using System.Xml;
using System.Xml.Schema;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaletaController : ControllerBase
    {

        //private string path = @"C:\Users\Familia\Documents\Gabo\Pruebas\REST\RestAPI\REST\DB\MALETAS.json";
        // private string path2 = @"C:\Users\Familia\Documents\Gabo\Pruebas\REST\RestAPI\REST\DB\TRABAJADORES.json";

        private string path = @"C:\Users\dani_\Documents\GitHub\TABAS\REST\DB\MALETAS.json";

        // GET: api/<MaletaController>
        [HttpGet("Maletas")]
        public string GetMaletas()
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                return json;
            }
        }

        // GET api/<MaletaController>
        [HttpGet("{numero_maleta}")]
        public string GetMaleta(string numero_maleta)
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var maletas = JsonConvert.DeserializeObject<List<Maleta>>(json);
                foreach (Maleta maletatp in maletas)
                {
                    if (maletatp.numero_maleta == Int32.Parse(numero_maleta))
                    {
                        return JsonConvert.SerializeObject(maletatp);
                    }
                }
            }
            return "ERROR";
        }

        /// <summary>
        /// Metodo GET para conseguir el costo de una maleta
        /// </summary>
        /// <param name="numero_maleta"> El numero identificador de la maleta deseada </param>
        /// <returns></returns>
        [HttpGet("getCosto/{num_maleta}")]
        public int GetCosto(string numero_maleta)
        {
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var maletas = JsonConvert.DeserializeObject<List<Maleta>>(json);
                foreach (Maleta maletatp in maletas)
                {
                    if (maletatp.numero_maleta == Int32.Parse(numero_maleta))
                    {
                        return maletatp.costo;
                    }
                }
            }
            return 0;
        }

        // POST api/<MaletaController>
        [HttpPost]
        public Estado addMaleta(Maleta maleta)
        {
            Estado estadotp = new();
            string jsonEscribir = "";
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var maletas = JsonConvert.DeserializeObject<List<Maleta>>(json);
                foreach (Maleta maletatp in maletas)
                {
                    if ((maletatp.numero_maleta == maleta.numero_maleta))
                    {
                        estadotp.estado = "ERROR";
                        return estadotp;
                    }
                }
                maleta.calcCosto();
                maleta.estadoAceptacion(); 
                maletas.Add(maleta);
                CrearXML(maleta);
                string json2 = JsonConvert.SerializeObject(maletas);
                jsonEscribir = json2;
            }
            System.IO.File.WriteAllText(path, jsonEscribir);
            estadotp.estado = "OK";
            return estadotp;
        }
        public void CrearXML(Maleta maleta){
            // Create the FirstName and LastName elements
            XmlSchemaElement ClaveElement = new XmlSchemaElement();
            ClaveElement.Name = "Clave";
            Random rd = new Random();
            int numClave = rd.Next(1000000,99999999);
            ClaveElement.DefaultValue=numClave.ToString();

            XmlSchemaElement CodiActiElement = new XmlSchemaElement();
            CodiActiElement.Name = "CodigoActividad";
            int numCodiActi = rd.Next(100000,999999);
            CodiActiElement.DefaultValue=numCodiActi.ToString();

            XmlSchemaElement NumConseElement = new XmlSchemaElement();
            NumConseElement.Name = "NumeroConsecutivo";
            NumConseElement.DefaultValue=maleta.numero_maleta.ToString();

            DateTime thisDay = DateTime.Today;
            XmlSchemaElement FechaEmisionElement = new XmlSchemaElement();        
            FechaEmisionElement.Name = "FechaEmision";
            FechaEmisionElement.DefaultValue=thisDay.ToString("d");

            XmlSchemaElement EmisorElement = new XmlSchemaElement();
            EmisorElement.Name = "Emisor";
            EmisorElement.DefaultValue=maleta.cedulaUsuario.ToString();

            XmlSchemaElement ReceptorElement = new XmlSchemaElement();
            ReceptorElement.Name = "Receptor";
            ReceptorElement.DefaultValue="25394000";

            XmlSchemaElement CondVentElement = new XmlSchemaElement();
            CondVentElement.Name = "CondicionVenta";
            CondVentElement.DefaultValue="Otros";

            XmlSchemaElement PlazoCreditoElement = new XmlSchemaElement();
            PlazoCreditoElement.Name = "PlazoCredito";
            PlazoCreditoElement.DefaultValue="NR";

            XmlSchemaElement MedioPagoElement = new XmlSchemaElement();
            MedioPagoElement.Name = "MedioPago";
            MedioPagoElement.DefaultValue="Virtual";

            XmlSchemaElement DetallesElement = new XmlSchemaElement();
            DetallesElement.Name = "DetalleServicio";
            DetallesElement.DefaultValue="Maleta:"+maleta.color+", Peso (kg):"+maleta.peso.ToString();

            XmlSchemaElement OtrosCargosElement = new XmlSchemaElement();
            OtrosCargosElement.Name = "OtrosCargosElement";
            OtrosCargosElement.DefaultValue="NR";

            XmlSchemaElement ResumenFacturaElement = new XmlSchemaElement();
            ResumenFacturaElement.Name = "ResumenFactura";
            ResumenFacturaElement.DefaultValue="Costo de la maleta en dolares es de:"+maleta.costo.ToString();

            XmlSchemaElement InformacionReferenciaElement = new XmlSchemaElement();
            InformacionReferenciaElement.Name = "InformacionReferencia";
            InformacionReferenciaElement.DefaultValue="NR";

            XmlSchemaElement OtrosElement = new XmlSchemaElement();
            OtrosElement.Name = "Otros";
            OtrosElement.DefaultValue="NR";
            // Associate the elements and attributes with their types.
            // Built-in type.
            ClaveElement.SchemaTypeName =new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

            // Create the top-level Customer element.
            XmlSchemaElement customerElement = new XmlSchemaElement();
            customerElement.Name = "FacturaElectronica";

            // Create an anonymous complex type for the Customer element.
            XmlSchemaComplexType customerType = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            sequence.Items.Add(ClaveElement);
            sequence.Items.Add(CodiActiElement);
            sequence.Items.Add(NumConseElement);
            sequence.Items.Add(FechaEmisionElement);
            sequence.Items.Add(EmisorElement);
            sequence.Items.Add(ReceptorElement);
            sequence.Items.Add(CondVentElement);
            sequence.Items.Add(PlazoCreditoElement);
            sequence.Items.Add(MedioPagoElement);
            sequence.Items.Add(DetallesElement);
            sequence.Items.Add(OtrosCargosElement);
            sequence.Items.Add(ResumenFacturaElement);
            sequence.Items.Add(InformacionReferenciaElement);
            sequence.Items.Add(OtrosElement);

            customerType.Particle = sequence;
            // Set the SchemaType of the Customer element to
            // the anonymous complex type created above.
            customerElement.SchemaType = customerType;

            // Create an empty schema.
            XmlSchema customerSchema = new XmlSchema();
            customerSchema.TargetNamespace = "https://cdn.comprobanteselectronicos.go.cr/xml-schemas/v4.3/facturaElectronica";

            // Add all top-level element and types to the schema
            customerSchema.Items.Add(customerElement);

            // Create an XmlSchemaSet to compile the customer schema.
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add(customerSchema);
            schemaSet.Compile();

            foreach (XmlSchema schema in schemaSet.Schemas()){
                customerSchema = schema;
            }
            XmlTextReader reader = new XmlTextReader("document.xml");
            FileStream file = new FileStream("document.xml", FileMode.Create, FileAccess.ReadWrite);
            XmlTextWriter xwriter = new XmlTextWriter(file, new UTF8Encoding());
            xwriter.Formatting = System.Xml.Formatting.Indented;
            customerSchema.Write(xwriter);
        }
        [HttpPost("AsignarBCMaleta")]
        public Estado asignarBagCart(Maleta maleta) {
            bool flag = false;
            Estado estadotp = new();
            string jsonEscribir = "";
            using (StreamReader jsonStream = System.IO.File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var maletas = JsonConvert.DeserializeObject<List<Maleta>>(json);
                foreach (Maleta maletatp in maletas)
                {
                    if ((maletatp.numero_maleta == maleta.numero_maleta))
                    {
                        maletatp.bagcartId = maleta.bagcartId;
                        maletatp.scanId = maleta.scanId;
                        flag = true;
                        break;
                    }
                }
                string json2 = JsonConvert.SerializeObject(maletas);
                jsonEscribir = json2;
            }
            if (flag == true)
            {
                System.IO.File.WriteAllText(path, jsonEscribir);
                estadotp.estado = "OK";
                return estadotp;
            }
            else {
                estadotp.estado = "ERROR";
                return estadotp;
            }

        }
    }
    

}
