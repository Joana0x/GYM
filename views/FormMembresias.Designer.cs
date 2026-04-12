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
            this.nudIdSocio = new System.Windows.Forms.NumericUpDown();
            this.lblIdPlan = new System.Windows.Forms.Label();
            this.nudIdPlan = new System.Windows.Forms.NumericUpDown();
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
            this.pnlTop.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdSocio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdPlan)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.Add(this.btnRegresar);
            this.pnlTop.Controls.Add(this.lblTitulo);

            // btnRegresar
            this.btnRegresar.Text = "←";
            this.btnRegresar.Size = new System.Drawing.Size(45, 35);
            this.btnRegresar.Location = new System.Drawing.Point(8, 10);
            this.btnRegresar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.BackColor = System.Drawing.Color.Transparent;
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.FlatAppearance.BorderSize = 0;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);

            // lblTitulo
            this.lblTitulo.Text = "Gestión de Membresías";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Size = new System.Drawing.Size(400, 40);
            this.lblTitulo.Location = new System.Drawing.Point(60, 8);
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Filtros
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.Location = new System.Drawing.Point(10, 65);
            this.lblBuscar.Size = new System.Drawing.Size(60, 20);
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.txtBuscar.Location = new System.Drawing.Point(72, 62);
            this.txtBuscar.Size = new System.Drawing.Size(200, 26);
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.lblEstado.Text = "Estado:";
            this.lblEstado.Location = new System.Drawing.Point(285, 65);
            this.lblEstado.Size = new System.Drawing.Size(55, 20);
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.cmbEstado.Location = new System.Drawing.Point(343, 62);
            this.cmbEstado.Size = new System.Drawing.Size(130, 26);
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Items.AddRange(new object[] { "Todos", "Activas", "Inactivas" });
            this.cmbEstado.SelectedIndex = 0;

            // dgvMembresias
            this.dgvMembresias.Location = new System.Drawing.Point(10, 100);
            this.dgvMembresias.Size = new System.Drawing.Size(750, 480);
            this.dgvMembresias.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right;
            this.dgvMembresias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembresias.ReadOnly = true;
            this.dgvMembresias.AllowUserToAddRows = false;
            this.dgvMembresias.BackgroundColor = System.Drawing.Color.White;
            this.dgvMembresias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMembresias.EnableHeadersVisualStyles = false;
            this.dgvMembresias.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.dgvMembresias.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMembresias.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvMembresias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembresias.SelectionChanged += new System.EventHandler(this.dgvMembresias_SelectionChanged);

            // pnlDerecha
            this.pnlDerecha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlDerecha.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Right;
            this.pnlDerecha.Size = new System.Drawing.Size(300, 580);
            this.pnlDerecha.Location = new System.Drawing.Point(760, 55);

            // Campos
            this.lblIdSocio.Text = "Id Socio";
            this.lblIdSocio.Location = new System.Drawing.Point(15, 15);
            this.lblIdSocio.Size = new System.Drawing.Size(260, 18);
            this.lblIdSocio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIdSocio.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.nudIdSocio.Location = new System.Drawing.Point(15, 35);
            this.nudIdSocio.Size = new System.Drawing.Size(260, 28);
            this.nudIdSocio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudIdSocio.Minimum = 1;

            this.lblIdPlan.Text = "Id Plan";
            this.lblIdPlan.Location = new System.Drawing.Point(15, 85);
            this.lblIdPlan.Size = new System.Drawing.Size(260, 18);
            this.lblIdPlan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIdPlan.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.nudIdPlan.Location = new System.Drawing.Point(15, 105);
            this.nudIdPlan.Size = new System.Drawing.Size(260, 28);
            this.nudIdPlan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudIdPlan.Minimum = 1;

            this.lblFechaInicio.Text = "Fecha Inicio";
            this.lblFechaInicio.Location = new System.Drawing.Point(15, 155);
            this.lblFechaInicio.Size = new System.Drawing.Size(260, 18);
            this.lblFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaInicio.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.dtpFechaInicio.Location = new System.Drawing.Point(15, 175);
            this.dtpFechaInicio.Size = new System.Drawing.Size(260, 28);
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblFechaFin.Text = "Fecha Fin";
            this.lblFechaFin.Location = new System.Drawing.Point(15, 225);
            this.lblFechaFin.Size = new System.Drawing.Size(260, 18);
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaFin.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.dtpFechaFin.Location = new System.Drawing.Point(15, 245);
            this.dtpFechaFin.Size = new System.Drawing.Size(260, 28);
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblActiva.Text = "Estado";
            this.lblActiva.Location = new System.Drawing.Point(15, 295);
            this.lblActiva.Size = new System.Drawing.Size(260, 18);
            this.lblActiva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblActiva.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.chkActiva.Text = "Activa";
            this.chkActiva.Location = new System.Drawing.Point(15, 318);
            this.chkActiva.Size = new System.Drawing.Size(260, 24);
            this.chkActiva.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkActiva.Checked = true;

            // Botones
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 38);
            this.btnAgregar.Location = new System.Drawing.Point(15, 365);
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            this.btnEditar.Text = "Editar";
            this.btnEditar.Size = new System.Drawing.Size(120, 38);
            this.btnEditar.Location = new System.Drawing.Point(150, 365);
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 38);
            this.btnEliminar.Location = new System.Drawing.Point(15, 413);
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(180, 50, 50);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 38);
            this.btnLimpiar.Location = new System.Drawing.Point(150, 413);
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.pnlDerecha.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblIdSocio, this.nudIdSocio,
                this.lblIdPlan, this.nudIdPlan,
                this.lblFechaInicio, this.dtpFechaInicio,
                this.lblFechaFin, this.dtpFechaFin,
                this.lblActiva, this.chkActiva,
                this.btnAgregar, this.btnEditar,
                this.btnEliminar, this.btnLimpiar
            });

            // FormMembresias
            this.ClientSize = new System.Drawing.Size(1080, 640);
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.Text = "Membresías";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlTop,
                this.lblBuscar, this.txtBuscar,
                this.lblEstado, this.cmbEstado,
                this.dgvMembresias,
                this.pnlDerecha
            });
            this.Load += new System.EventHandler(this.FormMembresias_Load);
            this.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlDerecha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdSocio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdPlan)).EndInit();
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
        private System.Windows.Forms.NumericUpDown nudIdSocio;
        private System.Windows.Forms.Label lblIdPlan;
        private System.Windows.Forms.NumericUpDown nudIdPlan;
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
    }
}