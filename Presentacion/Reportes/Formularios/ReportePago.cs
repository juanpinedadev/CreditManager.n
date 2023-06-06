using System;
using System.Windows.Forms;

namespace Presentacion.Reportes.Formularios
{
    public partial class ReportePago : Form
    {
        int IdPrestamoIngresado;

        public ReportePago(int idPrestamo)
        {
            IdPrestamoIngresado = idPrestamo;
            InitializeComponent();
        }

        private void ReportePago_Load(object sender, EventArgs e)
        {
            this.obtenerPagoClientePorCuotaTableAdapter.Fill(this.dataSet1.ObtenerPagoClientePorCuota, IdCuota: IdPrestamoIngresado);
            NombrarFormulario($"pago (ID: {IdPrestamoIngresado})");
            this.reportViewer.RefreshReport();
        }

        private void NombrarFormulario(string nombreReporte)
        {
            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Asignar el título con la fecha actual al control Label
            this.Text = $"Reporte de {nombreReporte}: " + fechaActual.ToString("dd/MM/yyyy");
        }
    }
}
