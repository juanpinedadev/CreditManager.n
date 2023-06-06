using Datos.Repositorios;
using Entidades;
using System.Collections.Generic;

namespace Negocio.Servicios
{
    public class FrecuenciaPagoServicio
    {
        private readonly FrecuenciaPagoRepositorio repositorio = new FrecuenciaPagoRepositorio();

        public List<FrecuenciaPago> Listar()
        {
            return repositorio.Listar();
        }
    }
}
