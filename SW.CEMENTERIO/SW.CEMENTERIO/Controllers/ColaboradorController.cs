using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SW.CEMENTERIO.BusinessLogicLayer;
using SW.CEMENTERIO.EntityLayer;
using SW.CEMENTERIO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace SW.CEMENTERIO.Controllers
{
    public class ColaboradorController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("idUsuario") != null)
                return View();
            else
                return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public JsonResult Buscar(int idColaborador)
        {
            ResponseViewModel oResponse = new();
            try
            {
                List<ENT_TA_COLABORADOR> modelo = new List<ENT_TA_COLABORADOR>();
                BLL_TA_COLABORADOR ColaboradorLN = new BLL_TA_COLABORADOR();
                if (idColaborador == 0)
                    modelo = ColaboradorLN.SelectAll();
                else
                    modelo.Add(ColaboradorLN.Select(idColaborador));
                if (modelo.Count > 0)
                {
                    oResponse.Estado = true;
                    oResponse.Tipo = 1;
                    oResponse.Mensaje = "Lista Obtenida";
                    oResponse.Datos = modelo;
                    return Json(oResponse);
                }
                else
                {
                    oResponse.Tipo = 0;
                    oResponse.Estado = false;
                    oResponse.Mensaje = "No se encontraron datos";
                    oResponse.Datos = modelo;
                    return Json(oResponse);
                }
            }
            catch (Exception e)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = e.Message;
                return Json(oResponse);
            }
        }

        [HttpPost]
        public JsonResult Guardar(ENT_TA_LOGIN objColaborador)
        {
            ResponseViewModel oResponse = new();
            try
            {
                BLL_TA_COLABORADOR ColaboradorLN = new BLL_TA_COLABORADOR();
                BLL_TA_LOGIN loginLN = new BLL_TA_LOGIN();
                using TransactionScope scope = new TransactionScope();
                if (objColaborador.COLN_IDCOLABORADOR == 0)
                {
                    objColaborador.COLS_USUREGISTRO = HttpContext.Session.GetString("idTrabajador");
                    ColaboradorLN.Insert(objColaborador);

                    objColaborador.LOGN_IDCOLABORADOR = objColaborador.COLN_IDCOLABORADOR;
                    objColaborador.LOGS_USUARIO = objColaborador.COLS_CORREO;
                    objColaborador.LOGS_CLAVE = Utilitarios.EncriptarPassword(Utilitarios.NumeroAletorio());
                    objColaborador.LOGS_USUREGISTRO = HttpContext.Session.GetString("idTrabajador");;
                    loginLN.Insert(objColaborador);

                    EnvioClave(objColaborador.COLN_IDCOLABORADOR.ToString(), "Te damos la bienvenida al Sistema");
                }
                else
                {
                    objColaborador.COLS_USUMODIFICA = HttpContext.Session.GetString("idTrabajador");
                    objColaborador.COLD_FECMODIFICA = DateTime.Now;
                    ColaboradorLN.Update(objColaborador);
                }
                oResponse.Estado = true;
                oResponse.Titulo = "Éxito";
                oResponse.AdicionalInt = objColaborador.COLN_IDCOLABORADOR;
                oResponse.Mensaje = "Colaborador " + (objColaborador.COLN_IDCOLABORADOR == 0 ? "registrado" : "actualizado") + " correctamente";
                oResponse.Tipo = 1;
                scope.Complete();
                return Json(oResponse); ;
            }
            catch (Exception e)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = e.Message;
                return Json(oResponse);
            }
        }

        [HttpDelete]
        public JsonResult Eliminar(int idColaborador)
        {
            ResponseViewModel oResponse = new();
            try
            {
                BLL_TA_COLABORADOR ColaboradorLN = new BLL_TA_COLABORADOR();
                ColaboradorLN.Delete(idColaborador);
                oResponse.Estado = true;
                oResponse.Titulo = "Éxito";
                oResponse.Mensaje = "Colaborador dado de baja correctamente";
                oResponse.Tipo = 1;
                return Json(oResponse); ;
            }
            catch (Exception e)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = e.Message;
                return Json(oResponse);
            }
        }

        [HttpPost]
        public JsonResult EnvioClave(string idColaborador, string asunto = "Recuperación de Contraseña", bool isReset = false)
        {
            ResponseViewModel oResponse = new();
            try
            {
                ENT_TA_LOGIN modelo = new ENT_TA_LOGIN();
                BLL_TA_LOGIN bllLogin = new BLL_TA_LOGIN();
                if (isReset)
                    modelo = bllLogin.SelectAllByCOLS_CORREO(idColaborador);
                else
                    modelo = bllLogin.SelectAllByLOGN_IDCOLABORADOR(Convert.ToInt32(idColaborador)).FirstOrDefault();
            
                    var parameters = new Dictionary<string, string> { 
                    { "Correo", modelo.COLS_CORREO },
                    { "Colaborador", modelo.COLS_NOMBRES + " " + modelo.COLS_APEPATERNO + " " + modelo.COLS_APEMATERNO },
                    { "Clave", Utilitarios.DesencriptarPassword(modelo.LOGS_CLAVE) },
                    { "Asunto", asunto }
                };

                if (!string.IsNullOrEmpty(modelo.COLS_CORREO))
                    oResponse.Estado = SendMail.EnviarCorreo(parameters, isReset);

                if (!oResponse.Estado) throw new Exception("No se pudo enviar el correo electrónico");

                oResponse.Titulo = "Éxito";
                oResponse.Mensaje = "Correo enviado correctamente";
                oResponse.Tipo = 1;
                return Json(oResponse); ;
            }
            catch (Exception e)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = e.Message;
                return Json(oResponse);
            }
        }
    }
}
