using Datos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace Datos.Repositorios
{
    public class PrestamoRepositorio : IPrestamoRepositorio
    {
        private readonly string connectionString = Conexion.ConexionMaestra.CadenaConexionMaestra;

        public bool InsertarPrestamoConCuotas(Prestamo prestamo, out string mensaje)
        {
            bool resultado = false;
            mensaje = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("InsertarPrestamoConCuotas", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdCliente", prestamo.Cliente.Id);
                    command.Parameters.AddWithValue("@IdEmpleado", prestamo.Empleado.Id);
                    command.Parameters.AddWithValue("@IdFrecuenciaPago", prestamo.FrecuenciaPrestamo.Id);
                    command.Parameters.AddWithValue("@Monto", prestamo.MontoSolicitado);
                    command.Parameters.AddWithValue("@TasaInteres", prestamo.TasaInteres);
                    command.Parameters.AddWithValue("@NumeroCuotas", prestamo.NumeroCuotas);

                    command.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    int resultadoProcedure = Convert.ToInt32(command.Parameters["@Resultado"].Value);
                    mensaje = command.Parameters["@Mensaje"].Value.ToString();

                    if (resultadoProcedure == 1)
                    {
                        resultado = true;
                    }
                }
                catch (Exception ex)
                {
                    mensaje = "Error: " + ex.Message;
                }
            }

            return resultado;
        }

        public bool RegistrarPago(Pago pago, out string mensaje)
        {
            bool resultado = false;
            mensaje = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("RegistrarPago", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdCuota", pago.Cuota.Id);
                    command.Parameters.AddWithValue("@Monto", pago.Monto);
                    command.Parameters.AddWithValue("@FechaPago", pago.FechaPago);

                    command.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    int resultadoProcedure = Convert.ToInt32(command.Parameters["@Resultado"].Value);
                    mensaje = command.Parameters["@Mensaje"].Value.ToString();

                    if (resultadoProcedure == 1)
                    {
                        resultado = true;
                    }
                }
                catch (Exception ex)
                {
                    mensaje = "Error: " + ex.Message;
                }
            }

            return resultado;
        }

        public List<Prestamo> ListarPrestamosActivos()
        {
            List<Prestamo> prestamosActivos = new List<Prestamo>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM VistaPrestamosActivos", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Prestamo prestamo = new Prestamo();
                        prestamo.Id = Convert.ToInt32(reader["IdPrestamo"]);

                        Cliente cliente = new Cliente();
                        cliente.Id = Convert.ToInt32(reader["IdCliente"]);

                        Empleado empleado = new Empleado();
                        empleado.Id = Convert.ToInt32(reader["IdEmpleado"]);

                        FrecuenciaPago frecuenciaPago = new FrecuenciaPago();
                        frecuenciaPago.Id = Convert.ToInt32(reader["IdFrecuenciaPago"]);

                        prestamo.MontoSolicitado = Convert.ToDecimal(reader["MontoSolicitado"]);
                        prestamo.TotalIntereses = Convert.ToDecimal(reader["TotalIntereses"]);
                        prestamo.TotalPagar = Convert.ToDecimal(reader["TotalPagar"]);
                        prestamo.TasaInteres = Convert.ToDecimal(reader["TasaInteres"]);
                        prestamo.NumeroCuotas = Convert.ToInt32(reader["NumeroCuotas"]);
                        prestamo.Estado = reader["Estado"].ToString();
                        prestamo.FechaPrestamo = Convert.ToDateTime(reader["FechaPrestamo"]);
                        prestamo.FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"]);

                        prestamo.Cliente = cliente;
                        prestamo.Empleado = empleado;
                        prestamo.FrecuenciaPrestamo = frecuenciaPago;

                        prestamosActivos.Add(prestamo);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return prestamosActivos;
        }

        public List<Cuota> ObtenerCuotasPorDia(int idPrestamo)
        {
            List<Cuota> cuotas = new List<Cuota>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("ObtenerCuotaDelDia", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdPrestamo", idPrestamo);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Cuota cuota = new Cuota();
                        cuota.Id = Convert.ToInt32(reader["IdCuota"]);

                        Prestamo prestamo = new Prestamo();
                        prestamo.Id = Convert.ToInt32(reader["IdPrestamo"]);

                        cuota.MontoCuota = Convert.ToDecimal(reader["MontoCuota"]);
                        cuota.FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"]);
                        cuota.EstadoCuota = reader["EstadoCuota"].ToString();
                        cuota.FechaPago = reader["FechaPago"] == DBNull.Value ? (DateTime?)null : (DateTime?)reader.GetValue(reader.GetOrdinal("FechaPago"));
                        cuota.Pagada = Convert.ToBoolean(reader["Pagada"]);
                        cuota.Prestamo = prestamo;
                        cuotas.Add(cuota);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return cuotas;
        }
    }
}
