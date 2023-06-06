namespace Presentacion.Formularios
{
    partial class FormularioGestorPagos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupPago = new System.Windows.Forms.GroupBox();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pickFechaPago = new System.Windows.Forms.DateTimePicker();
            this.txtIdCuota = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMontoCuota = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupCuotas = new System.Windows.Forms.GroupBox();
            this.tablaCuotas = new System.Windows.Forms.DataGridView();
            this.col_id_cuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_id_prestamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_monto_cuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fecha_vencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_estado_cuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fecha_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdPrestamo = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contador = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colum_id_prestamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nombre_completo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_monto_solicitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fecha_de_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupPago.SuspendLayout();
            this.groupCuotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaCuotas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(835, 527);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupPago);
            this.tabPage1.Controls.Add(this.groupCuotas);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(827, 491);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Registrar pago";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupPago
            // 
            this.groupPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupPago.Controls.Add(this.btnRegistrarPago);
            this.groupPago.Controls.Add(this.label2);
            this.groupPago.Controls.Add(this.pickFechaPago);
            this.groupPago.Controls.Add(this.txtIdCuota);
            this.groupPago.Controls.Add(this.label1);
            this.groupPago.Controls.Add(this.txtMontoCuota);
            this.groupPago.Controls.Add(this.label14);
            this.groupPago.Enabled = false;
            this.groupPago.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.groupPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(42)))), ((int)(((byte)(46)))));
            this.groupPago.Location = new System.Drawing.Point(120, 386);
            this.groupPago.Name = "groupPago";
            this.groupPago.Size = new System.Drawing.Size(587, 83);
            this.groupPago.TabIndex = 46;
            this.groupPago.TabStop = false;
            this.groupPago.Text = "Detalles del pago:";
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(73)))), ((int)(((byte)(89)))));
            this.btnRegistrarPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarPago.FlatAppearance.BorderSize = 0;
            this.btnRegistrarPago.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(123)))), ((int)(((byte)(150)))));
            this.btnRegistrarPago.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(109)))));
            this.btnRegistrarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarPago.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarPago.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarPago.Location = new System.Drawing.Point(454, 27);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(122, 41);
            this.btnRegistrarPago.TabIndex = 8;
            this.btnRegistrarPago.Text = "Registar pago";
            this.btnRegistrarPago.UseVisualStyleBackColor = false;
            this.btnRegistrarPago.Click += new System.EventHandler(this.btnRegistrarPago_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(245, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Seleccione la fecha de pago:";
            // 
            // pickFechaPago
            // 
            this.pickFechaPago.Location = new System.Drawing.Point(248, 45);
            this.pickFechaPago.Name = "pickFechaPago";
            this.pickFechaPago.Size = new System.Drawing.Size(200, 30);
            this.pickFechaPago.TabIndex = 12;
            // 
            // txtIdCuota
            // 
            this.txtIdCuota.BackColor = System.Drawing.SystemColors.Info;
            this.txtIdCuota.Location = new System.Drawing.Point(6, 45);
            this.txtIdCuota.MaxLength = 15;
            this.txtIdCuota.Name = "txtIdCuota";
            this.txtIdCuota.Size = new System.Drawing.Size(115, 30);
            this.txtIdCuota.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Id Cuota:";
            // 
            // txtMontoCuota
            // 
            this.txtMontoCuota.BackColor = System.Drawing.SystemColors.Info;
            this.txtMontoCuota.Location = new System.Drawing.Point(127, 45);
            this.txtMontoCuota.MaxLength = 15;
            this.txtMontoCuota.Name = "txtMontoCuota";
            this.txtMontoCuota.Size = new System.Drawing.Size(115, 30);
            this.txtMontoCuota.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 10F);
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(124, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 23);
            this.label14.TabIndex = 9;
            this.label14.Text = "Monto:";
            // 
            // groupCuotas
            // 
            this.groupCuotas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupCuotas.Controls.Add(this.tablaCuotas);
            this.groupCuotas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupCuotas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(42)))), ((int)(((byte)(46)))));
            this.groupCuotas.Location = new System.Drawing.Point(120, 107);
            this.groupCuotas.Name = "groupCuotas";
            this.groupCuotas.Size = new System.Drawing.Size(587, 273);
            this.groupCuotas.TabIndex = 45;
            this.groupCuotas.TabStop = false;
            this.groupCuotas.Text = "Listado de cuotas";
            // 
            // tablaCuotas
            // 
            this.tablaCuotas.AllowUserToAddRows = false;
            this.tablaCuotas.AllowUserToDeleteRows = false;
            this.tablaCuotas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaCuotas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaCuotas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tablaCuotas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(42)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaCuotas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaCuotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id_cuota,
            this.col_id_prestamo,
            this.col_monto_cuota,
            this.col_fecha_vencimiento,
            this.col_estado_cuota,
            this.col_fecha_pago});
            this.tablaCuotas.Location = new System.Drawing.Point(8, 21);
            this.tablaCuotas.Name = "tablaCuotas";
            this.tablaCuotas.ReadOnly = true;
            this.tablaCuotas.RowHeadersWidth = 20;
            this.tablaCuotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaCuotas.Size = new System.Drawing.Size(572, 245);
            this.tablaCuotas.TabIndex = 2;
            this.tablaCuotas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaCuotas_CellDoubleClick);
            this.tablaCuotas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.tablaCuotas_CellFormatting);
            // 
            // col_id_cuota
            // 
            this.col_id_cuota.HeaderText = "Id Cuota";
            this.col_id_cuota.MinimumWidth = 8;
            this.col_id_cuota.Name = "col_id_cuota";
            this.col_id_cuota.ReadOnly = true;
            // 
            // col_id_prestamo
            // 
            this.col_id_prestamo.HeaderText = "Id Prestamo";
            this.col_id_prestamo.MinimumWidth = 8;
            this.col_id_prestamo.Name = "col_id_prestamo";
            this.col_id_prestamo.ReadOnly = true;
            this.col_id_prestamo.Visible = false;
            // 
            // col_monto_cuota
            // 
            this.col_monto_cuota.HeaderText = "Monto pendiente";
            this.col_monto_cuota.MinimumWidth = 8;
            this.col_monto_cuota.Name = "col_monto_cuota";
            this.col_monto_cuota.ReadOnly = true;
            // 
            // col_fecha_vencimiento
            // 
            this.col_fecha_vencimiento.HeaderText = "Fecha de vencimiento";
            this.col_fecha_vencimiento.MinimumWidth = 8;
            this.col_fecha_vencimiento.Name = "col_fecha_vencimiento";
            this.col_fecha_vencimiento.ReadOnly = true;
            // 
            // col_estado_cuota
            // 
            this.col_estado_cuota.HeaderText = "Estado";
            this.col_estado_cuota.MinimumWidth = 8;
            this.col_estado_cuota.Name = "col_estado_cuota";
            this.col_estado_cuota.ReadOnly = true;
            // 
            // col_fecha_pago
            // 
            this.col_fecha_pago.HeaderText = "Fecha de pago";
            this.col_fecha_pago.MinimumWidth = 8;
            this.col_fecha_pago.Name = "col_fecha_pago";
            this.col_fecha_pago.ReadOnly = true;
            this.col_fecha_pago.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtIdPrestamo);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(120, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 72);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar cuotas por prestamo";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(73)))), ((int)(((byte)(89)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(123)))), ((int)(((byte)(150)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(89)))), ((int)(((byte)(109)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(164, 22);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(73, 38);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "ID del prestamo:";
            // 
            // txtIdPrestamo
            // 
            this.txtIdPrestamo.BackColor = System.Drawing.Color.White;
            this.txtIdPrestamo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.txtIdPrestamo.ForeColor = System.Drawing.Color.Black;
            this.txtIdPrestamo.Location = new System.Drawing.Point(9, 39);
            this.txtIdPrestamo.MaxLength = 15;
            this.txtIdPrestamo.Name = "txtIdPrestamo";
            this.txtIdPrestamo.Size = new System.Drawing.Size(149, 28);
            this.txtIdPrestamo.TabIndex = 6;
            this.txtIdPrestamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdPrestamo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdPrestamo_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.contador);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.tabla);
            this.tabPage2.Controls.Add(this.btnRestaurar);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.txtFiltro);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(827, 491);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Registros";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // contador
            // 
            this.contador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.contador.AutoSize = true;
            this.contador.Location = new System.Drawing.Point(128, 15);
            this.contador.Name = "contador";
            this.contador.Size = new System.Drawing.Size(114, 23);
            this.contador.TabIndex = 354;
            this.contador.Text = "Cargando...";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(192, 24);
            this.label16.TabIndex = 353;
            this.label16.Text = "Prestamos activos:";
            // 
            // tabla
            // 
            this.tabla.AllowUserToAddRows = false;
            this.tabla.AllowUserToDeleteRows = false;
            this.tabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tabla.BackgroundColor = System.Drawing.Color.Silver;
            this.tabla.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(73)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colum_id_prestamo,
            this.col_nombre_completo,
            this.col_monto_solicitado,
            this.col_fecha_de_pago});
            this.tabla.EnableHeadersVisualStyles = false;
            this.tabla.Location = new System.Drawing.Point(6, 36);
            this.tabla.Name = "tabla";
            this.tabla.RowHeadersWidth = 62;
            this.tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla.Size = new System.Drawing.Size(821, 419);
            this.tabla.TabIndex = 352;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.Image = global::Presentacion.Properties.Resources.limpiar;
            this.btnRestaurar.Location = new System.Drawing.Point(797, 6);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnRestaurar.Size = new System.Drawing.Size(24, 24);
            this.btnRestaurar.TabIndex = 351;
            this.btnRestaurar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRestaurar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = global::Presentacion.Properties.Resources.lupa;
            this.button1.Location = new System.Drawing.Point(707, 6);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.button1.Size = new System.Drawing.Size(85, 25);
            this.button1.TabIndex = 350;
            this.button1.Text = "Buscar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.Location = new System.Drawing.Point(552, 7);
            this.txtFiltro.MaxLength = 15;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(150, 30);
            this.txtFiltro.TabIndex = 349;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(815, 418);
            this.dataGridView1.TabIndex = 0;
            // 
            // colum_id_prestamo
            // 
            this.colum_id_prestamo.FillWeight = 113.6364F;
            this.colum_id_prestamo.HeaderText = "ID Prestamo";
            this.colum_id_prestamo.MinimumWidth = 8;
            this.colum_id_prestamo.Name = "colum_id_prestamo";
            // 
            // col_nombre_completo
            // 
            this.col_nombre_completo.FillWeight = 95.45457F;
            this.col_nombre_completo.HeaderText = "Nombre Completo";
            this.col_nombre_completo.MinimumWidth = 8;
            this.col_nombre_completo.Name = "col_nombre_completo";
            // 
            // col_monto_solicitado
            // 
            this.col_monto_solicitado.FillWeight = 95.45457F;
            this.col_monto_solicitado.HeaderText = "Monto Pagado";
            this.col_monto_solicitado.MinimumWidth = 8;
            this.col_monto_solicitado.Name = "col_monto_solicitado";
            // 
            // col_fecha_de_pago
            // 
            this.col_fecha_de_pago.FillWeight = 95.45457F;
            this.col_fecha_de_pago.HeaderText = "Fecha de pago";
            this.col_fecha_de_pago.MinimumWidth = 8;
            this.col_fecha_de_pago.Name = "col_fecha_de_pago";
            // 
            // FormularioGestorPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 551);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormularioGestorPagos";
            this.Text = "FormularioGestorPagos";
            this.Load += new System.EventHandler(this.FormularioGestorPagos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupPago.ResumeLayout(false);
            this.groupPago.PerformLayout();
            this.groupCuotas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablaCuotas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdPrestamo;
        private System.Windows.Forms.GroupBox groupCuotas;
        private System.Windows.Forms.GroupBox groupPago;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMontoCuota;
        private System.Windows.Forms.DataGridView tablaCuotas;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker pickFechaPago;
        private System.Windows.Forms.TextBox txtIdCuota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id_cuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id_prestamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_monto_cuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_vencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_estado_cuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_pago;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.Label contador;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn colum_id_prestamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nombre_completo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_monto_solicitado;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha_de_pago;
    }
}