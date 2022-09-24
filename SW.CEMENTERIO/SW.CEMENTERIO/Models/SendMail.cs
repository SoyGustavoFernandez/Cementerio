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
        public static string EnviarCorreo(string x_Correo, string x_CorreoCC, string x_CorreoCO, string Nombre, string x_Titulo, string x_Mensaje)
        {
            System.Net.Mail.MailMessage oMail = new System.Net.Mail.MailMessage();
            System.Net.Mail.SmtpClient oSMTP = new System.Net.Mail.SmtpClient();
            string Error = string.Empty;

            string resultado = string.Empty;
            try
            {
                string Cuerpo = string.Empty;
                System.Net.Mail.AlternateView texto;
                System.Net.Mail.MailAddress oMailAddress1;
                System.Net.Mail.LinkedResource oLk;
                System.Net.Mail.LinkedResource oLk1;


                //Correos Destino
                List<string> Destino = new List<string>();
                Destino = ListaCorreo(x_Correo);
                foreach (string item in Destino)
                {
                    try
                    {
                        oMailAddress1 = new System.Net.Mail.MailAddress(item);
                        oMail.To.Add(oMailAddress1);
                    }
                    catch (Exception)
                    {
                    }
                }

                //Correos CC
                List<string> DestinatariosCC = new List<string>();
                DestinatariosCC = ListaCorreo(x_CorreoCC);
                foreach (string item in DestinatariosCC)
                {
                    try
                    {
                        oMailAddress1 = new System.Net.Mail.MailAddress(item);
                        oMail.CC.Add(oMailAddress1);
                    }
                    catch (Exception)
                    {
                    }
                }

                //Correo Ocultos
                List<string> DestinatariosOcultos = new List<string>();
                DestinatariosOcultos = ListaCorreo(x_CorreoCO);
                foreach (string item in DestinatariosOcultos)
                {
                    try
                    {
                        oMailAddress1 = new System.Net.Mail.MailAddress(item);
                        oMail.Bcc.Add(oMailAddress1);
                    }
                    catch (Exception)
                    {
                    }
                }



                string cMensaje =
                    " <div style='border-bottom:1px solid #706e77;padding-bottom:5px;'><img src='cid:logo' style='width: 175px;' /></div>" +
                    "                                    <div style='padding-top:5px;font-family:Calibri, Arial,  sans-serif'>" +
                    "                                        <p>" +
                    "                                            Estimado(a): <stronger>" + Nombre + "<stronger> <br />" +
                                                                 x_Mensaje +
                    "                                        </p>" +
                    "                                        <br />" +
                    "                                        <br />" +
                    "                                        <div style='font-size:12px;font-weight:bold; font-style:italic;'>" +
                    "                                            Atentamente," +
                    "                                            <br />" +
                    "                                            System Security" +
                    "                                        </div>" +
                    "                                    </div>" +

                    "                    <table border='0' cellpadding='0' cellspacing='0' width='100%' style='color:#707070;font-family:Helvetica,Arial,sans-serif;font-size:8px;line-height:100%;padding-top:10px;margin-top:10px'>" +
                    "                        <tbody>" +
                    "                            <tr>" +
                    "                                <td align='center' valign='top'><span style='font-family:Arial,Helvetica,sans-serif;font-size:9px'> © </span> SOL Technologies " + DateTime.Now.Year + " <br></td>" +
                    "                            </tr>" +
                    "                             <tr>" +
                    "                                 <td align='center' valign='top' style='padding-top:5px'>" +
                    "                                     <img style='width:20px' title='SOL Technologies SAC' alt='SOL Technologies' src='cid:logo2'>" +
                    "                                 </td>" +
                    "                             </tr> " +
                    "                        </tbody>" +
                    "                    </table>";

                texto = AlternateView.CreateAlternateViewFromString(cMensaje, Encoding.UTF8, "text/html");


                oMail.AlternateViews.Add(texto);
                oMail.IsBodyHtml = true;
                oMail.Subject = x_Titulo;

                oMail.From = new System.Net.Mail.MailAddress("gustavo.fernandez@softgaperu.com", "Ochmon SAC");
                oSMTP.Host = "smtp.hostinger.com";
                oSMTP.Port = 465;
                oSMTP.Credentials = new System.Net.NetworkCredential("gustavo.fernandez@softgaperu.com", "Noseaschismoso.1");
                //oSMTP.EnableSsl = true; No funciona para SMARTERASP.NET
                oSMTP.Send(oMail);

                resultado = "1";
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                resultado = "0";
            }
            finally
            {
                oMail = null;
                oSMTP = null;
            }
            return resultado;
        }


        public static List<string> ListaCorreo(string x_Correos)
        {
            List<string> oListaCorreos = new List<string>();
            try
            {
                string[] oCorreos = x_Correos.Split(',');
                for (int i = 0; i < oCorreos.Length; i++)
                {
                    if (!string.IsNullOrEmpty(oCorreos[i]))
                        oListaCorreos.Add(oCorreos[i]);
                }
            }
            catch (Exception)
            {
                oListaCorreos = new List<string>();
            }
            return oListaCorreos;
        }
    }
}
