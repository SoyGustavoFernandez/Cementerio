using System;
using System.Collections.Generic;
using log4net;
using SW.CEMENTERIO.DataAccessLayer;
using SW.CEMENTERIO.EntityLayer;

namespace SW.CEMENTERIO.BusinessLogicLayer
{
	public class BLL_TA_LOGIN
	{
		#region Methods

		/// <summary>
		/// Guarda un registro de la tabla TA_LOGIN.
		/// </summary>
		public void Insert(ENT_TA_LOGIN x_oENT_TA_LOGIN)
		{
			 new DAL_TA_LOGIN().Insert(x_oENT_TA_LOGIN);
		}

		/// <summary>
		/// Actualiza a registro de la tabla TA_LOGIN.
		/// </summary>
		public void Update(ENT_TA_LOGIN x_oENT_TA_LOGIN)
		{
			 new DAL_TA_LOGIN().Update(x_oENT_TA_LOGIN);
		}

		/// <summary>
		/// Elimina un registro de la tabla TA_LOGIN por su primary key.
		/// </summary>
		public void Delete(int LOGN_IDLOGIN)
		{
			 new DAL_TA_LOGIN().Delete(LOGN_IDLOGIN);
		}

		/// <summary>
		/// Deletes a record from the TA_LOGIN table by a foreign key.
		/// </summary>
		public void DeleteAllByLOGN_IDCOLABORADOR(int LOGN_IDCOLABORADOR)
		{
			 new DAL_TA_LOGIN().DeleteAllByLOGN_IDCOLABORADOR(LOGN_IDCOLABORADOR);
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_LOGIN por su primary key.
		/// </summary>
		public ENT_TA_LOGIN Select(int LOGN_IDLOGIN)
		{
			return new DAL_TA_LOGIN().Select(LOGN_IDLOGIN);
		}

		/// <summary>
		/// Selecciona todos los registro de la tabla TA_LOGIN.
		/// </summary>
		public List<ENT_TA_LOGIN> SelectAll()
		{
			 return new DAL_TA_LOGIN().SelectAll();
		}

		/// <summary>
		/// Selecciona los registros de la tabla TA_LOGIN por un foreign key.
		/// </summary>
		public List<ENT_TA_LOGIN> SelectAllByLOGN_IDCOLABORADOR(int LOGN_IDCOLABORADOR)
		{
			return new DAL_TA_LOGIN().SelectAllByLOGN_IDCOLABORADOR(LOGN_IDCOLABORADOR);
		}


		#endregion
	}
}
