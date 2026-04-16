using GYM_NoSql.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace GYM_NoSql.controllers
{
    public class PagoController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        public List<Pago> ObtenerTodos()
        {
            List<Pago> listaPagos = new List<Pago>();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT p.id_pago, p.id_socio, p.fecha_pago, p.monto
                    FROM pagos p
                    ORDER BY p.id_pago DESC";

                OracleCommand cmd = new OracleCommand(sql, conn);

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

        public void Agregar(Pago p)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

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

        public void Eliminar(int idPago)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string sql = "DELETE FROM pagos WHERE id_pago = :id";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("id", idPago);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // NUEVO: trae socios con su plan y monto
        public DataTable ObtenerSociosConPlan()
        {
            DataTable dt = new DataTable();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT 
    s.id_socio,
    (TO_CHAR(s.id_socio) || ' - ' || s.nombre || ' ' || s.primer_apellido) AS socio_display,
    p.nombre AS plan_nombre,
    p.precio AS monto_plan
FROM socios s
INNER JOIN planes p ON s.id_plan = p.id_plan
ORDER BY s.id_socio";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        // NUEVO: trae el monto del plan del socio seleccionado
        public decimal ObtenerMontoPorSocio(int idSocio)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT p.precio
                    FROM socios s
                    INNER JOIN planes p ON s.id_plan = p.id_plan
                    WHERE s.id_socio = :idSocio";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("idSocio", idSocio);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                        return Convert.ToDecimal(resultado);

                    return 0;
                }
            }
        }

        // OPCIONAL: para mostrar nombre del socio en la tabla
        public DataTable ObtenerHistorialPagos()
        {
            DataTable dt = new DataTable();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        p.id_pago,
                        p.id_socio,
                        (s.nombre || ' ' || s.primer_apellido) AS socio,
                        p.fecha_pago,
                        p.monto
                    FROM pagos p
                    INNER JOIN socios s ON p.id_socio = s.id_socio
                    ORDER BY p.id_pago DESC";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public DateTime? ObtenerProximaFechaPermitida(int idSocio)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string sql = @"
            SELECT MAX(fecha_pago) AS ultima_fecha_pago
            FROM pagos
            WHERE id_socio = :idSocio";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("idSocio", idSocio);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado == null || resultado == DBNull.Value)
                        return null;

                    DateTime ultimaFechaPago = Convert.ToDateTime(resultado);
                    return ultimaFechaPago.AddDays(30);
                }
            }
        }

        public bool PuedeRegistrarPago(int idSocio, DateTime fechaIntento, out DateTime? proximaFechaPermitida)
        {
            proximaFechaPermitida = ObtenerProximaFechaPermitida(idSocio);

            if (proximaFechaPermitida == null)
                return true;

            return fechaIntento.Date >= proximaFechaPermitida.Value.Date;
        }


    }
}