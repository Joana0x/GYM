using GYM_NoSql.Models;
using Oracle.ManagedDataAccess.Client;
using Proyecto_GYM.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace GYM_NoSql.Views
{
    public partial class FormMembresias : Form
    {
        // Instancia del helper para conectar con Oracle
        OracleDbHelper db = new OracleDbHelper();

        public FormMembresias()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FormMembresias_Load(object sender, EventArgs e)
        {
            // Ajuste de diseño visual
            pnlDerecha.Left = this.ClientSize.Width - pnlDerecha.Width - 5;
            pnlDerecha.Height = this.ClientSize.Height - 55;
            dgvMembresias.Width = this.ClientSize.Width - pnlDerecha.Width - 20;
            dgvMembresias.Height = this.ClientSize.Height - 110;

            // CARGA DE DATOS INICIAL
            CargarSocios();
            CargarPlanes();
            ListarMembresias();

            // Configurar fechas por defecto
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now.AddMonths(1);
        }

        // 1. Llenar ComboBox de Socios (comboBox1)
        private void CargarSocios()
        {
            try
            {
                string sql = "SELECT ID_SOCIO, NOMBRE || ' ' || PRIMER_APELLIDO AS NOMBRE_COMPLETO FROM SOCIOS ORDER BY NOMBRE ASC";
                DataTable dt = db.ExecuteQuery(sql);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "NOMBRE_COMPLETO";
                comboBox1.ValueMember = "ID_SOCIO";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar socios: " + ex.Message);
            }
        }

        // 2. Llenar ComboBox de Planes (comboBox2)
        private void CargarPlanes()
        {
            try
            {
                string sql = "SELECT ID_PLAN, NOMBRE FROM PLANES WHERE ACTIVO = '1' ORDER BY NOMBRE ASC";
                DataTable dt = db.ExecuteQuery(sql);

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "NOMBRE";
                comboBox2.ValueMember = "ID_PLAN";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar planes: " + ex.Message);
            }
        }

        // 3. Mostrar membresías en el Grid
        private void ListarMembresias()
        {
            try
            {
                string sql = @"SELECT M.ID_MEMBRESIA, S.NOMBRE || ' ' || S.PRIMER_APELLIDO AS SOCIO, 
                               M.FECHA_INICIO, M.FECHA_FIN, M.ACTIVA 
                               FROM MEMBRESIAS M 
                               JOIN SOCIOS S ON M.ID_SOCIO = S.ID_SOCIO 
                               ORDER BY M.ID_MEMBRESIA DESC";
                dgvMembresias.DataSource = db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar: " + ex.Message);
            }
        }

        // 4. Botón Agregar con la nueva lógica de ComboBox
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificamos que haya algo seleccionado
                if (comboBox1.SelectedValue == null) return;

                string sql = @"INSERT INTO MEMBRESIAS (ID_SOCIO, FECHA_INICIO, FECHA_FIN, ACTIVA) 
                               VALUES (:id_socio, :inicio, :fin, :activa)";

                OracleParameter[] parametros = {
                    new OracleParameter("id_socio", comboBox1.SelectedValue),
                    new OracleParameter("inicio", dtpFechaInicio.Value.Date),
                    new OracleParameter("fin", dtpFechaFin.Value.Date),
                    new OracleParameter("activa", chkActiva.Checked ? "1" : "0")
                };

                if (db.ExecuteNonQuery(sql, parametros) > 0)
                {
                    MessageBox.Show("¡Membresía registrada con éxito!");
                    ListarMembresias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            if (comboBox2.Items.Count > 0) comboBox2.SelectedIndex = 0;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now.AddMonths(1);
            chkActiva.Checked = true;
        }

        private void btnRegresar_Click(object sender, EventArgs e) => this.Close();

        // Métodos de eventos que se mantienen para no romper el Designer
        private void dgvMembresias_SelectionChanged(object sender, EventArgs e) { }
        private void btnEditar_Click(object sender, EventArgs e) { }
        private void btnEliminar_Click(object sender, EventArgs e) { }
        private void nudIdPlan_ValueChanged(object sender, EventArgs e) { }
        private void nudIdSocio_ValueChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}