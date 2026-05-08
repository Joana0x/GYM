using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GYM_NoSql.Models
{
    public class Pago
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        // Llave primaria (NUMBER en Oracle)
        public int Id_Pago { get; set; }

        // Llave foránea: ahora conecta directamente con el Socio (ya no con Membresia)
        public int Id_Socio { get; set; }

        // Datos del pago
        public DateTime Fecha_Pago { get; set; }
        public decimal Monto { get; set; }
    }
}