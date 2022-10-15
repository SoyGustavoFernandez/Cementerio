using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SW.CEMENTERIO.BusinessLogicLayer;
using SW.CEMENTERIO.EntityLayer;
using SW.CEMENTERIO.Models;
using System;

namespace SW.CEMENTERIO.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AutenticarLogin(ENT_TA_LOGIN oLogin)
        {
            ResponseViewModel oResponse = new ResponseViewModel();
            try
            {
                if (string.IsNullOrEmpty(oLogin.LOGS_USUARIO) || string.IsNullOrEmpty(oLogin.LOGS_CLAVE))
                {
                    oResponse.Estado = false;
                    oResponse.Mensaje = "Falta completar datos";
                    oResponse.Titulo = "Advertencia";
                    oResponse.Tipo = 2;
                    return Json(oResponse);
                }

                ENT_TA_LOGIN modelo = new ENT_TA_LOGIN();
                BLL_TA_LOGIN loginLN = new BLL_TA_LOGIN();
                modelo = loginLN.AutenticarLogin(oLogin.LOGS_USUARIO, Utilitarios.EncriptarPassword(oLogin.LOGS_CLAVE));

                if (modelo.LOGN_IDLOGIN > 0)
                {
                    oResponse.Estado = true;
                    oResponse.Mensaje = "Login Correcto";
                    HttpContext.Session.SetInt32("idUsuario", modelo.LOGN_IDLOGIN);
                    HttpContext.Session.SetInt32("idTrabajador", modelo.COLN_IDCOLABORADOR);
                    oResponse.AdicionalTxt = modelo.COLS_NOMBRES;
                }
                else
                {
                    oResponse.Estado = false;
                    oResponse.Mensaje = "Usuario o contraseña incorrecta";
                }
                return Json(oResponse);
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

        public IActionResult CerrarSession()
        {
            return RedirectToAction("Index", "Admin");
        }
    }
}
