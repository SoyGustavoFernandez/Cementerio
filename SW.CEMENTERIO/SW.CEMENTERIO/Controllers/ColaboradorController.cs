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
            return View();
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
                    objColaborador.COLS_USUREGISTRO = "ADMIN";
                    ColaboradorLN.Insert(objColaborador);

                    objColaborador.LOGN_IDCOLABORADOR = objColaborador.COLN_IDCOLABORADOR;
                    objColaborador.LOGS_USUARIO = objColaborador.COLS_CORREO;
                    objColaborador.LOGS_CLAVE = Utilitarios.EncryptTripleDES(Utilitarios.NumeroAletorio(), ConfigurationManager.AppSettings["SendMailKey"]);
                    objColaborador.LOGS_USUREGISTRO = "ADMIN";
                    loginLN.Insert(objColaborador);
                }
                else
                {
                    objColaborador.COLS_USUMODIFICA = "ADMIN";
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
        public async Task<JsonResult> RecuperaClave(int idColaborador)
        {
            ResponseViewModel oResponse = new();
            try
            {
                ENT_TA_LOGIN modelo = new ENT_TA_LOGIN();
                BLL_TA_LOGIN bllLogin = new BLL_TA_LOGIN();
                modelo = bllLogin.SelectAllByLOGN_IDCOLABORADOR(idColaborador).FirstOrDefault();

                var parameters = new Dictionary<string, string> { { "Colaborador", "Gustavo" } };
                var asunto = string.Empty;

                if (!string.IsNullOrEmpty(modelo.COLS_CORREO))
                    oResponse.Estado = await SendMail.EnviarCorreoContrato(modelo.COLS_CORREO, "", "", 8, parameters, asunto);

                if (!oResponse.Estado) throw new Exception();

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
