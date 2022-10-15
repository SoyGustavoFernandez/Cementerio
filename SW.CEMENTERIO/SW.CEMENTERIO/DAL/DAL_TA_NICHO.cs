using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using log4net;
using Microsoft.ApplicationBlocks.Data;
using SW.CEMENTERIO.EntityLayer;

namespace SW.CEMENTERIO.DataAccessLayer
{
	public class DAL_TA_NICHO : DAL_Execute
	{
		#region Methods

		/// <summary>
		/// Guarda un registro de la tabla TA_NICHO.
		/// </summary>
		public void Insert(ENT_TA_NICHO x_oENT_TA_NICHO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@NICS_CODNICHO", x_oENT_TA_NICHO.NICS_CODNICHO),
					new SqlParameter("@NICB_NUMDIFTOTAL", x_oENT_TA_NICHO.NICB_NUMDIFTOTAL),
					new SqlParameter("@NICB_NUMDIFACTUAL", x_oENT_TA_NICHO.NICB_NUMDIFACTUAL),
					new SqlParameter("@NICN_IDPABELLON", x_oENT_TA_NICHO.NICN_IDPABELLON),
					new SqlParameter("@NICS_USUREGISTRO", x_oENT_TA_NICHO.NICS_USUREGISTRO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				x_oENT_TA_NICHO.NICN_IDNICHO = (int)ejecutarScalar("TA_NICHO_Insert", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error en operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Actualiza a registro de la tabla TA_NICHO.
		/// </summary>
		public void Update(ENT_TA_NICHO x_oENT_TA_NICHO)
		{

			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@NICN_IDNICHO", x_oENT_TA_NICHO.NICN_IDNICHO),
					new SqlParameter("@NICS_CODNICHO", x_oENT_TA_NICHO.NICS_CODNICHO),
					new SqlParameter("@NICB_NUMDIFTOTAL", x_oENT_TA_NICHO.NICB_NUMDIFTOTAL),
					new SqlParameter("@NICN_IDPABELLON", x_oENT_TA_NICHO.NICN_IDPABELLON),
					new SqlParameter("@NICS_USUMODIFICA", x_oENT_TA_NICHO.NICS_USUMODIFICA)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				x_oENT_TA_NICHO.NICB_STATUSRESPONSE = (int)ejecutarScalar("TA_NICHO_Update", parameters);
				//ejecutarNonQuery("TA_NICHO_Update", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Actualiza la cantidad de espacios libres en un NICHO.
		/// </summary>
		public ENT_TA_NICHO UpdateSpace(int NICN_IDNICHO)
		{
			SqlParameter[] parameters = null;
			try
			{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@NICN_IDNICHO", NICN_IDNICHO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			ENT_TA_NICHO objTA_NICHO = new ENT_TA_NICHO();
			try
			{
				objTA_NICHO.NICB_STATUSRESPONSE = (int)ejecutarScalar("TA_NICHO_UpdateSpace", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
			return objTA_NICHO; 
		}

		/// <summary>
		/// Elimina un registro de la tabla TA_NICHO por su primary key.
		/// </summary>
		public void Delete(int NICN_IDNICHO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@NICN_IDNICHO", NICN_IDNICHO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_NICHO_Delete", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Deletes a record from the TA_NICHO table by a foreign key.
		/// </summary>
		public void DeleteAllByNICN_IDPABELLON(int NICN_IDPABELLON)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@NICN_IDPABELLON", NICN_IDPABELLON)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_NICHODeleteAllByNICN_IDPABELLON", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_NICHO por su primary key.
		/// </summary>
		public ENT_TA_NICHO Select(int NICN_IDNICHO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@NICN_IDNICHO", NICN_IDNICHO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			ENT_TA_NICHO objTA_NICHO = new ENT_TA_NICHO();
			try{
					 objTA_NICHO = GetEntity<ENT_TA_NICHO>("TA_NICHO_Select", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
			return objTA_NICHO;
		}

		/// <summary>
		/// Selecciona todos los registro de la tabla TA_NICHO.
		/// </summary>
		public List<ENT_TA_NICHO> SelectAll()
		{

			try{
				List<ENT_TA_NICHO> x_oENT_TA_NICHOList = new List<ENT_TA_NICHO>();

				x_oENT_TA_NICHOList = GetList<ENT_TA_NICHO>("TA_NICHO_SelectAll");
				return x_oENT_TA_NICHOList;
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
		}

		/// <summary>
		/// Selecciona los registros de la tabla TA_NICHO por un foreign key.
		/// </summary>
		public List<ENT_TA_NICHO> SelectAllByNICN_IDPABELLON(int NICN_IDPABELLON)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
				new SqlParameter("@NICN_IDPABELLON", NICN_IDPABELLON)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			List<ENT_TA_NICHO> x_oENT_TA_NICHOList = new List<ENT_TA_NICHO>();

			try{
					x_oENT_TA_NICHOList = GetList<ENT_TA_NICHO>("TA_NICHOSelectAllByNICN_IDPABELLON", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
			return x_oENT_TA_NICHOList;
		}


		#endregion
	}
}
