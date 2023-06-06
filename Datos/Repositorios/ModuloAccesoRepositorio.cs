using Datos.Conexion;
using Datos.Interfaces;
using Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos.Repositorios
{
    public class ModuloAccesoRepositorio : IModuloAccesoRepositorio
    {
        private readonly string connectionString = Conexion.ConexionMaestra.CadenaConexionMaestra;

        public List<ModuloAcceso> ListarModulosActivosPorIdUsuario(int id)
        {
            List<ModuloAcceso> modulosAcceso = new List<ModuloAcceso>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM ObtenerModulosUsuarioActivos(@IdUsuario)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rol rol = new Rol()
                            {
                                Id = (int)reader["IdRol"]
                            };

                            ModuloAcceso moduloAcceso = new ModuloAcceso
                            {
                                Nombre = (string)reader["Nombre"]
                            };

                            modulosAcceso.Add(moduloAcceso);
                        }
                    }
                }
            }

            return modulosAcceso;
        }
    }
}
