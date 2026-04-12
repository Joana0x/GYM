namespace GYM_NoSql.Models
{
    public class Socio
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; } = "Activo";
    }
}