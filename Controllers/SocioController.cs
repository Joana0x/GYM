using GYM_NoSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GYM_NoSql.controllers
{
    public class SocioController
    {
        private readonly List<Socio> _socios = new List<Socio>();

        public List<Socio> ObtenerTodos() => _socios;

        public void Agregar(Socio s)
        {
            s.Id = Guid.NewGuid().ToString();
            _socios.Add(s);
        }

        public void Editar(Socio editado)
        {
            int i = _socios.FindIndex(s => s.Id == editado.Id);
            if (i >= 0) _socios[i] = editado;
        }

        public void Eliminar(string id) =>
            _socios.RemoveAll(s => s.Id == id);
    }
}