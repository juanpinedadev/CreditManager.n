using Datos.Interfaces.Generics;
using Entidades;

namespace Datos.Interfaces
{
    public interface IEmpleadoRepositorio : IRepositorioGenerico<Empleado>, IValidable
    {
    }
}
