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
        public JsonResult Guardar(ENT_TA_COLABORADOR objColaborador)
        {
            ResponseViewModel oResponse = new();
            try
            {
                BLL_TA_COLABORADOR ColaboradorLN = new BLL_TA_COLABORADOR();
                if (objColaborador.COLN_IDCOLABORADOR == 0)
                {
                    objColaborador.COLS_USUREGISTRO = "ADMIN";
                    ColaboradorLN.Insert(objColaborador);
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
    }
}
