using GYM_NoSql.Data;
using GYM_NoSql.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GYM_NoSql.controllers
{
    public class PlanController : MongoDbContext
    {
        private IMongoCollection<BsonDocument> _planes;

        public PlanController()
        {
            _planes = db.GetCollection<BsonDocument>("planes");
        }

        public List<Plan> ObtenerTodos()
        {
            var docs = _planes.Find(new BsonDocument()).ToList();
            return docs.Select(d => new Plan
            {
                Id_Plan = d["_id"].AsInt32,
                Nombre = d["nombre"].AsString,
                Precio = d.Contains("precio") ? Convert.ToDecimal(d["precio"].ToDouble()) : 0m,
                Activo = d["activo"].AsString
            }).ToList();
        }

        public void Agregar(Plan p)
        {
            // Nota: Como usas _id: int en tu validador, debemos calcular el siguiente ID
            int ultimoId = _planes.Find(new BsonDocument()).SortByDescending(x => x["_id"]).Limit(1).FirstOrDefault()?["_id"].AsInt32 ?? 0;

            var doc = new BsonDocument {
                { "_id", ultimoId + 1 },
                { "nombre", p.Nombre },
                // En el método Agregar:
{ "precio", Convert.ToDouble(p.Precio) },
                { "activo", p.Activo },
                { "duracion_dias", 30 } // Valor por defecto según tu script
            };
            _planes.InsertOne(doc);
        }

        public void Editar(Plan editado)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", editado.Id_Plan);
            var update = Builders<BsonDocument>.Update
                .Set("nombre", editado.Nombre)
                .Set("precio", (double)editado.Precio)
                .Set("activo", editado.Activo);

            _planes.UpdateOne(filter, update);
        }

        public void Eliminar(int idPlan)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", idPlan);
            _planes.DeleteOne(filter);
        }
    }
}