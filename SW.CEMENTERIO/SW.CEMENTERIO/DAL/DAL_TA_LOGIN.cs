using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using log4net;
using Microsoft.ApplicationBlocks.Data;
using SW.CEMENTERIO.EntityLayer;

namespace SW.CEMENTERIO.DataAccessLayer
{
	public class DAL_TA_LOGIN : DAL_Execute
	{
		#region Methods

		/// <summary>
		/// Guarda un registro de la tabla TA_LOGIN.
		/// </summary>
		public void Insert(ENT_TA_LOGIN x_oENT_TA_LOGIN)
		{
			SqlParameter[] parameters = null;
			try {
				parameters = new SqlParameter[]
				{
					new SqlParameter("@LOGN_IDCOLABORADOR", x_oENT_TA_LOGIN.LOGN_IDCOLABORADOR),
					new SqlParameter("@LOGS_USUARIO", x_oENT_TA_LOGIN.LOGS_USUARIO),
					new SqlParameter("@LOGS_CLAVE", x_oENT_TA_LOGIN.LOGS_CLAVE),
					new SqlParameter("@LOGS_USUREGISTRO", x_oENT_TA_LOGIN.LOGS_USUREGISTRO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try {
				x_oENT_TA_LOGIN.LOGN_IDLOGIN = (int)ejecutarScalar("TA_LOGIN_Insert", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error en operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Actualiza a registro de la tabla TA_LOGIN.
		/// </summary>
		public void Update(ENT_TA_LOGIN x_oENT_TA_LOGIN)
		{

			SqlParameter[] parameters = null;
			try {
				parameters = new SqlParameter[]
				{
					new SqlParameter("@LOGN_IDLOGIN", x_oENT_TA_LOGIN.LOGN_IDLOGIN),
					new SqlParameter("@LOGN_IDCOLABORADOR", x_oENT_TA_LOGIN.LOGN_IDCOLABORADOR),
					new SqlParameter("@LOGS_USUARIO", x_oENT_TA_LOGIN.LOGS_USUARIO),
					new SqlParameter("@LOGS_CLAVE", x_oENT_TA_LOGIN.LOGS_CLAVE),
					new SqlParameter("@LOGS_USUMODIFICA", x_oENT_TA_LOGIN.LOGS_USUMODIFICA),
					new SqlParameter("@LOGD_FECMODIFICA", x_oENT_TA_LOGIN.LOGD_FECMODIFICA)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try {
				ejecutarNonQuery("TA_LOGIN_Update", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Permite autenticar el inicio de sesión para un usuario
		/// </summary>
		public ENT_TA_LOGIN AutenticarLogin(string LOGS_USUARIO, string LOGS_CLAVE)
		{
			SqlParameter[] parameters = null;
			try
			{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@USU_USUARIO", LOGS_USUARIO),
					new SqlParameter("@USU_CLAVE", LOGS_CLAVE)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			ENT_TA_LOGIN objTA_LOGIN = new ENT_TA_LOGIN();
			try
			{
				objTA_LOGIN = GetEntity<ENT_TA_LOGIN>("TA_AutenticarLogin", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
			return objTA_LOGIN;
		}

		/// <summary>
		/// Elimina un registro de la tabla TA_LOGIN por su primary key.
		/// </summary>
		public void Delete(int LOGN_IDLOGIN)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@LOGN_IDLOGIN", LOGN_IDLOGIN)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_LOGIN_Delete", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Deletes a record from the TA_LOGIN table by a foreign key.
		/// </summary>
		public void DeleteAllByLOGN_IDCOLABORADOR(int LOGN_IDCOLABORADOR)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@LOGN_IDCOLABORADOR", LOGN_IDCOLABORADOR)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_LOGINDeleteAllByLOGN_IDCOLABORADOR", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_LOGIN por su primary key.
		/// </summary>
		public ENT_TA_LOGIN Select(int LOGN_IDLOGIN)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@LOGN_IDLOGIN", LOGN_IDLOGIN)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			ENT_TA_LOGIN objTA_LOGIN = new ENT_TA_LOGIN();
			try{
					 objTA_LOGIN = GetEntity<ENT_TA_LOGIN>("TA_LOGIN_Select", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
			return objTA_LOGIN;
		}

		/// <summary>
		/// Selecciona todos los registro de la tabla TA_LOGIN.
		/// </summary>
		public List<ENT_TA_LOGIN> SelectAll()
		{

			try{
				List<ENT_TA_LOGIN> x_oENT_TA_LOGINList = new List<ENT_TA_LOGIN>();

				x_oENT_TA_LOGINList = GetList<ENT_TA_LOGIN>("TA_LOGIN_SelectAll");
				return x_oENT_TA_LOGINList;
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
		}

		/// <summary>
		/// Selecciona los registros de la tabla TA_LOGIN por un foreign key.
		/// </summary>
		public List<ENT_TA_LOGIN> SelectAllByLOGN_IDCOLABORADOR(int LOGN_IDCOLABORADOR)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
				new SqlParameter("@LOGN_IDCOLABORADOR", LOGN_IDCOLABORADOR)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			List<ENT_TA_LOGIN> x_oENT_TA_LOGINList = new List<ENT_TA_LOGIN>();

			try{
					x_oENT_TA_LOGINList = GetList<ENT_TA_LOGIN>("TA_LOGINSelectAllByLOGN_IDCOLABORADOR", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
			return x_oENT_TA_LOGINList;
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_LOGIN por un foreign key.
		/// </summary>
		public ENT_TA_LOGIN SelectAllByCOLS_CORREO(string COLS_CORREO)
		{
			SqlParameter[] parameters = null;
			try
			{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@COLS_CORREO", COLS_CORREO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			ENT_TA_LOGIN objTA_LOGIN = new ENT_TA_LOGIN();
			try
			{
				objTA_LOGIN = GetEntity<ENT_TA_LOGIN>("TA_LOGIN_SelectByCOLS_CORREO", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
			return objTA_LOGIN;
		}
		
		#endregion
	}
}
