using Datos.Conexion;
using Datos.Interfaces;
using Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos.Repositorios
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly string connectionString = Conexion.ConexionMaestra.CadenaConexionMaestra;

        public List<Rol> Listar()
        {
            List<Rol> roles = new List<Rol>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT IdRol, Nombre, Estado FROM VistaRolesActivos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rol rol = new Rol
                            {
                                Id = (int)reader["IdRol"],
                                Nombre = (string)reader["Nombre"],
                                Estado = (bool)reader["Estado"]
                            };

                            roles.Add(rol);
                        }
                    }
                }
            }

            return roles;
        }
    }
}
