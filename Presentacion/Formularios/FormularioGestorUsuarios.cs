using Entidades;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.Formularios
{
    public partial class FormularioGestorUsuarios : Form
    {
        #region Constructor
        public FormularioGestorUsuarios()
        {
            InitializeComponent();
        }
        #endregion

        #region Variables
        private UsuarioServicio UsuarioServicio = new UsuarioServicio();
        private RolServicio RolServicio = new RolServicio();
        private TipoDocumentoServicio TipoDocumentoServicio = new TipoDocumentoServicio();

        Usuario Usuario = new Usuario();
        Persona Persona = new Persona();
        TipoDocumento TipoDocumento = new TipoDocumento();
        Rol Rol = new Rol();

        int id = 0;
        string nombreUsuario = string.Empty;
        #endregion

        #region Eventos
        
        private void FormularioGestorUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
            ListarTiposDocumento();
            ListarRoles();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarDataGridView(tabla, txtFiltro, btnBuscar);
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            txtFiltro.Clear();
            ListarUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            GenerarReporte(new Reportes.Formularios.ReporteUsuarios());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tabla.Enabled = true;
            btnLimpiar.Enabled = true;
            btnReporte.Enabled = true;
            LimpiarFormulario();
            ListarTiposDocumento();
            ListarRoles();
            RestablecerColoresTextBox();
            lblTitutloFormulario.Text = "Crear usuario:";
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarCampoNumerico(sender, e);
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
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
                    DialogResult result = MessageBox.Show("¿Desea crear este nuevo usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (!ValidarCamposVacios())
                        {
                            return;
                        }

                        Capturar();

                        string mensaje;
                        bool resultado = UsuarioServicio.Crear(Usuario, out mensaje);

                        if (resultado)
                        {
                            MessageBox.Show($"Usuario '{Usuario.Persona.PrimerNombre} {Usuario.Persona.PrimerApellido}' creado exitosamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimpiarFormulario();
                            ListarUsuarios();
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
                        bool resultado = UsuarioServicio.Actualizar(Usuario, out mensaje);

                        if (resultado)
                        {
                            MessageBox.Show($"Usuario '{Usuario.Persona.PrimerNombre} {Usuario.Persona.PrimerApellido}' actualizado exitosamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimpiarFormulario();
                            RestablecerColoresTextBox();
                            ListarUsuarios();
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

        private bool ValidarCamposVacios()
        {
            TextBox[] textBoxes = { txtPrimerNombre, txtPrimerApellido, txtNumeroDocumento, txtTelefono, txtDireccion };
            ComboBox[] comboBoxes = { boxTipoDocumento, boxRoles };

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
            Rol rolSeleccionado = (Rol)boxRoles.SelectedItem;

            Persona.TipoDocumento = new TipoDocumento
            {
                Id = tipoDocumentoSeleccionado.Id
            };

            Usuario.Rol = new Rol()
            {
                Id = rolSeleccionado.Id
            };

            // Asigno los valores a los atributos del usuario
            Usuario.Id = Convert.ToInt32(txtIdUsuario.Text);
            Persona.PrimerNombre = txtPrimerNombre.Text;
            Persona.SegundoNombre = txtSegundoNombre.Text;
            Persona.PrimerApellido = txtPrimerApellido.Text;
            Persona.SegundoApellido = txtSegundoApellido.Text;
            Persona.Telefono = txtTelefono.Text;
            Persona.Direccion = txtDireccion.Text;
            Persona.CorreoElectronico = txtCorreoElectronico.Text;
            Persona.NumeroDocumento = txtNumeroDocumento.Text;

            Usuario.Persona = Persona;
            Usuario.Nombre = txtNombreUsuario.Text;
            Usuario.Contraseña = ValidarClave();
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

                int idCliente = Convert.ToInt32(txtIdUsuario.Text);

                if (idCliente != 0)
                {
                    DialogResult dialogo = MessageBox.Show($"¿Está seguro que desea eliminar el usuario '{nombreUsuario}'?",
                        "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogo == DialogResult.Yes)
                    {
                        Usuario usuarioEliminar = new Usuario()
                        {
                            Id = idCliente
                        };

                        string mensaje;
                        bool eliminado = UsuarioServicio.Eliminar(usuarioEliminar.Id, out mensaje);

                        if (eliminado)
                        {
                            tabla.Enabled = true;
                            btnLimpiar.Enabled = true;
                            btnEliminar.Enabled = true;
                            LimpiarFormulario();
                            ListarTiposDocumento();
                            RestablecerColoresTextBox();
                            ListarUsuarios();
                            lblTitutloFormulario.Text = "Crear usuario:";
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

        private void ListarUsuarios()
        {
            try
            {
                tabla.Rows.Clear();

                List<Usuario> usuarios = UsuarioServicio.Listar();

                foreach (Usuario usuario in usuarios)
                {
                    string primerNombre = usuario.Persona.PrimerNombre.Trim();
                    string segundoNombre = usuario.Persona.SegundoNombre.Trim();
                    string primerApellido = usuario.Persona.PrimerApellido.Trim();
                    string segundoApellido = usuario.Persona.SegundoApellido.Trim();

                    string nombreCompleto = string.Join(" ", primerNombre, segundoNombre, primerApellido, segundoApellido).Trim();

                    tabla.Rows.Add(new object[]
                    {
                        usuario.Id,
                        usuario.Persona.Id,
                        nombreCompleto,
                        primerNombre,
                        segundoNombre,
                        primerApellido,
                        segundoApellido,
                        usuario.Persona.NumeroDocumento,
                        usuario.Persona.TipoDocumento.Id,
                        usuario.Persona.TipoDocumento.Nombre,
                        usuario.Rol.Id,
                        usuario.Rol.Nombre,
                        usuario.Persona.CorreoElectronico,
                        usuario.Persona.Telefono,
                        usuario.Persona.Direccion,
                        usuario.Nombre
                    });
                }

                tabla.ClearSelection();

                contador.Text = usuarios.Count.ToString();
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
                List<TipoDocumento> tiposDocumento = TipoDocumentoServicio.Listar();

                // Agrega la opción "Seleccionar"
                tiposDocumento.Insert(0, new TipoDocumento { Id = 0, Nombre = "Seleccionar" });

                // Asigna la lista al ComboBox
                boxTipoDocumento.DataSource = tiposDocumento;
                boxTipoDocumento.DisplayMember = "Nombre";
                boxTipoDocumento.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListarRoles()
        {
            try
            {
                List<Rol> roles = RolServicio.Listar();

                // Agrega la opción "Seleccionar"
                roles.Insert(0, new Rol { Id = 0, Nombre = "Seleccionar" });

                // Asigna la lista al ComboBox
                boxRoles.DataSource = roles;
                boxRoles.DisplayMember = "Nombre";
                boxRoles.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ValidarClave()
        {
            if (txtContraseña.Text != txtConfContraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (txtContraseña.Text.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return txtContraseña.Text;
        }

        private void LimpiarFormulario()
        {
            txtPrimerNombre.Clear();
            txtSegundoNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            txtNumeroDocumento.Clear();
            txtNombreUsuario.Clear();
            txtCorreoElectronico.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtContraseña.Clear();
            txtConfContraseña.Clear();
            boxTipoDocumento.SelectedIndex = 0;
            boxRoles.SelectedIndex = 0;
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

                if (tabla.CurrentRow.Cells["col_id_usuario"].Value == null)
                {
                    MessageBox.Show("El registro seleccionado no contiene un ID de usuario válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                id = Convert.ToInt32(tabla.CurrentRow.Cells["col_id_usuario"].Value);

                TipoDocumento = new TipoDocumento
                {
                    Id = Convert.ToInt32(tabla.CurrentRow.Cells["col_id_tipo_documento"].Value),
                    Nombre = tabla.CurrentRow.Cells["col_tipo_documento"].Value?.ToString(),
                };

                Rol = new Rol
                {
                    Id = Convert.ToInt32(tabla.CurrentRow.Cells["col_id_rol"].Value),
                    Nombre = tabla.CurrentRow.Cells["col_nombre_rol"].Value?.ToString(),
                };

                Usuario = new Usuario
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

                    Rol = Rol,

                    Nombre = tabla.CurrentRow.Cells["col_nombre_usuario"].Value?.ToString(),
                    Estado = Convert.ToBoolean(tabla.CurrentRow.Cells["col_estado"].Value)
                };

                nombreUsuario = $"{Usuario.Persona.PrimerNombre} {Usuario.Persona.PrimerApellido}";

                txtIdUsuario.Text = id.ToString();
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

            lblTitutloFormulario.Text = "Actualizar usuario:";

            if (Usuario.Persona != null)
            {
                txtPrimerNombre.Text = Usuario.Persona.PrimerNombre;
                txtSegundoNombre.Text = Usuario.Persona.SegundoNombre;
                txtPrimerApellido.Text = Usuario.Persona.PrimerApellido;
                txtSegundoApellido.Text = Usuario.Persona.SegundoApellido;
                txtNumeroDocumento.Text = Usuario.Persona.NumeroDocumento;
            }

            boxTipoDocumento.DataSource = TipoDocumentoServicio.Listar();
            boxTipoDocumento.DisplayMember = "Nombre";
            boxTipoDocumento.ValueMember = "Id";
            boxTipoDocumento.SelectedValue = TipoDocumento.Id;


            boxRoles.DataSource = RolServicio.Listar();
            boxRoles.DisplayMember = "Nombre";
            boxRoles.ValueMember = "Id";
            boxRoles.SelectedValue = Usuario.Rol.Id;

            txtCorreoElectronico.Text = Usuario.Persona.CorreoElectronico;
            txtTelefono.Text = Usuario.Persona.Telefono;
            txtDireccion.Text = Usuario.Persona.Direccion;
            txtNombreUsuario.Text = Usuario.Nombre;

            // Cambiar el color de fondo de los TextBox al dar clic en el botón
            Color colorAmarilloClaro = Color.FromArgb(255, 255, 200);
            txtPrimerNombre.BackColor = colorAmarilloClaro;
            txtSegundoNombre.BackColor = colorAmarilloClaro;
            txtPrimerApellido.BackColor = colorAmarilloClaro;
            txtSegundoApellido.BackColor = colorAmarilloClaro;
            txtNumeroDocumento.BackColor = colorAmarilloClaro;
            txtNombreUsuario.BackColor = colorAmarilloClaro;
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
            txtNombreUsuario.BackColor = SystemColors.Window;
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
