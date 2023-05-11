using System;
using System.Collections.Generic;
using log4net;
using SW.CEMENTERIO.DataAccessLayer;
using SW.CEMENTERIO.EntityLayer;

namespace SW.CEMENTERIO.BusinessLogicLayer
{
	public class BLL_TA_PABELLON
	{
		#region Methods

		/// <summary>
		/// Guarda un registro de la tabla TA_PABELLON.
		/// </summary>
		public void Insert(ENT_TA_PABELLON x_oENT_TA_PABELLON)
		{
			 new DAL_TA_PABELLON().Insert(x_oENT_TA_PABELLON);
		}

		/// <summary>
		/// Actualiza a registro de la tabla TA_PABELLON.
		/// </summary>
		public void Update(ENT_TA_PABELLON x_oENT_TA_PABELLON)
		{
			 new DAL_TA_PABELLON().Update(x_oENT_TA_PABELLON);
		}

		/// <summary>
		/// Elimina un registro de la tabla TA_PABELLON por su primary key.
		/// </summary>
		public void Delete(int PABN_IDPABELLON, string PABB_ESTADOBAJA)
		{
			 new DAL_TA_PABELLON().Delete(PABN_IDPABELLON, PABB_ESTADOBAJA);
		}

		/// <summary>
		/// Deletes a record from the TA_PABELLON table by a foreign key.
		/// </summary>
		public void DeleteAllByPABN_IDCEMENTERIO(int PABN_IDCEMENTERIO)
		{
			 new DAL_TA_PABELLON().DeleteAllByPABN_IDCEMENTERIO(PABN_IDCEMENTERIO);
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_PABELLON por su primary key.
		/// </summary>
		public ENT_TA_PABELLON Select(int PABN_IDPABELLON)
		{
			return new DAL_TA_PABELLON().Select(PABN_IDPABELLON);
		}

		/// <summary>
		/// Selecciona todos los registro de la tabla TA_PABELLON.
		/// </summary>
		public List<ENT_TA_PABELLON> SelectAll()
		{
			 return new DAL_TA_PABELLON().SelectAll();
		}

		/// <summary>
		/// Selecciona los registros de la tabla TA_PABELLON por un foreign key.
		/// </summary>
		public List<ENT_TA_PABELLON> SelectAllByPABN_IDCEMENTERIO(int PABN_IDCEMENTERIO)
		{
			return new DAL_TA_PABELLON().SelectAllByPABN_IDCEMENTERIO(PABN_IDCEMENTERIO);
		}


		#endregion
	}
}
