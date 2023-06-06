using Datos.Conexion;
using Datos.Interfaces;
using Entidades;
using Seguridad.Criptografia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace Datos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly string connectionString = Conexion.ConexionMaestra.CadenaConexionMaestra;

        public bool Actualizar(Usuario usuario, out string mensaje)
        {
            mensaje = string.Empty;
            bool resultado = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("ActualizarUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parámetros de entrada
                        command.Parameters.AddWithValue("@IdUsuario", usuario.Id);
                        command.Parameters.AddWithValue("@PrimerNombre", usuario.Persona.PrimerNombre);
                        command.Parameters.AddWithValue("@SegundoNombre", usuario.Persona.SegundoNombre);
                        command.Parameters.AddWithValue("@PrimerApellido", usuario.Persona.PrimerApellido);
                        command.Parameters.AddWithValue("@SegundoApellido", usuario.Persona.SegundoApellido);
                        command.Parameters.AddWithValue("@NumeroDocumento", usuario.Persona.NumeroDocumento);
                        command.Parameters.AddWithValue("@CorreoElectronico", usuario.Persona.CorreoElectronico);
                        command.Parameters.AddWithValue("@Telefono", usuario.Persona.Telefono);
                        command.Parameters.AddWithValue("@Direccion", usuario.Persona.Direccion);
                        command.Parameters.AddWithValue("@IdTipoDocumento", usuario.Persona.TipoDocumento.Id);
                        command.Parameters.AddWithValue("@NombreUsuario", usuario.Nombre);
                        command.Parameters.AddWithValue("@Clave", Encryptador.GetSHA256(usuario.Contraseña));
                        command.Parameters.AddWithValue("@IdRol", usuario.Rol.Id);

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
                mensaje = "Error al actualizar el usuario.\nDetalles: " + ex.Message;
            }

            return resultado;
        }

        public bool Crear(Usuario usuario, out string mensaje)
        {
            mensaje = string.Empty;
            bool resultado = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("CrearUsuario", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PrimerNombre", usuario.Persona.PrimerNombre);
                    command.Parameters.AddWithValue("@SegundoNombre", usuario.Persona.SegundoNombre);
                    command.Parameters.AddWithValue("@PrimerApellido", usuario.Persona.PrimerApellido);
                    command.Parameters.AddWithValue("@SegundoApellido", usuario.Persona.SegundoApellido);
                    command.Parameters.AddWithValue("@NumeroDocumento", usuario.Persona.NumeroDocumento);
                    command.Parameters.AddWithValue("@CorreoElectronico", usuario.Persona.CorreoElectronico);
                    command.Parameters.AddWithValue("@Telefono", usuario.Persona.Telefono);
                    command.Parameters.AddWithValue("@Direccion", usuario.Persona.Direccion);
                    command.Parameters.AddWithValue("@IdRol", usuario.Rol.Id);
                    command.Parameters.AddWithValue("@IdTipoDocumento", usuario.Persona.TipoDocumento.Id);
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@Contraseña", Encryptador.GetSHA256(usuario.Contraseña));
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
                mensaje = "Error al crear el usuario.\nDetalles: " + ex.Message;
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

                    using (SqlCommand command = new SqlCommand("EliminarUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parámetro de entrada: IdUsuario
                        command.Parameters.AddWithValue("@IdUsuario", id);
                        command.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                        // Parámetro de salida: Resultado
                        //SqlParameter resultadoParameter = new SqlParameter("@Resultado", SqlDbType.Int);
                        //resultadoParameter.Direction = ParameterDirection.Output;
                        //command.Parameters.Add(resultadoParameter);

                        // Parámetro de salida: Mensaje
                        //SqlParameter mensajeParameter = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500);
                        //mensajeParameter.Direction = ParameterDirection.Output;
                        //command.Parameters.Add(mensajeParameter);

                        // Ejecutar el comando
                        command.ExecuteNonQuery();

                        // Obtener los valores de salida
                        int resultadoValue = Convert.ToInt32(command.Parameters["@Resultado"].Value.ToString());
                        mensaje = Convert.ToString(command.Parameters["@Mensaje"].Value);

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

        public List<Usuario> Listar()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM VistaUsuariosActivos";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(reader["IdUsuario"]);
                        usuario.Nombre = reader["NombreUsuario"].ToString();
                        usuario.Contraseña = reader["Contraseña"].ToString();
                        usuario.Estado = Convert.ToBoolean(reader["Estado"]);
                        usuario.FechaCreacion = Convert.ToDateTime(reader["FechaCreacionUsuario"]);

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
                        persona.FechaCreacion = Convert.ToDateTime(reader["FechaCreacionPersona"]);

                        TipoDocumento tipoDocumento = new TipoDocumento();
                        tipoDocumento.Id = Convert.ToInt32(reader["IdTipoDocumento"]);
                        tipoDocumento.Nombre = reader["TipoDocumento"].ToString();

                        Rol rol = new Rol();
                        rol.Id = Convert.ToInt32(reader["IdRol"]);
                        rol.Nombre = reader["Rol"].ToString();

                        persona.TipoDocumento = tipoDocumento;
                        usuario.Persona = persona;
                        usuario.Rol = rol;

                        usuarios.Add(usuario);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    usuarios = new List<Usuario>();
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }

            return usuarios;
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
