using Entidades;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.Formularios
{
    public partial class FormularioGestorEmpleados : Form
    {
        #region Variables
        private EmpleadoServicio EmpleadoService = new EmpleadoServicio();
        private TipoDocumentoServicio TipoDocumentoService = new TipoDocumentoServicio();
        private CargoServicio CargoService = new CargoServicio();

        Empleado Empleado = new Empleado();
        Persona Persona = new Persona();
        TipoDocumento TipoDocumento = new TipoDocumento();
        Cargo Cargo = new Cargo();

        int id = 0;
        string nombreEmpleado = string.Empty;
        #endregion

        #region Constructor
        public FormularioGestorEmpleados()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos
        private void FormularioGestorEmpleados_Load(object sender, System.EventArgs e)
        {
            ListarEmpleados();
            ListarTiposDocumento();
            ListarCargos();
        }

        private void tabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarRegistroTabla();
        }

        private void tabla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabla.Rows.Count >= 1)
            {
                ObtenerRegistro();
                tabla.Enabled = false;
            }
        }

        private void tabla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatearDataGridView(sender, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tabla.Enabled = true;
            btnLimpiar.Enabled = true;
            btnReporte.Enabled = true;
            LimpiarFormulario();
            ListarTiposDocumento();
            ListarCargos();
            RestablecerColoresTextBox();
            lblTitutloFormulario.Text = "Crear empleado:";
            btnGuardar.Text = "Guardar";
            id = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Crear_Actualizar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
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

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarCampoNumerico(sender, e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarCampoNumerico(sender, e);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            GenerarReporte(new Reportes.Formularios.ReporteEmpleados());
        }

        #endregion

        #region Funciones

        private void Crear_Actualizar()
        {
            try
            {
                if (id == 0)
                {
                    DialogResult result = MessageBox.Show("¿Desea crear este nuevo empleado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (!ValidarCamposVacios())
                        {
                            return;
                        }

                        Capturar();

                        string mensaje;
                        bool resultado = EmpleadoService.Crear(Empleado, out mensaje);

                        if (resultado)
                        {
                            MessageBox.Show($"Empleado '{Empleado.Persona.PrimerNombre} {Empleado.Persona.PrimerApellido}' creado exitosamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimpiarFormulario();
                            ListarEmpleados();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Desea confirmar esta actualización?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (!ValidarCamposVacios())
                        {
                            return;
                        }

                        Capturar();

                        string mensaje;
                        bool resultado = EmpleadoService.Actualizar(Empleado, out mensaje);

                        if (resultado)
                        {
                            MessageBox.Show($"Empleado '{Empleado.Persona.PrimerNombre} {Empleado.Persona.PrimerApellido}' actualizado exitosamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimpiarFormulario();
                            RestablecerColoresTextBox();
                            ListarEmpleados();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminar()
        {
            try
            {
                if (tabla.Rows.Count < 1)
                {
                    MessageBox.Show("No existen registros para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idEmpleado = Convert.ToInt32(txtIdEmpleado.Text);

                if (idEmpleado != 0)
                {
                    DialogResult dialogo = MessageBox.Show($"¿Está seguro que desea eliminar el empleado '{nombreEmpleado}'?",
                        "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogo == DialogResult.Yes)
                    {
                        Empleado empleadoEliminar = new Empleado()
                        {
                            Id = idEmpleado
                        };

                        string mensaje;
                        bool eliminado = EmpleadoService.Eliminar(empleadoEliminar.Id, out mensaje);

                        if (eliminado)
                        {
                            tabla.Enabled = true;
                            btnLimpiar.Enabled = true;
                            btnReporte.Enabled = true;
                            LimpiarFormulario();
                            ListarTiposDocumento();
                            RestablecerColoresTextBox();
                            ListarEmpleados();
                            lblTitutloFormulario.Text = "Crear empleado:";
                            btnGuardar.Text = "Guardar";
                            id = 0;
                            MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                        empleado.Persona.Direccion
                    });
                }

                tabla.ClearSelection();

                contador.Text = empleados.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListarTiposDocumento()
        {
            try
            {
                List<TipoDocumento> tiposDocumento = TipoDocumentoService.Listar();

                tiposDocumento.Insert(0, new TipoDocumento { Id = 0, Nombre = "Seleccionar" });

                boxTipoDocumento.DataSource = tiposDocumento;
                boxTipoDocumento.DisplayMember = "Nombre";
                boxTipoDocumento.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListarCargos()
        {
            try
            {
                List<Cargo> cargos = CargoService.Listar();

                cargos.Insert(0, new Cargo { Id = 0, Nombre = "Seleccionar" });

                boxCargos.DataSource = cargos;
                boxCargos.DisplayMember = "Nombre";
                boxCargos.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCamposVacios()
        {
            TextBox[] textBoxes = { txtPrimerNombre, txtPrimerApellido, txtNumeroDocumento, txtCorreoElectronico, txtTelefono, txtDireccion };
            ComboBox[] comboBoxes = { boxTipoDocumento, boxCargos };

            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show($"El campo '{textBox.Name.Substring(3)}' está vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Focus();
                    return false;
                }
            }

            foreach (ComboBox comboBox in comboBoxes)
            {
                if (comboBox.SelectedIndex == 0)
                {
                    MessageBox.Show($"Debe seleccionar un valor para el campo '{comboBox.Name.Substring(3)}'.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox.Focus();
                    return false;
                }
            }

            return true;
        }

        private void Capturar()
        {
            TipoDocumento tipoDocumentoSeleccionado = (TipoDocumento)boxTipoDocumento.SelectedItem;
            Cargo cargoSeleccionado = (Cargo)boxCargos.SelectedItem;

            Persona.TipoDocumento = new TipoDocumento { Id = tipoDocumentoSeleccionado.Id };
            Empleado.Cargo = new Cargo() { Id = cargoSeleccionado.Id };

            // Asigno los valores a los atributos del usuario
            Empleado.Id = Convert.ToInt32(txtIdEmpleado.Text);
            Persona.PrimerNombre = txtPrimerNombre.Text;
            Persona.SegundoNombre = txtSegundoNombre.Text;
            Persona.PrimerApellido = txtPrimerApellido.Text;
            Persona.SegundoApellido = txtSegundoApellido.Text;
            Persona.CorreoElectronico = txtCorreoElectronico.Text;
            Persona.Telefono = txtTelefono.Text;
            Persona.NumeroDocumento = txtNumeroDocumento.Text;
            Persona.Direccion = txtDireccion.Text;

            Empleado.Persona = Persona;
        }

        private void LimpiarFormulario()
        {
            txtPrimerNombre.Clear();
            txtSegundoNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            txtNumeroDocumento.Clear();
            txtCorreoElectronico.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            boxTipoDocumento.SelectedIndex = 0;
            boxCargos.SelectedIndex = 0;
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
                        Direccion = tabla.CurrentRow.Cells["col_direccion"].Value?.ToString(),
                    },

                    Cargo = this.Cargo,

                    Estado = Convert.ToBoolean(tabla.CurrentRow.Cells["col_estado"].Value)
                };

                nombreEmpleado = $"{Empleado.Persona.PrimerNombre} {Empleado.Persona.PrimerApellido}";

                txtIdEmpleado.Text = id.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerRegistro()
        {
            if (tabla.Rows.Count < 1)
            {
                MessageBox.Show("No existen registros para actualizar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnGuardar.Text = "Actualizar";
            btnLimpiar.Enabled = false;

            SeleccionarRegistroTabla();

            lblTitutloFormulario.Text = "Actualizar empleado:";

            if (Empleado.Persona != null)
            {
                txtPrimerNombre.Text = Empleado.Persona.PrimerNombre;
                txtSegundoNombre.Text = Empleado.Persona.SegundoNombre;
                txtPrimerApellido.Text = Empleado.Persona.PrimerApellido;
                txtSegundoApellido.Text = Empleado.Persona.SegundoApellido;
                txtNumeroDocumento.Text = Empleado.Persona.NumeroDocumento;
            }

            boxTipoDocumento.DataSource = TipoDocumentoService.Listar();
            boxTipoDocumento.DisplayMember = "Nombre";
            boxTipoDocumento.ValueMember = "Id";
            boxTipoDocumento.SelectedValue = TipoDocumento.Id;


            boxCargos.DataSource = CargoService.Listar();
            boxCargos.DisplayMember = "Nombre";
            boxCargos.ValueMember = "Id";
            boxCargos.SelectedValue = Empleado.Cargo.Id;

            txtCorreoElectronico.Text = Empleado.Persona.CorreoElectronico;
            txtTelefono.Text = Empleado.Persona.Telefono;
            txtDireccion.Text = Empleado.Persona.Direccion;

            // Cambiar el color de fondo de los TextBox al dar clic en el botón
            Color colorAmarilloClaro = Color.FromArgb(255, 255, 200);
            txtPrimerNombre.BackColor = colorAmarilloClaro;
            txtSegundoNombre.BackColor = colorAmarilloClaro;
            txtPrimerApellido.BackColor = colorAmarilloClaro;
            txtSegundoApellido.BackColor = colorAmarilloClaro;
            txtNumeroDocumento.BackColor = colorAmarilloClaro;
            txtCorreoElectronico.BackColor = colorAmarilloClaro;
            txtTelefono.BackColor = colorAmarilloClaro;
            txtDireccion.BackColor = colorAmarilloClaro;
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

        private void ValidarCampoNumerico(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo solo admite números.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void RestablecerColoresTextBox()
        {
            txtPrimerNombre.BackColor = SystemColors.Window;
            txtSegundoNombre.BackColor = SystemColors.Window;
            txtPrimerApellido.BackColor = SystemColors.Window;
            txtSegundoApellido.BackColor = SystemColors.Window;
            txtNumeroDocumento.BackColor = SystemColors.Window;
            txtCorreoElectronico.BackColor = SystemColors.Window;
            txtTelefono.BackColor = SystemColors.Window;
            txtDireccion.BackColor = SystemColors.Window;
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
