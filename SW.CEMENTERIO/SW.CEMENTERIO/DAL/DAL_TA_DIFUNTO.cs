using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using log4net;
using Microsoft.ApplicationBlocks.Data;
using SW.CEMENTERIO.EntityLayer;

namespace SW.CEMENTERIO.DataAccessLayer
{
	public class DAL_TA_DIFUNTO : DAL_Execute
	{
		#region Methods

		/// <summary>
		/// Guarda un registro de la tabla TA_DIFUNTO.
		/// </summary>
		public void Insert(ENT_TA_DIFUNTO x_oENT_TA_DIFUNTO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@DIFN_IDCEMENTERIO", x_oENT_TA_DIFUNTO.DIFN_IDCEMENTERIO),
					new SqlParameter("@DIFS_DNI", x_oENT_TA_DIFUNTO.DIFS_DNI),
					new SqlParameter("@DIFS_NOMBRES", x_oENT_TA_DIFUNTO.DIFS_NOMBRES),
					new SqlParameter("@DIFS_APEPATERNO", x_oENT_TA_DIFUNTO.DIFS_APEPATERNO),
					new SqlParameter("@DIFS_APEMATERNO", x_oENT_TA_DIFUNTO.DIFS_APEMATERNO),
					new SqlParameter("@DIFD_FECHADEFUNCION", x_oENT_TA_DIFUNTO.DIFD_FECHADEFUNCION),
					new SqlParameter("@DIFS_USUREGISTRO", x_oENT_TA_DIFUNTO.DIFS_USUREGISTRO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				x_oENT_TA_DIFUNTO.DIFN_IDDIFUNTO = (int)ejecutarScalar("TA_DIFUNTO_Insert", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error en operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Actualiza a registro de la tabla TA_DIFUNTO.
		/// </summary>
		public void Update(ENT_TA_DIFUNTO x_oENT_TA_DIFUNTO)
		{

			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@DIFN_IDDIFUNTO", x_oENT_TA_DIFUNTO.DIFN_IDDIFUNTO),
					new SqlParameter("@@DIFS_DNI", x_oENT_TA_DIFUNTO.@DIFS_DNI),
					new SqlParameter("@DIFN_IDCEMENTERIO", x_oENT_TA_DIFUNTO.DIFN_IDCEMENTERIO),
					new SqlParameter("@DIFS_NOMBRES", x_oENT_TA_DIFUNTO.DIFS_NOMBRES),
					new SqlParameter("@DIFS_APEPATERNO", x_oENT_TA_DIFUNTO.DIFS_APEPATERNO),
					new SqlParameter("@DIFS_APEMATERNO", x_oENT_TA_DIFUNTO.DIFS_APEMATERNO),
					new SqlParameter("@DIFD_FECHADEFUNCION", x_oENT_TA_DIFUNTO.DIFD_FECHADEFUNCION),
					new SqlParameter("@DIFS_USUMODIFICA", x_oENT_TA_DIFUNTO.DIFS_USUMODIFICA),
					new SqlParameter("@DIFD_FECMODIFICA", x_oENT_TA_DIFUNTO.DIFD_FECMODIFICA)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarScalar("TA_DIFUNTO_Update", parameters);
				//ejecutarNonQuery("TA_DIFUNTO_Update", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Elimina un registro de la tabla TA_DIFUNTO por su primary key.
		/// </summary>
		public void Delete(int DIFN_IDDIFUNTO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@DIFN_IDDIFUNTO", DIFN_IDDIFUNTO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_DIFUNTO_Delete", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Deletes a record from the TA_DIFUNTO table by a foreign key.
		/// </summary>
		public void DeleteAllByDIFN_IDCEMENTERIO(int DIFN_IDCEMENTERIO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@DIFN_IDCEMENTERIO", DIFN_IDCEMENTERIO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_DIFUNTODeleteAllByDIFN_IDCEMENTERIO", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_DIFUNTO por su primary key.
		/// </summary>
		public ENT_TA_DIFUNTO Select(int DIFN_IDDIFUNTO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@DIFN_IDDIFUNTO", DIFN_IDDIFUNTO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			ENT_TA_DIFUNTO objTA_DIFUNTO = new ENT_TA_DIFUNTO();
			try{
					 objTA_DIFUNTO = GetEntity<ENT_TA_DIFUNTO>("TA_DIFUNTO_Select", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
			return objTA_DIFUNTO;
		}

		/// <summary>
		/// Selecciona todos los registro de la tabla TA_DIFUNTO.
		/// </summary>
		public List<ENT_TA_DIFUNTO> SelectAll()
		{

			try{
				List<ENT_TA_DIFUNTO> x_oENT_TA_DIFUNTOList = new List<ENT_TA_DIFUNTO>();

				x_oENT_TA_DIFUNTOList = GetList<ENT_TA_DIFUNTO>("TA_DIFUNTO_SelectAll");
				return x_oENT_TA_DIFUNTOList;
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
		}

		/// <summary>
		/// Selecciona los registros de la tabla TA_DIFUNTO por un foreign key.
		/// </summary>
		public List<ENT_TA_DIFUNTO> SelectAllByDIFN_IDCEMENTERIO(int DIFN_IDCEMENTERIO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
				new SqlParameter("@DIFN_IDCEMENTERIO", DIFN_IDCEMENTERIO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			List<ENT_TA_DIFUNTO> x_oENT_TA_DIFUNTOList = new List<ENT_TA_DIFUNTO>();

			try{
					x_oENT_TA_DIFUNTOList = GetList<ENT_TA_DIFUNTO>("TA_DIFUNTOSelectAllByDIFN_IDCEMENTERIO", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
			return x_oENT_TA_DIFUNTOList;
		}

		/// <summary>
		/// Selecciona todos los registro de la tabla TA_DIFUNTO por nombres o apellidos.
		/// </summary>
		public List<ENT_TA_DIFUNTO> BuscarSerQuerido(ENT_TA_DIFUNTO x_oENT_TA_DIFUNTO)
		{
			SqlParameter[] parameters = null;
			try
			{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@DIFS_NOMBRES", x_oENT_TA_DIFUNTO.DIFS_NOMBRES),
					new SqlParameter("@DIFS_APEPATERNO", x_oENT_TA_DIFUNTO.DIFS_APEPATERNO),
					new SqlParameter("@DIFS_APEMATERNO", x_oENT_TA_DIFUNTO.DIFS_APEMATERNO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			};
			List<ENT_TA_DIFUNTO> x_oENT_TA_DIFUNTOList = new List<ENT_TA_DIFUNTO>();
			try
			{
				x_oENT_TA_DIFUNTOList = GetList<ENT_TA_DIFUNTO>("TA_DIFUNTO_BuscarSerQuerido", parameters);
				return x_oENT_TA_DIFUNTOList;
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
		}

		#endregion
	}
}
