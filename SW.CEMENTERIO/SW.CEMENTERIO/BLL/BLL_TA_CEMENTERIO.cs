using System;
using System.Collections.Generic;
using log4net;
using SW.CEMENTERIO.DataAccessLayer;
using SW.CEMENTERIO.EntityLayer;

namespace SW.CEMENTERIO.BusinessLogicLayer
{
	public class BLL_TA_CEMENTERIO
	{
		#region Methods

		/// <summary>
		/// Guarda un registro de la tabla TA_CEMENTERIO.
		/// </summary>
		public void Insert(ENT_TA_CEMENTERIO x_oENT_TA_CEMENTERIO)
		{
			 new DAL_TA_CEMENTERIO().Insert(x_oENT_TA_CEMENTERIO);
		}

		/// <summary>
		/// Actualiza a registro de la tabla TA_CEMENTERIO.
		/// </summary>
		public void Update(ENT_TA_CEMENTERIO x_oENT_TA_CEMENTERIO)
		{
			 new DAL_TA_CEMENTERIO().Update(x_oENT_TA_CEMENTERIO);
		}

		/// <summary>
		/// Elimina un registro de la tabla TA_CEMENTERIO por su primary key.
		/// </summary>
		public void Delete(int CEMN_IDCEMENTERIO)
		{
			 new DAL_TA_CEMENTERIO().Delete(CEMN_IDCEMENTERIO);
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_CEMENTERIO por su primary key.
		/// </summary>
		public ENT_TA_CEMENTERIO Select(int CEMN_IDCEMENTERIO)
		{
			return new DAL_TA_CEMENTERIO().Select(CEMN_IDCEMENTERIO);
		}

		/// <summary>
		/// Selecciona todos los registro de la tabla TA_CEMENTERIO.
		/// </summary>
		public List<ENT_TA_CEMENTERIO> SelectAll()
		{
			 return new DAL_TA_CEMENTERIO().SelectAll();
		}


		#endregion
	}
}
