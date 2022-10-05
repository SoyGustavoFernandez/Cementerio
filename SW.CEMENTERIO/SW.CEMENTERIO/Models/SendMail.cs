using Microsoft.AspNetCore.Http;
using SW.CEMENTERIO.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SW.CEMENTERIO.Models
{
    public class SendMail
    {
        public static bool EnviarCorreo(Dictionary<string, string> parameters)
        {
            try
            {
                string _emailOrigen = "cementeriometropolitanopiura@gmail.com";
                string _clave = "mzfgebvkjlunpwpn";
                string _emailDestino = parameters.First(x => x.Key == "Correo").Value;
                MailMessage oMailMesagge = new MailMessage(_emailOrigen, _emailDestino, parameters.First(x => x.Key == "Asunto").Value, $"Estimado {parameters.First(x => x.Key == "Colaborador").Value} su contraseña es: <b>{parameters.First(x => x.Key == "Clave").Value}</b>");
                oMailMesagge.IsBodyHtml = true;
                SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
                oSmtpClient.EnableSsl = true;
                oSmtpClient.Port = 587;
                oSmtpClient.Credentials = new NetworkCredential(_emailOrigen, _clave);
                oSmtpClient.Send(oMailMesagge);
                oSmtpClient.Dispose();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
