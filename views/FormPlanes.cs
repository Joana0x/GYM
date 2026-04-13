using GYM_NoSql.Models;
using Oracle.ManagedDataAccess.Client;
using Proyecto_GYM.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace GYM_NoSql.Views
{
    public partial class FormPlanes : Form
    {
        OracleDbHelper db = new OracleDbHelper();
        // Variable para saber qué ID estamos editando
        private string idSeleccionado = "";

        public FormPlanes()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FormPlanes_Load(object sender, EventArgs e)
        {
            pnlDerecha.Left = this.ClientSize.Width - pnlDerecha.Width - 5;
            pnlDerecha.Height = this.ClientSize.Height - 55;
            dgvPlanes.Width = this.ClientSize.Width - pnlDerecha.Width - 20;
            dgvPlanes.Height = this.ClientSize.Height - 110;

            CargarPlanes();
        }

        private void CargarPlanes()
        {
            try
            {
                string sql = "SELECT ID_PLAN, NOMBRE, PRECIO, ACTIVO FROM PLANES ORDER BY ID_PLAN DESC";
                dgvPlanes.DataSource = db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO PLANES (NOMBRE, PRECIO, ACTIVO) VALUES (:nombre, :precio, :activo)";
                OracleParameter[] parametros = {
                    new OracleParameter("nombre", txtNombre.Text),
                    new OracleParameter("precio", Convert.ToDecimal(txtPrecio.Text)),
                    new OracleParameter("activo", "1")
                };

                if (db.ExecuteNonQuery(sql, parametros) > 0)
                {
                    MessageBox.Show("Plan guardado correctamente.");
                    CargarPlanes();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        // Lógica para seleccionar un renglón y cargar los datos en los cuadros de texto
        private void dgvPlanes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlanes.SelectedRows.Count > 0)
            {
                idSeleccionado = dgvPlanes.CurrentRow.Cells["ID_PLAN"].Value.ToString();
                txtNombre.Text = dgvPlanes.CurrentRow.Cells["NOMBRE"].Value.ToString();
                txtPrecio.Text = dgvPlanes.CurrentRow.Cells["PRECIO"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idSeleccionado)) return;

            try
            {
                string sql = "UPDATE PLANES SET NOMBRE = :nom, PRECIO = :pre WHERE ID_PLAN = :id";
                OracleParameter[] parametros = {
                    new OracleParameter("nom", txtNombre.Text),
                    new OracleParameter("pre", Convert.ToDecimal(txtPrecio.Text)),
                    new OracleParameter("id", idSeleccionado)
                };

                if (db.ExecuteNonQuery(sql, parametros) > 0)
                {
                    MessageBox.Show("Plan actualizado.");
                    CargarPlanes();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idSeleccionado)) return;

            var confirm = MessageBox.Show("¿Seguro que quieres eliminar este plan?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM PLANES WHERE ID_PLAN = :id";
                    OracleParameter[] p = { new OracleParameter("id", idSeleccionado) };

                    db.ExecuteNonQuery(sql, p);
                    CargarPlanes();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede eliminar porque hay socios usando este plan.");
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            idSeleccionado = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCampos();
        private void btnRegresar_Click(object sender, EventArgs e) => this.Close();
    }
}