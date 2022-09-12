using Microsoft.AspNetCore.Mvc;
using SW.CEMENTERIO.BusinessLogicLayer;
using SW.CEMENTERIO.EntityLayer;
using SW.CEMENTERIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.CEMENTERIO.Controllers
{
    public class PabellonController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Buscar(int idPabellon)
        {
            ResponseViewModel oResponse = new();
            try
            {
                List<ENT_TA_PABELLON> modelo = new List<ENT_TA_PABELLON>();
                BLL_TA_PABELLON pabellonLN = new BLL_TA_PABELLON();
                if (idPabellon == 0)
                    modelo = pabellonLN.SelectAll();
                else
                    modelo.Add(pabellonLN.Select(idPabellon));
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
        public JsonResult Guardar(ENT_TA_PABELLON objPabellon)
        {
            ResponseViewModel oResponse = new();
            try
            {
                BLL_TA_PABELLON pabellonLN = new BLL_TA_PABELLON();
                if (objPabellon.PABN_IDPABELLON == 0)
                {
                    objPabellon.PABS_USUREGISTRO = "ADMIN";
                    pabellonLN.Insert(objPabellon);
                }
                else
                {
                    objPabellon.PABS_USUMODIFICA = "ADMIN";
                    objPabellon.PABD_FECMODIFICA = DateTime.Now;
                    pabellonLN.Update(objPabellon);
                }
                oResponse.Estado = true;
                oResponse.Titulo = "Éxito";
                oResponse.AdicionalInt = objPabellon.PABN_IDPABELLON;
                oResponse.Mensaje = "Pabellón " + (objPabellon.PABN_IDPABELLON == 0 ? "registrado" : "actualizado") + " correctamente";
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

        [HttpDelete]
        public JsonResult Eliminar(int idPabellon)
        {
            ResponseViewModel oResponse = new();
            try
            {
                BLL_TA_PABELLON pabellonLN = new BLL_TA_PABELLON();
                pabellonLN.Delete(idPabellon);
                oResponse.Estado = true;
                oResponse.Titulo = "Éxito";
                oResponse.Mensaje = "Pabellón eliminado correctamente";
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