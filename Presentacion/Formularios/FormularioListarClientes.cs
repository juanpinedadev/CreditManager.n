using Entidades;
using Negocio.Servicios;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Presentacion.Formularios
{
    public partial class FormularioListarClientes : Form
    {
        #region Variables
        private ClienteServicio ClienteService = new ClienteServicio();
        public TipoDocumento tipoDocumento = new TipoDocumento();
        public Cliente cliente = new Cliente();
        public Persona persona = new Persona();
        int id = 0;
        #endregion

        #region Constructor
        public FormularioListarClientes()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        
        private void FormularioListarClientes_Load(object sender, EventArgs e)
        {
            ListarClientes();
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
            ListarClientes();
        }

        #endregion

        #region Funciones
        
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

                if (tabla.CurrentRow.Cells["col_id_cliente"].Value == null)
                {
                    MessageBox.Show("El registro seleccionado no contiene un ID de cliente válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                id = Convert.ToInt32(tabla.CurrentRow.Cells["col_id_cliente"].Value);

                tipoDocumento = new TipoDocumento
                {
                    Id = Convert.ToInt32(tabla.CurrentRow.Cells["col_id_tipo_documento"].Value),
                    Nombre = tabla.CurrentRow.Cells["col_tipo_documento"].Value?.ToString(),
                };

                cliente = new Cliente
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

                        TipoDocumento = tipoDocumento,

                        CorreoElectronico = tabla.CurrentRow.Cells["col_correo_electronico"].Value?.ToString(),
                        Telefono = tabla.CurrentRow.Cells["col_telefono"].Value?.ToString(),
                    },

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
