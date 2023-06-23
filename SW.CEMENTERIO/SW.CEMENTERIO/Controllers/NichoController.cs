﻿using Microsoft.ApplicationBlocks.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SW.CEMENTERIO.BusinessLogicLayer;
using SW.CEMENTERIO.EntityLayer;
using SW.CEMENTERIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace SW.CEMENTERIO.Controllers
{
    public class NichoController : Controller
    {
        private readonly DAL_Execute _objExecute = new DAL_Execute();

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("idUsuario") != null)
                return View();
            else
                return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public JsonResult Buscar(int idNicho)
        {
            ResponseViewModel oResponse = new();
            try
            {
                List<ENT_TA_NICHO> modelo = new List<ENT_TA_NICHO>();
                BLL_TA_NICHO NichoLN = new BLL_TA_NICHO();
                if (idNicho == 0)
                    modelo = NichoLN.SelectAll();
                else
                    modelo.Add(NichoLN.Select(idNicho));
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
            catch (TimeoutException)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Tiempo de espera superado. Consulte al administrador del sistema";
                return Json(oResponse);
            }
            catch (SqlException)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Error en Base de Datos. Consulte al administrador del sistema";
                return Json(oResponse);
            }
            catch (DbException)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Error en conexión a base de datos. Consulte al administrador del sistema";
                return Json(oResponse);
            }
            catch (Exception)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Error al momento de buscar un Nicho. Consulte al administrador del sistema";
                return Json(oResponse); 
            }
        }

        [HttpPost]
        public JsonResult BuscarPorPabellon(int idPabellon, bool valCantidad = false)
        {
            ResponseViewModel oResponse = new();
            try
            {
                List<ENT_TA_NICHO> modelo = new List<ENT_TA_NICHO>();
                BLL_TA_NICHO NichoLN = new BLL_TA_NICHO();
                modelo = NichoLN.SelectAllByNICN_IDPABELLON(idPabellon);
                if (modelo.Count > 0)
                {
                    oResponse.Estado = true;
                    oResponse.Tipo = 1;
                    oResponse.Mensaje = "Lista Obtenida";
                    //if (valCantidad) modelo = modelo.FindAll(x => x.NICB_NUMDIF > 0);
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
            catch (TimeoutException)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Tiempo de espera superado. Consulte al administrador del sistema";
                return Json(oResponse);
            }
            catch (SqlException)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Error en Base de Datos. Consulte al administrador del sistema";
                return Json(oResponse);
            }
            catch (DbException)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Error en conexión a base de datos. Consulte al administrador del sistema";
                return Json(oResponse);
            }
            catch (Exception)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Error al momento de buscar pabellón según el Nicho enviado. Consulte al administrador del sistema";
                return Json(oResponse);
            }
        }

        [HttpPost]
        public JsonResult Guardar(ENT_TA_NICHO objNicho)
        {
            ResponseViewModel oResponse = new();
            try
            {
                TransactionScope scope = new TransactionScope();
                BLL_TA_NICHO nichoLN = new BLL_TA_NICHO();
                if (objNicho.NICN_IDNICHO == 0)
                {
                    objNicho.NICB_NUMDIFACTUAL = objNicho.NICB_NUMDIFTOTAL;
                    objNicho.NICS_USUREGISTRO = HttpContext.Session.GetString("idTrabajador"); ;
                    nichoLN.Insert(objNicho);
                }
                else
                {
                    objNicho.NICS_USUMODIFICA = HttpContext.Session.GetString("idTrabajador");
                    objNicho.NICD_FECMODIFICA = DateTime.Now;
                    nichoLN.Update(objNicho);
                    if (objNicho.NICB_STATUSRESPONSE == 0) throw new Exception("La cantidad de difuntos registrados es mayor a la que se intenta actualizar.");

                }
                oResponse.Estado = true;
                oResponse.Titulo = "Éxito";
                oResponse.AdicionalInt = objNicho.NICN_IDNICHO;
                oResponse.Mensaje = "Nicho " + (objNicho.NICN_IDNICHO == 0 ? "registrado" : "actualizado") + " correctamente";
                oResponse.Tipo = 1;
                scope.Complete();
                scope.Dispose();
                return Json(oResponse); ;
            }
            catch (TimeoutException)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Tiempo de espera superado. Consulte al administrador del sistema";
                return Json(oResponse);
            }
            catch (SqlException)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Error en Base de Datos. Consulte al administrador del sistema";
                return Json(oResponse);
            }
            catch (DbException)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Error en conexión a base de datos. Consulte al administrador del sistema";
                return Json(oResponse);
            }
            catch (Exception)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Error al momento de " + (objNicho.NICN_IDNICHO == 0 ? "registrar" : "actualizar") +" un Nicho. Consulte al administrador del sistema";
                return Json(oResponse);
            }
        }

        [HttpDelete]
        public JsonResult Eliminar(int idNicho)
        {
            ResponseViewModel oResponse = new();
            try
            {
                TransactionScope scope = new TransactionScope();

                List<ENT_TA_NICHO_DIFUNTO> lstNichos = new List<ENT_TA_NICHO_DIFUNTO> ();
                BLL_TA_NICHO_DIFUNTO ln_TA_NICHO_DIFUNTO = new BLL_TA_NICHO_DIFUNTO();
                lstNichos = ln_TA_NICHO_DIFUNTO.SelectAllByNICDIFN_IDNICHO(idNicho);

                if (lstNichos.Count > 0)
                {
                    lstNichos = lstNichos.FindAll(x => x.NICB_NUMDIFTOTAL - x.NICB_NUMDIFACTUAL == 0);
                    if (lstNichos.Count == 0)
                        throw new Exception("No se puede eliminar el nicho actual, hay difuntos registrados actualmente");

                    ENT_TA_NICHO objNicho = new ENT_TA_NICHO();
                    BLL_TA_NICHO nichoLN = new BLL_TA_NICHO();
                    objNicho = nichoLN.Select(idNicho);
                    objNicho = nichoLN.UpdateSpace(objNicho.NICN_IDNICHO, 1);
                }

                BLL_TA_NICHO NichoLN = new BLL_TA_NICHO();
                NichoLN.Delete(idNicho);
                oResponse.Estado = true;
                oResponse.Titulo = "Éxito";
                oResponse.Mensaje = "Nicho eliminado correctamente";
                oResponse.Tipo = 1;
                scope.Complete();
                scope.Dispose();
                return Json(oResponse); ;
            }
            catch (TimeoutException)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Tiempo de espera superado. Consulte al administrador del sistema";
                return Json(oResponse);
            }
            catch (SqlException)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Error en Base de Datos. Consulte al administrador del sistema";
                return Json(oResponse);
            }
            catch (DbException)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Error en conexión a base de datos. Consulte al administrador del sistema";
                return Json(oResponse);
            }
            catch (Exception)
            {
                oResponse.Tipo = 2;
                oResponse.Estado = false;
                oResponse.Titulo = "Error";
                oResponse.Mensaje = "Error al momento de eliminar un Nicho. Consulte al administrador del sistema";
                return Json(oResponse);
            }
        }
    }
}
