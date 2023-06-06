using Datos.Repositorios;
using Entidades;
using System.Collections.Generic;

namespace Negocio.Servicios
{
    public class EmpleadoServicio
    {
        private readonly EmpleadoRepositorio repositorio = new EmpleadoRepositorio();

        public bool Actualizar(Empleado empleado, out string mensaje)
        {
            if (!ValidarCorreoElectronico(empleado.Persona.CorreoElectronico))
            {
                mensaje = "El correo electrónico no es valido.";
                return false;
            }

            return repositorio.Actualizar(empleado, out mensaje);
        }

        public bool Crear(Empleado empleado, out string mensaje)
        {
            if (!ValidarCorreoElectronico(empleado.Persona.CorreoElectronico))
            {
                mensaje = "El correo electrónico no es valido.";
                return false;
            }

            return repositorio.Crear(empleado, out mensaje);
        }

        public bool Eliminar(int id, out string mensaje)
        {
            return repositorio.Eliminar(id, out mensaje);
        }

        public List<Empleado> Listar()
        {
            return repositorio.Listar();
        }

        public bool ValidarCorreoElectronico(string correoElectronico)
        {
            return repositorio.ValidarCorreoElectronico(correoElectronico);
        }
    }
}
