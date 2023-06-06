using Datos.Repositorios;
using Entidades;
using System.Collections.Generic;

namespace Negocio.Servicios
{
    public class TipoDocumentoServicio 
    {
        private readonly TipoDocumentoRepositorio repositorio = new TipoDocumentoRepositorio();

        public List<TipoDocumento> Listar()
        {
            return repositorio.Listar();
        }
    }
}
