using System;
using System.Collections.Generic;
using log4net;
using SW.CEMENTERIO.DataAccessLayer;
using SW.CEMENTERIO.EntityLayer;

namespace SW.CEMENTERIO.BusinessLogicLayer
{
	public class BLL_TA_NICHO_DIFUNTO
	{
		#region Methods

		/// <summary>
		/// Guarda un registro de la tabla TA_NICHO_DIFUNTO.
		/// </summary>
		public void Insert(ENT_TA_NICHO_DIFUNTO x_oENT_TA_NICHO_DIFUNTO)
		{
			 new DAL_TA_NICHO_DIFUNTO().Insert(x_oENT_TA_NICHO_DIFUNTO);
		}

		/// <summary>
		/// Actualiza a registro de la tabla TA_NICHO_DIFUNTO.
		/// </summary>
		public void Update(ENT_TA_NICHO_DIFUNTO x_oENT_TA_NICHO_DIFUNTO)
		{
			 new DAL_TA_NICHO_DIFUNTO().Update(x_oENT_TA_NICHO_DIFUNTO);
		}

		/// <summary>
		/// Elimina un registro de la tabla TA_NICHO_DIFUNTO por su primary key.
		/// </summary>
		public void Delete(int NICDIFN_IDNICHODIFUNTO)
		{
			 new DAL_TA_NICHO_DIFUNTO().Delete(NICDIFN_IDNICHODIFUNTO);
		}

		/// <summary>
		/// Deletes a record from the TA_NICHO_DIFUNTO table by a foreign key.
		/// </summary>
		public void DeleteAllByNICDIFN_IDDIFUNTO(int NICDIFN_IDDIFUNTO)
		{
			 new DAL_TA_NICHO_DIFUNTO().DeleteAllByNICDIFN_IDDIFUNTO(NICDIFN_IDDIFUNTO);
		}

		/// <summary>
		/// Deletes a record from the TA_NICHO_DIFUNTO table by a foreign key.
		/// </summary>
		public void DeleteAllByNICDIFN_IDNICHO(int NICDIFN_IDNICHO)
		{
			 new DAL_TA_NICHO_DIFUNTO().DeleteAllByNICDIFN_IDNICHO(NICDIFN_IDNICHO);
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_NICHO_DIFUNTO por su primary key.
		/// </summary>
		public ENT_TA_NICHO_DIFUNTO Select(int NICDIFN_IDNICHODIFUNTO)
		{
			return new DAL_TA_NICHO_DIFUNTO().Select(NICDIFN_IDNICHODIFUNTO);
		}

		/// <summary>
		/// Selecciona todos los registro de la tabla TA_NICHO_DIFUNTO.
		/// </summary>
		public List<ENT_TA_NICHO_DIFUNTO> SelectAll()
		{
			 return new DAL_TA_NICHO_DIFUNTO().SelectAll();
		}

		/// <summary>
		/// Selecciona los registros de la tabla TA_NICHO_DIFUNTO por un foreign key.
		/// </summary>
		public ENT_TA_NICHO_DIFUNTO SelectAllByNICDIFN_IDDIFUNTO(int NICDIFN_IDDIFUNTO)
		{
			return new DAL_TA_NICHO_DIFUNTO().SelectAllByNICDIFN_IDDIFUNTO(NICDIFN_IDDIFUNTO);
		}

		/// <summary>
		/// Selecciona los registros de la tabla TA_NICHO_DIFUNTO por un foreign key.
		/// </summary>
		public List<ENT_TA_NICHO_DIFUNTO> SelectAllByNICDIFN_IDNICHO(int NICDIFN_IDNICHO)
		{
			return new DAL_TA_NICHO_DIFUNTO().SelectAllByNICDIFN_IDNICHO(NICDIFN_IDNICHO);
		}


		#endregion
	}
}
