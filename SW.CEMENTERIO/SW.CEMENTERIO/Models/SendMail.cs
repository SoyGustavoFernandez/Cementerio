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
        public static bool EnviarCorreo(Dictionary<string, string> parameters, bool isReset = false)
        {
            try
            {
                string _emailOrigen = ConfigurationManager.AppSettings["CorreoCementerio"];
                string _clave = ConfigurationManager.AppSettings["ContrasenaCementerioSecure"];
                string _emailDestino = parameters.First(x => x.Key == "Correo").Value;
                StringBuilder sb = new StringBuilder();
                sb.Append("<td align=\"center\">" +
                    "<h1>Te damos la Bienvenida al Sistema!</h1>" +
                    "</td>" +
                    "<td align=\"center\">" +
                    "<table style=\"border-radius: 4px; border-collapse: separate; background-color: #ffffff;\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"#ffffff\">" +
                    "<tbody>" +
                    "<tr>" +
                    "<td bgcolor=\"#ffffff\" align=\"left\">" +
                    $"<p><b>{parameters.First(x => x.Key == "Colaborador").Value}</b>, estamos emocionados de que comiences. Para ello te compartimos tu contraseña generada automáticamente: \n  <p style=\"text-align: center\"<b>{parameters.First(x => x.Key == "Clave").Value}</b></p> \n recuerda que esta contraseña puedes modificarla en cualquier momento desde tu perfil personal dentro del sistema.</p>" +
                    "</td>" +
                    "</tr>" +
                    "<tr>" +
                    $"<td align=\"center\"><span><a href={ConfigurationManager.AppSettings["LinkSistema"]} target=\"_blank\" style=\"border-width: 15px 30px;\">Acceder al Sistema</a></span></td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td align=\"left\">" +
                    "<p>Si eso no funciona, copie y pegue el siguiente enlace en su navegador:</p>" +
                    "</td>" +
                    "</tr>" +
                    "<tr>" +
                    $"<td align=\"left\"><a target = \"_blank\" href={ConfigurationManager.AppSettings["LinkSistema"]}>{ConfigurationManager.AppSettings["LinkSistema"]}</a></td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td align=\"left\">" +
                    "<p>Saludos,<br>Equipo de Desarrollo<br></p>" +
                    "</td>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>" +
                    "</td>" +
                    "</tr>" +
                    "</td>");
                if (isReset)
                {
                    sb = new StringBuilder();
                    sb.Append("<td align=\"center\">" +
                        "<h1>Te enviamos tu contraseña!</h1>" +
                        "</td>" +
                        "<td align=\"center\">" +
                        "<table style=\"border-radius: 4px; border-collapse: separate; background-color: #ffffff;\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"#ffffff\">" +
                        "<tbody>" +
                        "<tr>" +
                        "<td bgcolor=\"#ffffff\" align=\"left\">" +
                        $"<p><b>{parameters.First(x => x.Key == "Colaborador").Value}</b>, se ha solicitado el reenvío de su contraseña para poder iniciar sesión, te compartimos tu contraseña generada automáticamente: \n  <p style=\"text-align: center\"<b>{parameters.First(x => x.Key == "Clave").Value}</b></p> \n recuerda que esta contraseña puedes modificarla en cualquier momento desde tu perfil personal dentro del sistema.</p>" +
                        "</td>" +
                        "</tr>" +
                        "<tr>" +
                        $"<td align=\"center\"><span><a href={ConfigurationManager.AppSettings["LinkSistema"]} target=\"_blank\" style=\"border-width: 15px 30px;\">Acceder al Sistema</a></span></td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td align=\"left\">" +
                        "<p>Si eso no funciona, copie y pegue el siguiente enlace en su navegador:</p>" +
                        "</td>" +
                        "</tr>" +
                        "<tr>" +
                        $"<td align=\"left\"><a target = \"_blank\" href={ConfigurationManager.AppSettings["LinkSistema"]}>{ConfigurationManager.AppSettings["LinkSistema"]}</a></td>" +
                        "</tr>" +
                        "<tr>" +
                        "<td align=\"left\">" +
                        "<p>Saludos,<br>Equipo de Desarrollo<br></p>" +
                        "</td>" +
                        "</tr>" +
                        "</tbody>" +
                        "</table>" +
                        "</td>" +
                        "</tr>" +
                        "</td>");
                }
                MailMessage oMailMesagge = new MailMessage(_emailOrigen, _emailDestino, parameters.First(x => x.Key == "Asunto").Value, sb.ToString())
                {
                    IsBodyHtml = true
                };
                SmtpClient oSmtpClient = new SmtpClient(ConfigurationManager.AppSettings["SMTPCorreo"])
                {
                    EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SSLCorreo"]),
                    Port = Convert.ToInt32(ConfigurationManager.AppSettings["PORTCorreo"]),
                    Credentials = new NetworkCredential(_emailOrigen, _clave)
                };
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
