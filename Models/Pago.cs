using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_NoSql.models
{
    public class Pago
    {
        public string Id { get; set; }
        public string MembresiaId { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Metodo { get; set; }
    }
}
