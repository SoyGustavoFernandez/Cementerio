using Microsoft.AspNetCore.Mvc;
using SW.CEMENTERIO.BusinessLogicLayer;
using SW.CEMENTERIO.DataAccessLayer;
using SW.CEMENTERIO.EntityLayer;
using SW.CEMENTERIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace SW.CEMENTERIO.Controllers
{
    public class DifuntoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Buscar(int idDifunto)
        {
            ResponseViewModel oResponse = new();
            try
            {
                List<ENT_TA_NICHO_DIFUNTO> modelo = new List<ENT_TA_NICHO_DIFUNTO>();
                BLL_TA_NICHO_DIFUNTO difuntoLN = new BLL_TA_NICHO_DIFUNTO();
                if (idDifunto == 0)
                    modelo = difuntoLN.SelectAll();
                else
                    modelo.Add(difuntoLN.Select(idDifunto));
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
        public JsonResult Guardar(ENT_TA_NICHO_DIFUNTO objDifunto)
        {
            ResponseViewModel oResponse = new();
            using TransactionScope scope = new TransactionScope();
            try
            {
                BLL_TA_DIFUNTO obj_TA_DIFUNTO = new BLL_TA_DIFUNTO();
                BLL_TA_NICHO_DIFUNTO obj_TA_NICHO_DIFUNTO = new BLL_TA_NICHO_DIFUNTO();
                if (objDifunto.DIFN_IDDIFUNTO == 0)
                {
                    objDifunto.DIFS_USUREGISTRO = "ADMIN";
                    obj_TA_DIFUNTO.Insert(objDifunto);
                }
                else
                {
                    objDifunto.DIFS_USUMODIFICA = "ADMIN";
                    objDifunto.DIFD_FECMODIFICA = DateTime.Now;
                    obj_TA_DIFUNTO.Update(objDifunto);
                }
                objDifunto.NICDIFN_IDNICHO = objDifunto.NICN_IDNICHO;
                objDifunto.NICDIFN_IDDIFUNTO = objDifunto.DIFN_IDDIFUNTO;
                if (objDifunto.NICDIFN_IDNICHODIFUNTO == 0)
                {
                    objDifunto.NICDIFS_USUREGISTRO = "ADMIN";
                    obj_TA_NICHO_DIFUNTO.Insert(objDifunto);
                }
                else
                {
                    objDifunto.NICDIFS_USUMODIFICA = "ADMIN";
                    objDifunto.NICDIFD_FECMODIFICA = DateTime.Now;
                    obj_TA_NICHO_DIFUNTO.Update(objDifunto);
                }
                oResponse.Estado = true;
                oResponse.Titulo = "Éxito";
                oResponse.AdicionalInt = objDifunto.NICDIFN_IDNICHODIFUNTO;
                oResponse.Mensaje = "Difunto " + (objDifunto.NICDIFN_IDNICHODIFUNTO == 0 ? "registrado" : "actualizado") + " correctamente";
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
        public JsonResult Eliminar(int idDifunto)
        {
            ResponseViewModel oResponse = new();
            try
            {
                BLL_TA_NICHO_DIFUNTO DifuntoLN = new BLL_TA_NICHO_DIFUNTO();
                DifuntoLN.Delete(idDifunto);
                oResponse.Estado = true;
                oResponse.Titulo = "Éxito";
                oResponse.Mensaje = "Difunto eliminado correctamente";
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
