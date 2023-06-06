using System.Collections.Generic;

namespace Datos.Interfaces.Generics
{
    public interface IRepositorioListar<T> where T : class
    {
        List<T> Listar();
    }
}
