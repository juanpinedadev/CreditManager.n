using Entidades;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Formularios
{
    public partial class FormularioPrincipal : Form
    {
        #region Variables
        public static Usuario usuarioActual;
        public ModuloAccesoServicio ModuloAccesoService = new ModuloAccesoServicio();
        #endregion

        #region Constructor
        public FormularioPrincipal(Usuario usuario)
        {
            usuarioActual = usuario;
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void FormularioPrincipal_Load(object sender, System.EventArgs e)
        {
            ValidadControles();
            CargarDatosUsuario();
            AbrirModulo(new FormularioInicio(), inicio);
        }

        private void usuarios_Click(object sender, System.EventArgs e)
        {
            AbrirModulo(new FormularioGestorUsuarios(), usuarios);
        }

        private void empleados_Click(object sender, System.EventArgs e)
        {
            AbrirModulo(new FormularioGestorEmpleados(), empleados);
        }

        private void clientes_Click(object sender, System.EventArgs e)
        {
            AbrirModulo(new FormularioGestorClientes(), clientes);
        }

        private void inicio_Click(object sender, EventArgs e)
        {
            AbrirModulo(new FormularioInicio(), inicio);
        }

        private void prestamos_Click(object sender, EventArgs e)
        {
            AbrirModulo(new FormularioGestorPrestamos(), prestamos);
        }

        private void pagos_Click(object sender, EventArgs e)
        {
            AbrirModulo(new FormularioGestorPagos(), pagos);
        }

        private void FormularioPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall) { return; }

            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea salir del sistema?",
                "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            e.Cancel = (dialogResult == DialogResult.No);

            if (!e.Cancel) { Application.Exit(); }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿Desea cerrar el sesión?",
                    "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogo == DialogResult.No) { }
            else
            {
                this.Hide();
                FormularioLogin Login = new FormularioLogin();
                Login.Show();
            }
        }

        #endregion

        #region Funciones

        private void ValidadControles()
        {
            List<ModuloAcceso> modulosAcceso = ModuloAccesoService.ListarModulosActivosPorIdUsuario(usuarioActual.Id);

            //Recorremos los elementos del menú lateral
            foreach (var elemento in panelLateral.Controls)
            {
                //Si el elemento del menú lateral es un botón entonces ejecuta el bloque de codigo
                if (elemento is Button boton)
                {
                    bool encontrado = modulosAcceso.Any(m => m.Nombre == boton.Name);
                    if (encontrado) { boton.Visible = true; }
                    else { boton.Visible = false; }
                }
            }
        }

        private void CambiarEstadoBotonesPrincipales(bool state, Button button)
        {
            List<Button> buttons = new List<Button> { inicio, prestamos, pagos, clientes, empleados, usuarios, reportes };

            if (buttons.Contains(button))
            {
                button.Enabled = !state;

                foreach (Button btn in buttons)
                {
                    if (btn != button)
                    {
                        btn.Enabled = state;
                    }
                }
            }
        }

        private void AbrirNuevoFormulario(Form modulo)
        {
            panelBase.Controls.Clear();
            modulo.TopLevel = false;
            modulo.Dock = DockStyle.Fill;
            panelBase.Controls.Add(modulo);
            panelBase.Tag = modulo;
            modulo.Show();
            panelBase.BringToFront();
        }

        private void AbrirModulo(Form panel, Button botonModulo)
        {
            CambiarEstadoBotonesPrincipales(true, botonModulo);
            AbrirNuevoFormulario(panel);
        }

        private void CargarDatosUsuario()
        {
            try
            {
                lblNombreUsuario.Text = usuarioActual.Nombre;
                lblNombre.Text = $"{usuarioActual.Persona.PrimerNombre} {usuarioActual.Persona.PrimerApellido}";
                lblRol.Text = usuarioActual.Rol.Nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
