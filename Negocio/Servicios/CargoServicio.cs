using Datos.Repositorios;
using Entidades;
using System.Collections.Generic;

namespace Negocio.Servicios
{
    public class CargoServicio
    {
        private readonly CargoRepositorio repositorio = new CargoRepositorio();

        public List<Cargo> Listar()
        {
            return repositorio.Listar();
        }
    }
}
