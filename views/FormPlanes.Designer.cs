namespace GYM_NoSql.Views
{
    partial class FormPlanes
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
            this.lblActivo = new System.Windows.Forms.Label();
            this.cmbActivo = new System.Windows.Forms.ComboBox();
            this.dgvPlanes = new System.Windows.Forms.DataGridView();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblActivo2 = new System.Windows.Forms.Label();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).BeginInit();
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
            this.lblTitulo.Text = "Gestión de Planes";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Size = new System.Drawing.Size(350, 40);
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

            this.lblActivo.Text = "Estado:";
            this.lblActivo.Location = new System.Drawing.Point(285, 65);
            this.lblActivo.Size = new System.Drawing.Size(55, 20);
            this.lblActivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.cmbActivo.Location = new System.Drawing.Point(343, 62);
            this.cmbActivo.Size = new System.Drawing.Size(130, 26);
            this.cmbActivo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivo.Items.AddRange(new object[] { "Todos", "Activos", "Inactivos" });
            this.cmbActivo.SelectedIndex = 0;

            // dgvPlanes
            this.dgvPlanes.Location = new System.Drawing.Point(10, 100);
            this.dgvPlanes.Size = new System.Drawing.Size(750, 480);
            this.dgvPlanes.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right;
            this.dgvPlanes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlanes.ReadOnly = true;
            this.dgvPlanes.AllowUserToAddRows = false;
            this.dgvPlanes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlanes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPlanes.EnableHeadersVisualStyles = false;
            this.dgvPlanes.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.dgvPlanes.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPlanes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvPlanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanes.SelectionChanged += new System.EventHandler(this.dgvPlanes_SelectionChanged);

            // pnlDerecha
            this.pnlDerecha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlDerecha.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Right;
            this.pnlDerecha.Size = new System.Drawing.Size(300, 580);
            this.pnlDerecha.Location = new System.Drawing.Point(760, 55);

            // lblNombre
            this.lblNombre.Text = "Nombre del Plan";
            this.lblNombre.Location = new System.Drawing.Point(15, 15);
            this.lblNombre.Size = new System.Drawing.Size(260, 18);
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.txtNombre.Location = new System.Drawing.Point(15, 35);
            this.txtNombre.Size = new System.Drawing.Size(260, 28);
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);

            // lblPrecio
            this.lblPrecio.Text = "Precio";
            this.lblPrecio.Location = new System.Drawing.Point(15, 85);
            this.lblPrecio.Size = new System.Drawing.Size(260, 18);
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.txtPrecio.Location = new System.Drawing.Point(15, 105);
            this.txtPrecio.Size = new System.Drawing.Size(260, 28);
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);

            // chkActivo
            this.lblActivo2.Text = "Estado";
            this.lblActivo2.Location = new System.Drawing.Point(15, 155);
            this.lblActivo2.Size = new System.Drawing.Size(260, 18);
            this.lblActivo2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblActivo2.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.chkActivo.Text = "Activo";
            this.chkActivo.Location = new System.Drawing.Point(15, 178);
            this.chkActivo.Size = new System.Drawing.Size(260, 24);
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkActivo.Checked = true;

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
                this.lblNombre, this.txtNombre,
                this.lblPrecio, this.txtPrecio,
                this.lblActivo2, this.chkActivo,
                this.btnAgregar, this.btnEditar,
                this.btnEliminar, this.btnLimpiar
            });

            // FormPlanes
            this.ClientSize = new System.Drawing.Size(1080, 640);
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.Text = "Planes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlTop,
                this.lblBuscar, this.txtBuscar,
                this.lblActivo, this.cmbActivo,
                this.dgvPlanes,
                this.pnlDerecha
            });
            this.Load += new System.EventHandler(this.FormPlanes_Load);
            this.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlDerecha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).EndInit();
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblActivo;
        private System.Windows.Forms.ComboBox cmbActivo;
        private System.Windows.Forms.DataGridView dgvPlanes;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblActivo2;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}