using GYM_NoSql.Models;
using GYM_NoSql.controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GYM_NoSql.Views
{
    public partial class FormPlanes : Form
    {
        private readonly PlanController controller = new PlanController();
        private int? idPlanSeleccionado = null;
        private string placeholder = "Buscar por ID o nombre...";
        public FormPlanes()
        {
            InitializeComponent();
        }

        private void FormPlanes_Load(object sender, EventArgs e)
        {
            CargarPlanes();
            LimpiarCampos();
            txtBuscar.Text = placeholder;
            txtBuscar.ForeColor = System.Drawing.Color.Gray;
        }

        private void CargarPlanes()
        {
            try
            {
                List<Plan> lista = controller.ObtenerTodos();

                string textoBusqueda = txtBuscar.Text.Trim().ToLower();

                if (textoBusqueda == placeholder.ToLower())
                    textoBusqueda = "";

                string filtroEstado = cmbActivo.SelectedItem?.ToString() ?? "Todos";

                if (!string.IsNullOrWhiteSpace(textoBusqueda))
                {
                    lista = lista
    .Where(p =>
        p.Nombre != null && p.Nombre.ToLower().Contains(textoBusqueda)
        || p.Id_Plan.ToString().Contains(textoBusqueda))
    .ToList();
                }

                if (filtroEstado == "Activos")
                {
                    lista = lista.Where(p => p.Activo == "1").ToList();
                }
                else if (filtroEstado == "Inactivos")
                {
                    lista = lista.Where(p => p.Activo == "0").ToList();
                }

                dgvPlanes.DataSource = null;
                dgvPlanes.DataSource = lista.Select(p => new
                {
                    ID = p.Id_Plan,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Estado = p.Activo == "1" ? "Activo" : "Inactivo"
                }).ToList();

                if (dgvPlanes.Columns["ID"] != null)
                {
                    dgvPlanes.Columns["ID"].Visible = true;
                    dgvPlanes.Columns["ID"].HeaderText = "ID Plan";
                    dgvPlanes.Columns["ID"].DisplayIndex = 0;
                    dgvPlanes.Columns["ID"].Width = 80;
                }

                if (dgvPlanes.Columns["Nombre"] != null)
                    dgvPlanes.Columns["Nombre"].DisplayIndex = 1;

                if (dgvPlanes.Columns["Precio"] != null)
                    dgvPlanes.Columns["Precio"].DisplayIndex = 2;

                if (dgvPlanes.Columns["Estado"] != null)
                    dgvPlanes.Columns["Estado"].DisplayIndex = 3;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar planes: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos(out decimal precio)
        {
            precio = 0;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingresa el nombre del plan.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out precio) &&
                !decimal.TryParse(txtPrecio.Text.Trim(), out precio))
            {
                MessageBox.Show("Ingresa un precio válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }

            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }

            return true;
        }

       
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos(out decimal precio))
                    return;

                Plan nuevo = new Plan
                {
                    Nombre = txtNombre.Text.Trim(),
                    Precio = precio,
                    Activo = chkActivo.Checked ? "1" : "0"
                };

                controller.Agregar(nuevo);
                MessageBox.Show("Plan agregado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarPlanes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar plan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPlanSeleccionado == null)
                {
                    MessageBox.Show("Selecciona un plan para editar.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarCampos(out decimal precio))
                    return;

                Plan editado = new Plan
                {
                    Id_Plan = idPlanSeleccionado.Value,
                    Nombre = txtNombre.Text.Trim(),
                    Precio = precio,
                    Activo = chkActivo.Checked ? "1" : "0"
                };

                controller.Editar(editado);
                MessageBox.Show("Plan editado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarPlanes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar plan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPlanSeleccionado == null)
                {
                    MessageBox.Show("Selecciona un plan para eliminar.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    "¿Estás segura de eliminar este plan?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                controller.Eliminar(idPlanSeleccionado.Value);
                MessageBox.Show("Plan eliminado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarPlanes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar plan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            idPlanSeleccionado = null;
            txtNombre.Clear();
            txtPrecio.Clear();
            chkActivo.Checked = true;

            if (dgvPlanes.CurrentRow != null)
                dgvPlanes.ClearSelection();

            txtNombre.Focus();
        }

        private void dgvPlanes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlanes.CurrentRow == null || dgvPlanes.CurrentRow.Index < 0)
                return;

            try
            {
                var fila = dgvPlanes.CurrentRow;

                if (fila.Cells["ID"].Value == null)
                    return;

                idPlanSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString() ?? string.Empty;
                txtPrecio.Text = fila.Cells["Precio"].Value?.ToString() ?? string.Empty;

                string estado = fila.Cells["Estado"].Value?.ToString() ?? "Inactivo";
                chkActivo.Checked = estado == "Activo";
            }
            catch
            {
                // Evitamos que truene al cambiar datasource o limpiar selección
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == placeholder)
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = placeholder;
                txtBuscar.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarPlanes();
        }

        private void cmbActivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPlanes();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}