using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_NoSql.models
{
    public class Membresia
    {
        public string Id { get; set; }
        public string SocioId { get; set; }
        public string PlanId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } = "Activa";
    }
}
