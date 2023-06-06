using Entidades;
using System.Collections.Generic;

namespace Datos.Interfaces
{
    public interface IModuloAccesoRepositorio
    {
        List<ModuloAcceso> ListarModulosActivosPorIdUsuario(int id);
    }
}
