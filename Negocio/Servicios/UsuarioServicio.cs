using Datos.Repositorios;
using Entidades;
using System.Collections.Generic;

namespace Negocio.Servicios
{
    public class UsuarioServicio
    {
        private readonly UsuarioRepositorio repositorio = new UsuarioRepositorio();

        public bool Actualizar(Usuario usuario, out string mensaje)
        {
            if (!ValidarCorreoElectronico(usuario.Persona.CorreoElectronico))
            {
                mensaje = "El correo electrónico no es valido.";
                return false;
            }

            return repositorio.Actualizar(usuario, out mensaje);
        }

        public bool Crear(Usuario usuario, out string mensaje)
        {
            if (!ValidarCorreoElectronico(usuario.Persona.CorreoElectronico))
            {
                mensaje = "El correo electrónico no es valido.";
                return false;
            }

            return repositorio.Crear(usuario, out mensaje);
        }

        public bool Eliminar(int id, out string mensaje)
        {
            return repositorio.Eliminar(id, out mensaje);
        }

        public List<Usuario> Listar()
        {
            return repositorio.Listar();
        }

        public bool ValidarCorreoElectronico(string correoElectronico)
        {
            return repositorio.ValidarCorreoElectronico(correoElectronico);
        }
    }
}
