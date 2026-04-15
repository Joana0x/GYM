using GYM_NoSql.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client; // Para conectarnos a Oracle
using System.Configuration;            // Para leer el App.config

namespace GYM_NoSql.controllers
{
    public class PagoController
    {
        // Jalamos la cadena de conexión
        private string connectionString = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        // 1. LEER (Trae el historial real de pagos desde Oracle)
        public List<Pago> ObtenerTodos()
        {
            List<Pago> listaPagos = new List<Pago>();
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("SELECT id_pago, id_socio, fecha_pago, monto FROM pagos", conn);

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaPagos.Add(new Pago
                        {
                            Id_Pago = Convert.ToInt32(reader["id_pago"]),
                            Id_Socio = Convert.ToInt32(reader["id_socio"]),
                            Fecha_Pago = Convert.ToDateTime(reader["fecha_pago"]),
                            Monto = Convert.ToDecimal(reader["monto"])
                        });
                    }
                }
            }
            return listaPagos;
        }

        // 2. CREAR (Registra el pago directo en la base de datos)
        public void Agregar(Pago p)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                // Oracle genera el id_pago automáticamente
                string sql = "INSERT INTO pagos (id_socio, fecha_pago, monto) VALUES (:idSocio, :fecha, :monto)";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("idSocio", p.Id_Socio);
                    cmd.Parameters.Add("fecha", p.Fecha_Pago);
                    cmd.Parameters.Add("monto", p.Monto);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 3. ELIMINAR (Borra de verdad el registro)
        public void Eliminar(int idPago) // Aquí está la variable correcta
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM pagos WHERE id_pago = :id";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("id", idPago); // <--- ¡Aquí estaba el error! Ya dice idPago
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}