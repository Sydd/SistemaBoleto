using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Capa_de_Datos
{
    /// <summary>
    /// Clase estatica, no es necesario instancearla para usarla.
    /// Sirve para conectar
    /// </summary>
    public static class Conexion_BD
    {
        static SqlConnection conexion = new SqlConnection("workstation id=microsbd.mssql.somee.com;packet size=4096;user id=Sydd_SQLLogin_1;pwd=f5ofdh9bo3;data source=microsbd.mssql.somee.com;persist security info=False;initial catalog=microsbd");
        
        static private void Conectar()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    
                    conexion.Open();
                }
            }
            catch
            {
                throw new Exception("Error conexion");
            }
        }

        static void Desconectar()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {

                    conexion.Close();
                }
            }
            catch
            {
                throw new Exception("Error de conexion");
            }
        }

        static public int EjecutarEscalar(string cmdText)
        {
            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand(cmdText, conexion);
                int aux = Convert.ToInt32(cmd.ExecuteScalar());
                Desconectar();
                return aux;
            }
            catch (SqlException ex)
            {
                Desconectar();
                throw ex;
            }
        }
        /// <summary>
        /// Carga una sentencia SQL en una tabla.
        /// </summary>
        /// <param name="cmdText">Consulta SQL</param>
        /// <returns></returns>
        static public DataTable CargarDatos(string cmdText)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(cmdText, conexion);
                Conectar();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                Desconectar();
                return dt;
            }
            catch (SqlException ex)
            {
                Desconectar();
                throw ex;
            }
        }

        static public void EjecutarSql(string cmdText)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, conexion);
                Conectar();
                cmd.ExecuteNonQuery();
                Desconectar();
            }
            catch (SqlException ex)
            {
                Desconectar();
                throw ex;
            }
        }

    }
}