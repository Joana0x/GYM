using System;

namespace GYM_NoSql.Models
{
    public class Socio
    {
        // Usamos 'int' porque en Oracle lo definimos como NUMBER
        public int Id_Socio { get; set; }

        // Llaves foráneas para conectar con las otras tablas
        public int Id_Plan { get; set; }
        public int Id_Sexo { get; set; }

        // Datos personales
        public string Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public string Telefono { get; set; }

        // Usamos 'DateTime' porque en Oracle es un DATE
        public DateTime Fecha_Registro { get; set; }
    }
}