using Negocio.Servicios;
using System.Windows.Forms;

namespace Presentacion.Formularios
{
    public partial class FormularioInicio : Form
    {
        #region Variables
        private PrestamoServicio prestamoServicio = new PrestamoServicio();
        private EmpleadoServicio empleadoService = new EmpleadoServicio();
        private ClienteServicio clienteService = new ClienteServicio();
        #endregion

        #region Constructor
        public FormularioInicio()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos

        private void FormularioInicio_Load(object sender, System.EventArgs e)
        {
            CargarContadores();
        }
        #endregion

        #region Funciones

        private void CargarContadores()
        {
            contadorPrestamos.Text = prestamoServicio.ListarPrestamosActivos().Count.ToString();
            contadorEmpleados.Text = empleadoService.Listar().Count.ToString();
            contadorClientes.Text = clienteService.Listar().Count.ToString();
        }

        #endregion
    }
}
