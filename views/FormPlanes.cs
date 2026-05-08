using GYM_NoSql.Models;
using GYM_NoSql.controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace GYM_NoSql.Views
{
    public partial class FormPlanes : Form
    {
        // El controlador ya utiliza MongoDbContext internamente
        private readonly PlanController controller = new PlanController();
        private int? idPlanSeleccionado = null;
        private string placeholder = "Buscar por ID o nombre...";

        public FormPlanes()
        {
            InitializeComponent();
            // Aseguramos que el formulario se vea bien en cualquier resolución
            this.WindowState = FormWindowState.Maximized;
        }

        private void FormPlanes_Load(object sender, EventArgs e)
        {
            // Ajustes visuales de los paneles (similares a tus otros forms)
            pnlDerecha.Left = this.ClientSize.Width - pnlDerecha.Width - 5;
            pnlDerecha.Height = this.ClientSize.Height - 55;
            dgvPlanes.Width = this.ClientSize.Width - pnlDerecha.Width - 20;
            dgvPlanes.Height = this.ClientSize.Height - 110;

            txtBuscar.Text = placeholder;
            txtBuscar.ForeColor = Color.Gray;

            // Cargar el combo de estado por defecto
            if (cmbActivo.Items.Count == 0)
            {
                cmbActivo.Items.AddRange(new string[] { "Todos", "Activos", "Inactivos" });
                cmbActivo.SelectedIndex = 0;
            }

            CargarPlanes();
            LimpiarCampos();
        }

        private void CargarPlanes()
        {
            try
            {
                // Obtenemos la lista desde MongoDB
                List<Plan> lista = controller.ObtenerTodos();

                string textoBusqueda = txtBuscar.Text.Trim().ToLower();
                if (textoBusqueda == placeholder.ToLower()) textoBusqueda = "";

                string filtroEstado = cmbActivo.SelectedItem?.ToString() ?? "Todos";

                // Filtrado en memoria usando LINQ (muy eficiente en NoSQL)
                if (!string.IsNullOrWhiteSpace(textoBusqueda))
                {
                    lista = lista.Where(p =>
                        (p.Nombre != null && p.Nombre.ToLower().Contains(textoBusqueda)) ||
                        p.Id_Plan.ToString().Contains(textoBusqueda)
                    ).ToList();
                }

                if (filtroEstado == "Activos")
                {
                    lista = lista.Where(p => p.Activo == "1").ToList();
                }
                else if (filtroEstado == "Inactivos")
                {
                    lista = lista.Where(p => p.Activo == "0").ToList();
                }

                // Proyectamos a un tipo anónimo para que el DataGridView muestre lo que queremos
                dgvPlanes.DataSource = null;
                dgvPlanes.DataSource = lista.Select(p => new
                {
                    ID = p.Id_Plan,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Estado = p.Activo == "1" ? "Activo" : "Inactivo"
                }).ToList();

                ConfigurarColumnasGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar planes desde MongoDB: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrid()
        {
            if (dgvPlanes.Columns["ID"] != null)
            {
                dgvPlanes.Columns["ID"].HeaderText = "ID Plan";
                dgvPlanes.Columns["ID"].Width = 80;
            }

            if (dgvPlanes.Columns["Precio"] != null)
            {
                dgvPlanes.Columns["Precio"].DefaultCellStyle.Format = "C2"; // Formato Moneda
            }

            dgvPlanes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private bool ValidarCampos(out decimal precio)
        {
            precio = 0;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingresa el nombre del plan.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            // Validación robusta de moneda
            if (!decimal.TryParse(txtPrecio.Text.Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out precio))
            {
                MessageBox.Show("Ingresa un precio numérico válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }

            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos(out decimal precio)) return;

                Plan nuevo = new Plan
                {
                    Nombre = txtNombre.Text.Trim(),
                    Precio = precio,
                    Activo = chkActivo.Checked ? "1" : "0"
                };

                controller.Agregar(nuevo);
                MessageBox.Show("Plan guardado en MongoDB.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarPlanes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPlanSeleccionado == null)
                {
                    MessageBox.Show("Selecciona un plan de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarCampos(out decimal precio)) return;

                Plan editado = new Plan
                {
                    Id_Plan = idPlanSeleccionado.Value,
                    Nombre = txtNombre.Text.Trim(),
                    Precio = precio,
                    Activo = chkActivo.Checked ? "1" : "0"
                };

                controller.Editar(editado);
                MessageBox.Show("Plan actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarPlanes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPlanSeleccionado == null) return;

                DialogResult confirmacion = MessageBox.Show("¿Eliminar este plan de MongoDB?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    controller.Eliminar(idPlanSeleccionado.Value);
                    CargarPlanes();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            idPlanSeleccionado = null;
            txtNombre.Clear();
            txtPrecio.Clear();
            chkActivo.Checked = true;
            if (dgvPlanes.CurrentRow != null) dgvPlanes.ClearSelection();
            txtNombre.Focus();
        }

        private void dgvPlanes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlanes.CurrentRow == null || dgvPlanes.CurrentRow.Index < 0) return;

            try
            {
                var fila = dgvPlanes.CurrentRow;
                idPlanSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value?.ToString();
                chkActivo.Checked = fila.Cells["Estado"].Value?.ToString() == "Activo";
            }
            catch { /* Silenciar errores de casteo temporal durante recarga */ }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == placeholder) { txtBuscar.Text = ""; txtBuscar.ForeColor = Color.Black; }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text)) { txtBuscar.Text = placeholder; txtBuscar.ForeColor = Color.Gray; }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) => CargarPlanes();

        private void cmbActivo_SelectedIndexChanged(object sender, EventArgs e) => CargarPlanes();

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCampos();

        private void btnRegresar_Click(object sender, EventArgs e) => this.Close();
    }
}