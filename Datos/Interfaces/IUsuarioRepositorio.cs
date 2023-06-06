using Datos.Interfaces.Generics;
using Entidades;

namespace Datos.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorioGenerico<Usuario>, IValidable
    { 
    }
}
