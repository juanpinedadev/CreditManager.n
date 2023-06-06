using Datos.Interfaces.Generics;
using Entidades;

namespace Datos.Interfaces
{
    public interface IClienteRepositorio : IRepositorioGenerico<Cliente>, IValidable
    {
    }
}
