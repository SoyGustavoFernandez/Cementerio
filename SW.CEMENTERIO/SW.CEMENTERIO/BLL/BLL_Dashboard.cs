using SW.CEMENTERIO.DAL;
using SW.CEMENTERIO.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.CEMENTERIO.BLL
{
    public class BLL_Dashboard
    {
		/// <summary>
		/// Selecciona todos los registro de la tabla TA_PABELLON.
		/// </summary>
		public List<TotalDifuntos> BuscarDifuntos()
		{
			return new DAL_Dashboard().BuscarDifuntos();
		}
	}
}
