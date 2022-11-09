using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SW.CEMENTERIO.BusinessLogicLayer;
using SW.CEMENTERIO.EntityLayer;
using SW.CEMENTERIO.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace SW.CEMENTERIO.Controllers
{
    public class PabellonController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public PabellonController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("idUsuario") != null)
                return View();
            else
                return RedirectToAction("Index", "Admin");
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
        public async Task<JsonResult> Guardar(ENT_TA_PABELLON objPabellon)
        {
            ResponseViewModel oResponse = new();
            try
            {
                BLL_TA_PABELLON pabellonLN = new BLL_TA_PABELLON();
                if (objPabellon.PABN_IDPABELLON == 0)
                {
                    objPabellon.PABS_UBICACION = await GuardarArchivoEnDisco(objPabellon.UBICACIONFILE, null);
                    objPabellon.PABS_USUREGISTRO = HttpContext.Session.GetString("idTrabajador"); ;
                    pabellonLN.Insert(objPabellon);
                }
                else
                {
                    ENT_TA_PABELLON objPabellonTMP = pabellonLN.Select(objPabellon.PABN_IDPABELLON);
                    objPabellon.PABS_UBICACION = await GuardarArchivoEnDisco(objPabellon.UBICACIONFILE, objPabellonTMP.PABS_UBICACION);
                    objPabellon.PABS_USUMODIFICA = HttpContext.Session.GetString("idTrabajador");
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
                TransactionScope scope = new TransactionScope();
                List<ENT_TA_NICHO> lstNichos = new List<ENT_TA_NICHO>();
                BLL_TA_NICHO NichoLN = new BLL_TA_NICHO();
                lstNichos = NichoLN.SelectAllByNICN_IDPABELLON(idPabellon);

                if (lstNichos.Count > 0)
                {
                    lstNichos = lstNichos.FindAll(x => x.NICB_NUMDIFTOTAL - x.NICB_NUMDIFACTUAL > 0);
                    if (lstNichos.Count > 0)
                        throw new Exception("No se puede eliminar el pabellón actual, hay difuntos registrados actualmente");
                }

                BLL_TA_PABELLON pabellonLN = new BLL_TA_PABELLON();
                pabellonLN.Delete(idPabellon);
                oResponse.Estado = true;
                oResponse.Titulo = "Éxito";
                oResponse.Mensaje = "Pabellón eliminado correctamente";
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

        [HttpPost]
        public JsonResult CargaMasiva(IFormFile file)
        {
            ResponseViewModel oResponse = new();
            try
            {
                var _File = file;
                if (_File == null)
                    throw new Exception("El archivo excel es requerido");

                List<ENT_TA_NICHO> lstNichos = new List<ENT_TA_NICHO>();
                using (var package = new ExcelPackage(_File.OpenReadStream()))
                {
                    using var Sheet = package.Workbook.Worksheets[0];
                    for (int IndiceFila = 2; IndiceFila <= Sheet.Dimension.End.Row; IndiceFila++)
                    {
                        ENT_TA_NICHO objNicho = new ENT_TA_NICHO
                        {
                            PABS_NOMBRE = Sheet.Cells[IndiceFila, 1].Value != null ? Sheet.Cells[IndiceFila, 1].Value.ToString() : throw new Exception("El campo " + IndiceFila + ", 1 tiene un formato incorrecto"),
                            PABS_TIPO = Sheet.Cells[IndiceFila, 2].Value != null ? Convert.ToInt32(Sheet.Cells[IndiceFila, 2].Value) : throw new Exception("El campo " + IndiceFila + ", 2 tiene un formato incorrecto"),
                            NICS_CODNICHO = Sheet.Cells[IndiceFila, 3].Value != null ? Sheet.Cells[IndiceFila, 3].Value.ToString() : throw new Exception("El campo " + IndiceFila + ", 3 tiene un formato incorrecto"),
                            NICB_NUMDIFTOTAL = Sheet.Cells[IndiceFila, 4].Value != null ? Convert.ToInt32(Sheet.Cells[IndiceFila, 4].Value) : throw new Exception("El campo " + IndiceFila + ", 4 tiene un formato incorrecto"),
                            NICB_NUMDIFACTUAL = Sheet.Cells[IndiceFila, 4].Value != null ? Convert.ToInt32(Sheet.Cells[IndiceFila, 4].Value) : throw new Exception("El campo " + IndiceFila + ", 4 tiene un formato incorrecto")
                        };
                        lstNichos.Add(objNicho);
                    }
                }

                //INICIAMOS LA CARGA MASIVA
                using TransactionScope scope = new TransactionScope();

                var TMP_lstPabellon = new List<ENT_TA_NICHO>();
                var TMP_lstNichos = new List<ENT_TA_NICHO>();

                TMP_lstPabellon = lstNichos.GroupBy(x => x.PABS_NOMBRE).Select(x => x.FirstOrDefault()).ToList();
                //INSERTAMOS LOS PABELLONES
                foreach (var item in TMP_lstPabellon)
                {
                    item.PABN_IDCEMENTERIO = 1;
                    item.PABS_UBICACION = "";
                    item.PABS_USUREGISTRO = HttpContext.Session.GetString("idTrabajador");
                    BLL_TA_PABELLON bllPabellon = new BLL_TA_PABELLON();
                    bllPabellon.Insert(item);
                }

                foreach (var item in lstNichos)
                {
                    item.NICS_USUREGISTRO = HttpContext.Session.GetString("idTrabajador");
                    BLL_TA_NICHO bllNicho = new BLL_TA_NICHO();
                    item.NICN_IDPABELLON = TMP_lstPabellon.Find(x => x.PABS_NOMBRE == item.PABS_NOMBRE).PABN_IDPABELLON;
                    bllNicho.Insert(item);
                }
                oResponse.Estado = true;
                oResponse.Titulo = "Éxito";
                oResponse.Mensaje = "Archivo cargado correctamente";
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

        public async Task<string> GuardarArchivoEnDisco(IFormFile upload, string ArchivoAnterior)
        {
            string RutaFinal = "";
            try
            {
                //Validar si no existe directorio
                if (!Directory.Exists(Path.Combine(_environment.ContentRootPath, "Pabellones")))
                    Directory.CreateDirectory(Path.Combine(_environment.ContentRootPath, "Pabellones"));
                else
                {
                    //Validar si existe archivo
                    if (string.IsNullOrEmpty(ArchivoAnterior))
                    {
                        var filename = Path.Combine(_environment.ContentRootPath, "Pabellones", upload.FileName);
                        RutaFinal = "http://127.0.0.1:8887/" + upload.FileName;
                        await upload.CopyToAsync(new FileStream(filename, FileMode.Create));
                    }
                    else
                    {
                        var filename = Path.Combine(_environment.ContentRootPath, "Pabellones", upload.FileName);
                        RutaFinal = "http://127.0.0.1:8887/" + upload.FileName;
                        await upload.CopyToAsync(new FileStream(filename, FileMode.Create));

                        if (System.IO.File.Exists(ArchivoAnterior))
                            System.IO.File.Delete(ArchivoAnterior);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return RutaFinal;
        }
    }
}