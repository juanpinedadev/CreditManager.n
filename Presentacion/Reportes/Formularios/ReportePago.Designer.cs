namespace Presentacion.Reportes.Formularios
{
    partial class ReportePago
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportePago));
            this.obtenerPagoClientePorCuotaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Presentacion.Reportes.DataSet.DataSet1();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.obtenerPagoClientePorCuotaTableAdapter = new Presentacion.Reportes.DataSet.DataSet1TableAdapters.ObtenerPagoClientePorCuotaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerPagoClientePorCuotaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // obtenerPagoClientePorCuotaBindingSource
            // 
            this.obtenerPagoClientePorCuotaBindingSource.DataMember = "ObtenerPagoClientePorCuota";
            this.obtenerPagoClientePorCuotaBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer
            // 
            this.reportViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.obtenerPagoClientePorCuotaBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "Presentacion.Reportes.Informes.InformePago.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(389, 511);
            this.reportViewer.TabIndex = 0;
            // 
            // obtenerPagoClientePorCuotaTableAdapter
            // 
            this.obtenerPagoClientePorCuotaTableAdapter.ClearBeforeFill = true;
            // 
            // ReportePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 511);
            this.Controls.Add(this.reportViewer);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(405, 600);
            this.MinimumSize = new System.Drawing.Size(405, 550);
            this.Name = "ReportePago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ReportePago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.obtenerPagoClientePorCuotaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource obtenerPagoClientePorCuotaBindingSource;
        private DataSet.DataSet1 dataSet1;
        private DataSet.DataSet1TableAdapters.ObtenerPagoClientePorCuotaTableAdapter obtenerPagoClientePorCuotaTableAdapter;
    }
}