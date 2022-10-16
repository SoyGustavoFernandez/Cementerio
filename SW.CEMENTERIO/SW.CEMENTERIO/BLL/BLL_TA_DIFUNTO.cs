using System;
using System.Collections.Generic;
using log4net;
using SW.CEMENTERIO.DataAccessLayer;
using SW.CEMENTERIO.EntityLayer;

namespace SW.CEMENTERIO.BusinessLogicLayer
{
	public class BLL_TA_DIFUNTO
	{
		#region Methods

		/// <summary>
		/// Guarda un registro de la tabla TA_DIFUNTO.
		/// </summary>
		public void Insert(ENT_TA_DIFUNTO x_oENT_TA_DIFUNTO)
		{
			 new DAL_TA_DIFUNTO().Insert(x_oENT_TA_DIFUNTO);
		}

		/// <summary>
		/// Actualiza a registro de la tabla TA_DIFUNTO.
		/// </summary>
		public void Update(ENT_TA_DIFUNTO x_oENT_TA_DIFUNTO)
		{
			 new DAL_TA_DIFUNTO().Update(x_oENT_TA_DIFUNTO);
		}

		/// <summary>
		/// Elimina un registro de la tabla TA_DIFUNTO por su primary key.
		/// </summary>
		public void Delete(int DIFN_IDDIFUNTO)
		{
			 new DAL_TA_DIFUNTO().Delete(DIFN_IDDIFUNTO);
		}

		/// <summary>
		/// Deletes a record from the TA_DIFUNTO table by a foreign key.
		/// </summary>
		public void DeleteAllByDIFN_IDCEMENTERIO(int DIFN_IDCEMENTERIO)
		{
			 new DAL_TA_DIFUNTO().DeleteAllByDIFN_IDCEMENTERIO(DIFN_IDCEMENTERIO);
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_DIFUNTO por su primary key.
		/// </summary>
		public ENT_TA_DIFUNTO Select(int DIFN_IDDIFUNTO)
		{
			return new DAL_TA_DIFUNTO().Select(DIFN_IDDIFUNTO);
		}

		/// <summary>
		/// Selecciona todos los registro de la tabla TA_DIFUNTO.
		/// </summary>
		public List<ENT_TA_DIFUNTO> SelectAll()
		{
			 return new DAL_TA_DIFUNTO().SelectAll();
		}

		/// <summary>
		/// Selecciona los registros de la tabla TA_DIFUNTO por un foreign key.
		/// </summary>
		public List<ENT_TA_DIFUNTO> SelectAllByDIFN_IDCEMENTERIO(int DIFN_IDCEMENTERIO)
		{
			return new DAL_TA_DIFUNTO().SelectAllByDIFN_IDCEMENTERIO(DIFN_IDCEMENTERIO);
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_DIFUNTO por nombres o apellidos.
		/// </summary>
		public List<ENT_TA_DIFUNTO> BuscarSerQuerido(ENT_TA_DIFUNTO x_oENT_TA_DIFUNTO)
		{
			return new DAL_TA_DIFUNTO().BuscarSerQuerido(x_oENT_TA_DIFUNTO);
		}

		#endregion
	}
}
