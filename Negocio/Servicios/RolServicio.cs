using Datos.Repositorios;
using Entidades;
using System.Collections.Generic;

namespace Negocio.Servicios
{
    public class RolServicio
    {
        private readonly RolRepositorio repositorio = new RolRepositorio();

        public List<Rol> Listar()
        {
            return repositorio.Listar();
        }
    }
}
