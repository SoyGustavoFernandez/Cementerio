using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using log4net;

namespace Microsoft.ApplicationBlocks.Data
{
    public class DAL_Execute
    {
        protected string strConexion = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        protected bool Ejecutado = false;
        protected string Error = string.Empty;

        #region OPERACIONES UNITARIAS

        protected List<T> GetList<T>(string storeProcedure, SqlParameter[] parameters = null)
        {
            using (SqlConnection conexion = new SqlConnection(strConexion))
            {
                return DataReaderHelper.DataReaderMapToList<T>(EjecutarReader(conexion, storeProcedure, parameters));
            }
        }

        protected T GetEntity<T>(string storeProcedure, SqlParameter[] parameters = null)
        {
            using (SqlConnection conexion = new SqlConnection(strConexion))
            {
                return DataReaderHelper.DataReaderMapToEntidad<T>(EjecutarReader(conexion, storeProcedure, parameters));
            }
        }

        protected DataTable GetTable(string storeProcedure, SqlParameter[] parameters = null)
        {
            DataTable dtResult = new DataTable();
            using (SqlConnection conexion = new SqlConnection(strConexion))
            {
                dtResult.Load(EjecutarReader(conexion, storeProcedure, parameters));
                return dtResult;
            }
        }

        private SqlDataReader EjecutarReader(SqlConnection conexion, string xProcedimiento, SqlParameter[] xParametros = null)
        {
            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                throw controlarExcepcion("Error de conexión a base de datos.", ex);
            }

            try
            {
                SqlDataReader dr;

                if (xParametros == null || xParametros.Length == 0)
                    dr = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, xProcedimiento);
                else
                    dr = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, xProcedimiento, xParametros);
                Ejecutado = true;

                return dr;
            }
            catch (TimeoutException ex)
            {
                throw controlarExcepcion("Tiempo de espera superado. Consulte al administrador del sistema.", ex);
            }
            catch (SqlException ex)
            {
                throw controlarExcepcion("Error en Base de Datos. Consulte al administrador del sistema.", ex);
            }
            catch (DbException ex)
            {
                throw controlarExcepcion("Error en conexión a base de datos. Consulte al administrador del sistema.", ex);
            }
            catch (Exception ex)
            {
                throw controlarExcepcion("Error en capa de acceso a datos. Consulte al administrador del sistema.", ex);
            }
        }

        #endregion


        #region TRANSACCIONES UNITARIAS
        public DAL_Execute()
        {
        }
        public DataSet ejecutarDataSet(string x_Procedimiento, SqlParameter[] x_parametros = null)
        {
            SqlConnection conexion = new SqlConnection();
            SqlTransaction transaccion = null;

            try
            {
                conexion = new SqlConnection(strConexion);
                conexion.Open();
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw controlarExcepcion("Error de conexión a base de datos.", ex);
            }

            try
            {
                DataSet ds = null;

                conexion = new SqlConnection(strConexion);
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                if (x_parametros == null || x_parametros.Length == 0)
                    ds = SqlHelper.ExecuteDataset(transaccion, CommandType.StoredProcedure, x_Procedimiento);
                else
                    ds = SqlHelper.ExecuteDataset(transaccion, CommandType.StoredProcedure, x_Procedimiento, x_parametros);
                Ejecutado = true;
                transaccion.Commit();
                return ds;
            }
            catch (TimeoutException ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Tiempo de espera superado. Consulte al administrador del sistema.", ex);
            }
            catch (SqlException ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Error en Base de Datos. Consulte al administrador del sistema.", ex);
            }
            catch (DbException ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Error en conexión a base de datos. Consulte al administrador del sistema.", ex);
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Error en capa de acceso a datos. Consulte al administrador del sistema.", ex);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                conexion.Dispose();
            }
        }

        public SqlDataReader ejecutarReader(string x_Procedimiento, SqlParameter[] x_parametros = null)
        {
            SqlConnection conexion = new SqlConnection();
            SqlTransaction transaccion = null;
            SqlDataReader dr;
            try
            {
                conexion = new SqlConnection(strConexion);
                conexion.Open();
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw controlarExcepcion("Error de conexión a base de datos.", ex);
            }

            try
            {
                //conexion = new SqlConnection(strConexion);
                //conexion.Open();
                //transaccion = conexion.BeginTransaction();
                if (x_parametros == null || x_parametros.Length == 0)
                    dr = SqlHelper.ExecuteReader(conexion,CommandType.StoredProcedure, x_Procedimiento);
                else
                    dr = SqlHelper.ExecuteReader(conexion,CommandType.StoredProcedure, x_Procedimiento, x_parametros);
                Ejecutado = true;
                //transaccion.Commit();
                return dr;
            }
            catch (TimeoutException ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Tiempo de espera superado. Consulte al administrador del sistema.", ex);
            }
            catch (SqlException ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Error en Base de Datos. Consulte al administrador del sistema.", ex);
            }
            catch (DbException ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Error en conexión a base de datos. Consulte al administrador del sistema.", ex);
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Error en capa de acceso a datos. Consulte al administrador del sistema.", ex);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                conexion.Dispose();
            }
        }

        public DataTable ejecutarDataTable(string x_Procedimiento, SqlParameter[] x_parametros = null)
        {
            SqlConnection conexion = new SqlConnection();
            SqlTransaction transaccion = null;
            SqlDataReader reader = null;
            try
            {
                conexion = new SqlConnection(strConexion);
                conexion.Open();
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw controlarExcepcion("Error de conexión a base de datos.", ex);
            }

            try
            {

                transaccion = conexion.BeginTransaction();

                DataTable dt = null;

                if (x_parametros == null || x_parametros.Length == 0)
                {
                    reader = SqlHelper.ExecuteReader(transaccion, CommandType.StoredProcedure, x_Procedimiento);
                    dt.Load(reader);
                }
                else
                {
                    reader = SqlHelper.ExecuteReader(transaccion, CommandType.StoredProcedure, x_Procedimiento, x_parametros);
                    dt.Load(reader);
                }

                

                Ejecutado = true;
                transaccion.Commit();
                return dt;
            }
            catch (TimeoutException ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Tiempo de espera superado. Consulte al administrador del sistema.", ex);
            }
            catch (SqlException ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Error en Base de Datos. Consulte al administrador del sistema.", ex);
            }
            catch (DbException ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Error en conexión a base de datos. Consulte al administrador del sistema.", ex);
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Error en capa de acceso a datos. Consulte al administrador del sistema.", ex);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                conexion.Dispose();
            }
        }

        public int ejecutarScalar(string x_Procedimiento, SqlParameter[] x_parametros = null)
        {
            SqlConnection conexion = new SqlConnection();

            try
            {
                using (conexion = new SqlConnection(strConexion))
                {
                    conexion.Open();

                    object resultado = null;
                    if (x_parametros == null || x_parametros.Length == 0)
                        resultado = SqlHelper.ExecuteScalar(conexion, CommandType.StoredProcedure, x_Procedimiento);
                    else
                        resultado = SqlHelper.ExecuteScalar(conexion, CommandType.StoredProcedure, x_Procedimiento, x_parametros);

                    Ejecutado = true;
                    return Convert.ToInt32(resultado);
                }
            }
            catch (TimeoutException ex)
            {
                throw controlarExcepcion("Tiempo de espera superado. Consulte al administrador del sistema.", ex);
            }
            catch (SqlException ex)
            {
                throw controlarExcepcion("Error en Base de Datos. Consulte al administrador del sistema.", ex);
            }
            catch (DbException ex)
            {
                throw controlarExcepcion("Error en conexión a base de datos. Consulte al administrador del sistema.", ex);
            }
            catch (Exception ex)
            {
                throw controlarExcepcion("Error en capa de acceso a datos. Consulte al administrador del sistema.", ex);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                conexion.Dispose();
            }
        }

        public int ejecutarNonQuery(string x_Procedimiento, SqlParameter[] x_parametros = null)
        {

            SqlConnection conexion = new SqlConnection();
            SqlTransaction transaccion = null;

            try
            {
                conexion = new SqlConnection(strConexion);
                conexion.Open();
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw controlarExcepcion("Error de conexión a base de datos.", ex);
            }

            try
            {
                conexion = new SqlConnection(strConexion);
                conexion.Open();
                transaccion = conexion.BeginTransaction();

                int resultado = -1;
                if (x_parametros == null || x_parametros.Length == 0)
                    resultado = SqlHelper.ExecuteNonQuery(transaccion, CommandType.StoredProcedure, x_Procedimiento);
                else
                    resultado = SqlHelper.ExecuteNonQuery(transaccion, CommandType.StoredProcedure, x_Procedimiento, x_parametros);

                transaccion.Commit();
                Ejecutado = true;
                return resultado;
            }
            catch (TimeoutException ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Tiempo de espera superado. Consulte al administrador del sistema.", ex);
            }
            catch (SqlException ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Error en Base de Datos. Consulte al administrador del sistema.", ex);
            }
            catch (DbException ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Error en conexión a base de datos. Consulte al administrador del sistema.", ex);
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw controlarExcepcion("Error en capa de acceso a datos. Consulte al administrador del sistema.", ex);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                conexion.Dispose();
            }
        } 
        #endregion

        #region TRANSACCIONES EN CONJUNTO
        public DataSet ejecutarDataSet_Transaction(SqlTransaction x_transaccion, string x_Procedimiento, SqlParameter[] x_parametros = null)
        {
            try
            {
                DataSet ds = null;
                if (x_parametros == null || x_parametros.Length == 0)
                    ds = SqlHelper.ExecuteDataset(x_transaccion, CommandType.StoredProcedure, x_Procedimiento);
                else
                    ds = SqlHelper.ExecuteDataset(x_transaccion, CommandType.StoredProcedure, x_Procedimiento, x_parametros);
                Ejecutado = true;
                return ds;
            }
            catch (TimeoutException ex)
            {
                throw controlarExcepcion("Tiempo de espera superado. Consulte al administrador del sistema.", ex);
            }
            catch (SqlException ex)
            {
                throw controlarExcepcion("Error en Base de Datos. Consulte al administrador del sistema.", ex);
            }
            catch (DbException ex)
            {
                throw controlarExcepcion("Error en conexión a base de datos. Consulte al administrador del sistema.", ex);
            }
            catch (Exception ex)
            {
                throw controlarExcepcion("Error en capa de acceso a datos. Consulte al administrador del sistema.", ex);
            }
        }

        public SqlDataReader ejecutarReader_Transaction(SqlTransaction x_transaccion, string x_Procedimiento, SqlParameter[] x_parametros = null)
        {
            SqlDataReader dr;

            try
            {
                if (x_parametros == null || x_parametros.Length == 0)
                    dr = SqlHelper.ExecuteReader(x_transaccion, CommandType.StoredProcedure, x_Procedimiento);
                else
                    dr = SqlHelper.ExecuteReader(x_transaccion, CommandType.StoredProcedure, x_Procedimiento, x_parametros);
                Ejecutado = true;
                
                return dr;
            }
            catch (TimeoutException ex)
            {
                throw controlarExcepcion("Tiempo de espera superado. Consulte al administrador del sistema.", ex);
            }
            catch (SqlException ex)
            {
                throw controlarExcepcion("Error en Base de Datos. Consulte al administrador del sistema.", ex);
            }
            catch (DbException ex)
            {
                throw controlarExcepcion("Error en conexión a base de datos. Consulte al administrador del sistema.", ex);
            }
            catch (Exception ex)
            {
                throw controlarExcepcion("Error en capa de acceso a datos. Consulte al administrador del sistema.", ex);
            }
        }

        public DataTable ejecutarDataTable_Transaction(SqlTransaction x_transaccion, string x_Procedimiento, SqlParameter[] x_parametros = null)
        {
            try
            {
                DataSet ds = null;
                DataTable dt = null;

                if (x_parametros == null || x_parametros.Length == 0)
                    ds = SqlHelper.ExecuteDataset(x_transaccion, CommandType.StoredProcedure, x_Procedimiento);
                else
                    ds = SqlHelper.ExecuteDataset(x_transaccion, CommandType.StoredProcedure, x_Procedimiento, x_parametros);

                dt = ds.Tables[0];

                Ejecutado = true;
                return dt;
            }
            catch (TimeoutException ex)
            {
                throw controlarExcepcion("Tiempo de espera superado. Consulte al administrador del sistema.", ex);
            }
            catch (SqlException ex)
            {
                throw controlarExcepcion("Error en Base de Datos. Consulte al administrador del sistema.", ex);
            }
            catch (DbException ex)
            {
                throw controlarExcepcion("Error en conexión a base de datos. Consulte al administrador del sistema.", ex);
            }
            catch (Exception ex)
            {
                throw controlarExcepcion("Error en capa de acceso a datos. Consulte al administrador del sistema.", ex);
            }
        }

        public int ejecutarScalar_Transaction(SqlTransaction x_transaccion, string x_Procedimiento, SqlParameter[] x_parametros = null)
        {


            try
            {

                object resultado = null;
                if (x_parametros == null || x_parametros.Length == 0)
                    resultado = SqlHelper.ExecuteScalar(x_transaccion, CommandType.StoredProcedure, x_Procedimiento);
                else
                    resultado = SqlHelper.ExecuteScalar(x_transaccion, CommandType.StoredProcedure, x_Procedimiento, x_parametros);

                Ejecutado = true;
                return Convert.ToInt32(resultado);
            }
            catch (TimeoutException ex)
            {
                throw controlarExcepcion("Tiempo de espera superado. Consulte al administrador del sistema.", ex);
            }
            catch (SqlException ex)
            {
                throw controlarExcepcion("Error en Base de Datos. Consulte al administrador del sistema.", ex);
            }
            catch (DbException ex)
            {
                throw controlarExcepcion("Error en conexión a base de datos. Consulte al administrador del sistema.", ex);
            }
            catch (Exception ex)
            {
                throw controlarExcepcion("Error en capa de acceso a datos. Consulte al administrador del sistema.", ex);
            }
        }

        public int ejecutarNonQuery_Transaction(SqlTransaction x_transaccion, string x_Procedimiento, SqlParameter[] x_parametros = null)
        {
            try
            {
                int resultado = -1;
                if (x_parametros == null || x_parametros.Length == 0)
                    resultado = SqlHelper.ExecuteNonQuery(x_transaccion, CommandType.StoredProcedure, x_Procedimiento);
                else
                    resultado = SqlHelper.ExecuteNonQuery(x_transaccion, CommandType.StoredProcedure, x_Procedimiento, x_parametros);

                Ejecutado = true;
                return resultado;
            }
            catch (TimeoutException ex)
            {
                throw controlarExcepcion("Tiempo de espera superado. Consulte al administrador del sistema.", ex);
            }
            catch (SqlException ex)
            {
                throw controlarExcepcion("Error en Base de Datos. Consulte al administrador del sistema.", ex);
            }
            catch (DbException ex)
            {
                throw controlarExcepcion("Error en conexión a base de datos. Consulte al administrador del sistema.", ex);
            }
            catch (Exception ex)
            {
                throw controlarExcepcion("Error en capa de acceso a datos. Consulte al administrador del sistema.", ex);
            }
        }
        #endregion

        public _DataRuntimeException controlarExcepcion(string x_mensaje, Exception x_excepcion)
        {
            Ejecutado = false;
            ILog oILog = LogManager.GetLogger(this.GetType());
            oILog.Error(x_excepcion.Message, x_excepcion);
            _DataRuntimeException drex = new _DataRuntimeException(x_mensaje, x_excepcion);
            return drex;
        }
    }
}