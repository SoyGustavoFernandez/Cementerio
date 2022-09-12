using System;
using System.Collections.Generic;
using log4net;
using SW.CEMENTERIO.DataAccessLayer;
using SW.CEMENTERIO.EntityLayer;

namespace SW.CEMENTERIO.BusinessLogicLayer
{
	public class BLL_TA_NICHO
	{
		#region Methods

		/// <summary>
		/// Guarda un registro de la tabla TA_NICHO.
		/// </summary>
		public void Insert(ENT_TA_NICHO x_oENT_TA_NICHO)
		{
			 new DAL_TA_NICHO().Insert(x_oENT_TA_NICHO);
		}

		/// <summary>
		/// Actualiza a registro de la tabla TA_NICHO.
		/// </summary>
		public void Update(ENT_TA_NICHO x_oENT_TA_NICHO)
		{
			 new DAL_TA_NICHO().Update(x_oENT_TA_NICHO);
		}

		/// <summary>
		/// Elimina un registro de la tabla TA_NICHO por su primary key.
		/// </summary>
		public void Delete(int NICN_IDNICHO)
		{
			 new DAL_TA_NICHO().Delete(NICN_IDNICHO);
		}

		/// <summary>
		/// Deletes a record from the TA_NICHO table by a foreign key.
		/// </summary>
		public void DeleteAllByNICN_IDPABELLON(int NICN_IDPABELLON)
		{
			 new DAL_TA_NICHO().DeleteAllByNICN_IDPABELLON(NICN_IDPABELLON);
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_NICHO por su primary key.
		/// </summary>
		public ENT_TA_NICHO Select(int NICN_IDNICHO)
		{
			return new DAL_TA_NICHO().Select(NICN_IDNICHO);
		}

		/// <summary>
		/// Selecciona todos los registro de la tabla TA_NICHO.
		/// </summary>
		public List<ENT_TA_NICHO> SelectAll()
		{
			 return new DAL_TA_NICHO().SelectAll();
		}

		/// <summary>
		/// Selecciona los registros de la tabla TA_NICHO por un foreign key.
		/// </summary>
		public List<ENT_TA_NICHO> SelectAllByNICN_IDPABELLON(int NICN_IDPABELLON)
		{
			return new DAL_TA_NICHO().SelectAllByNICN_IDPABELLON(NICN_IDPABELLON);
		}


		#endregion
	}
}
