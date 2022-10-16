using Microsoft.ApplicationBlocks.Data;
using SW.CEMENTERIO.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.CEMENTERIO.DAL
{
    public class DAL_Dashboard : DAL_Execute
	{
		/// <summary>
		/// Muestra la cantidad de difuntos registrados por pabellon.
		/// </summary>
		public List<TotalDifuntos> BuscarDifuntos()
		{
			try
			{
				List<TotalDifuntos> x_oENT_DashboardList = new List<TotalDifuntos>();

				x_oENT_DashboardList = GetList<TotalDifuntos>("Dashboard_TotalDifuntos");
				return x_oENT_DashboardList;
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
		}

		/// <summary>
		/// Muestra la cantidad de pabellones registrados.
		/// </summary>
		public List<TotalPabellon> BuscarPabellones()
		{
			try
			{
				List<TotalPabellon> x_oENT_DashboardList = new List<TotalPabellon>();

				x_oENT_DashboardList = GetList<TotalPabellon>("Dashboard_TotalPabellones");
				return x_oENT_DashboardList;
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
		}
	}
}
