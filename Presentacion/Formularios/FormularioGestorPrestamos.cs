using Entidades;
using Negocio.Servicios;
using Presentacion.Reportes.Formularios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Presentacion.Formularios
{
    public partial class FormularioGestorPrestamos : Form
    {
        #region Variable
        
        FrecuenciaPagoServicio frecuenciaPagoServicio = new FrecuenciaPagoServicio();
        PrestamoServicio PrestamoServicio = new PrestamoServicio();
        Cliente clienteSolicitante = new Cliente();
        Empleado empleadoAsignado = new Empleado();
        
        #endregion

        #region Constructor
        public FormularioGestorPrestamos()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        
        private void btnAsignarCliente_Click(object sender, EventArgs e)
        {
            ConsultarCliente();
        }

        private void btnAsignarEmpleado_Click(object sender, EventArgs e)
        {
            ConsultarEmpleado();
        }

        private void FormularioGestorPrestamos_Load(object sender, EventArgs e)
        {
            ListarFrecuenciasPagos();
            ListarPrestamosActivos();
            txtFechaPrestamo.Text = DateTime.Now.ToShortDateString();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            CalcularPrestamo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CrearPrestamo();
        }

        private void tabla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearDataGridView(sender, e);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            GenerarReporte(new ReportePrestamosActivos());
        }

        #endregion

        #region Funciones

        private void CalcularPrestamo()
        {
            // Verificar que los campos no estén vacíos
            if (string.IsNullOrEmpty(txtMontoPrestamo.Text) || numNumeroCuotas.Value == 0 || boxFrecuenciaPago.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener los valores ingresados por el usuario
            decimal montoPrestamo = decimal.Parse(txtMontoPrestamo.Text);
            int numeroCuotas = (int)numNumeroCuotas.Value;
            decimal tasaInteres = (decimal)txtTasInteres.Value;
            FrecuenciaPago frecuenciaPago = (FrecuenciaPago)boxFrecuenciaPago.SelectedItem;

            // Convertir la tasa de interés a decimal
            decimal tasaInteresDecimal = tasaInteres / 100;

            // Calcular el valor total a pagar en intereses
            decimal totalIntereses = montoPrestamo * tasaInteresDecimal;

            // Calcular el total a pagar del préstamo
            decimal totalPrestamo = montoPrestamo + totalIntereses;

            // Calcular el valor a pagar por cuota
            decimal valorCuota = totalPrestamo / numeroCuotas;

            // Limpiar la tabla de cuotas
            tablaCuotas.Rows.Clear();

            // Calcular y agregar las cuotas a la tabla
            DateTime fechaPago = DateTime.Now;
            for (int i = 1; i <= numeroCuotas; i++)
            {
                // Calcular la fecha de vencimiento de la cuota
                DateTime fechaVencimiento;
                switch (frecuenciaPago.Nombre)
                {
                    case "Diario":
                        fechaVencimiento = fechaPago.AddDays(1);
                        break;
                    case "Semanal":
                        fechaVencimiento = fechaPago.AddDays(7);
                        break;
                    case "Quincenal":
                        fechaVencimiento = fechaPago.AddDays(15);
                        break;
                    default:
                        fechaVencimiento = fechaPago.AddDays(30);
                        break;
                }

                // Agregar la cuota a la tabla
                tablaCuotas.Rows.Add(i, valorCuota.ToString("C", new CultureInfo("es-CO")),
                    "Pendiente", fechaVencimiento.ToString("dd/MM/yyyy"));

                // Actualizar la fecha de pago para la siguiente cuota
                fechaPago = fechaVencimiento;
            }

            // Mostrar los valores en los TextBox
            txtTotalIntereses.Text = totalIntereses.ToString("C", new CultureInfo("es-CO")); ;
            txtValorCuota.Text = valorCuota.ToString("C", new CultureInfo("es-CO")); ;
            txtTotalPrestamo.Text = totalPrestamo.ToString("C", new CultureInfo("es-CO")); ;
        }

        private void CrearPrestamo()
        {
            FrecuenciaPago frecuenciaPago = (FrecuenciaPago)boxFrecuenciaPago.SelectedItem;
            decimal monto = Convert.ToDecimal(txtMontoPrestamo.Text);
            decimal tasaInteres = (decimal)txtTasInteres.Value;
            int numeroCuotas = (int)numNumeroCuotas.Value;

            Prestamo prestamo = new Prestamo()
            {
                Cliente = new Cliente() { Id = clienteSolicitante.Id },
                Empleado = new Empleado() { Id = empleadoAsignado.Id },
                FrecuenciaPrestamo = new FrecuenciaPago() { Id = frecuenciaPago.Id },
                MontoSolicitado = monto,
                TasaInteres = tasaInteres,
                NumeroCuotas = numeroCuotas
            };

            DialogResult result = MessageBox.Show("¿Desea crear este nuevo prestamo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string mensaje;
                bool resultado = PrestamoServicio.InsertarPrestamoConCuotas(prestamo, out mensaje);

                if (resultado)
                {
                    MessageBox.Show($"Prestamo creado exitosamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //LimpiarFormulario();
                    //ListarClientes();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ListarPrestamosActivos()
        {
            try
            {
                tabla.Rows.Clear();

                List<Prestamo> prestamos = PrestamoServicio.ListarPrestamosActivos();

                foreach (Prestamo prestamo in prestamos)
                {
                    // Convertir los valores a pesos colombianos y formato porcentaje
                    string montoSolicitado = prestamo.MontoSolicitado.ToString("C", new CultureInfo("es-CO"));
                    string totalIntereses = prestamo.TotalIntereses.ToString("C", new CultureInfo("es-CO"));
                    string totalPagar = prestamo.TotalPagar.ToString("C", new CultureInfo("es-CO"));
                    string tasaInteres = prestamo.TasaInteres.ToString() + "%";

                    tabla.Rows.Add(new object[]
                    {
                prestamo.Id,
                prestamo.FrecuenciaPrestamo.Id,
                prestamo.Cliente.Id,
                prestamo.Empleado.Id,
                tasaInteres,
                montoSolicitado,
                totalIntereses,
                totalPagar,
                prestamo.NumeroCuotas,
                prestamo.Estado,
                prestamo.FechaPrestamo,
                prestamo.FechaVencimiento
                    });
                }

                tabla.ClearSelection();

                contador.Text = prestamos.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListarFrecuenciasPagos()
        {
            try
            {
                List<FrecuenciaPago> frecuenciasPagos = frecuenciaPagoServicio.Listar();

                frecuenciasPagos.Insert(0, new FrecuenciaPago { Id = 0, Nombre = "Seleccionar" });

                boxFrecuenciaPago.DataSource = frecuenciasPagos;
                boxFrecuenciaPago.DisplayMember = "Nombre";
                boxFrecuenciaPago.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConsultarCliente()
        {
            try
            {
                FormularioListarClientes listarClientes = new FormularioListarClientes();

                var result = listarClientes.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string primerNombre = listarClientes.cliente.Persona.PrimerNombre.Trim();
                    string segundoNombre = listarClientes.cliente.Persona.SegundoNombre.Trim();
                    string primerApellido = listarClientes.cliente.Persona.PrimerApellido.Trim();
                    string segundoApellido = listarClientes.cliente.Persona.SegundoApellido.Trim();

                    string nombreCompletoCliente = string.Join(" ", primerNombre, segundoNombre, primerApellido, segundoApellido).Trim();

                    clienteSolicitante.Id = listarClientes.cliente.Id;
                    txtNombreCompletoCliente.Text = nombreCompletoCliente;
                    txtNumeroDocumentoCliente.Text = listarClientes.cliente.Persona.NumeroDocumento;
                    txtTipoDocumentoCliente.Text = listarClientes.cliente.Persona.TipoDocumento.Nombre;

                    HabilitarGrupos(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConsultarEmpleado()
        {
            try
            {
                FormularioListarEmpleados listarEmpleados = new FormularioListarEmpleados();

                var result = listarEmpleados.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string primerNombre = listarEmpleados.Empleado.Persona.PrimerNombre.Trim();
                    string segundoNombre = listarEmpleados.Empleado.Persona.SegundoNombre.Trim();
                    string primerApellido = listarEmpleados.Empleado.Persona.PrimerApellido.Trim();
                    string segundoApellido = listarEmpleados.Empleado.Persona.SegundoApellido.Trim();

                    string nombreCompletoEmpleado = string.Join(" ", primerNombre, segundoNombre, primerApellido, segundoApellido).Trim();

                    empleadoAsignado.Id = listarEmpleados.Empleado.Id;
                    txtNombreCompletoEmpleado.Text = nombreCompletoEmpleado;
                    txtNumeroDocumentoEmpleado.Text = listarEmpleados.Empleado.Persona.NumeroDocumento;
                    txtTipoDocumentoEmpleado.Text = listarEmpleados.Empleado.Persona.TipoDocumento.Nombre;
                    txtCargoEmpleado.Text = listarEmpleados.Empleado.Cargo.Nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HabilitarGrupos(bool estado)
        {
            groupCobrador.Enabled = estado;
            groupPrestamo.Enabled = estado;
            groupCuotas.Enabled = estado;
            groupResultado.Enabled = estado;
        }

        private void FormatearDataGridView(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 0) { e.CellStyle.BackColor = Color.FromArgb(239, 247, 255); }
            else { e.CellStyle.BackColor = Color.FromArgb(221, 235, 247); }

            if (e.Value == null || string.IsNullOrEmpty(e.Value.ToString().Trim()))
            {
                e.Value = "No ingresado";
                e.CellStyle.ForeColor = Color.Gray;
            }

            int ultimaColumnaVisible = (sender as DataGridView).Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index;

            if (e.ColumnIndex == ultimaColumnaVisible)
            {
                e.CellStyle.ForeColor = Color.FromArgb(1, 46, 64);
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }
        }

        private void GenerarReporte(Form formulario)
        {
            if (tabla.Rows.Count <= 0)
            {
                MessageBox.Show("No se encontraron registros de usuarios para generar el reporte.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                formulario.ShowDialog();
            }
        }

        #endregion

    }
}