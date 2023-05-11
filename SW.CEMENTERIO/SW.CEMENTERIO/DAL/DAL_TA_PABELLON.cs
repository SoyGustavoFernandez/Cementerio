using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using log4net;
using Microsoft.ApplicationBlocks.Data;
using SW.CEMENTERIO.EntityLayer;

namespace SW.CEMENTERIO.DataAccessLayer
{
	public class DAL_TA_PABELLON : DAL_Execute
	{
		#region Methods

		/// <summary>
		/// Guarda un registro de la tabla TA_PABELLON.
		/// </summary>
		public void Insert(ENT_TA_PABELLON x_oENT_TA_PABELLON)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@PABN_IDCEMENTERIO", x_oENT_TA_PABELLON.PABN_IDCEMENTERIO),
					new SqlParameter("@PABS_NOMBRE", x_oENT_TA_PABELLON.PABS_NOMBRE),
					new SqlParameter("@PABS_TIPO", x_oENT_TA_PABELLON.PABS_TIPO),
					new SqlParameter("@PABS_UBICACION", x_oENT_TA_PABELLON.PABS_UBICACION),
					new SqlParameter("@PABS_USUREGISTRO", x_oENT_TA_PABELLON.PABS_USUREGISTRO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				x_oENT_TA_PABELLON.PABN_IDPABELLON = (int)ejecutarScalar("TA_PABELLON_Insert", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error en operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Actualiza a registro de la tabla TA_PABELLON.
		/// </summary>
		public void Update(ENT_TA_PABELLON x_oENT_TA_PABELLON)
		{

			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@PABN_IDPABELLON", x_oENT_TA_PABELLON.PABN_IDPABELLON),
					new SqlParameter("@PABN_IDCEMENTERIO", x_oENT_TA_PABELLON.PABN_IDCEMENTERIO),
					new SqlParameter("@PABS_NOMBRE", x_oENT_TA_PABELLON.PABS_NOMBRE),
					new SqlParameter("@PABS_TIPO", x_oENT_TA_PABELLON.PABS_TIPO),
					new SqlParameter("@PABS_UBICACION", x_oENT_TA_PABELLON.PABS_UBICACION),
					new SqlParameter("@PABS_USUMODIFICA", x_oENT_TA_PABELLON.PABS_USUMODIFICA),
					new SqlParameter("@PABD_FECMODIFICA", x_oENT_TA_PABELLON.PABD_FECMODIFICA)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_PABELLON_Update", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Elimina un registro de la tabla TA_PABELLON por su primary key.
		/// </summary>
		public void Delete(int PABN_IDPABELLON, string PABB_ESTADOBAJA)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@PABN_IDPABELLON", PABN_IDPABELLON),
					new SqlParameter("@PABB_ESTADOBAJA", PABB_ESTADOBAJA)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarScalar("TA_PABELLON_Delete", parameters);
				//ejecutarNonQuery("TA_PABELLON_Delete", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Deletes a record from the TA_PABELLON table by a foreign key.
		/// </summary>
		public void DeleteAllByPABN_IDCEMENTERIO(int PABN_IDCEMENTERIO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@PABN_IDCEMENTERIO", PABN_IDCEMENTERIO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_PABELLONDeleteAllByPABN_IDCEMENTERIO", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_PABELLON por su primary key.
		/// </summary>
		public ENT_TA_PABELLON Select(int PABN_IDPABELLON)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@PABN_IDPABELLON", PABN_IDPABELLON)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			ENT_TA_PABELLON objTA_PABELLON = new ENT_TA_PABELLON();
			try{
					 objTA_PABELLON = GetEntity<ENT_TA_PABELLON>("TA_PABELLON_Select", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
			return objTA_PABELLON;
		}

		/// <summary>
		/// Selecciona todos los registro de la tabla TA_PABELLON.
		/// </summary>
		public List<ENT_TA_PABELLON> SelectAll()
		{

			try{
				List<ENT_TA_PABELLON> x_oENT_TA_PABELLONList = new List<ENT_TA_PABELLON>();

				x_oENT_TA_PABELLONList = GetList<ENT_TA_PABELLON>("TA_PABELLON_SelectAll");
				return x_oENT_TA_PABELLONList;
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
		}

		/// <summary>
		/// Selecciona los registros de la tabla TA_PABELLON por un foreign key.
		/// </summary>
		public List<ENT_TA_PABELLON> SelectAllByPABN_IDCEMENTERIO(int PABN_IDCEMENTERIO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
				new SqlParameter("@PABN_IDCEMENTERIO", PABN_IDCEMENTERIO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			List<ENT_TA_PABELLON> x_oENT_TA_PABELLONList = new List<ENT_TA_PABELLON>();

			try{
					x_oENT_TA_PABELLONList = GetList<ENT_TA_PABELLON>("TA_PABELLONSelectAllByPABN_IDCEMENTERIO", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
			return x_oENT_TA_PABELLONList;
		}


		#endregion
	}
}
