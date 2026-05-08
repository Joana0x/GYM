using MongoDB.Driver;
using MongoDB.Bson;
using GYM_NoSql.Models;
using GYM_NoSql.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace GYM_NoSql.controllers
{
    public class SocioController : MongoDbContext
    {
        private IMongoCollection<BsonDocument> _socios;
        private IMongoCollection<BsonDocument> _planes;
        private IMongoCollection<BsonDocument> _sexos;
        private IMongoCollection<BsonDocument> _pagos;

        public SocioController()
        {
            _socios = db.GetCollection<BsonDocument>("socios");
            _planes = db.GetCollection<BsonDocument>("planes");
            _sexos = db.GetCollection<BsonDocument>("sexos");
            _pagos = db.GetCollection<BsonDocument>("pagos");
        }

        // 1. OBTENER FILTRADO (Simula el JOIN de Oracle)
        public DataTable ObtenerSociosFiltrados(string busqueda, string planFiltro, string estadoFiltro)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID Socio", typeof(int));
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Paterno");
            dt.Columns.Add("Materno");
            dt.Columns.Add("Teléfono");
            dt.Columns.Add("Sexo");
            dt.Columns.Add("Plan");
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Estado");

            // Filtro de búsqueda por texto (Regex)
            var filterBuilder = Builders<BsonDocument>.Filter;
            var filter = filterBuilder.Empty;

            if (!string.IsNullOrEmpty(busqueda))
            {
                var regex = new BsonRegularExpression(new Regex(busqueda, RegexOptions.IgnoreCase));
                filter = filterBuilder.Or(
                    filterBuilder.Regex("nombre", regex),
                    filterBuilder.Regex("primer_apellido", regex),
                    filterBuilder.Regex("segundo_apellido", regex),
                    filterBuilder.Regex("_id", regex)
                );
            }

            // Descargamos colecciones para el cruce en memoria
            var sociosList = _socios.Find(filter).ToList();
            var planesList = _planes.Find(new BsonDocument()).ToList();
            var sexosList = _sexos.Find(new BsonDocument()).ToList();
            var pagosList = _pagos.Find(new BsonDocument()).ToList();

            // JOIN con LINQ
            var query = from s in sociosList
                        join p in planesList on s["id_plan"].AsInt32 equals p["_id"].AsInt32
                        join x in sexosList on s["id_sexo"].AsInt32 equals x["_id"].AsInt32
                        let ultimoPago = pagosList.Where(pg => pg["id_socio"].AsInt32 == s["_id"].AsInt32)
                                                 .OrderByDescending(pg => pg["fecha_pago"])
                                                 .FirstOrDefault()
                        select new
                        {
                            Id = s["_id"].AsInt32,
                            Nom = s["nombre"].AsString,
                            Pat = s["primer_apellido"].AsString,
                            Mat = s.Contains("segundo_apellido") && !s["segundo_apellido"].IsBsonNull ? s["segundo_apellido"].AsString : "",
                            Tel = s.Contains("telefono") && !s["telefono"].IsBsonNull ? s["telefono"].AsString : "",
                            SexoDesc = x["descripcion"].AsString,
                            PlanNom = p["nombre"].AsString,
                            // Busca esta línea en tu SocioController y cámbiala:
                            Precio = p.Contains("precio") ? Convert.ToDecimal(p["precio"].ToDouble()) : 0m,
                            Fecha = s["fecha_registro"].ToLocalTime(),
                            // Cálculo de estado: si el último pago fue hace menos de 30 días
                            EstadoCalc = (ultimoPago != null && ultimoPago["fecha_pago"].ToLocalTime().AddDays(30) >= DateTime.Now) ? "Activo" : "Inactivo"
                        };

            // Filtros adicionales de los ComboBox
            var filtradoFinal = query.AsEnumerable();
            if (planFiltro != "Todos" && !string.IsNullOrEmpty(planFiltro))
                filtradoFinal = filtradoFinal.Where(f => f.PlanNom == planFiltro);

            if (estadoFiltro == "Activos")
                filtradoFinal = filtradoFinal.Where(f => f.EstadoCalc == "Activo");
            else if (estadoFiltro == "Inactivos")
                filtradoFinal = filtradoFinal.Where(f => f.EstadoCalc == "Inactivo");

            foreach (var i in filtradoFinal)
                dt.Rows.Add(i.Id, i.Nom, i.Pat, i.Mat, i.Tel, i.SexoDesc, i.PlanNom, i.Precio, i.Fecha, i.EstadoCalc);

            return dt;
        }

        // 2. AGREGAR (Con autoincremento de ID)
        // 2. AGREGAR (Corregido)
        public void Agregar(Socio s)
        {
            int ultimoId = _socios.Find(new BsonDocument())
                                 .SortByDescending(x => x["_id"])
                                 .Limit(1)
                                 .FirstOrDefault()?["_id"].AsInt32 ?? 0;

            var doc = new BsonDocument {
        { "_id", ultimoId + 1 },
        { "id_plan", s.Id_Plan },
        { "id_sexo", s.Id_Sexo },
        { "nombre", s.Nombre },
        { "primer_apellido", s.Primer_Apellido },
        // Cambiamos el cast de (object) por una asignación directa de BsonValue
        { "segundo_apellido", (BsonValue)s.Segundo_Apellido ?? BsonNull.Value },
        { "telefono", (BsonValue)s.Telefono ?? BsonNull.Value },
        { "fecha_registro", s.Fecha_Registro },
        { "activo", "1" }
    };
            _socios.InsertOne(doc);
        }

        // 3. EDITAR (Corregido)
        public void Editar(Socio s)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", s.Id_Socio);
            var update = Builders<BsonDocument>.Update
                .Set("id_plan", s.Id_Plan)
                .Set("id_sexo", s.Id_Sexo)
                .Set("nombre", s.Nombre)
                .Set("primer_apellido", s.Primer_Apellido)
                // Usamos la misma lógica de conversión explícita
                .Set("segundo_apellido", (BsonValue)s.Segundo_Apellido ?? BsonNull.Value)
                .Set("telefono", (BsonValue)s.Telefono ?? BsonNull.Value)
                .Set("fecha_registro", s.Fecha_Registro);

            _socios.UpdateOne(filter, update);
        }

        // 4. ELIMINAR
        public void Eliminar(int idSocio)
        {
            _socios.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", idSocio));
        }
    }
}