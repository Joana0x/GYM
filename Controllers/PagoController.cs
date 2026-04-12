using GYM_NoSql.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_NoSql.controllers
{
    public class PagoController
    {
        private readonly List<Pago> _pagos = new List<Pago>();

        public List<Pago> ObtenerTodos() => _pagos;

        public void Agregar(Pago p)
        {
            p.Id = Guid.NewGuid().ToString();
            _pagos.Add(p);
        }

        public void Eliminar(string id) =>
            _pagos.RemoveAll(p => p.Id == id);
    }
}