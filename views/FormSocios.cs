using GYM_NoSql.Models;
using Oracle.ManagedDataAccess.Client;
using Proyecto_GYM.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace GYM_NoSql.Views
{
    public partial class FormSocios : Form
    {
        OracleDbHelper db = new OracleDbHelper();

        public FormSocios()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FormSocios_Load(object sender, EventArgs e)
        {
            // Ajuste de diseño (asegúrate que los nombres pnlDerecha y dgvSocios coincidan)
            pnlDerecha.Left = this.ClientSize.Width - pnlDerecha.Width - 5;
            pnlDerecha.Height = this.ClientSize.Height - 55;
            dgvSocios.Width = this.ClientSize.Width - pnlDerecha.Width - 20;
            dgvSocios.Height = this.ClientSize.Height - 110;

            // Carga inicial
            CargarPlanes();
            ListarSocios();
        }

        // 1. Llenar el ComboBox de Planes (comboBox1)
        private void CargarPlanes()
        {
            try
            {
                string sql = "SELECT ID_PLAN, NOMBRE FROM PLANES WHERE ACTIVO = '1' ORDER BY NOMBRE ASC";
                DataTable dt = db.ExecuteQuery(sql);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "NOMBRE";
                comboBox1.ValueMember = "ID_PLAN";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar planes: " + ex.Message);
            }
        }

        // 2. Mostrar socios en el Grid con el nombre del Plan (JOIN)
        private void ListarSocios()
        {
            try
            {
                string sql = @"SELECT S.ID_SOCIO, S.NOMBRE, S.PRIMER_APELLIDO, S.SEGUNDO_APELLIDO, 
                               S.TELEFONO, S.SEXO, S.FECHA_REGISTRO, P.NOMBRE AS PLAN
                               FROM SOCIOS S
                               JOIN PLANES P ON S.ID_PLAN = P.ID_PLAN
                               ORDER BY S.ID_SOCIO DESC";
                dgvSocios.DataSource = db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar socios: " + ex.Message);
            }
        }

        // 3. Botón Agregar Socio
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un plan para el socio.");
                    return;
                }

                string sql = @"INSERT INTO SOCIOS (ID_PLAN, NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO, TELEFONO, SEXO, FECHA_REGISTRO) 
                               VALUES (:id_p, :nom, :ape1, :ape2, :tel, :sex, :fec)";

                // Asumimos que tienes ComboBox para Sexo o usas el primer caracter de un TextBox
                // Si usas un ComboBox para sexo llamado cmbSexo:
                string genero = txtSexo.Text.Length > 0 ? txtSexo.Text.Substring(0, 1).ToUpper() : "M";

                OracleParameter[] parametros = {
                    new OracleParameter("id_p", comboBox1.SelectedValue),
                    new OracleParameter("nom", txtNombre.Text),
                    new OracleParameter("ape1", txtApellido1.Text),
                    new OracleParameter("ape2", txtApellido2.Text),
                    new OracleParameter("tel", txtTelefono.Text),
                    new OracleParameter("sex", genero),
                    new OracleParameter("fec", DateTime.Now.Date)
                };

                if (db.ExecuteNonQuery(sql, parametros) > 0)
                {
                    MessageBox.Show("Socio registrado con éxito.");
                    ListarSocios();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message);
            }
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido1.Clear();
            txtApellido2.Clear();
            txtTelefono.Clear();
            txtSexo.Clear();
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => Limpiar();

        private void btnRegresar_Click(object sender, EventArgs e) => this.Close();

        // Eventos para el Designer
        private void dgvSocios_SelectionChanged(object sender, EventArgs e) { }
        private void btnEditar_Click(object sender, EventArgs e) { }
        private void btnEliminar_Click(object sender, EventArgs e) { }
    }
}