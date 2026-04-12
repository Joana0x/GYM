using GYM_NoSql.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_NoSql.controllers
{
    public class MembresiaController
    {
        private readonly List<Membresia> _membresias = new List<Membresia>();

        public List<Membresia> ObtenerTodos() => _membresias;

        public void Agregar(Membresia m)
        {
            m.Id = Guid.NewGuid().ToString();
            _membresias.Add(m);
        }

        public void Editar(Membresia editada)
        {
            int i = _membresias.FindIndex(m => m.Id == editada.Id);
            if (i >= 0) _membresias[i] = editada;
        }

        public void Eliminar(string id) =>
            _membresias.RemoveAll(m => m.Id == id);
    }
}