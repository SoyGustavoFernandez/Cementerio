using SW.CEMENTERIO.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SW.CEMENTERIO.Models
{
    public class SendMail
    {
        public static async Task<bool> EnviarCorreoContrato(string correo, string correoCC, string CCO, int idtipo, Dictionary<string, string> parameters, string asunto, byte[] documento = null)
        {
            ENT_SendMailPersonalizado oBESendMail = new ENT_SendMailPersonalizado();
            oBESendMail.Destinatarios = new List<string>();
            oBESendMail.DestinatariosCC = new List<string>();
            oBESendMail.DestinatariosCO = new List<string>();
            oBESendMail.Parametros = new Dictionary<string, string>();
            oBESendMail.ListadoColumnas = new Dictionary<string, List<string>>();
            oBESendMail.ListadoFilas = new Dictionary<string, List<List<string>>>();

            string[] correos = correo.Split(';');
            string[] correosCC = correoCC.Split(';');
            string[] correosCO = CCO.Split(';');

            foreach (var item in correos)
            {
                oBESendMail.Destinatarios.Add(item);
            }
            foreach (var item in correosCC)
            {
                oBESendMail.DestinatariosCC.Add(item);
            }
            foreach (var item in correosCO)
            {
                oBESendMail.DestinatariosCO.Add(item);
            }

            var attachment = new Dictionary<string, byte[]>();

            switch (idtipo)
            {
                case 1: // Modelo de correo que llega al jefe para que gestione la(s) renovación(es) (este correo debe llegar a diario hasta que se gestione)
                    oBESendMail.Parametros.Add("CantContratos", parameters.First(x => x.Key == "CantContratos").Value);
                    oBESendMail.Parametros.Add("Periodo", parameters.First(x => x.Key == "Periodo").Value);
                    oBESendMail.Plantilla = "autoservicio.contrato.porgestionar.html"; // https://losportalesdev.blob.core.windows.net/central/plantillas.correo.interno/autoservicio.contrato.porgestionar.html
                    break;
                case 2: // Modelo de correo que llega a CH cuando el jefe aprueba una renovación
                    oBESendMail.Parametros.Add("Cantidad", parameters.First(x => x.Key == "Cantidad").Value);
                    oBESendMail.Parametros.Add("Solicitante", parameters.First(x => x.Key == "Solicitante").Value);
                    oBESendMail.Plantilla = "autoservicio.contrato.gestionado.masivo.renovacion.toCH.html";
                    break;
                case 3: // Modelo de correo que llega a CH cuando el jefe no renueva
                    oBESendMail.Parametros.Add("Cantidad", parameters.First(x => x.Key == "Cantidad").Value);
                    oBESendMail.Parametros.Add("Solicitante", parameters.First(x => x.Key == "Solicitante").Value);
                    oBESendMail.Plantilla = "autoservicio.contrato.gestionado.masivo.norenueva.toCH.html";
                    break;
                case 4: // Modelo de correo que llega a CH cuando el jefe autoriza el pase a estable
                    oBESendMail.Parametros.Add("Cantidad", parameters.First(x => x.Key == "Cantidad").Value);
                    oBESendMail.Parametros.Add("Solicitante", parameters.First(x => x.Key == "Solicitante").Value);
                    oBESendMail.Plantilla = "autoservicio.contrato.gestionado.masivo.estable.toCH.html";
                    break;
                case 5: // Modelo de correo que llega al jefe cuando CH observa una renovación (este proceso debe ser individual)
                    oBESendMail.Parametros.Add("Colaborador", parameters.First(x => x.Key == "Colaborador").Value);
                    oBESendMail.Parametros.Add("Observacion", parameters.First(x => x.Key == "Observacion").Value);
                    oBESendMail.Plantilla = "autoservicio.contrato.observado.html";
                    break;
                case 6: // Modelo de correo que llega al jefe cuando CH elabora la renovación o estable y está lista para descargar (este correo debe llegar a diario hasta que se cierre el flujo)
                    oBESendMail.Parametros.Add("CantContratos", parameters.First(x => x.Key == "CantContratos").Value);
                    oBESendMail.Plantilla = "autoservicio.contrato.gestionarfirma.html";
                    break;
                case 7: // Modelo de correo que llega al jefe informando las NO RENOVACIONES (este correo debe llegar el penúltimo día hábil del mes)
                    oBESendMail.Parametros.Add("CantContratos", parameters.First(x => x.Key == "CantContratos").Value);
                    oBESendMail.Parametros.Add("Colaboradores", parameters.First(x => x.Key == "Colaboradores").Value);
                    oBESendMail.Plantilla = "autoservicio.contrato.norenovaciones.html";
                    break;
                case 8: // Modelo de correo que llega al jefe cuando CH rechaza un documento cargado por el jefe (este proceso debe ser individual)
                    oBESendMail.Parametros.Add("Colaborador", parameters.First(x => x.Key == "Colaborador").Value);
                    oBESendMail.Plantilla = "autoservicio.contrato.firmarechazado.html";
                    break;
                case 9: // Modelo de correo que se envia al jefe aprobador de contrato para notificar que el documento esta listo para descargar
                    oBESendMail.Parametros.Add("CantContratos", parameters.First(x => x.Key == "CantContratos").Value);
                    oBESendMail.Plantilla = "autoservicio.contrato.notificar.aprobador.html";
                    break;
                case 10: // Modelo de correo que se envia al colaborador para notificar que el documento esta listo para descargar
                    oBESendMail.Parametros.Add("TipoDocumento", parameters.First(x => x.Key == "TipoDocumento").Value);
                    oBESendMail.Plantilla = "autoservicio.contrato.notificar.colaborador.html";

                    attachment.Add(parameters.First(x => x.Key == "NombreDocumento").Value, documento);
                    oBESendMail.Attachments = attachment;
                    break;
                case 11: // Modelo de correo que llega a CH cuando el jefe solicita el cese por periodo de prueba
                    oBESendMail.Parametros.Add("Cantidad", parameters.First(x => x.Key == "Cantidad").Value);
                    oBESendMail.Parametros.Add("Solicitante", parameters.First(x => x.Key == "Solicitante").Value);
                    oBESendMail.Plantilla = "autoservicio.contrato.masivo.cese.toCH.html";
                    break;
                case 12: // Modelo de correo que llega al jefe informando las SOLICITUDES DE CESE (este correo debe llegar el penúltimo día hábil del mes)
                    oBESendMail.Parametros.Add("CantContratos", parameters.First(x => x.Key == "CantContratos").Value);
                    oBESendMail.Parametros.Add("Colaboradores", parameters.First(x => x.Key == "Colaboradores").Value);
                    oBESendMail.Plantilla = "autoservicio.contrato.cese.html";
                    break;
            }

            oBESendMail.Asunto = "Modulo de contratos - " + asunto;
            oBESendMail.Correo = "cementeriometropolitanopiura@gmail.com";// ConfigurationManager.AppSettings["CorreoCementerio"];
            oBESendMail.Contrasena = "UTP_C3m3nterio2022*"; //ConfigurationManager.AppSettings["ContrasenaCementerio"];

            HttpClient client = new HttpClient();

            // Request headers
            client.BaseAddress = new Uri("http://devapi-lp.azure-api.net"); //new Uri(ConfigurationManager.AppSettings["ApimURI"]);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "1f3fbd357ad3483d9fecd07a380b7420"); //"Ocp-Apim-Subscription-Key", ConfigurationManager.AppSettings["ApimSubscriptionKey"]);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var uri = "/EnvioMails/api/SendMail/personalizado";

            try
            {
                HttpResponseMessage response;
                response = await client.PostAsJsonAsync(uri, oBESendMail);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }
    }
}
