using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using log4net;
using Microsoft.ApplicationBlocks.Data;
using SW.CEMENTERIO.EntityLayer;

namespace SW.CEMENTERIO.DataAccessLayer
{
	public class DAL_TA_CEMENTERIO : DAL_Execute
	{
		#region Methods

		/// <summary>
		/// Guarda un registro de la tabla TA_CEMENTERIO.
		/// </summary>
		public void Insert(ENT_TA_CEMENTERIO x_oENT_TA_CEMENTERIO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@CEMS_NOMBRES", x_oENT_TA_CEMENTERIO.CEMS_NOMBRES),
					new SqlParameter("@CEMS_USUREGISTRO", x_oENT_TA_CEMENTERIO.CEMS_USUREGISTRO),
					new SqlParameter("@CEMD_FECREGISTRO", x_oENT_TA_CEMENTERIO.CEMD_FECREGISTRO),
					new SqlParameter("@CEMS_USUMODIFICA", x_oENT_TA_CEMENTERIO.CEMS_USUMODIFICA),
					new SqlParameter("@CEMD_FECMODIFICA", x_oENT_TA_CEMENTERIO.CEMD_FECMODIFICA),
					new SqlParameter("@CEMB_ESTADO", x_oENT_TA_CEMENTERIO.CEMB_ESTADO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				x_oENT_TA_CEMENTERIO.CEMN_IDCEMENTERIO = (int)ejecutarScalar("TA_CEMENTERIO_Insert", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error en operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Actualiza a registro de la tabla TA_CEMENTERIO.
		/// </summary>
		public void Update(ENT_TA_CEMENTERIO x_oENT_TA_CEMENTERIO)
		{

			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@CEMN_IDCEMENTERIO", x_oENT_TA_CEMENTERIO.CEMN_IDCEMENTERIO),
					new SqlParameter("@CEMS_NOMBRES", x_oENT_TA_CEMENTERIO.CEMS_NOMBRES),
					new SqlParameter("@CEMS_USUREGISTRO", x_oENT_TA_CEMENTERIO.CEMS_USUREGISTRO),
					new SqlParameter("@CEMD_FECREGISTRO", x_oENT_TA_CEMENTERIO.CEMD_FECREGISTRO),
					new SqlParameter("@CEMS_USUMODIFICA", x_oENT_TA_CEMENTERIO.CEMS_USUMODIFICA),
					new SqlParameter("@CEMD_FECMODIFICA", x_oENT_TA_CEMENTERIO.CEMD_FECMODIFICA),
					new SqlParameter("@CEMB_ESTADO", x_oENT_TA_CEMENTERIO.CEMB_ESTADO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_CEMENTERIO_Update", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Elimina un registro de la tabla TA_CEMENTERIO por su primary key.
		/// </summary>
		public void Delete(int CEMN_IDCEMENTERIO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@CEMN_IDCEMENTERIO", CEMN_IDCEMENTERIO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			try{
				ejecutarNonQuery("TA_CEMENTERIO_Delete", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
		}

		/// <summary>
		/// Selecciona una registro de la tabla TA_CEMENTERIO por su primary key.
		/// </summary>
		public ENT_TA_CEMENTERIO Select(int CEMN_IDCEMENTERIO)
		{
			SqlParameter[] parameters = null;
			try{
				parameters = new SqlParameter[]
				{
					new SqlParameter("@CEMN_IDCEMENTERIO", CEMN_IDCEMENTERIO)
				};
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}

			ENT_TA_CEMENTERIO objTA_CEMENTERIO = new ENT_TA_CEMENTERIO();
			try{
					 objTA_CEMENTERIO = GetEntity<ENT_TA_CEMENTERIO>("TA_CEMENTERIO_Select", parameters);
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de operación de acceso a datos.", ex);
			}
			return objTA_CEMENTERIO;
		}

		/// <summary>
		/// Selecciona todos los registro de la tabla TA_CEMENTERIO.
		/// </summary>
		public List<ENT_TA_CEMENTERIO> SelectAll()
		{

			try{
				List<ENT_TA_CEMENTERIO> x_oENT_TA_CEMENTERIOList = new List<ENT_TA_CEMENTERIO>();

				x_oENT_TA_CEMENTERIOList = GetList<ENT_TA_CEMENTERIO>("TA_CEMENTERIO_SelectAll");
				return x_oENT_TA_CEMENTERIOList;
			}
			catch (Exception ex)
			{
				throw controlarExcepcion("Error de asignación de parámetros.", ex);
			}
		}


		#endregion
	}
}
