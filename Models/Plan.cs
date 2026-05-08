using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GYM_NoSql.Models
{
    public class Plan
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        // Llave primaria (NUMBER en Oracle)
        public int Id_Plan { get; set; }

        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        // En Oracle lo definieron como CHAR(1) que guarda '0' o '1'
        // Lo manejamos como string para que C# lo lea sin problemas
        public string Activo { get; set; }
    }
}