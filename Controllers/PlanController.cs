using GYM_NoSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_NoSql.controllers
{
    public class PlanController
    {
        private readonly List<Plan> _planes = new List<Plan>();

        public List<Plan> ObtenerTodos() => _planes;

        public void Agregar(Plan p)
        {
            p.Id = Guid.NewGuid().ToString();
            _planes.Add(p);
        }

        public void Editar(Plan editado)
        {
            int i = _planes.FindIndex(p => p.Id == editado.Id);
            if (i >= 0) _planes[i] = editado;
        }

        public void Eliminar(string id) =>
            _planes.RemoveAll(p => p.Id == id);
    }
}