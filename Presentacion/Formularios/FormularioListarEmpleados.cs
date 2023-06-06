using Entidades;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.Formularios
{
    public partial class FormularioListarEmpleados : Form
    {
        #region Variables
        private EmpleadoServicio EmpleadoService = new EmpleadoServicio();
        private TipoDocumentoServicio TipoDocumentoService = new TipoDocumentoServicio();
        private CargoServicio CargoService = new CargoServicio();

        public Empleado Empleado = new Empleado();
        public Persona Persona = new Persona();
        TipoDocumento TipoDocumento = new TipoDocumento();
        Cargo Cargo = new Cargo();

        int id = 0;
        #endregion

        #region Constructor
        public FormularioListarEmpleados()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void FormularioListarEmpleados_Load(object sender, EventArgs e)
        {
            ListarEmpleados();
        }

        private void tabla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarRegistroTabla();
        }

        private void tabla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                e.CellStyle.BackColor = Color.FromArgb(235, 241, 240); // Verde claro para renglones pares
            }
            else
            {
                e.CellStyle.BackColor = Color.FromArgb(215, 227, 226); // Verde más claro para renglones impares
            }

            // Si detecta que algún campo está vacío, le asigna un mensaje y cambia el color de fuente
            if (e.Value == null || string.IsNullOrEmpty(e.Value.ToString().Trim()))
            {
                e.Value = "No ingresado";
                e.CellStyle.ForeColor = Color.Gray;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarDataGridView(tabla, txtFiltro, btnBuscar);
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            txtFiltro.Clear();
            ListarEmpleados();
        }

        #endregion

        #region Funciones

        private void ListarEmpleados()
        {
            try
            {
                tabla.Rows.Clear();

                List<Empleado> empleados = EmpleadoService.Listar();

                foreach (Empleado empleado in empleados)
                {
                    string primerNombre = empleado.Persona.PrimerNombre.Trim();
                    string segundoNombre = empleado.Persona.SegundoNombre.Trim();
                    string primerApellido = empleado.Persona.PrimerApellido.Trim();
                    string segundoApellido = empleado.Persona.SegundoApellido.Trim();

                    string nombreCompleto = string.Join(" ", primerNombre, segundoNombre, primerApellido, segundoApellido).Trim();

                    tabla.Rows.Add(new object[]
                    {
                        empleado.Id,
                        empleado.Persona.Id,
                        nombreCompleto,
                        primerNombre,
                        segundoNombre,
                        primerApellido,
                        segundoApellido,
                        empleado.Persona.NumeroDocumento,
                        empleado.Persona.TipoDocumento.Id,
                        empleado.Persona.TipoDocumento.Nombre,
                        empleado.Cargo.Id,
                        empleado.Cargo.Nombre,
                        empleado.Persona.CorreoElectronico,
                        empleado.Persona.Telefono,
                    });
                }

                tabla.ClearSelection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarRegistroTabla()
        {
            try
            {
                if (tabla.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un registro.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tabla.CurrentRow.Cells["col_id_empleado"].Value == null)
                {
                    MessageBox.Show("El registro seleccionado no contiene un ID de empleado válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                id = Convert.ToInt32(tabla.CurrentRow.Cells["col_id_empleado"].Value);

                TipoDocumento = new TipoDocumento
                {
                    Id = Convert.ToInt32(tabla.CurrentRow.Cells["col_id_tipo_documento"].Value),
                    Nombre = tabla.CurrentRow.Cells["col_tipo_documento"].Value?.ToString(),
                };

                Cargo = new Cargo
                {
                    Id = Convert.ToInt32(tabla.CurrentRow.Cells["col_id_cargo"].Value),
                    Nombre = tabla.CurrentRow.Cells["col_nombre_cargo"].Value?.ToString(),
                };

                Empleado = new Empleado
                {
                    Id = this.id,

                    Persona = new Persona
                    {
                        Id = Convert.ToInt32(tabla.CurrentRow.Cells["col_id_persona"].Value),
                        PrimerNombre = tabla.CurrentRow.Cells["col_primer_nombre"].Value?.ToString(),
                        SegundoNombre = tabla.CurrentRow.Cells["col_segundo_nombre"].Value?.ToString(),
                        PrimerApellido = tabla.CurrentRow.Cells["col_primer_apellido"].Value?.ToString(),
                        SegundoApellido = tabla.CurrentRow.Cells["col_segundo_apellido"].Value?.ToString(),
                        NumeroDocumento = tabla.CurrentRow.Cells["col_numero_documento"].Value?.ToString(),

                        TipoDocumento = this.TipoDocumento,

                        CorreoElectronico = tabla.CurrentRow.Cells["col_correo_electronico"].Value?.ToString(),
                        Telefono = tabla.CurrentRow.Cells["col_telefono"].Value?.ToString(),
                    },

                    Cargo = this.Cargo,

                    Estado = Convert.ToBoolean(tabla.CurrentRow.Cells["col_estado"].Value)
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarDataGridView(DataGridView dataGridView, TextBox textBox, Button buscarButton)
        {
            buscarButton.Click += (sender, e) =>
            {
                string filtro = textBox.Text; // Obtener el texto del TextBox

                // Iterar sobre las filas del DataGridView y ocultar aquellas que no cumplan con el filtro
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    bool coincide = false;

                    // Iterar sobre las celdas de cada fila y verificar si alguna coincide con el filtro
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            coincide = true;
                            break;
                        }
                    }

                    // Mostrar u ocultar la fila según si coincide con el filtro
                    row.Visible = coincide;
                }
            };
        }

        #endregion
    }
}
