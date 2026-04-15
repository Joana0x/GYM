using GYM_NoSql.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client; // Para conectarnos a Oracle
using System.Configuration;            // Para leer el App.config

namespace GYM_NoSql.controllers
{
    public class SocioController
    {
        // Jalamos la cadena de conexión de tu archivo de configuración
        private string connectionString = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        // 1. LEER (Trae todos los socios directamente de Oracle)
        public List<Socio> ObtenerTodos()
        {
            List<Socio> listaSocios = new List<Socio>();
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT id_socio, id_plan, id_sexo, nombre, primer_apellido, segundo_apellido, telefono, fecha_registro FROM socios";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaSocios.Add(new Socio
                            {
                                Id_Socio = Convert.ToInt32(reader["id_socio"]),
                                Id_Plan = Convert.ToInt32(reader["id_plan"]),
                                Id_Sexo = Convert.ToInt32(reader["id_sexo"]),
                                Nombre = reader["nombre"].ToString(),
                                Primer_Apellido = reader["primer_apellido"].ToString(),
                                // Validamos si estos campos vienen vacíos (NULL) desde la base de datos
                                Segundo_Apellido = reader["segundo_apellido"] != DBNull.Value ? reader["segundo_apellido"].ToString() : "",
                                Telefono = reader["telefono"] != DBNull.Value ? reader["telefono"].ToString() : "",
                                Fecha_Registro = Convert.ToDateTime(reader["fecha_registro"])
                            });
                        }
                    }
                }
            }
            return listaSocios;
        }

        // 2. CREAR (Registra un socio nuevo desde el objeto)
        public void Agregar(Socio s)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO socios (id_plan, id_sexo, nombre, primer_apellido, segundo_apellido, telefono, fecha_registro) " +
                             "VALUES (:plan, :sexo, :nom, :ape1, :ape2, :tel, :fecha)";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("plan", s.Id_Plan);
                    cmd.Parameters.Add("sexo", s.Id_Sexo);
                    cmd.Parameters.Add("nom", s.Nombre);
                    cmd.Parameters.Add("ape1", s.Primer_Apellido);
                    cmd.Parameters.Add("ape2", s.Segundo_Apellido);
                    cmd.Parameters.Add("tel", s.Telefono);
                    cmd.Parameters.Add("fecha", s.Fecha_Registro);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 3. ACTUALIZAR (Modifica los datos de un socio existente)
        public void Editar(Socio editado)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE socios SET id_plan = :plan, id_sexo = :sexo, nombre = :nom, " +
                             "primer_apellido = :ape1, segundo_apellido = :ape2, telefono = :tel " +
                             "WHERE id_socio = :id";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("plan", editado.Id_Plan);
                    cmd.Parameters.Add("sexo", editado.Id_Sexo);
                    cmd.Parameters.Add("nom", editado.Nombre);
                    cmd.Parameters.Add("ape1", editado.Primer_Apellido);
                    cmd.Parameters.Add("ape2", editado.Segundo_Apellido);
                    cmd.Parameters.Add("tel", editado.Telefono);
                    cmd.Parameters.Add("id", editado.Id_Socio); // Identificador para saber a quién editar
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 4. ELIMINAR (Borra el registro de la base de datos)
        public void Eliminar(int idSocio) // Ahora es 'int' en lugar de 'string'
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM socios WHERE id_socio = :id";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("id", idSocio);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}