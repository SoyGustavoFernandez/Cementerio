using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using log4net;
using Microsoft.ApplicationBlocks.Data;
using SW.CEMENTERIO.EntityLayer;

namespace SW.CEMENTERIO.DataAccessLayer
{
	public class DAL_TA_COLABORADOR : DAL_Execute
	{
		#region Methods

		/// <summary>
		/// Guarda un registro de la tabla TA_COLABORADOR.
		/// </summary>
		public void Insert(ENT_TA_COLABORADOR x_oENT_TA_COLABORADOR)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@COLN_IDCEMENTERIO", x_oENT_TA_COLABORADOR.COLN_IDCEMENTERIO),
					new SqlParameter("@COLS_NOMBRES", x_oENT_TA_COLABORADOR.COLS_NOMBRES),
					new SqlParameter("@COLS_APEPATERNO", x_oENT_TA_COLABORADOR.COLS_APEPATERNO),
					new SqlParameter("@COLS_APEMATERNO", x_oENT_TA_COLABORADOR.COLS_APEMATERNO),
					new SqlParameter("@COLS_CORREO", x_oENT_TA_COLABORADOR.COLS_CORREO),
					new SqlParameter("@COLS_USUREGISTRO", x_oENT_TA_COLABORADOR.COLS_USUREGISTRO),
					new SqlParameter("@COLD_FECREGISTRO", x_oENT_TA_COLABORADOR.COLD_FECREGISTRO),
					new SqlParameter("@COLS_USUMODIFICA", x_oENT_TA_COLABORADOR.COLS_USUMODIFICA),
					new SqlParameter("@COLD_FECMODIFICA", x_oENT_TA_COLABORADOR.COLD_FECMODIFICA),
					new SqlParameter("@COLB_ESTADO", x_oENT_TA_COLABORADOR.COLB_ESTADO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				x_oENT_TA_COLABORADOR.COLN_IDCOLABORADOR = (int)ejecutarScalar("TA_COLABORADOR_Insert", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error en operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Actualiza a registro de la tabla TA_COLABORADOR.
		/// </summary>
		public void Update(ENT_TA_COLABORADOR x_oENT_TA_COLABORADOR)
		{

			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@COLN_IDCOLABORADOR", x_oENT_TA_COLABORADOR.COLN_IDCOLABORADOR),
					new SqlParameter("@COLN_IDCEMENTERIO", x_oENT_TA_COLABORADOR.COLN_IDCEMENTERIO),
					new SqlParameter("@COLS_NOMBRES", x_oENT_TA_COLABORADOR.COLS_NOMBRES),
					new SqlParameter("@COLS_APEPATERNO", x_oENT_TA_COLABORADOR.COLS_APEPATERNO),
					new SqlParameter("@COLS_APEMATERNO", x_oENT_TA_COLABORADOR.COLS_APEMATERNO),
					new SqlParameter("@COLS_CORREO", x_oENT_TA_COLABORADOR.COLS_CORREO),
					new SqlParameter("@COLS_USUREGISTRO", x_oENT_TA_COLABORADOR.COLS_USUREGISTRO),
					new SqlParameter("@COLD_FECREGISTRO", x_oENT_TA_COLABORADOR.COLD_FECREGISTRO),
					new SqlParameter("@COLS_USUMODIFICA", x_oENT_TA_COLABORADOR.COLS_USUMODIFICA),
					new SqlParameter("@COLD_FECMODIFICA", x_oENT_TA_COLABORADOR.COLD_FECMODIFICA),
					new SqlParameter("@COLB_ESTADO", x_oENT_TA_COLABORADOR.COLB_ESTADO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_COLABORADOR_Update", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Elimina un registro de la tabla TA_COLABORADOR por su primary key.
		/// </summary>
		public void Delete(int COLN_IDCOLABORADOR)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@COLN_IDCOLABORADOR", COLN_IDCOLABORADOR)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_COLABORADOR_Delete", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Deletes a record from the TA_COLABORADOR table by a foreign key.
		/// </summary>
		public void DeleteAllByCOLN_IDCEMENTERIO(int COLN_IDCEMENTERIO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@COLN_IDCEMENTERIO", COLN_IDCEMENTERIO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_COLABORADORDeleteAllByCOLN_IDCEMENTERIO", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_COLABORADOR por su primary key.
		/// </summary>
		public ENT_TA_COLABORADOR Select(int COLN_IDCOLABORADOR)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@COLN_IDCOLABORADOR", COLN_IDCOLABORADOR)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			ENT_TA_COLABORADOR objTA_COLABORADOR = new ENT_TA_COLABORADOR();
			try{
					 objTA_COLABORADOR = GetEntity<ENT_TA_COLABORADOR>("TA_COLABORADOR_Select", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
			return objTA_COLABORADOR;
		}

		/// <summary>
		/// Selecciona todos los registro de la tabla TA_COLABORADOR.
		/// </summary>
		public List<ENT_TA_COLABORADOR> SelectAll()
		{

			try{
				List<ENT_TA_COLABORADOR> x_oENT_TA_COLABORADORList = new List<ENT_TA_COLABORADOR>();

				x_oENT_TA_COLABORADORList = GetList<ENT_TA_COLABORADOR>("TA_COLABORADOR_SelectAll");
				return x_oENT_TA_COLABORADORList;
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
		}

		/// <summary>
		/// Selecciona los registros de la tabla TA_COLABORADOR por un foreign key.
		/// </summary>
		public List<ENT_TA_COLABORADOR> SelectAllByCOLN_IDCEMENTERIO(int COLN_IDCEMENTERIO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
				new SqlParameter("@COLN_IDCEMENTERIO", COLN_IDCEMENTERIO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			List<ENT_TA_COLABORADOR> x_oENT_TA_COLABORADORList = new List<ENT_TA_COLABORADOR>();

			try{
					x_oENT_TA_COLABORADORList = GetList<ENT_TA_COLABORADOR>("TA_COLABORADORSelectAllByCOLN_IDCEMENTERIO", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
			return x_oENT_TA_COLABORADORList;
		}


		#endregion
	}
}
