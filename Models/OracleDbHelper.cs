using System;
using System.Data;
using Oracle.ManagedDataAccess.Client; // Si te sale error aquí, mira el paso 3
using System.Configuration;

namespace Proyecto_GYM.Models
{
    public class OracleDbHelper
    {
        // Cadena de conexión directa para tu BD del GYM
        private readonly string _connectionString = "Data Source=localhost:1521/FREEPDB1;User Id=LUMINA_APP;Password=Lumina2026;";

        // Método para abrir la conexión
        public OracleConnection GetConnection()
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar a Oracle: " + ex.Message);
            }
        }

        // Método para ejecutar consultas (SELECT)
        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            using (OracleConnection conn = GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Método para insertar, actualizar o eliminar (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string sql, OracleParameter[] parameters = null)
        {
            using (OracleConnection conn = GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}