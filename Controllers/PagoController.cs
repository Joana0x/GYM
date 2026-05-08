using GYM_NoSql.Models;
using GYM_NoSql.Data; // Donde creaste MongoDbContext
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GYM_NoSql.controllers
{
    public class PagoController : MongoDbContext
    {
        private IMongoCollection<BsonDocument> _pagos;
        private IMongoCollection<BsonDocument> _socios;
        private IMongoCollection<BsonDocument> _planes;

        public PagoController()
        {
            _pagos = db.GetCollection<BsonDocument>("pagos");
            _socios = db.GetCollection<BsonDocument>("socios");
            _planes = db.GetCollection<BsonDocument>("planes");
        }

        public void Agregar(Pago p)
        {
            // Calculamos el siguiente ID manual (porque tu validador pide int)
            int ultimoId = _pagos.Find(new BsonDocument()).SortByDescending(x => x["_id"]).Limit(1).FirstOrDefault()?["_id"].AsInt32 ?? 0;

            var doc = new BsonDocument {
                { "_id", ultimoId + 1 },
                { "id_socio", p.Id_Socio },
                { "fecha_pago", p.Fecha_Pago },
                { "monto", (double)p.Monto }
            };
            _pagos.InsertOne(doc);
        }

        public void Eliminar(int idPago)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", idPago);
            _pagos.DeleteOne(filter);
        }

        // Simula el INNER JOIN entre socios y planes
        public DataTable ObtenerSociosConPlan()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id_socio", typeof(int));
            dt.Columns.Add("socio_display");
            dt.Columns.Add("plan_nombre");
            dt.Columns.Add("monto_plan", typeof(decimal));

            var listaSocios = _socios.Find(new BsonDocument()).ToList();
            var listaPlanes = _planes.Find(new BsonDocument()).ToList();

            var query = from s in listaSocios
                        join pl in listaPlanes on s["id_plan"].AsInt32 equals pl["_id"].AsInt32
                        orderby s["_id"].AsInt32
                        select new
                        {
                            IdSocio = s["_id"].AsInt32,
                            Display = $"{s["_id"].AsInt32} - {s["nombre"].AsString} {s["primer_apellido"].AsString}",
                            Plan = pl["nombre"].AsString,
                            // CORRECCIÓN AQUÍ: Usamos ToDouble() para que sea flexible
                            Monto = Convert.ToDecimal(pl["precio"].ToDouble())
                        };

            foreach (var item in query)
                dt.Rows.Add(item.IdSocio, item.Display, item.Plan, item.Monto);

            return dt;
        }

        public decimal ObtenerMontoPorSocio(int idSocio)
        {
            var socio = _socios.Find(Builders<BsonDocument>.Filter.Eq("_id", idSocio)).FirstOrDefault();
            if (socio != null)
            {
                var plan = _planes.Find(Builders<BsonDocument>.Filter.Eq("_id", socio["id_plan"].AsInt32)).FirstOrDefault();
                if (plan != null)
                    // CORRECCIÓN AQUÍ: ToDouble() en lugar de AsDouble
                    return Convert.ToDecimal(plan["precio"].ToDouble());
            }
            return 0;
        }

        public DataTable ObtenerHistorialPagos()
        {
            DataTable dt = new DataTable();
            // Definimos los nombres de las columnas explícitamente
            dt.Columns.Add("id_pago", typeof(int));
            dt.Columns.Add("id_socio", typeof(int));
            dt.Columns.Add("socio");
            dt.Columns.Add("fecha_pago", typeof(DateTime));
            dt.Columns.Add("monto", typeof(decimal));

            var pagos = _pagos.Find(new BsonDocument()).ToList();
            var socios = _socios.Find(new BsonDocument()).ToList();

            var query = from p in pagos
                        join s in socios on p["id_socio"].AsInt32 equals s["_id"].AsInt32
                        select new
                        {
                            IdPago = p["_id"].AsInt32,
                            IdSocio = s["_id"].AsInt32,
                            NombreSocio = $"{s["nombre"].AsString} {s["primer_apellido"].AsString}",
                            Fecha = p["fecha_pago"].ToLocalTime(),
                            Monto = Convert.ToDecimal(p["monto"].ToDouble())
                        };

            foreach (var item in query)
                dt.Rows.Add(item.IdPago, item.IdSocio, item.NombreSocio, item.Fecha, item.Monto);

            return dt;
        }

        public DateTime? ObtenerProximaFechaPermitida(int idSocio)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("id_socio", idSocio);
            var ultimoPago = _pagos.Find(filter).SortByDescending(x => x["fecha_pago"]).FirstOrDefault();

            if (ultimoPago == null)
                return null;

            DateTime ultimaFecha = ultimoPago["fecha_pago"].ToLocalTime();
            return ultimaFecha.AddDays(30);
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