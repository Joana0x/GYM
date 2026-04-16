using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client; // Para Oracle
using System.Configuration;            // Para App.config

namespace GYM_NoSql.Views
{
    public partial class FormSocios : Form
    {
        // Conexión a Oracle
        string connectionString = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        // Rastreador de ID seleccionado
        int idSocioSeleccionado = 0;

        // BANDERA: Para evitar que se llenen las cajas solas al abrir la ventana
        bool cargandoDatos = false;

        public FormSocios()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            // --- CABLES CORRECTOS DE LOS BOTONES DE ACCIÓN ---
            this.btnAgregar.Click -= btnAgregar_Click;
            this.btnAgregar.Click += btnAgregar_Click;

            this.btnEditar.Click -= btnEditar_Click;
            this.btnEditar.Click += btnEditar_Click;

            this.btnEliminar.Click -= btnEliminar_Click;
            this.btnEliminar.Click += btnEliminar_Click;

            this.btnLimpiar.Click -= btnLimpiar_Click;
            this.btnLimpiar.Click += btnLimpiar_Click;

            this.dgvSocios.SelectionChanged -= dgvSocios_SelectionChanged;
            this.dgvSocios.SelectionChanged += dgvSocios_SelectionChanged;
        }

        private void FormSocios_Load(object sender, EventArgs e)
        {
            // Acomoda tu diseño visual
            pnlDerecha.Left = this.ClientSize.Width - pnlDerecha.Width - 5;
            pnlDerecha.Height = this.ClientSize.Height - 55;
            dgvSocios.Width = this.ClientSize.Width - pnlDerecha.Width - 20;
            dgvSocios.Height = this.ClientSize.Height - 110;

            // --- BLOQUEO DE FECHA ---
            dtpFecha.Enabled = false;

            ConfigurarFiltrosBusqueda(); // Carga las opciones de los combos de búsqueda
            CargarListas();              // Carga los combos de registro
            CargarTablaSocios();         // Carga la tabla
        }

        // --- CONFIGURAR LOS COMBOS DE BÚSQUEDA ---
        private void ConfigurarFiltrosBusqueda()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Llenar cmbPlan dinámicamente desde la BD
                    if (cmbPlan != null)
                    {
                        OracleCommand cmdPlan = new OracleCommand(
    "SELECT id_plan, nombre FROM planes WHERE activo = '1' ORDER BY id_plan", conn);
                        OracleDataAdapter daPlan = new OracleDataAdapter(cmdPlan);
                        DataTable dtPlan = new DataTable();
                        daPlan.Fill(dtPlan);

                        DataRow filaPlan = dtPlan.NewRow();
                        filaPlan["nombre"] = "Todos";
                        dtPlan.Rows.InsertAt(filaPlan, 0);

                        // Desactivamos temporalmente la bandera para que no busque mientras se llena
                        bool estadoAnterior = cargandoDatos;
                        cargandoDatos = true;

                        cmbPlan.DataSource = dtPlan;
                        cmbPlan.DisplayMember = "nombre";
                        cmbPlan.ValueMember = "nombre";

                        cargandoDatos = estadoAnterior;
                    }

                    // Llenar cmbEstado
                    if (cmbEstado != null)
                    {
                        bool estadoAnterior = cargandoDatos;
                        cargandoDatos = true;

                        cmbEstado.Items.Clear();
                        cmbEstado.Items.AddRange(new string[] { "Todos", "Activos", "Inactivos" });
                        cmbEstado.SelectedIndex = 0;

                        cargandoDatos = estadoAnterior;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Aviso en filtros: " + ex.Message);
                }
            }
        }

        private void CargarListas()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // --- Llenar cmbSexo ---
                    OracleCommand cmdSexo = new OracleCommand("SELECT id_sexo, descripcion FROM sexos ORDER BY id_sexo", conn);
                    OracleDataAdapter daSexo = new OracleDataAdapter(cmdSexo);
                    DataTable dtSexo = new DataTable();
                    daSexo.Fill(dtSexo);

                    DataRow filaSexo = dtSexo.NewRow();
                    filaSexo["id_sexo"] = 0;
                    filaSexo["descripcion"] = "-- Seleccione --";
                    dtSexo.Rows.InsertAt(filaSexo, 0);

                    cmbSexo.DataSource = dtSexo;
                    cmbSexo.DisplayMember = "descripcion";
                    cmbSexo.ValueMember = "id_sexo";

                    // --- Llenar cmbPlanRegistro ---
                    OracleCommand cmdPlan = new OracleCommand(
                        "SELECT id_plan, nombre FROM planes WHERE activo = '1' ORDER BY id_plan", conn); OracleDataAdapter daPlan = new OracleDataAdapter(cmdPlan);
                    DataTable dtPlan = new DataTable();
                    daPlan.Fill(dtPlan);

                    DataRow filaPlan = dtPlan.NewRow();
                    filaPlan["id_plan"] = 0;
                    filaPlan["nombre"] = "-- Seleccione un Plan --";
                    dtPlan.Rows.InsertAt(filaPlan, 0);

                    cmbPlanRegistro.DataSource = dtPlan;
                    cmbPlanRegistro.DisplayMember = "nombre";
                    cmbPlanRegistro.ValueMember = "id_plan";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar listas: " + ex.Message);
                }
            }
        }

        private void CargarTablaSocios()
        {
            if (txtBuscarNombre == null || cmbPlan == null || cmbEstado == null) return;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    cargandoDatos = true;
                    conn.Open();

                    string textoBusqueda = txtBuscarNombre.Text.Trim().ToUpper();
                    string planFiltro = cmbPlan.Text;
                    string estadoFiltro = cmbEstado.Text;

                    string sql = @"
                SELECT 
                    s.id_socio AS ""ID Socio"",
                    s.nombre AS ""Nombre"",
                    s.primer_apellido AS ""Paterno"",
                    s.segundo_apellido AS ""Materno"",
                    s.telefono AS ""Teléfono"",
                    x.descripcion AS ""Sexo"",
                    p.nombre AS ""Plan"",
                    p.precio AS ""Precio"",
                    s.fecha_registro AS ""Fecha"",
                    CASE
                        WHEN MAX(pg.fecha_pago) IS NULL THEN 'Inactivo'
                        WHEN MAX(pg.fecha_pago) + 30 >= TRUNC(SYSDATE) THEN 'Activo'
                        ELSE 'Inactivo'
                    END AS ""Estado""
                FROM socios s
                INNER JOIN sexos x ON s.id_sexo = x.id_sexo
                INNER JOIN planes p ON s.id_plan = p.id_plan
                LEFT JOIN pagos pg ON s.id_socio = pg.id_socio
                WHERE 1=1 ";

                    if (!string.IsNullOrEmpty(textoBusqueda))
                    {
                        sql += @" AND (
                            UPPER(s.nombre) LIKE :busq 
                            OR UPPER(s.primer_apellido) LIKE :busq 
                            OR UPPER(s.segundo_apellido) LIKE :busq
                            OR TO_CHAR(s.id_socio) LIKE :busq
                         )";
                    }

                    if (planFiltro != "Todos" && !string.IsNullOrEmpty(planFiltro))
                    {
                        sql += " AND p.nombre = :plan";
                    }

                    sql += @"
                GROUP BY
                    s.id_socio,
                    s.nombre,
                    s.primer_apellido,
                    s.segundo_apellido,
                    s.telefono,
                    x.descripcion,
                    p.nombre,
                    p.precio,
                    s.fecha_registro";

                    if (estadoFiltro == "Activos")
                    {
                        sql += @"
                    HAVING MAX(pg.fecha_pago) IS NOT NULL
                       AND MAX(pg.fecha_pago) + 30 >= TRUNC(SYSDATE)";
                    }
                    else if (estadoFiltro == "Inactivos")
                    {
                        sql += @"
                    HAVING MAX(pg.fecha_pago) IS NULL
                        OR MAX(pg.fecha_pago) + 30 < TRUNC(SYSDATE)";
                    }

                    sql += " ORDER BY s.id_socio ASC";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.BindByName = true;

                        if (!string.IsNullOrEmpty(textoBusqueda))
                            cmd.Parameters.Add("busq", "%" + textoBusqueda + "%");

                        if (planFiltro != "Todos" && !string.IsNullOrEmpty(planFiltro))
                            cmd.Parameters.Add("plan", planFiltro);

                        OracleDataAdapter daTabla = new OracleDataAdapter(cmd);
                        DataTable dtTabla = new DataTable();
                        daTabla.Fill(dtTabla);

                        dgvSocios.DataSource = dtTabla;
                        dgvSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        if (dgvSocios.Columns["Precio"] != null)
                            dgvSocios.Columns["Precio"].DefaultCellStyle.Format = "C2";

                        if (dgvSocios.Columns["ID_INTERNO"] != null)
                            dgvSocios.Columns["ID_INTERNO"].Visible = false;

                        dgvSocios.ClearSelection();
                        LimpiarCajas();

                        cargandoDatos = false;
                    }
                }
                catch (Exception ex)
                {
                    cargandoDatos = false;
                    if (!ex.Message.Contains("no data found"))
                        Console.WriteLine("Error al filtrar la tabla: " + ex.Message);
                }
            }
        }

        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            if (!cargandoDatos) CargarTablaSocios();
        }

        private void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargandoDatos) CargarTablaSocios();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // El estado visual cambia, pero la consulta aún no tiene estado en BD.
            // Aún así, refrescamos la tabla por si acaso.
            if (!cargandoDatos) CargarTablaSocios();
        }
        // ------------------------------------------------

        private void LimpiarCajas()
        {
            txtNombre.Clear();
            txtPrimerAp.Clear();
            txtSegundoAp.Clear();
            txtTelefono.Clear();

            if (cmbSexo.Items.Count > 0) cmbSexo.SelectedIndex = 0;
            if (cmbPlanRegistro.Items.Count > 0) cmbPlanRegistro.SelectedIndex = 0;

            dtpFecha.Value = DateTime.Now;
            idSocioSeleccionado = 0;
        }

        private void dgvSocios_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoDatos) return;

            if (dgvSocios.CurrentRow != null && dgvSocios.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgvSocios.CurrentRow;

                if (fila.Cells["ID Socio"].Value != DBNull.Value && fila.Cells["ID Socio"].Value != null)
                {
                    idSocioSeleccionado = Convert.ToInt32(fila.Cells["ID Socio"].Value);

                    txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
                    txtPrimerAp.Text = fila.Cells["Paterno"].Value?.ToString();
                    txtSegundoAp.Text = fila.Cells["Materno"].Value?.ToString();
                    txtTelefono.Text = fila.Cells["Teléfono"].Value?.ToString();
                    cmbSexo.Text = fila.Cells["Sexo"].Value?.ToString();
                    cmbPlanRegistro.Text = fila.Cells["Plan"].Value?.ToString();

                    if (fila.Cells["Fecha"].Value != DBNull.Value)
                        dtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);
                }
            }
        }

        // --- BOTÓN AGREGAR ---
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbSexo.SelectedValue == null || Convert.ToInt32(cmbSexo.SelectedValue) == 0 ||
                cmbPlanRegistro.SelectedValue == null || Convert.ToInt32(cmbPlanRegistro.SelectedValue) == 0)
            {
                MessageBox.Show("Por favor, selecciona un Sexo y un Plan de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Registrar a este nuevo socio?", "Confirmar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.No) return;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO socios (id_plan, id_sexo, nombre, primer_apellido, segundo_apellido, telefono, fecha_registro) " +
                                 "VALUES (:plan, :sexo, :nom, :ape1, :ape2, :tel, :fecha)";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add("plan", Convert.ToInt32(cmbPlanRegistro.SelectedValue));
                        cmd.Parameters.Add("sexo", Convert.ToInt32(cmbSexo.SelectedValue));
                        cmd.Parameters.Add("nom", txtNombre.Text);
                        cmd.Parameters.Add("ape1", txtPrimerAp.Text);
                        cmd.Parameters.Add("ape2", txtSegundoAp.Text);
                        cmd.Parameters.Add("tel", txtTelefono.Text);
                        cmd.Parameters.Add("fecha", DateTime.Now);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("¡Socio guardado con éxito!", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarTablaSocios();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- BOTÓN EDITAR ---
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSocioSeleccionado == 0)
            {
                MessageBox.Show("Por favor, selecciona un socio de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Estás seguro de que deseas APLICAR LOS CAMBIOS a este socio?", "Confirmar Edición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.No) return;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE socios SET id_plan = :plan, id_sexo = :sexo, nombre = :nom, " +
                                 "primer_apellido = :ape1, segundo_apellido = :ape2, telefono = :tel, fecha_registro = :fecha " +
                                 "WHERE id_socio = :id";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add("plan", Convert.ToInt32(cmbPlanRegistro.SelectedValue));
                        cmd.Parameters.Add("sexo", Convert.ToInt32(cmbSexo.SelectedValue));
                        cmd.Parameters.Add("nom", txtNombre.Text);
                        cmd.Parameters.Add("ape1", txtPrimerAp.Text);
                        cmd.Parameters.Add("ape2", txtSegundoAp.Text);
                        cmd.Parameters.Add("tel", txtTelefono.Text);
                        cmd.Parameters.Add("fecha", dtpFecha.Value);
                        cmd.Parameters.Add("id", idSocioSeleccionado);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("¡Socio actualizado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarTablaSocios();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- BOTÓN ELIMINAR ---
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSocioSeleccionado == 0)
            {
                MessageBox.Show("Por favor, selecciona un socio de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Estás seguro de que deseas ELIMINAR este socio? Esta acción no se puede deshacer.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (respuesta == DialogResult.No) return;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM socios WHERE id_socio = :id";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add("id", idSocioSeleccionado);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Socio eliminado del sistema.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarTablaSocios();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar. Es posible que el socio tenga pagos registrados.\n\n" + ex.Message, "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCajas();
        private void btnRegresar_Click(object sender, EventArgs e) => this.Close();

        // Eventos vacíos por si el diseñador visual los sigue buscando
        private void dgvSocios_CellClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvSocios_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

    }
}