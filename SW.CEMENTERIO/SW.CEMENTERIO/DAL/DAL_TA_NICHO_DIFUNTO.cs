using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using log4net;
using Microsoft.ApplicationBlocks.Data;
using SW.CEMENTERIO.EntityLayer;

namespace SW.CEMENTERIO.DataAccessLayer
{
	public class DAL_TA_NICHO_DIFUNTO : DAL_Execute
	{
		#region Methods

		/// <summary>
		/// Guarda un registro de la tabla TA_NICHO_DIFUNTO.
		/// </summary>
		public void Insert(ENT_TA_NICHO_DIFUNTO x_oENT_TA_NICHO_DIFUNTO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@NICDIFN_IDNICHO", x_oENT_TA_NICHO_DIFUNTO.NICDIFN_IDNICHO),
					new SqlParameter("@NICDIFN_IDDIFUNTO", x_oENT_TA_NICHO_DIFUNTO.NICDIFN_IDDIFUNTO),
					new SqlParameter("@NICDIFS_USUREGISTRO", x_oENT_TA_NICHO_DIFUNTO.NICDIFS_USUREGISTRO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				x_oENT_TA_NICHO_DIFUNTO.NICDIFN_IDNICHODIFUNTO = (int)ejecutarScalar("TA_NICHO_DIFUNTO_Insert", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error en operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Actualiza a registro de la tabla TA_NICHO_DIFUNTO.
		/// </summary>
		public void Update(ENT_TA_NICHO_DIFUNTO x_oENT_TA_NICHO_DIFUNTO)
		{

			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@NICDIFN_IDNICHODIFUNTO", x_oENT_TA_NICHO_DIFUNTO.NICDIFN_IDNICHODIFUNTO),
					new SqlParameter("@NICDIFN_IDNICHO", x_oENT_TA_NICHO_DIFUNTO.NICDIFN_IDNICHO),
					new SqlParameter("@NICDIFN_IDDIFUNTO", x_oENT_TA_NICHO_DIFUNTO.NICDIFN_IDDIFUNTO),
					new SqlParameter("@NICDIFS_USUMODIFICA", x_oENT_TA_NICHO_DIFUNTO.NICDIFS_USUMODIFICA),
					new SqlParameter("@NICDIFD_FECMODIFICA", x_oENT_TA_NICHO_DIFUNTO.NICDIFD_FECMODIFICA)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarScalar("TA_NICHO_DIFUNTO_Update", parameters);
				//ejecutarNonQuery("TA_NICHO_DIFUNTO_Update", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Elimina un registro de la tabla TA_NICHO_DIFUNTO por su primary key.
		/// </summary>
		public void Delete(int NICDIFN_IDNICHODIFUNTO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@NICDIFN_IDNICHODIFUNTO", NICDIFN_IDNICHODIFUNTO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_NICHO_DIFUNTO_Delete", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Deletes a record from the TA_NICHO_DIFUNTO table by a foreign key.
		/// </summary>
		public void DeleteAllByNICDIFN_IDDIFUNTO(int NICDIFN_IDDIFUNTO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@NICDIFN_IDDIFUNTO", NICDIFN_IDDIFUNTO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_NICHO_DIFUNTODeleteAllByNICDIFN_IDDIFUNTO", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Deletes a record from the TA_NICHO_DIFUNTO table by a foreign key.
		/// </summary>
		public void DeleteAllByNICDIFN_IDNICHO(int NICDIFN_IDNICHO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@NICDIFN_IDNICHO", NICDIFN_IDNICHO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_NICHO_DIFUNTODeleteAllByNICDIFN_IDNICHO", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_NICHO_DIFUNTO por su primary key.
		/// </summary>
		public ENT_TA_NICHO_DIFUNTO Select(int NICDIFN_IDNICHODIFUNTO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@NICDIFN_IDNICHODIFUNTO", NICDIFN_IDNICHODIFUNTO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			ENT_TA_NICHO_DIFUNTO objTA_NICHO_DIFUNTO = new ENT_TA_NICHO_DIFUNTO();
			try{
					 objTA_NICHO_DIFUNTO = GetEntity<ENT_TA_NICHO_DIFUNTO>("TA_NICHO_DIFUNTO_Select", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
			return objTA_NICHO_DIFUNTO;
		}

		/// <summary>
		/// Selecciona todos los registro de la tabla TA_NICHO_DIFUNTO.
		/// </summary>
		public List<ENT_TA_NICHO_DIFUNTO> SelectAll()
		{

			try{
				List<ENT_TA_NICHO_DIFUNTO> x_oENT_TA_NICHO_DIFUNTOList = new List<ENT_TA_NICHO_DIFUNTO>();

				x_oENT_TA_NICHO_DIFUNTOList = GetList<ENT_TA_NICHO_DIFUNTO>("TA_NICHO_DIFUNTO_SelectAll");
				return x_oENT_TA_NICHO_DIFUNTOList;
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
		}

		/// <summary>
		/// Selecciona los registros de la tabla TA_NICHO_DIFUNTO por un foreign key.
		/// </summary>
		public List<ENT_TA_NICHO_DIFUNTO> SelectAllByNICDIFN_IDDIFUNTO(int NICDIFN_IDDIFUNTO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
				new SqlParameter("@NICDIFN_IDDIFUNTO", NICDIFN_IDDIFUNTO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			List<ENT_TA_NICHO_DIFUNTO> x_oENT_TA_NICHO_DIFUNTOList = new List<ENT_TA_NICHO_DIFUNTO>();

			try{
					x_oENT_TA_NICHO_DIFUNTOList = GetList<ENT_TA_NICHO_DIFUNTO>("TA_NICHO_DIFUNTOSelectAllByNICDIFN_IDDIFUNTO", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
			return x_oENT_TA_NICHO_DIFUNTOList;
		}

		/// <summary>
		/// Selecciona los registros de la tabla TA_NICHO_DIFUNTO por un foreign key.
		/// </summary>
		public List<ENT_TA_NICHO_DIFUNTO> SelectAllByNICDIFN_IDNICHO(int NICDIFN_IDNICHO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
				new SqlParameter("@NICDIFN_IDNICHO", NICDIFN_IDNICHO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			List<ENT_TA_NICHO_DIFUNTO> x_oENT_TA_NICHO_DIFUNTOList = new List<ENT_TA_NICHO_DIFUNTO>();

			try{
					x_oENT_TA_NICHO_DIFUNTOList = GetList<ENT_TA_NICHO_DIFUNTO>("TA_NICHO_DIFUNTOSelectAllByNICDIFN_IDNICHO", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
			return x_oENT_TA_NICHO_DIFUNTOList;
		}


		#endregion
	}
}
