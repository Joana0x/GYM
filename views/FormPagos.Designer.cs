namespace GYM_NoSql.Views
{
    partial class FormPagos
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
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.lblIdMembresia = new System.Windows.Forms.Label();
            this.nudIdMembresia = new System.Windows.Forms.NumericUpDown();
            this.lblFechaPago = new System.Windows.Forms.Label();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdMembresia)).BeginInit();
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
            this.lblTitulo.Text = "Gestión de Pagos";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Size = new System.Drawing.Size(350, 40);
            this.lblTitulo.Location = new System.Drawing.Point(60, 8);
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Filtro
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.Location = new System.Drawing.Point(10, 65);
            this.lblBuscar.Size = new System.Drawing.Size(60, 20);
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.txtBuscar.Location = new System.Drawing.Point(72, 62);
            this.txtBuscar.Size = new System.Drawing.Size(200, 26);
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);

            // dgvPagos
            this.dgvPagos.Location = new System.Drawing.Point(10, 100);
            this.dgvPagos.Size = new System.Drawing.Size(750, 480);
            this.dgvPagos.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right;
            this.dgvPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPagos.ReadOnly = true;
            this.dgvPagos.AllowUserToAddRows = false;
            this.dgvPagos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPagos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPagos.EnableHeadersVisualStyles = false;
            this.dgvPagos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.dgvPagos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPagos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagos.SelectionChanged += new System.EventHandler(this.dgvPagos_SelectionChanged);

            // pnlDerecha
            this.pnlDerecha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlDerecha.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Right;
            this.pnlDerecha.Size = new System.Drawing.Size(300, 580);
            this.pnlDerecha.Location = new System.Drawing.Point(760, 55);

            // Campos
            this.lblIdMembresia.Text = "Id Membresía";
            this.lblIdMembresia.Location = new System.Drawing.Point(15, 15);
            this.lblIdMembresia.Size = new System.Drawing.Size(260, 18);
            this.lblIdMembresia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIdMembresia.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.nudIdMembresia.Location = new System.Drawing.Point(15, 35);
            this.nudIdMembresia.Size = new System.Drawing.Size(260, 28);
            this.nudIdMembresia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudIdMembresia.Minimum = 1;

            this.lblFechaPago.Text = "Fecha de Pago";
            this.lblFechaPago.Location = new System.Drawing.Point(15, 85);
            this.lblFechaPago.Size = new System.Drawing.Size(260, 18);
            this.lblFechaPago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaPago.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.dtpFechaPago.Location = new System.Drawing.Point(15, 105);
            this.dtpFechaPago.Size = new System.Drawing.Size(260, 28);
            this.dtpFechaPago.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblMonto.Text = "Monto";
            this.lblMonto.Location = new System.Drawing.Point(15, 155);
            this.lblMonto.Size = new System.Drawing.Size(260, 18);
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMonto.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.txtMonto.Location = new System.Drawing.Point(15, 175);
            this.txtMonto.Size = new System.Drawing.Size(260, 28);
            this.txtMonto.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Botones
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 38);
            this.btnAgregar.Location = new System.Drawing.Point(15, 230);
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            this.btnEditar.Text = "Editar";
            this.btnEditar.Size = new System.Drawing.Size(120, 38);
            this.btnEditar.Location = new System.Drawing.Point(150, 230);
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 38);
            this.btnEliminar.Location = new System.Drawing.Point(15, 278);
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(180, 50, 50);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 38);
            this.btnLimpiar.Location = new System.Drawing.Point(150, 278);
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.pnlDerecha.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblIdMembresia, this.nudIdMembresia,
                this.lblFechaPago, this.dtpFechaPago,
                this.lblMonto, this.txtMonto,
                this.btnAgregar, this.btnEditar,
                this.btnEliminar, this.btnLimpiar
            });

            // FormPagos
            this.ClientSize = new System.Drawing.Size(1080, 640);
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.Text = "Pagos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlTop,
                this.lblBuscar, this.txtBuscar,
                this.dgvPagos,
                this.pnlDerecha
            });
            this.Load += new System.EventHandler(this.FormPagos_Load);
            this.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlDerecha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdMembresia)).EndInit();
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Label lblIdMembresia;
        private System.Windows.Forms.NumericUpDown nudIdMembresia;
        private System.Windows.Forms.Label lblFechaPago;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}