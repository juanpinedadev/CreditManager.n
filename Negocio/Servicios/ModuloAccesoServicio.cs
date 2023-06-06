using Datos.Repositorios;
using Entidades;
using System.Collections.Generic;

namespace Negocio.Servicios
{
    public class ModuloAccesoServicio
    {
        private readonly ModuloAccesoRepositorio repositorio = new ModuloAccesoRepositorio();

        public List<ModuloAcceso> ListarModulosActivosPorIdUsuario(int id)
        {
            return repositorio.ListarModulosActivosPorIdUsuario(id);
        }
    }
}
