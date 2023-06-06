using Datos.Conexion;
using Datos.Interfaces;
using Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos.Repositorios
{
    public class TipoDocumentoRepositorio : ITipoDocumentoRepositorio
    {
        private readonly string connectionString = Conexion.ConexionMaestra.CadenaConexionMaestra;

        public List<TipoDocumento> Listar()
        {
            List<TipoDocumento> listaTiposDocumento = new List<TipoDocumento>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT IdTipoDocumento, Nombre, Estado FROM VistaTiposDocumentoActivos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TipoDocumento tipoDocumento = new TipoDocumento
                            {
                                Id = (int)reader["IdTipoDocumento"],
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
