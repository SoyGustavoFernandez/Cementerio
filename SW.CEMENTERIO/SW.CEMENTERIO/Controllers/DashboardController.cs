using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SW.CEMENTERIO.BLL;
using SW.CEMENTERIO.ENT;
using SW.CEMENTERIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.CEMENTERIO.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("idUsuario") != null)
                return View();
            else
                return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public JsonResult BuscarDifuntos()
        {
            ResponseViewModel oResponse = new();
            try
            {
                List<TotalDifuntos> modelo = new List<TotalDifuntos>();
                BLL_Dashboard dashboardLN = new BLL_Dashboard();
                modelo = dashboardLN.BuscarDifuntos();
                if (modelo.Count > 0)
                {
                    oResponse.Estado = true;
                    oResponse.Tipo = 1;
                    oResponse.Mensaje = "Lista Obtenida";
                    oResponse.AdicionalInt = modelo.Sum(x => x.CANTIDAD_DIFUNTOS);
                    int[] cantidades = new int[modelo.Count];
                    string[] nombres = new string[modelo.Count];

                    for (int i = 0; i < modelo.Count; i++)
                    {
                        cantidades[i] = modelo[i].CANTIDAD_DIFUNTOS;
                        nombres[i] = modelo[i].PABELLON;
                    }
                
                    oResponse.Datos = modelo;
                    //return Json(oResponse);

                    return Json(new
                    {
                        resultado =
                           new
                           {
                               data = cantidades,
                               labels = nombres
                           },
                        Response = oResponse
                    });
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
        public JsonResult BuscarPabellones()
        {
            ResponseViewModel oResponse = new();
            try
            {
                List<TotalPabellon> modelo = new List<TotalPabellon>();
                BLL_Dashboard dashboardLN = new BLL_Dashboard();
                modelo = dashboardLN.BuscarPabellones();
                if (modelo.Count > 0)
                {
                    oResponse.Estado = true;
                    oResponse.Tipo = 1;
                    oResponse.Mensaje = "Lista Obtenida";
                    oResponse.AdicionalInt = modelo.Count();
                    int[] cantidadesLibres = new int[modelo.Count];
                    int[] cantidadesOcupados = new int[modelo.Count];
                    string[] nombres = new string[modelo.Count];

                    for (int i = 0; i < modelo.Count; i++)
                    {
                        cantidadesLibres[i] = modelo[i].NICHOS_LIBRES;
                        cantidadesOcupados[i] = modelo[i].NICHOS_OCUPADOS;
                        nombres[i] = modelo[i].PABELLON;
                    }

                    oResponse.Datos = modelo;
                    //return Json(oResponse);

                    return Json(new
                    {
                        resultado = new { dataLibre = cantidadesLibres, dataOcupado = cantidadesOcupados, labels = nombres},
                        Response = oResponse
                    });
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
    }
}
