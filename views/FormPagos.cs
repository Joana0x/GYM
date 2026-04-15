using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client; // Para conectarnos a Oracle
using System.Configuration;           // Para leer el App.config

namespace GYM_NoSql.Views
{
    public partial class FormPagos : Form
    {
        // Jalamos la cadena de conexión de tu archivo de configuración
        string connectionString = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        public FormPagos()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FormPagos_Load(object sender, EventArgs e)
        {
            // Ajustamos el diseño responsivo (asumiendo que tus paneles se llaman igual que en Socios)
            // Si te marca error aquí, es porque los paneles en tu diseño tienen otro nombre.
            // Si es así, puedes comentar estas 4 líneas por ahora.
            pnlDerecha.Left = this.ClientSize.Width - pnlDerecha.Width - 5;
            pnlDerecha.Height = this.ClientSize.Height - 55;
            dgvPagos.Width = this.ClientSize.Width - pnlDerecha.Width - 20;
            dgvPagos.Height = this.ClientSize.Height - 110;

            // Llenamos la lista de socios al abrir la ventana
            CargarListaSocios();
        }

        private void CargarListaSocios()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Concatenamos el nombre y el apellido para que se vea completo en la lista
                    string sql = "SELECT id_socio, (nombre || ' ' || primer_apellido) AS nombre_completo FROM socios";

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataTable dtSocios = new DataTable();
                    da.Fill(dtSocios);

                    // Configuramos el Data Binding (Lo que explicamos en el widget anterior)
                    cmbSocio.DataSource = dtSocios;
                    cmbSocio.DisplayMember = "nombre_completo"; // Lo que lee el usuario
                    cmbSocio.ValueMember = "id_socio";          // El número que se manda a Oracle
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los socios: " + ex.Message);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validamos que el monto sea un número válido antes de intentar guardar
            if (!decimal.TryParse(txtMonto.Text, out decimal monto))
            {
                MessageBox.Show("Por favor, ingresa un monto válido con números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO pagos (id_socio, fecha_pago, monto) VALUES (:idSocio, :fecha, :monto)";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        // Enlazamos los valores
                        cmd.Parameters.Add("idSocio", cmbSocio.SelectedValue);
                        cmd.Parameters.Add("fecha", dtpFecha.Value);
                        cmd.Parameters.Add("monto", monto);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("¡Pago registrado con éxito!", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiamos la caja de monto
                        txtMonto.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e) => this.Close();

        // Métodos vacíos listos para programarse después
        private void btnEditar_Click(object sender, EventArgs e) { }
        private void btnEliminar_Click(object sender, EventArgs e) { }
        private void btnLimpiar_Click(object sender, EventArgs e) { txtMonto.Clear(); }
    }
}