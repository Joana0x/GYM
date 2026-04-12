namespace GYM_NoSql.Views
{
    partial class FormSocios
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
            this.btnRegresar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscarNombre = new System.Windows.Forms.TextBox();
            this.lblPlan = new System.Windows.Forms.Label();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.dgvSocios = new System.Windows.Forms.DataGridView();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblPrimerAp = new System.Windows.Forms.Label();
            this.txtPrimerAp = new System.Windows.Forms.TextBox();
            this.lblSegundoAp = new System.Windows.Forms.Label();
            this.txtSegundoAp = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblSexo = new System.Windows.Forms.Label();
            this.txtSexo = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblIdPlan = new System.Windows.Forms.Label();
            this.nudIdPlan = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).BeginInit();
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
            this.lblTitulo.Text = "Gestión de Socios";
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

            this.txtBuscarNombre.Location = new System.Drawing.Point(72, 62);
            this.txtBuscarNombre.Size = new System.Drawing.Size(180, 26);
            this.txtBuscarNombre.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.lblPlan.Text = "Plan:";
            this.lblPlan.Location = new System.Drawing.Point(265, 65);
            this.lblPlan.Size = new System.Drawing.Size(40, 20);
            this.lblPlan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.cmbPlan.Location = new System.Drawing.Point(308, 62);
            this.cmbPlan.Size = new System.Drawing.Size(140, 26);
            this.cmbPlan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlan.Items.AddRange(new object[] { "Todos", "Plan 1", "Plan 2", "Plan 3" });
            this.cmbPlan.SelectedIndex = 0;

            this.lblEstado.Text = "Estado:";
            this.lblEstado.Location = new System.Drawing.Point(460, 65);
            this.lblEstado.Size = new System.Drawing.Size(55, 20);
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.cmbEstado.Location = new System.Drawing.Point(518, 62);
            this.cmbEstado.Size = new System.Drawing.Size(130, 26);
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Items.AddRange(new object[] { "Todos", "Activos", "Inactivos" });
            this.cmbEstado.SelectedIndex = 0;

            // dgvSocios
            this.dgvSocios.Location = new System.Drawing.Point(10, 100);
            this.dgvSocios.Size = new System.Drawing.Size(750, 480);
            this.dgvSocios.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right;
            this.dgvSocios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSocios.ReadOnly = true;
            this.dgvSocios.AllowUserToAddRows = false;
            this.dgvSocios.BackgroundColor = System.Drawing.Color.White;
            this.dgvSocios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSocios.EnableHeadersVisualStyles = false;
            this.dgvSocios.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.dgvSocios.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSocios.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvSocios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSocios.SelectionChanged += new System.EventHandler(this.dgvSocios_SelectionChanged);

            // pnlDerecha
            this.pnlDerecha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlDerecha.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Right;
            this.pnlDerecha.Size = new System.Drawing.Size(300, 580);
            this.pnlDerecha.Location = new System.Drawing.Point(760, 55);

            // lblNombre
            this.lblNombre.Text = "Nombre";
            this.lblNombre.Location = new System.Drawing.Point(15, 15);
            this.lblNombre.Size = new System.Drawing.Size(260, 18);
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.txtNombre.Location = new System.Drawing.Point(15, 35);
            this.txtNombre.Size = new System.Drawing.Size(260, 28);
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);

            // lblPrimerAp
            this.lblPrimerAp.Text = "Primer Apellido";
            this.lblPrimerAp.Location = new System.Drawing.Point(15, 85);
            this.lblPrimerAp.Size = new System.Drawing.Size(260, 18);
            this.lblPrimerAp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrimerAp.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.txtPrimerAp.Location = new System.Drawing.Point(15, 105);
            this.txtPrimerAp.Size = new System.Drawing.Size(260, 28);
            this.txtPrimerAp.Font = new System.Drawing.Font("Segoe UI", 10F);

            // lblSegundoAp
            this.lblSegundoAp.Text = "Segundo Apellido";
            this.lblSegundoAp.Location = new System.Drawing.Point(15, 155);
            this.lblSegundoAp.Size = new System.Drawing.Size(260, 18);
            this.lblSegundoAp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSegundoAp.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.txtSegundoAp.Location = new System.Drawing.Point(15, 175);
            this.txtSegundoAp.Size = new System.Drawing.Size(260, 28);
            this.txtSegundoAp.Font = new System.Drawing.Font("Segoe UI", 10F);

            // lblTelefono
            this.lblTelefono.Text = "Teléfono";
            this.lblTelefono.Location = new System.Drawing.Point(15, 225);
            this.lblTelefono.Size = new System.Drawing.Size(260, 18);
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.txtTelefono.Location = new System.Drawing.Point(15, 245);
            this.txtTelefono.Size = new System.Drawing.Size(260, 28);
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 10F);

            // lblSexo
            this.lblSexo.Text = "Sexo (M/F)";
            this.lblSexo.Location = new System.Drawing.Point(15, 295);
            this.lblSexo.Size = new System.Drawing.Size(260, 18);
            this.lblSexo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSexo.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.txtSexo.Location = new System.Drawing.Point(15, 315);
            this.txtSexo.Size = new System.Drawing.Size(260, 28);
            this.txtSexo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSexo.MaxLength = 1;

            // lblFecha
            this.lblFecha.Text = "Fecha de Registro";
            this.lblFecha.Location = new System.Drawing.Point(15, 365);
            this.lblFecha.Size = new System.Drawing.Size(260, 18);
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.dtpFecha.Location = new System.Drawing.Point(15, 385);
            this.dtpFecha.Size = new System.Drawing.Size(260, 28);
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // lblIdPlan
            this.lblIdPlan.Text = "Id Plan";
            this.lblIdPlan.Location = new System.Drawing.Point(15, 435);
            this.lblIdPlan.Size = new System.Drawing.Size(260, 18);
            this.lblIdPlan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIdPlan.ForeColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.nudIdPlan.Location = new System.Drawing.Point(15, 455);
            this.nudIdPlan.Size = new System.Drawing.Size(260, 28);
            this.nudIdPlan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudIdPlan.Minimum = 1;

            // Botones
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 38);
            this.btnAgregar.Location = new System.Drawing.Point(15, 510);
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            this.btnEditar.Text = "Editar";
            this.btnEditar.Size = new System.Drawing.Size(120, 38);
            this.btnEditar.Location = new System.Drawing.Point(150, 510);
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 38);
            this.btnEliminar.Location = new System.Drawing.Point(15, 558);
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(180, 50, 50);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 38);
            this.btnLimpiar.Location = new System.Drawing.Point(150, 558);
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.pnlDerecha.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblNombre, this.txtNombre,
                this.lblPrimerAp, this.txtPrimerAp,
                this.lblSegundoAp, this.txtSegundoAp,
                this.lblTelefono, this.txtTelefono,
                this.lblSexo, this.txtSexo,
                this.lblFecha, this.dtpFecha,
                this.lblIdPlan, this.nudIdPlan,
                this.btnAgregar, this.btnEditar,
                this.btnEliminar, this.btnLimpiar
            });

            // FormSocios
            this.ClientSize = new System.Drawing.Size(1080, 640);
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.Text = "Socios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlTop,
                this.lblBuscar, this.txtBuscarNombre,
                this.lblPlan, this.cmbPlan,
                this.lblEstado, this.cmbEstado,
                this.dgvSocios,
                this.pnlDerecha
            });
            this.Load += new System.EventHandler(this.FormSocios_Load);
            this.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlDerecha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdPlan)).EndInit();
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscarNombre;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.DataGridView dgvSocios;
        private System.Windows.Forms.Panel pnlDerecha;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblPrimerAp;
        private System.Windows.Forms.TextBox txtPrimerAp;
        private System.Windows.Forms.Label lblSegundoAp;
        private System.Windows.Forms.TextBox txtSegundoAp;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.TextBox txtSexo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblIdPlan;
        private System.Windows.Forms.NumericUpDown nudIdPlan;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}