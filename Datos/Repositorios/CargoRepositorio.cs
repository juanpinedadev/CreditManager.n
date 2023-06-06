using Datos.Conexion;
using Datos.Interfaces;
using Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos.Repositorios
{
    public class CargoRepositorio : ICargoRepositorio
    {
        private readonly string connectionString = Conexion.ConexionMaestra.CadenaConexionMaestra;

        public List<Cargo> Listar()
        {
            List<Cargo> cargos = new List<Cargo>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT IdCargo, Nombre, Estado FROM VistaCargosActivos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cargo tipoDocumento = new Cargo
                            {
                                Id = (int)reader["IdCargo"],
                                Nombre = (string)reader["Nombre"],
                                Estado = (bool)reader["Estado"]
                            };

                            cargos.Add(tipoDocumento);
                        }
                    }
                }
            }

            return cargos;
        }
    }
}
