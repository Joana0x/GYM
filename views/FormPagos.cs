using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using GYM_NoSql.controllers;
using GYM_NoSql.Models;
using System.Drawing;

namespace GYM_NoSql.Views
{
    public partial class FormPagos : Form
    {

        private readonly PagoController controller = new PagoController();
        private int? idPagoSeleccionado = null;
        private DataTable dtPagosOriginal;
        string placeholder = "Buscar por ID o nombre...";


        public FormPagos()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FormPagos_Load(object sender, EventArgs e)
        {
            pnlDerecha.Left = this.ClientSize.Width - pnlDerecha.Width - 5;
            pnlDerecha.Height = this.ClientSize.Height - 55;
            dgvPagos.Width = this.ClientSize.Width - pnlDerecha.Width - 20;
            dgvPagos.Height = this.ClientSize.Height - 110;

            txtBuscar.Text = placeholder;
            txtBuscar.ForeColor = Color.Gray;

            txtMonto.ReadOnly = true;
            txtMonto.TabStop = false;

            btnEditar.Visible = false; // ocultamos editar
                                       // o si prefieres:
                                       // btnEditar.Enabled = false;

            CargarListaSocios();
            CargarPagos();
            LimpiarCampos();
        }
        private void CargarListaSocios()
        {
            try
            {
                DataTable dtSocios = controller.ObtenerSociosConPlan();

                cmbSocio.DataSource = null;
                cmbSocio.DisplayMember = "socio_display";
                cmbSocio.ValueMember = "id_socio";
                cmbSocio.DataSource = dtSocios;

                cmbSocio.DropDownStyle = ComboBoxStyle.DropDown;
                cmbSocio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbSocio.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbSocio.SelectedIndex = -1;
                txtMonto.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los socios: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPagos()
        {
            try
            {
                dtPagosOriginal = controller.ObtenerHistorialPagos();

                dgvPagos.DataSource = dtPagosOriginal;

                if (dgvPagos.Columns["id_socio"] != null)
                    dgvPagos.Columns["id_socio"].HeaderText = "ID Socio";

                if (dgvPagos.Columns["id_pago"] != null)
                    dgvPagos.Columns["id_pago"].HeaderText = "ID Pago";

                if (dgvPagos.Columns["socio"] != null)
                    dgvPagos.Columns["socio"].HeaderText = "Socio";

                if (dgvPagos.Columns["fecha_pago"] != null)
                    dgvPagos.Columns["fecha_pago"].HeaderText = "Fecha de Pago";

                if (dgvPagos.Columns["monto"] != null)
                    dgvPagos.Columns["monto"].HeaderText = "Monto";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pagos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarPagos()
        {
            try
            {
                if (dtPagosOriginal == null)
                    return;

                string texto = txtBuscar.Text.Trim();

                
                if (string.IsNullOrWhiteSpace(texto) || texto == placeholder)
                {
                    dgvPagos.DataSource = dtPagosOriginal;
                    return;
                }

                texto = texto.Replace("'", "''");

                DataView vista = dtPagosOriginal.DefaultView;

                vista.RowFilter = $@"
            Convert(id_pago, 'System.String') LIKE '%{texto}%'
            OR Convert(id_socio, 'System.String') LIKE '%{texto}%'
            OR socio LIKE '%{texto}%'
        ";

                dgvPagos.DataSource = vista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar pagos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSocio.SelectedIndex == -1 || cmbSocio.SelectedValue == null)
                {
                    MessageBox.Show("Selecciona un socio.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
                {
                    MessageBox.Show("No se pudo obtener un monto válido para el plan del socio.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idSocio = Convert.ToInt32(cmbSocio.SelectedValue);
                DateTime fechaPago = dtpFecha.Value.Date;

                if (!controller.PuedeRegistrarPago(idSocio, fechaPago, out DateTime? proximaFechaPermitida))
                {
                    MessageBox.Show(
                        $"Este socio aún tiene su mensualidad vigente.\n\nLa próxima fecha permitida para pagar es: {proximaFechaPermitida:dd/MM/yyyy}",
                        "Pago no permitido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                Pago nuevo = new Pago
                {
                    Id_Socio = idSocio,
                    Fecha_Pago = fechaPago,
                    Monto = monto
                };

                controller.Agregar(nuevo);

                MessageBox.Show("¡Pago registrado con éxito!", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarPagos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el pago: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPagoSeleccionado == null)
                {
                    MessageBox.Show("Selecciona un pago para eliminar.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Deseas eliminar este pago?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                controller.Eliminar(idPagoSeleccionado.Value);

                MessageBox.Show("Pago eliminado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarPagos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el pago: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSocio.SelectedValue == null || cmbSocio.SelectedValue is DataRowView)
                {
                    txtMonto.Clear();
                    return;
                }

                int idSocio = Convert.ToInt32(cmbSocio.SelectedValue);
                decimal monto = controller.ObtenerMontoPorSocio(idSocio);

                txtMonto.Text = monto > 0 ? monto.ToString("0.00") : string.Empty;
            }
            catch (Exception ex)
            {
                txtMonto.Clear();
                MessageBox.Show("Error al obtener el monto del plan: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            idPagoSeleccionado = null;
            txtMonto.Clear();
            dtpFecha.Value = DateTime.Now;
            cmbSocio.SelectedIndex = -1;

            if (dgvPagos.CurrentRow != null)
                dgvPagos.ClearSelection();

            txtMonto.Focus();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == placeholder)
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = placeholder;
                txtBuscar.ForeColor = Color.Gray;
            }
        }



        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
            FiltrarPagos();
        
    }
    }
}