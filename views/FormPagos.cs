using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GYM_NoSql.controllers;
using GYM_NoSql.Models;

namespace GYM_NoSql.Views
{
    public partial class FormPagos : Form
    {
        // El controlador ya está preparado para MongoDB
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
            // Ajustes de diseño
            pnlDerecha.Left = this.ClientSize.Width - pnlDerecha.Width - 5;
            pnlDerecha.Height = this.ClientSize.Height - 55;
            dgvPagos.Width = this.ClientSize.Width - pnlDerecha.Width - 20;
            dgvPagos.Height = this.ClientSize.Height - 110;

            txtBuscar.Text = placeholder;
            txtBuscar.ForeColor = Color.Gray;

            txtMonto.ReadOnly = true;
            txtMonto.TabStop = false;

            btnEditar.Visible = false; // Mantenemos oculto editar según tu lógica

            CargarListaSocios();
            CargarPagos();
            LimpiarCampos();
        }

        private void CargarListaSocios()
        {
            try
            {
                // Este método en el controlador ahora hace el "JOIN" en memoria de MongoDB
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
                MessageBox.Show("Error al cargar los socios desde MongoDB: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPagos()
        {
            try
            {
                // Obtiene el historial cruzando colecciones de MongoDB
                dtPagosOriginal = controller.ObtenerHistorialPagos();
                dgvPagos.DataSource = dtPagosOriginal;

                // Configuración de encabezados
                if (dgvPagos.Columns["id_pago"] != null) dgvPagos.Columns["id_pago"].HeaderText = "ID Pago";
                if (dgvPagos.Columns["id_socio"] != null) dgvPagos.Columns["id_socio"].HeaderText = "ID Socio";
                if (dgvPagos.Columns["socio"] != null) dgvPagos.Columns["socio"].HeaderText = "Socio";
                if (dgvPagos.Columns["fecha_pago"] != null) dgvPagos.Columns["fecha_pago"].HeaderText = "Fecha de Pago";
                if (dgvPagos.Columns["monto"] != null)
                {
                    dgvPagos.Columns["monto"].HeaderText = "Monto";
                    dgvPagos.Columns["monto"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial de MongoDB: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarPagos()
        {
            try
            {
                if (dtPagosOriginal == null) return;

                string texto = txtBuscar.Text.Trim();

                if (string.IsNullOrWhiteSpace(texto) || texto == placeholder)
                {
                    dgvPagos.DataSource = dtPagosOriginal;
                    return;
                }

                DataView vista = dtPagosOriginal.DefaultView;
                // El filtrado en memoria sigue siendo igual de efectivo
                vista.RowFilter = $@"
                    Convert(id_pago, 'System.String') LIKE '%{texto}%'
                    OR Convert(id_socio, 'System.String') LIKE '%{texto}%'
                    OR socio LIKE '%{texto}%'";

                dgvPagos.DataSource = vista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en filtro: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSocio.SelectedIndex == -1 || cmbSocio.SelectedValue == null)
                {
                    MessageBox.Show("Selecciona un socio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
                {
                    MessageBox.Show("Monto no válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idSocio = Convert.ToInt32(cmbSocio.SelectedValue);
                DateTime fechaPago = dtpFecha.Value.Date;

                // Validación de vigencia (ahora consulta la colección 'pagos' en MongoDB)
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

                MessageBox.Show("¡Pago registrado en MongoDB!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarPagos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Si sigue saliendo el mensaje, es que idPagoSeleccionado sigue siendo null
            if (idPagoSeleccionado == null)
            {
                MessageBox.Show("El sistema no detecta el ID del pago. Intenta hacer clic en otra fila y regresar a esta.", "Error de Selección");
                return;
            }

            if (MessageBox.Show("¿Seguro que quieres eliminar el pago #" + idPagoSeleccionado + "?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                controller.Eliminar(idPagoSeleccionado.Value);
                CargarPagos();
                LimpiarCampos();
            }
        }

        private void cmbSocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificación extra para evitar que intente leer mientras el combo se está llenando
            if (cmbSocio.SelectedValue == null || cmbSocio.SelectedValue is DataRowView)
            {
                txtMonto.Clear();
                return;
            }

            try
            {
                // Busca el precio del plan asociado al socio en MongoDB
                int idSocio = Convert.ToInt32(cmbSocio.SelectedValue);
                decimal monto = controller.ObtenerMontoPorSocio(idSocio);
                txtMonto.Text = monto.ToString("0.00");
            }
            catch
            {
                txtMonto.Clear();
            }
        }

        private void dgvPagos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow != null && dgvPagos.CurrentRow.Index >= 0)
            {
                try
                {
                    // Intentamos por nombre primero
                    if (dgvPagos.Columns.Contains("id_pago") && dgvPagos.CurrentRow.Cells["id_pago"].Value != null)
                    {
                        idPagoSeleccionado = Convert.ToInt32(dgvPagos.CurrentRow.Cells["id_pago"].Value);
                    }
                    // Si falla, intentamos por la PRIMERA COLUMNA (índice 0) que es donde está el ID Pago
                    else if (dgvPagos.CurrentRow.Cells[0].Value != null)
                    {
                        idPagoSeleccionado = Convert.ToInt32(dgvPagos.CurrentRow.Cells[0].Value);
                    }

                    Console.WriteLine("ID Capturado: " + idPagoSeleccionado);
                }
                catch (Exception ex)
                {
                    idPagoSeleccionado = null;
                    Console.WriteLine("Error al capturar selección: " + ex.Message);
                }
            }
        }

        private void LimpiarCampos()
        {
            idPagoSeleccionado = null;
            txtMonto.Clear();
            dtpFecha.Value = DateTime.Now;
            cmbSocio.SelectedIndex = -1;

            if (dgvPagos.DataSource != null)
                dgvPagos.ClearSelection();

            cmbSocio.Focus();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == placeholder) { txtBuscar.Text = ""; txtBuscar.ForeColor = Color.Black; }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text)) { txtBuscar.Text = placeholder; txtBuscar.ForeColor = Color.Gray; }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) => FiltrarPagos();

        private void btnRegresar_Click(object sender, EventArgs e) => this.Close();

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCampos();
    }
}