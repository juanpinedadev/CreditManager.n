namespace Presentacion.Formularios
{
    partial class FormularioPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioPrincipal));
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.panelLateral = new System.Windows.Forms.Panel();
            this.reportes = new System.Windows.Forms.Button();
            this.usuarios = new System.Windows.Forms.Button();
            this.empleados = new System.Windows.Forms.Button();
            this.clientes = new System.Windows.Forms.Button();
            this.pagos = new System.Windows.Forms.Button();
            this.prestamos = new System.Windows.Forms.Button();
            this.inicio = new System.Windows.Forms.Button();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lblRol = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelBase = new System.Windows.Forms.Panel();
            this.panelLateral.SuspendLayout();
            this.panelInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(934, 30);
            this.panelSuperior.TabIndex = 0;
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelLateral.Controls.Add(this.reportes);
            this.panelLateral.Controls.Add(this.usuarios);
            this.panelLateral.Controls.Add(this.empleados);
            this.panelLateral.Controls.Add(this.clientes);
            this.panelLateral.Controls.Add(this.pagos);
            this.panelLateral.Controls.Add(this.prestamos);
            this.panelLateral.Controls.Add(this.inicio);
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Location = new System.Drawing.Point(0, 30);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(75, 551);
            this.panelLateral.TabIndex = 1;
            // 
            // reportes
            // 
            this.reportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.reportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.reportes.FlatAppearance.BorderSize = 0;
            this.reportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportes.Font = new System.Drawing.Font("Arial", 8F);
            this.reportes.ForeColor = System.Drawing.Color.Black;
            this.reportes.Image = global::Presentacion.Properties.Resources.Reporte;
            this.reportes.Location = new System.Drawing.Point(0, 450);
            this.reportes.Name = "reportes";
            this.reportes.Size = new System.Drawing.Size(75, 75);
            this.reportes.TabIndex = 6;
            this.reportes.Text = "Reportes";
            this.reportes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.reportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.reportes.UseVisualStyleBackColor = false;
            // 
            // usuarios
            // 
            this.usuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.usuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.usuarios.FlatAppearance.BorderSize = 0;
            this.usuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usuarios.Font = new System.Drawing.Font("Arial", 8F);
            this.usuarios.ForeColor = System.Drawing.Color.Black;
            this.usuarios.Image = global::Presentacion.Properties.Resources.usuario;
            this.usuarios.Location = new System.Drawing.Point(0, 375);
            this.usuarios.Name = "usuarios";
            this.usuarios.Size = new System.Drawing.Size(75, 75);
            this.usuarios.TabIndex = 5;
            this.usuarios.Text = "Usuarios";
            this.usuarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.usuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.usuarios.UseVisualStyleBackColor = false;
            this.usuarios.Click += new System.EventHandler(this.usuarios_Click);
            // 
            // empleados
            // 
            this.empleados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.empleados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.empleados.Dock = System.Windows.Forms.DockStyle.Top;
            this.empleados.FlatAppearance.BorderSize = 0;
            this.empleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.empleados.Font = new System.Drawing.Font("Arial", 8F);
            this.empleados.ForeColor = System.Drawing.Color.Black;
            this.empleados.Image = global::Presentacion.Properties.Resources.empleado;
            this.empleados.Location = new System.Drawing.Point(0, 300);
            this.empleados.Name = "empleados";
            this.empleados.Size = new System.Drawing.Size(75, 75);
            this.empleados.TabIndex = 4;
            this.empleados.Text = "Empleados";
            this.empleados.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.empleados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.empleados.UseVisualStyleBackColor = false;
            this.empleados.Click += new System.EventHandler(this.empleados_Click);
            // 
            // clientes
            // 
            this.clientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.clientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.clientes.FlatAppearance.BorderSize = 0;
            this.clientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientes.Font = new System.Drawing.Font("Arial", 8F);
            this.clientes.ForeColor = System.Drawing.Color.Black;
            this.clientes.Image = global::Presentacion.Properties.Resources.cliente;
            this.clientes.Location = new System.Drawing.Point(0, 225);
            this.clientes.Name = "clientes";
            this.clientes.Size = new System.Drawing.Size(75, 75);
            this.clientes.TabIndex = 3;
            this.clientes.Text = "Clientes";
            this.clientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.clientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.clientes.UseVisualStyleBackColor = false;
            this.clientes.Click += new System.EventHandler(this.clientes_Click);
            // 
            // pagos
            // 
            this.pagos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pagos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pagos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pagos.FlatAppearance.BorderSize = 0;
            this.pagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pagos.Font = new System.Drawing.Font("Arial", 8F);
            this.pagos.ForeColor = System.Drawing.Color.Black;
            this.pagos.Image = global::Presentacion.Properties.Resources.pagos;
            this.pagos.Location = new System.Drawing.Point(0, 150);
            this.pagos.Name = "pagos";
            this.pagos.Size = new System.Drawing.Size(75, 75);
            this.pagos.TabIndex = 2;
            this.pagos.Text = "Pagos";
            this.pagos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.pagos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.pagos.UseVisualStyleBackColor = false;
            this.pagos.Click += new System.EventHandler(this.pagos_Click);
            // 
            // prestamos
            // 
            this.prestamos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.prestamos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prestamos.Dock = System.Windows.Forms.DockStyle.Top;
            this.prestamos.FlatAppearance.BorderSize = 0;
            this.prestamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prestamos.Font = new System.Drawing.Font("Arial", 8F);
            this.prestamos.ForeColor = System.Drawing.Color.Black;
            this.prestamos.Image = global::Presentacion.Properties.Resources.prestamo;
            this.prestamos.Location = new System.Drawing.Point(0, 75);
            this.prestamos.Name = "prestamos";
            this.prestamos.Size = new System.Drawing.Size(75, 75);
            this.prestamos.TabIndex = 1;
            this.prestamos.Text = "Prestamos";
            this.prestamos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.prestamos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.prestamos.UseVisualStyleBackColor = false;
            this.prestamos.Click += new System.EventHandler(this.prestamos_Click);
            // 
            // inicio
            // 
            this.inicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.inicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.inicio.FlatAppearance.BorderSize = 0;
            this.inicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inicio.Font = new System.Drawing.Font("Arial", 8F);
            this.inicio.ForeColor = System.Drawing.Color.Black;
            this.inicio.Image = global::Presentacion.Properties.Resources.inicio;
            this.inicio.Location = new System.Drawing.Point(0, 0);
            this.inicio.Name = "inicio";
            this.inicio.Size = new System.Drawing.Size(75, 75);
            this.inicio.TabIndex = 0;
            this.inicio.Text = "Inicio";
            this.inicio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.inicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.inicio.UseVisualStyleBackColor = false;
            this.inicio.Click += new System.EventHandler(this.inicio_Click);
            // 
            // panelInferior
            // 
            this.panelInferior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelInferior.Controls.Add(this.btnCerrarSesion);
            this.panelInferior.Controls.Add(this.lblRol);
            this.panelInferior.Controls.Add(this.label5);
            this.panelInferior.Controls.Add(this.lblNombre);
            this.panelInferior.Controls.Add(this.label3);
            this.panelInferior.Controls.Add(this.lblNombreUsuario);
            this.panelInferior.Controls.Add(this.label2);
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInferior.Location = new System.Drawing.Point(0, 581);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(934, 30);
            this.panelInferior.TabIndex = 2;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(42)))), ((int)(((byte)(46)))));
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(830, 0);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(104, 30);
            this.btnCerrarSesion.TabIndex = 0;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblRol.ForeColor = System.Drawing.Color.Firebrick;
            this.lblRol.Location = new System.Drawing.Point(399, 8);
            this.lblRol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(71, 15);
            this.lblRol.TabIndex = 14;
            this.lblRol.Text = "Cargando...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(373, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Rol:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.Firebrick;
            this.lblNombre.Location = new System.Drawing.Point(242, 8);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(71, 15);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Cargando...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(190, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nombre:";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.Firebrick;
            this.lblNombreUsuario.Location = new System.Drawing.Point(96, 7);
            this.lblNombreUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(71, 15);
            this.lblNombreUsuario.TabIndex = 10;
            this.lblNombreUsuario.Text = "Cargando...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Usuario actual:";
            // 
            // panelBase
            // 
            this.panelBase.BackColor = System.Drawing.Color.White;
            this.panelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBase.Location = new System.Drawing.Point(75, 30);
            this.panelBase.Name = "panelBase";
            this.panelBase.Size = new System.Drawing.Size(859, 551);
            this.panelBase.TabIndex = 3;
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 611);
            this.Controls.Add(this.panelBase);
            this.Controls.Add(this.panelLateral);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.panelInferior);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(950, 650);
            this.Name = "FormularioPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credit Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormularioPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormularioPrincipal_Load);
            this.panelLateral.ResumeLayout(false);
            this.panelInferior.ResumeLayout(false);
            this.panelInferior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Panel panelBase;
        private System.Windows.Forms.Button reportes;
        private System.Windows.Forms.Button usuarios;
        private System.Windows.Forms.Button empleados;
        private System.Windows.Forms.Button clientes;
        private System.Windows.Forms.Button pagos;
        private System.Windows.Forms.Button prestamos;
        private System.Windows.Forms.Button inicio;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}