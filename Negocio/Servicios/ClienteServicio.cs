using Datos.Repositorios;
using Entidades;
using System;
using System.Collections.Generic;

namespace Negocio.Servicios
{
    public class ClienteServicio
    {
        private readonly ClienteRepository repositorio = new ClienteRepository();

        public bool Actualizar(Cliente cliente, out string mensaje)
        {
            if (!ValidarCorreoElectronico(cliente.Persona.CorreoElectronico))
            {
                mensaje = "El correo electrónico no es valido.";
                return false;
            }

            return repositorio.Actualizar(cliente, out mensaje);
        }

        public bool Crear(Cliente cliente, out string mensaje)
        {
            if (!ValidarCorreoElectronico(cliente.Persona.CorreoElectronico))
            {
                mensaje = "El correo electrónico no es valido.";
                return false;
            }

            return repositorio.Crear(cliente, out mensaje);
        }

        public bool Eliminar(int id, out string mensaje)
        {
            return repositorio.Eliminar(id, out mensaje);
        }

        public List<Cliente> Listar()
        {
            return repositorio.Listar();
        }

        public bool ValidarCorreoElectronico(string correoElectronico)
        {
            return repositorio.ValidarCorreoElectronico(correoElectronico);
        }
    }
}
