using System;
using System.Windows.Forms;

namespace Presentacion.Reportes.Formularios
{
    public partial class ReportePrestamosActivos : Form
    {
        public ReportePrestamosActivos()
        {
            InitializeComponent();
        }

        private void ReportePrestamosActivos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.Prestamos' Puede moverla o quitarla según sea necesario.
            this.prestamosTableAdapter.Fill(this.dataSet1.Prestamos);
            NombrarFormulario("prestamos activos");
            this.reportViewer1.RefreshReport();
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
