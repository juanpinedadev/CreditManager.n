using Entidades;
using Negocio.Servicios;
using Seguridad.Criptografia;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Formularios
{
    public partial class FormularioLogin : Form
    {
        public FormularioLogin()
        {
            InitializeComponent();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            ValidarCredenciales();
        }

        private void ValidarCredenciales()
        {
            try
            {
                string contraseñaEncryptada = Encryptador.GetSHA256(txtContraseña.Text);

                Usuario usuario = new UsuarioServicio().Listar().Where(u => u.Nombre == txtUsuario.Text && u.Contraseña == contraseñaEncryptada).FirstOrDefault();

                if (txtUsuario.Text == "")
                {
                    MessageBox.Show("El campo del documento está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                }
                else if (txtContraseña.Text == "")
                {
                    MessageBox.Show("El campo de contraseña está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContraseña.Focus();
                }
                else
                {
                    if (usuario != null)
                    {
                        if (usuario.Estado == false)
                        {
                            MessageBox.Show("Este usuario se encuentra Inactivo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            this.Hide();
                            FormularioPrincipal principal = new FormularioPrincipal(usuario);
                            principal.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorrectas, verifique e intentelo nuevamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormularioLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall) { return; }

            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea salir del sistema?",
                "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            e.Cancel = (dialogResult == DialogResult.No);

            if (!e.Cancel) { Application.Exit(); }
        }

        private void FormularioLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}
