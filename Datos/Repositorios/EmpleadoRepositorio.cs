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
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {
        private readonly string connectionString = Conexion.ConexionMaestra.CadenaConexionMaestra;

        public bool Actualizar(Empleado empleado, out string mensaje)
        {
            mensaje = string.Empty;
            bool resultado = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("ActualizarEmpleado", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parámetros de entrada
                        command.Parameters.AddWithValue("@IdEmpleado", empleado.Id);
                        command.Parameters.AddWithValue("@PrimerNombre", empleado.Persona.PrimerNombre);
                        command.Parameters.AddWithValue("@SegundoNombre", empleado.Persona.SegundoNombre);
                        command.Parameters.AddWithValue("@PrimerApellido", empleado.Persona.PrimerApellido);
                        command.Parameters.AddWithValue("@SegundoApellido", empleado.Persona.SegundoApellido);
                        command.Parameters.AddWithValue("@NumeroDocumento", empleado.Persona.NumeroDocumento);
                        command.Parameters.AddWithValue("@CorreoElectronico", empleado.Persona.CorreoElectronico);
                        command.Parameters.AddWithValue("@Telefono", empleado.Persona.Telefono);
                        command.Parameters.AddWithValue("@Direccion", empleado.Persona.Direccion);
                        command.Parameters.AddWithValue("@IdTipoDocumento", empleado.Persona.TipoDocumento.Id);
                        command.Parameters.AddWithValue("@IdCargo", empleado.Cargo.Id);

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
                mensaje = "Error al actualizar el empleado.\nDetalles: " + ex.Message;
            }

            return resultado;
        }

        public bool Crear(Empleado empleado, out string mensaje)
        {
            mensaje = string.Empty;
            bool resultado = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("CrearEmpleado", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PrimerNombre", empleado.Persona.PrimerNombre);
                    command.Parameters.AddWithValue("@SegundoNombre", empleado.Persona.SegundoNombre);
                    command.Parameters.AddWithValue("@PrimerApellido", empleado.Persona.PrimerApellido);
                    command.Parameters.AddWithValue("@SegundoApellido", empleado.Persona.SegundoApellido);
                    command.Parameters.AddWithValue("@NumeroDocumento", empleado.Persona.NumeroDocumento);
                    command.Parameters.AddWithValue("@CorreoElectronico", empleado.Persona.CorreoElectronico);
                    command.Parameters.AddWithValue("@Telefono", empleado.Persona.Telefono);
                    command.Parameters.AddWithValue("@Direccion", empleado.Persona.Direccion);
                    command.Parameters.AddWithValue("@IdCargo", empleado.Cargo.Id);
                    command.Parameters.AddWithValue("@IdTipoDocumento", empleado.Persona.TipoDocumento.Id);
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
                mensaje = "Error al crear el empleado.\nDetalles: " + ex.Message;
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

                    using (SqlCommand command = new SqlCommand("EliminarEmpleado", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parámetro de entrada: IdUsuario
                        command.Parameters.AddWithValue("@IdEmpleado", id);

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

        public List<Empleado> Listar()
        {
            List<Empleado> empleados = new List<Empleado>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM VistaEmpleadosActivos";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Empleado empleado = new Empleado();
                        empleado.Id = Convert.ToInt32(reader["IdEmpleado"]);
                        empleado.Estado = Convert.ToBoolean(reader["Estado"]);
                        empleado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacionEmpleado"]);

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

                        Cargo cargo = new Cargo();
                        cargo.Id = Convert.ToInt32(reader["IdCargo"]);
                        cargo.Nombre = reader["Cargo"].ToString();

                        persona.TipoDocumento = tipoDocumento;
                        empleado.Persona = persona;
                        empleado.Cargo = cargo;

                        empleados.Add(empleado);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    empleados = new List<Empleado>();
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }

            return empleados;
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
