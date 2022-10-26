using Microsoft.AspNetCore.Http;
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
            if (HttpContext.Session.GetInt32("idUsuario") != null)
                return View();
            else
                return RedirectToAction("Index", "Admin");
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
            int Accion; //1: INSERT     2: UPDATE
            ResponseViewModel oResponse = new();
            using TransactionScope scope = new TransactionScope();
            try
            {
                BLL_TA_DIFUNTO obj_TA_DIFUNTO = new BLL_TA_DIFUNTO();
                BLL_TA_NICHO nichoLN = new BLL_TA_NICHO();
                BLL_TA_NICHO_DIFUNTO obj_TA_NICHO_DIFUNTO = new BLL_TA_NICHO_DIFUNTO();
                ENT_TA_NICHO_DIFUNTO objNicho = new ENT_TA_NICHO_DIFUNTO();
                objNicho = obj_TA_NICHO_DIFUNTO.SelectAllByNICDIFN_IDDIFUNTO(objDifunto.DIFN_IDDIFUNTO);
                if (objDifunto.DIFN_IDDIFUNTO == 0)
                {
                    objDifunto.DIFS_USUREGISTRO = HttpContext.Session.GetString("idTrabajador");
                    obj_TA_DIFUNTO.Insert(objDifunto);
                    Accion = 1;
                }
                else
                {
                    objDifunto.DIFS_USUMODIFICA = HttpContext.Session.GetString("idTrabajador");
                    objDifunto.DIFD_FECMODIFICA = DateTime.Now;
                    obj_TA_DIFUNTO.Update(objDifunto);
                    Accion = 2;
                }
                objDifunto.NICDIFN_IDNICHO = objDifunto.NICN_IDNICHO;
                objDifunto.NICDIFN_IDDIFUNTO = objDifunto.DIFN_IDDIFUNTO;
                if (objDifunto.NICDIFN_IDNICHODIFUNTO == 0)
                {
                    objDifunto.NICDIFS_USUREGISTRO = HttpContext.Session.GetString("idTrabajador");
                    obj_TA_NICHO_DIFUNTO.Insert(objDifunto);
                }
                else
                {
                    objDifunto.NICDIFS_USUMODIFICA = HttpContext.Session.GetString("idTrabajador");
                    objDifunto.NICDIFD_FECMODIFICA = DateTime.Now;
                    obj_TA_NICHO_DIFUNTO.Update(objDifunto);
                }

                ENT_TA_NICHO objNichoAnterior = new ENT_TA_NICHO();
                ENT_TA_NICHO objNichoNuevo = new ENT_TA_NICHO();
                if (Accion == 2)
                    objNichoAnterior = nichoLN.Select(objNicho.NICDIFN_IDNICHO);
                objNichoNuevo = nichoLN.Select(objDifunto.NICDIFN_IDNICHO);
                if (objNichoAnterior.NICN_IDNICHO != objNichoNuevo.NICN_IDNICHO && objNichoNuevo.NICB_NUMDIFACTUAL <= 0)
                    throw new Exception("No se puede agregar más difuntos en el nicho seleccionado. Excede límite disponible");
                else
                {
                    if (Accion == 1)
                        objNicho = nichoLN.UpdateSpace(objNichoNuevo.NICN_IDNICHO, -1);
                    else
                    {
                        if (objNichoAnterior.NICN_IDNICHO != objNichoNuevo.NICN_IDNICHO)
                        {
                            objNicho = nichoLN.UpdateSpace(objNichoAnterior.NICN_IDNICHO, +1);
                            objNicho = nichoLN.UpdateSpace(objNichoNuevo.NICN_IDNICHO, -1);
                        }
                    }
                }

                oResponse.Estado = true;
                oResponse.Titulo = "Éxito";
                oResponse.AdicionalInt = objDifunto.NICDIFN_IDNICHODIFUNTO;
                oResponse.Mensaje = "Difunto " + (objDifunto.NICDIFN_IDNICHODIFUNTO == 0 ? "registrado" : "actualizado") + " correctamente";
                oResponse.Tipo = 1;
                scope.Complete();
                scope.Dispose();
                return Json(oResponse); ;
            }
            catch (Exception e)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Error en operación de Acceso a Datos: " + e.Message;
                return Json(oResponse);
            }
        }

        [HttpDelete]
        public JsonResult Eliminar(int idDifunto)
        {
            ResponseViewModel oResponse = new();
            try
            {
                TransactionScope scope = new TransactionScope();

                ENT_TA_NICHO_DIFUNTO objNichoDifunto = new ENT_TA_NICHO_DIFUNTO();
                BLL_TA_NICHO_DIFUNTO obj_TA_NICHO_DIFUNTO = new BLL_TA_NICHO_DIFUNTO();
                objNichoDifunto = obj_TA_NICHO_DIFUNTO.SelectAllByNICDIFN_IDDIFUNTO(idDifunto);
                ENT_TA_NICHO objNicho = new ENT_TA_NICHO();
                BLL_TA_NICHO nichoLN = new BLL_TA_NICHO();
                objNicho = nichoLN.Select(objNichoDifunto.NICDIFN_IDNICHO);
                objNicho = nichoLN.UpdateSpace(objNicho.NICN_IDNICHO, 1);

                BLL_TA_NICHO_DIFUNTO DifuntoLN = new BLL_TA_NICHO_DIFUNTO();
                DifuntoLN.Delete(idDifunto);
                oResponse.Estado = true;
                oResponse.Titulo = "Éxito";
                oResponse.Mensaje = "Difunto eliminado correctamente";
                oResponse.Tipo = 1;
                scope.Complete();
                scope.Dispose();
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

        [HttpGet]
        public JsonResult BuscarSerQuerido(ENT_TA_DIFUNTO objDifunto)
        {
            ResponseViewModel oResponse = new();
            try
            {
                List<ENT_TA_DIFUNTO> modelo = new List<ENT_TA_DIFUNTO>();
                BLL_TA_DIFUNTO difuntoLN = new BLL_TA_DIFUNTO();
                modelo = difuntoLN.BuscarSerQuerido(objDifunto);
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
        public JsonResult BuscarPorDNI(string dni)
        {
            ResponseViewModel oResponse = new();
            try
            {
                List<ENT_TA_NICHO_DIFUNTO> modelo = new List<ENT_TA_NICHO_DIFUNTO>();
                BLL_TA_NICHO_DIFUNTO difuntoLN = new BLL_TA_NICHO_DIFUNTO();
                modelo.Add(difuntoLN.SelectByDNI(dni));
                if (modelo.FirstOrDefault() != null)
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
                    oResponse.Estado = true;
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
    }
}