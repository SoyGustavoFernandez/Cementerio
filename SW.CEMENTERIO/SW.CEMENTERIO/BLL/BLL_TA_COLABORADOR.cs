using System;
using System.Collections.Generic;
using log4net;
using SW.CEMENTERIO.DataAccessLayer;
using SW.CEMENTERIO.EntityLayer;

namespace SW.CEMENTERIO.BusinessLogicLayer
{
	public class BLL_TA_COLABORADOR
	{
		#region Methods

		/// <summary>
		/// Guarda un registro de la tabla TA_COLABORADOR.
		/// </summary>
		public void Insert(ENT_TA_COLABORADOR x_oENT_TA_COLABORADOR)
		{
			 new DAL_TA_COLABORADOR().Insert(x_oENT_TA_COLABORADOR);
		}

		/// <summary>
		/// Actualiza a registro de la tabla TA_COLABORADOR.
		/// </summary>
		public void Update(ENT_TA_COLABORADOR x_oENT_TA_COLABORADOR)
		{
			 new DAL_TA_COLABORADOR().Update(x_oENT_TA_COLABORADOR);
		}

		/// <summary>
		/// Elimina un registro de la tabla TA_COLABORADOR por su primary key.
		/// </summary>
		public void Delete(int COLN_IDCOLABORADOR)
		{
			 new DAL_TA_COLABORADOR().Delete(COLN_IDCOLABORADOR);
		}

		/// <summary>
		/// Deletes a record from the TA_COLABORADOR table by a foreign key.
		/// </summary>
		public void DeleteAllByCOLN_IDCEMENTERIO(int COLN_IDCEMENTERIO)
		{
			 new DAL_TA_COLABORADOR().DeleteAllByCOLN_IDCEMENTERIO(COLN_IDCEMENTERIO);
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_COLABORADOR por su primary key.
		/// </summary>
		public ENT_TA_COLABORADOR Select(int COLN_IDCOLABORADOR)
		{
			return new DAL_TA_COLABORADOR().Select(COLN_IDCOLABORADOR);
		}

		/// <summary>
		/// Selecciona todos los registro de la tabla TA_COLABORADOR.
		/// </summary>
		public List<ENT_TA_COLABORADOR> SelectAll()
		{
			 return new DAL_TA_COLABORADOR().SelectAll();
		}

		/// <summary>
		/// Selecciona los registros de la tabla TA_COLABORADOR por un foreign key.
		/// </summary>
		public List<ENT_TA_COLABORADOR> SelectAllByCOLN_IDCEMENTERIO(int COLN_IDCEMENTERIO)
		{
			return new DAL_TA_COLABORADOR().SelectAllByCOLN_IDCEMENTERIO(COLN_IDCEMENTERIO);
		}


		#endregion
	}
}
