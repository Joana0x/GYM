using GYM_NoSql.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client; // Para conectarnos a Oracle
using System.Configuration;            // Para leer el App.config

namespace GYM_NoSql.controllers
{
    public class PlanController
    {
        // Jalamos la cadena de conexión de tu archivo de configuración
        private string connectionString = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        // 1. LEER (Reemplaza a la lista temporal)
        public List<Plan> ObtenerTodos()
        {
            List<Plan> listaPlanes = new List<Plan>();
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                // Traemos los datos directamente de la tabla de Oracle
                OracleCommand cmd = new OracleCommand("SELECT id_plan, nombre, precio, activo FROM planes", conn);

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaPlanes.Add(new Plan
                        {
                            Id_Plan = Convert.ToInt32(reader["id_plan"]),
                            Nombre = reader["nombre"].ToString(),
                            Precio = Convert.ToDecimal(reader["precio"]),
                            Activo = reader["activo"].ToString()
                        });
                    }
                }
            }
            return listaPlanes;
        }

        // 2. CREAR (Hacemos un INSERT real)
        public void Agregar(Plan p)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO planes (nombre, precio, activo) VALUES (:nombre, :precio, :activo)";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add("nombre", p.Nombre);
                        cmd.Parameters.Add("precio", p.Precio);
                        cmd.Parameters.Add("activo", p.Activo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar plan: " + ex.Message);
            }
        }

        // 3. ACTUALIZAR (Hacemos un UPDATE real)
        public void Editar(Plan editado)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE planes SET nombre = :nombre, precio = :precio, activo = :activo WHERE id_plan = :id";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("nombre", editado.Nombre);
                    cmd.Parameters.Add("precio", editado.Precio);
                    cmd.Parameters.Add("activo", editado.Activo);
                    cmd.Parameters.Add("id", editado.Id_Plan); // Usamos el ID correcto
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 4. ELIMINAR (Hacemos un DELETE real)
        public void Eliminar(int idPlan) // Cambiamos el parámetro de string a int
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM planes WHERE id_plan = :id";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("id", idPlan);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        
        }
    
}