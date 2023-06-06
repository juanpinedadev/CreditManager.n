using Entidades;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.Formularios
{
    public partial class FormularioGestorClientes : Form
    {
        #region Variables
        private ClienteServicio ClienteService = new ClienteServicio();
        private TipoDocumentoServicio TipoDocumentoService = new TipoDocumentoServicio();

        Cliente Cliente = new Cliente();
        Persona Persona = new Persona();
        TipoDocumento TipoDocumento = new TipoDocumento();
        int id = 0;
        string nombreCliente = string.Empty;
        #endregion

        #region Constructor
        public FormularioGestorClientes()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos
        private void FormularioGestorClientes_Load(object sender, System.EventArgs e)
        {
            ListarClientes();
            ListarTiposDocumento();
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            tabla.Enabled = true;
            btnLimpiar.Enabled = true;
            btnReporte.Enabled = true;
            LimpiarFormulario();
            ListarTiposDocumento();
            RestablecerColoresTextBox();
            lblTitutloFormulario.Text = "Crear cliente:";
            btnGuardar.Text = "Guardar";
            id = 0;
        }

        private void btnLimpiar_Click(object sender, System.EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            Crear_Actualizar();
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            Eliminar();
        }

        private void btnReporte_Click(object sender, System.EventArgs e)
        {
            GenerarReporte(new Reportes.Formularios.ReporteClientes());
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            FiltrarDataGridView(tabla, txtFiltro, btnBuscar);
        }

        private void btnRestaurar_Click(object sender, System.EventArgs e)
        {
            txtFiltro.Clear();
            ListarClientes();
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

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarCampoNumerico(sender, e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarCampoNumerico(sender, e);
        }

        #endregion

        #region Funciones
        private void Crear_Actualizar()
        {
            try
            {
                if (id == 0)
                {
                    DialogResult result = MessageBox.Show("¿Desea crear este nuevo cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (!ValidarCamposVacios())
                        {
                            return;
                        }

                        Capturar();

                        string mensaje;
                        bool resultado = ClienteService.Crear(Cliente, out mensaje);

                        if (resultado)
                        {
                            MessageBox.Show($"Cliente '{Cliente.Persona.PrimerNombre} {Cliente.Persona.PrimerApellido}' creado exitosamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimpiarFormulario();
                            ListarClientes();
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
                        bool resultado = ClienteService.Actualizar(Cliente, out mensaje);

                        if (resultado)
                        {
                            MessageBox.Show($"Cliente '{Cliente.Persona.PrimerNombre} {Cliente.Persona.PrimerApellido}' actualizado exitosamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimpiarFormulario();
                            RestablecerColoresTextBox();
                            ListarClientes();
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

                int idEmpleado = Convert.ToInt32(txtIdCliente.Text);

                if (idEmpleado != 0)
                {
                    DialogResult dialogo = MessageBox.Show($"¿Está seguro que desea eliminar el cliente '{nombreCliente}'?",
                        "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogo == DialogResult.Yes)
                    {
                        Cliente empleadoEliminar = new Cliente()
                        {
                            Id = idEmpleado
                        };

                        string mensaje;
                        bool eliminado = ClienteService.Eliminar(empleadoEliminar.Id, out mensaje);

                        if (eliminado)
                        {
                            tabla.Enabled = true;
                            btnLimpiar.Enabled = true;
                            btnReporte.Enabled = true;
                            LimpiarFormulario();
                            ListarTiposDocumento();
                            RestablecerColoresTextBox();
                            ListarClientes();
                            lblTitutloFormulario.Text = "Crear cliente:";
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

        private void ListarClientes()
        {
            try
            {
                tabla.Rows.Clear();

                List<Cliente> clientes = ClienteService.Listar();

                foreach (Cliente cliente in clientes)
                {
                    string primerNombre = cliente.Persona.PrimerNombre.Trim();
                    string segundoNombre = cliente.Persona.SegundoNombre.Trim();
                    string primerApellido = cliente.Persona.PrimerApellido.Trim();
                    string segundoApellido = cliente.Persona.SegundoApellido.Trim();

                    string nombreCompleto = string.Join(" ", primerNombre, segundoNombre, primerApellido, segundoApellido).Trim();

                    tabla.Rows.Add(new object[]
                    {
                        cliente.Id,
                        cliente.Persona.Id,
                        nombreCompleto,
                        primerNombre,
                        segundoNombre,
                        primerApellido,
                        segundoApellido,
                        cliente.Persona.NumeroDocumento,
                        cliente.Persona.TipoDocumento.Id,
                        cliente.Persona.TipoDocumento.Nombre,
                        cliente.Persona.CorreoElectronico,
                        cliente.Persona.Telefono,
                        cliente.Persona.Direccion
                    });
                }

                tabla.ClearSelection();

                contador.Text = clientes.Count.ToString();
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

        private bool ValidarCamposVacios()
        {
            TextBox[] textBoxes = { txtPrimerNombre, txtPrimerApellido, txtNumeroDocumento, txtCorreoElectronico, txtTelefono, txtDireccion };
            ComboBox[] comboBoxes = { boxTipoDocumento };

            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show($"El campo '{textBox.Name.Substring(3)}' está vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Focus();
                    return false;
                }
            }

            //foreach (ComboBox comboBox in comboBoxes)
            //{
            //    if (comboBox.SelectedIndex == 0)
            //    {
            //        MessageBox.Show($"Debe seleccionar un valor para el campo '{comboBox.Name.Substring(3)}'.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        comboBox.Focus();
            //        return false;
            //    }
            //}

            return true;
        }

        private void Capturar()
        {
            TipoDocumento tipoDocumentoSeleccionado = (TipoDocumento)boxTipoDocumento.SelectedItem;

            Persona.TipoDocumento = new TipoDocumento { Id = tipoDocumentoSeleccionado.Id };

            // Asigno los valores a los atributos del usuario
            Cliente.Id = Convert.ToInt32(txtIdCliente.Text);
            Persona.PrimerNombre = txtPrimerNombre.Text;
            Persona.SegundoNombre = txtSegundoNombre.Text;
            Persona.PrimerApellido = txtPrimerApellido.Text;
            Persona.SegundoApellido = txtSegundoApellido.Text;
            Persona.CorreoElectronico = txtCorreoElectronico.Text;
            Persona.Telefono = txtTelefono.Text;
            Persona.Direccion = txtDireccion.Text;
            Persona.NumeroDocumento = txtNumeroDocumento.Text;

            Cliente.Persona = Persona;
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

                if (tabla.CurrentRow.Cells["col_id_cliente"].Value == null)
                {
                    MessageBox.Show("El registro seleccionado no contiene un ID de cliente válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                id = Convert.ToInt32(tabla.CurrentRow.Cells["col_id_cliente"].Value);

                TipoDocumento = new TipoDocumento
                {
                    Id = Convert.ToInt32(tabla.CurrentRow.Cells["col_id_tipo_documento"].Value),
                    Nombre = tabla.CurrentRow.Cells["col_tipo_documento"].Value?.ToString(),
                };

                Cliente = new Cliente
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

                    Estado = Convert.ToBoolean(tabla.CurrentRow.Cells["col_estado"].Value)
                };

                nombreCliente = $"{Cliente.Persona.PrimerNombre} {Cliente.Persona.PrimerApellido}";

                txtIdCliente.Text = id.ToString();
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

            lblTitutloFormulario.Text = "Actualizar cliente:";

            if (Cliente.Persona != null)
            {
                txtPrimerNombre.Text = Cliente.Persona.PrimerNombre;
                txtSegundoNombre.Text = Cliente.Persona.SegundoNombre;
                txtPrimerApellido.Text = Cliente.Persona.PrimerApellido;
                txtSegundoApellido.Text = Cliente.Persona.SegundoApellido;
                txtNumeroDocumento.Text = Cliente.Persona.NumeroDocumento;
            }

            boxTipoDocumento.DataSource = TipoDocumentoService.Listar();
            boxTipoDocumento.DisplayMember = "Nombre";
            boxTipoDocumento.ValueMember = "Id";
            boxTipoDocumento.SelectedValue = TipoDocumento.Id;

            txtCorreoElectronico.Text = Cliente.Persona.CorreoElectronico;
            txtTelefono.Text = Cliente.Persona.Telefono;
            txtDireccion.Text = Cliente.Persona.Direccion;

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
