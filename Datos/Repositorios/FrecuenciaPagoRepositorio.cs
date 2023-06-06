using Datos.Interfaces;
using Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos.Repositorios
{
    public class FrecuenciaPagoRepositorio : IFrecuenciaPagoRepositorio
    {
        private readonly string connectionString = Conexion.ConexionMaestra.CadenaConexionMaestra;

        public List<FrecuenciaPago> Listar()
        {
            List<FrecuenciaPago> listaTiposDocumento = new List<FrecuenciaPago>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT IdFrecuenciaPago, Nombre, Estado FROM VistaFrecuenciasPagosActivos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FrecuenciaPago tipoDocumento = new FrecuenciaPago
                            {
                                Id = (int)reader["IdFrecuenciaPago"],
                                Nombre = (string)reader["Nombre"],
                                Estado = (bool)reader["Estado"]
                            };

                            listaTiposDocumento.Add(tipoDocumento);
                        }
                    }
                }
            }

            return listaTiposDocumento;
        }
    }
}
