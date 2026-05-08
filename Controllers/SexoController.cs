using MongoDB.Driver;
using MongoDB.Bson;
using GYM_NoSql.Data;
using System.Collections.Generic;
using System.Linq;

namespace GYM_NoSql.controllers
{
    public class SexoController : MongoDbContext
    {
        private IMongoCollection<BsonDocument> _sexos;

        public SexoController()
        {
            _sexos = db.GetCollection<BsonDocument>("sexos");
        }

        public List<dynamic> ObtenerTodos()
        {
            var docs = _sexos.Find(new BsonDocument()).ToList();
            return docs.Select(d => new {
                Id_Sexo = d["_id"].AsInt32,
                Descripcion = d["descripcion"].AsString
            }).Cast<dynamic>().ToList();
        }
    }
}