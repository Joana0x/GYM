namespace GYM_NoSql.Views
{
    partial class FormMembresias
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.dgvMembresias = new System.Windows.Forms.DataGridView();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.lblIdSocio = new System.Windows.Forms.Label();
            this.lblIdPlan = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblActiva = new System.Windows.Forms.Label();
            this.chkActiva = new System.Windows.Forms.CheckBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresias)).BeginInit();
            this.pnlDerecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(73)))));
            this.pnlTop.Controls.Add(this.btnRegresar);
            this.pnlTop.Controls.Add(this.lblTitulo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1080, 55);
            this.pnlTop.TabIndex = 0;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Transparent;
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.FlatAppearance.BorderSize = 0;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Location = new System.Drawing.Point(8, 10);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(45, 35);
            this.btnRegresar.TabIndex = 0;
            this.btnRegresar.Text = "←";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(60, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 40);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Gestión de Membresías";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBuscar
            // 
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.Location = new System.Drawing.Point(10, 65);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(60, 20);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(72, 62);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(200, 34);
            this.txtBuscar.TabIndex = 2;
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(285, 65);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(55, 20);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstado.Items.AddRange(new object[] {
            "Todos",
            "Activas",
            "Inactivas"});
            this.cmbEstado.Location = new System.Drawing.Point(343, 62);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(130, 36);
            this.cmbEstado.TabIndex = 4;
            // 
            // dgvMembresias
            // 
            this.dgvMembresias.AllowUserToAddRows = false;
            this.dgvMembresias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMembresias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembresias.BackgroundColor = System.Drawing.Color.White;
            this.dgvMembresias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMembresias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMembresias.ColumnHeadersHeight = 34;
            this.dgvMembresias.EnableHeadersVisualStyles = false;
            this.dgvMembresias.Location = new System.Drawing.Point(10, 100);
            this.dgvMembresias.Name = "dgvMembresias";
            this.dgvMembresias.ReadOnly = true;
            this.dgvMembresias.RowHeadersWidth = 62;
            this.dgvMembresias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembresias.Size = new System.Drawing.Size(750, 480);
            this.dgvMembresias.TabIndex = 5;
            this.dgvMembresias.SelectionChanged += new System.EventHandler(this.dgvMembresias_SelectionChanged);
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDerecha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlDerecha.Controls.Add(this.comboBox2);
            this.pnlDerecha.Controls.Add(this.comboBox1);
            this.pnlDerecha.Controls.Add(this.lblIdSocio);
            this.pnlDerecha.Controls.Add(this.lblIdPlan);
            this.pnlDerecha.Controls.Add(this.lblFechaInicio);
            this.pnlDerecha.Controls.Add(this.dtpFechaInicio);
            this.pnlDerecha.Controls.Add(this.lblFechaFin);
            this.pnlDerecha.Controls.Add(this.dtpFechaFin);
            this.pnlDerecha.Controls.Add(this.lblActiva);
            this.pnlDerecha.Controls.Add(this.chkActiva);
            this.pnlDerecha.Controls.Add(this.btnAgregar);
            this.pnlDerecha.Controls.Add(this.btnEditar);
            this.pnlDerecha.Controls.Add(this.btnEliminar);
            this.pnlDerecha.Controls.Add(this.btnLimpiar);
            this.pnlDerecha.Location = new System.Drawing.Point(760, 55);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(300, 580);
            this.pnlDerecha.TabIndex = 6;
            // 
            // lblIdSocio
            // 
            this.lblIdSocio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIdSocio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(73)))));
            this.lblIdSocio.Location = new System.Drawing.Point(15, 15);
            this.lblIdSocio.Name = "lblIdSocio";
            this.lblIdSocio.Size = new System.Drawing.Size(260, 18);
            this.lblIdSocio.TabIndex = 0;
            this.lblIdSocio.Text = "Id Socio";
            // 
            // lblIdPlan
            // 
            this.lblIdPlan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIdPlan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(73)))));
            this.lblIdPlan.Location = new System.Drawing.Point(15, 85);
            this.lblIdPlan.Name = "lblIdPlan";
            this.lblIdPlan.Size = new System.Drawing.Size(260, 18);
            this.lblIdPlan.TabIndex = 2;
            this.lblIdPlan.Text = "Id Plan";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(73)))));
            this.lblFechaInicio.Location = new System.Drawing.Point(15, 155);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(260, 18);
            this.lblFechaInicio.TabIndex = 4;
            this.lblFechaInicio.Text = "Fecha Inicio";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(15, 175);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(260, 34);
            this.dtpFechaInicio.TabIndex = 5;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(73)))));
            this.lblFechaFin.Location = new System.Drawing.Point(15, 225);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(260, 18);
            this.lblFechaFin.TabIndex = 6;
            this.lblFechaFin.Text = "Fecha Fin";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(15, 245);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(260, 34);
            this.dtpFechaFin.TabIndex = 7;
            // 
            // lblActiva
            // 
            this.lblActiva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblActiva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(73)))));
            this.lblActiva.Location = new System.Drawing.Point(15, 295);
            this.lblActiva.Name = "lblActiva";
            this.lblActiva.Size = new System.Drawing.Size(260, 18);
            this.lblActiva.TabIndex = 8;
            this.lblActiva.Text = "Estado";
            // 
            // chkActiva
            // 
            this.chkActiva.Checked = true;
            this.chkActiva.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActiva.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkActiva.Location = new System.Drawing.Point(15, 318);
            this.chkActiva.Name = "chkActiva";
            this.chkActiva.Size = new System.Drawing.Size(260, 24);
            this.chkActiva.TabIndex = 9;
            this.chkActiva.Text = "Activa";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(73)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(15, 365);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 38);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(73)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(150, 365);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(120, 38);
            this.btnEditar.TabIndex = 11;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(15, 413);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 38);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(150, 413);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 38);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(260, 28);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(15, 124);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(260, 28);
            this.comboBox2.TabIndex = 15;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // FormMembresias
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1080, 640);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.dgvMembresias);
            this.Controls.Add(this.pnlDerecha);
            this.Name = "FormMembresias";
            this.Text = "Membresías";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMembresias_Load);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresias)).EndInit();
            this.pnlDerecha.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.DataGridView dgvMembresias;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Label lblIdSocio;
        private System.Windows.Forms.Label lblIdPlan;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblActiva;
        private System.Windows.Forms.CheckBox chkActiva;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}