using Entidades;
using Negocio.Servicios;
using Presentacion.Reportes.Formularios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion.Formularios
{
    public partial class FormularioGestorPagos : Form
    {
        #region Variables
        private PrestamoServicio prestamoServicio = new PrestamoServicio();
        Pago Pago = new Pago();
        int id = 0;
        #endregion

        #region Constructor
        public FormularioGestorPagos()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void FormularioGestorPagos_Load(object sender, EventArgs e)
        {

        }

        private void txtIdPrestamo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarCampoNumerico(sender, e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdPrestamo.Text))
            {
                MessageBox.Show("Ingrese un ID de préstamo válido.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(txtIdPrestamo.Text);
            ConsultarCuotasPorDia(id);
        }

        private void tablaCuotas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaCuotas.Rows.Count >= 1)
            {
                SeleccionarRegistro();
            }
        }

        private void tablaCuotas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (tablaCuotas.Columns[e.ColumnIndex].Name == "col_estado_cuota") // Verificar que es la columna "col_estado"
            {
                if (e.Value != null)
                {
                    string estado = e.Value.ToString();

                    if (estado == "Pendiente")
                    {
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.DarkOrange;
                    }
                    else if (estado == "Atrasada")
                    {
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.DarkRed;
                    }
                }
            }
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if(txtIdCuota.Text == "")
            {
                MessageBox.Show("Seleccione con doble clic, la cuota que desea pagar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RegistarPago();
        }

        #endregion

        #region Funciones

        private void RegistarPago()
        {
            DateTime fechaPago = pickFechaPago.Value;

            if (fechaPago.Date > DateTime.Today) // Comparar solo las fechas sin tener en cuenta la hora
            {
                MessageBox.Show("La fecha de pago no puede ser superior a la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método sin registrar el pago
            }

            DialogResult result = MessageBox.Show($"¿Desea registrar este pago? (ID CUOTA: {Pago.Cuota.Id})", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string mensaje;
                    bool resultado = prestamoServicio.RegistrarPago(Pago, out mensaje);

                    if (resultado)
                    {
                        LimpiarFormulario();
                        MessageBox.Show($"Pago registrado exitosamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        ReportePago reporteCuotas = new ReportePago(Pago.Cuota.Id);
                        reporteCuotas.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SeleccionarRegistro()
        {
            try
            {
                id = Convert.ToInt32(tablaCuotas.CurrentRow.Cells["col_id_cuota"].Value);

                Pago = new Pago
                {
                    Cuota = new Cuota()
                    {
                        Id = this.id
                    },
                    Monto = Convert.ToDecimal(tablaCuotas.CurrentRow.Cells["col_monto_cuota"].Value),
                    FechaPago = pickFechaPago.Value
                };

                txtIdCuota.Text = Pago.Cuota.Id.ToString();
                txtMontoCuota.Text = Pago.Monto.ToString("C", new CultureInfo("es-CO"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarCampoNumerico(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo solo admite números.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void ConsultarCuotasPorDia(int idPrestamo)
        {
            try
            {
                tablaCuotas.Rows.Clear();

                List<Cuota> cuotas = prestamoServicio.ObtenerCuotasPorDia(idPrestamo);

                bool hayCuotasPendientes = cuotas.Any(c => c.EstadoCuota == "Pendiente");
                bool hayCuotasAtrasadas = cuotas.Any(c => c.EstadoCuota == "Atrasada");

                if (hayCuotasPendientes || hayCuotasAtrasadas)
                {
                    foreach (Cuota cuota in cuotas)
                    {
                        tablaCuotas.Rows.Add(new object[]
                        {
                            cuota.Id,
                            cuota.Prestamo.Id,
                            cuota.MontoCuota,
                            cuota.FechaVencimiento,
                            cuota.EstadoCuota,
                        });
                    }

                    tablaCuotas.ClearSelection();

                    string mensaje = "";

                    if (hayCuotasPendientes && hayCuotasAtrasadas)
                    {
                        mensaje = "Se han encontrado cuotas pendientes por pagar y cuotas atrasadas.";
                    }
                    else if (hayCuotasPendientes)
                    {
                        mensaje = "Se han encontrado cuotas pendientes por pagar.";
                    }
                    else if (hayCuotasAtrasadas)
                    {
                        mensaje = "Se han encontrado cuotas atrasadas.";
                    }

                    MessageBox.Show(mensaje, "Consulta exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupPago.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se encontraron cuotas para el préstamo seleccionado.", "Sin registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtIdPrestamo.Clear();
            groupPago.Enabled = false;
            txtIdCuota.Clear();
            txtMontoCuota.Clear();
            tablaCuotas.DataSource = null;
        }

        #endregion
    }
}