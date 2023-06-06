using Datos.Conexion;
using Datos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace Datos.Repositorios
{
    public class ClienteRepository : IClienteRepositorio
    {
        private readonly string connectionString = Conexion.ConexionMaestra.CadenaConexionMaestra;

        public bool Actualizar(Cliente cliente, out string mensaje)
        {
            mensaje = string.Empty;
            bool resultado = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("ActualizarCliente", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parámetros de entrada
                        command.Parameters.AddWithValue("@IdCliente", cliente.Id);
                        command.Parameters.AddWithValue("@PrimerNombre", cliente.Persona.PrimerNombre);
                        command.Parameters.AddWithValue("@SegundoNombre", cliente.Persona.SegundoNombre);
                        command.Parameters.AddWithValue("@PrimerApellido", cliente.Persona.PrimerApellido);
                        command.Parameters.AddWithValue("@SegundoApellido", cliente.Persona.SegundoApellido);
                        command.Parameters.AddWithValue("@NumeroDocumento", cliente.Persona.NumeroDocumento);
                        command.Parameters.AddWithValue("@CorreoElectronico", cliente.Persona.CorreoElectronico);
                        command.Parameters.AddWithValue("@Telefono", cliente.Persona.Telefono);
                        command.Parameters.AddWithValue("@Direccion", cliente.Persona.Direccion);
                        command.Parameters.AddWithValue("@IdTipoDocumento", cliente.Persona.TipoDocumento.Id);

                        // Parámetros de salida
                        command.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        int resultadoSP = Convert.ToInt32(command.Parameters["@Resultado"].Value);
                        mensaje = Convert.ToString(command.Parameters["@Mensaje"].Value);

                        resultado = resultadoSP > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar el cliente.\nDetalles: " + ex.Message;
            }

            return resultado;
        }

        public bool Crear(Cliente cliente, out string mensaje)
        {
            mensaje = string.Empty;
            bool resultado = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("CrearCliente", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PrimerNombre", cliente.Persona.PrimerNombre);
                    command.Parameters.AddWithValue("@SegundoNombre", cliente.Persona.SegundoNombre);
                    command.Parameters.AddWithValue("@PrimerApellido", cliente.Persona.PrimerApellido);
                    command.Parameters.AddWithValue("@SegundoApellido", cliente.Persona.SegundoApellido);
                    command.Parameters.AddWithValue("@NumeroDocumento", cliente.Persona.NumeroDocumento);
                    command.Parameters.AddWithValue("@CorreoElectronico", cliente.Persona.CorreoElectronico);
                    command.Parameters.AddWithValue("@Telefono", cliente.Persona.Telefono);
                    command.Parameters.AddWithValue("@Direccion", cliente.Persona.Direccion);
                    command.Parameters.AddWithValue("@IdTipoDocumento", cliente.Persona.TipoDocumento.Id);
                    command.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    int resultadoSP = Convert.ToInt32(command.Parameters["@Resultado"].Value);
                    mensaje = Convert.ToString(command.Parameters["@Mensaje"].Value);

                    resultado = resultadoSP > 0;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al crear el cliente.\nDetalles: " + ex.Message;
            }

            return resultado;
        }

        public bool Eliminar(int id, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("EliminarCliente", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parámetro de entrada: IdUsuario
                        command.Parameters.AddWithValue("@IdCliente", id);

                        // Parámetro de salida: Resultado
                        SqlParameter resultadoParameter = new SqlParameter("@Resultado", SqlDbType.Int);
                        resultadoParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultadoParameter);

                        // Parámetro de salida: Mensaje
                        SqlParameter mensajeParameter = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500);
                        mensajeParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(mensajeParameter);

                        // Ejecutar el comando
                        command.ExecuteNonQuery();

                        // Obtener los valores de salida
                        int resultadoValue = Convert.ToInt32(resultadoParameter.Value);
                        mensaje = Convert.ToString(mensajeParameter.Value);

                        // Verificar el resultado
                        resultado = resultadoValue == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return resultado;
        }

        public List<Cliente> Listar()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM VistaClientesActivos";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.Id = Convert.ToInt32(reader["IdCliente"]);
                        cliente.Estado = Convert.ToBoolean(reader["Estado"]);

                        Persona persona = new Persona();
                        persona.Id = Convert.ToInt32(reader["IdPersona"]);
                        persona.PrimerNombre = reader["PrimerNombre"].ToString();
                        persona.SegundoNombre = reader["SegundoNombre"].ToString();
                        persona.PrimerApellido = reader["PrimerApellido"].ToString();
                        persona.SegundoApellido = reader["SegundoApellido"].ToString();
                        persona.NumeroDocumento = reader["NumeroDocumento"].ToString();
                        persona.CorreoElectronico = reader["CorreoElectronico"].ToString();
                        persona.Telefono = reader["Telefono"].ToString();
                        persona.Direccion = reader["Direccion"].ToString();
                        TipoDocumento tipoDocumento = new TipoDocumento();
                        tipoDocumento.Id = Convert.ToInt32(reader["IdTipoDocumento"]);
                        tipoDocumento.Nombre = reader["TipoDocumento"].ToString();

                        persona.TipoDocumento = tipoDocumento;
                        cliente.Persona = persona;

                        clientes.Add(cliente);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    clientes = new List<Cliente>();
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }

            return clientes;
        }

        public bool ValidarCorreoElectronico(string correoElectronico)
        {
            try
            {
                var addr = new MailAddress(correoElectronico);
                return addr.Address == correoElectronico;
            }
            catch
            {
                return false;
            }
        }
    }
}
