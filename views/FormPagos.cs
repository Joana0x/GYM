using GYM_NoSql.Models;
using Oracle.ManagedDataAccess.Client;
using Proyecto_GYM.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace GYM_NoSql.Views
{
    public partial class FormPagos : Form
    {
        OracleDbHelper db = new OracleDbHelper();

        public FormPagos()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FormPagos_Load(object sender, EventArgs e)
        {
            // Ajuste de diseño visual
            pnlDerecha.Left = this.ClientSize.Width - pnlDerecha.Width - 5;
            pnlDerecha.Height = this.ClientSize.Height - 55;
            dgvPagos.Width = this.ClientSize.Width - pnlDerecha.Width - 20;
            dgvPagos.Height = this.ClientSize.Height - 110;

            // CARGA DE DATOS INICIAL
            CargarMembresias();
            ListarPagos();

            // Configurar fecha de pago por defecto (hoy)
            // Si tienes un DateTimePicker llamado dtpFechaPago:
            // dtpFechaPago.Value = DateTime.Now;
        }

        // 1. Llenar ComboBox de Membresías (comboBox1)
        private void CargarMembresias()
        {
            try
            {
                // Unimos con Socios para mostrar "Nombre del Socio (ID Membresía)"
                string sql = @"SELECT M.ID_MEMBRESIA, S.NOMBRE || ' ' || S.PRIMER_APELLIDO || ' (Membresía #' || M.ID_MEMBRESIA || ')' AS INFO 
                               FROM MEMBRESIAS M 
                               JOIN SOCIOS S ON M.ID_SOCIO = S.ID_SOCIO 
                               WHERE M.ACTIVA = '1'
                               ORDER BY S.NOMBRE ASC";
                DataTable dt = db.ExecuteQuery(sql);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "INFO";
                comboBox1.ValueMember = "ID_MEMBRESIA";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar membresías: " + ex.Message);
            }
        }

        // 2. Mostrar historial de pagos en el Grid
        private void ListarPagos()
        {
            try
            {
                // JOIN triple para traer el nombre del socio relacionado al pago
                string sql = @"SELECT P.ID_PAGO, S.NOMBRE || ' ' || S.PRIMER_APELLIDO AS SOCIO, 
                               P.MONTO, P.FECHA_PAGO 
                               FROM PAGOS P 
                               JOIN MEMBRESIAS M ON P.ID_MEMBRESIA = M.ID_MEMBRESIA 
                               JOIN SOCIOS S ON M.ID_SOCIO = S.ID_SOCIO 
                               ORDER BY P.ID_PAGO DESC";
                dgvPagos.DataSource = db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar pagos: " + ex.Message);
            }
        }

        // 3. Botón Agregar Pago
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedValue == null || string.IsNullOrEmpty(txtMonto.Text))
                {
                    MessageBox.Show("Por favor complete el monto y seleccione una membresía.");
                    return;
                }

                string sql = "INSERT INTO PAGOS (ID_MEMBRESIA, FECHA_PAGO, MONTO) VALUES (:id_m, :fecha, :monto)";

                OracleParameter[] parametros = {
                    new OracleParameter("id_m", comboBox1.SelectedValue),
                    new OracleParameter("fecha", DateTime.Now.Date), // Fecha actual
                    new OracleParameter("monto", Convert.ToDecimal(txtMonto.Text))
                };

                if (db.ExecuteNonQuery(sql, parametros) > 0)
                {
                    MessageBox.Show("¡Pago registrado correctamente!");
                    ListarPagos();
                    txtMonto.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar pago: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMonto.Clear();
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
        }

        private void btnRegresar_Click(object sender, EventArgs e) => this.Close();

        // Eventos del Designer
        private void dgvPagos_SelectionChanged(object sender, EventArgs e) { }
        private void btnEditar_Click(object sender, EventArgs e) { }
        private void btnEliminar_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}