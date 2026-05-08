using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using GYM_NoSql.controllers;
using GYM_NoSql.Models;

namespace GYM_NoSql.Views
{
    public partial class FormSocios : Form
    {
        // Instancia de los controladores para MongoDB
        private SocioController socioCtrl = new SocioController();
        private PlanController planCtrl = new PlanController();
        // Nota: Puedes crear un SexoController similar al de PlanController
        private SexoController sexoCtrl = new SexoController();

        int idSocioSeleccionado = 0;
        bool cargandoDatos = false;

        public FormSocios()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            // Suscripción de eventos
            this.btnAgregar.Click += btnAgregar_Click;
            this.btnEditar.Click += btnEditar_Click;
            this.btnEliminar.Click += btnEliminar_Click;
            this.btnLimpiar.Click += btnLimpiar_Click;
            this.dgvSocios.SelectionChanged += dgvSocios_SelectionChanged;
        }

        private void FormSocios_Load(object sender, EventArgs e)
        {
            // Ajuste visual
            pnlDerecha.Left = this.ClientSize.Width - pnlDerecha.Width - 5;
            pnlDerecha.Height = this.ClientSize.Height - 55;
            dgvSocios.Width = this.ClientSize.Width - pnlDerecha.Width - 20;
            dgvSocios.Height = this.ClientSize.Height - 110;

            dtpFecha.Enabled = false;

            ConfigurarFiltrosBusqueda();
            CargarListasRegistro();
            RefrescarTabla();
        }

        private void ConfigurarFiltrosBusqueda()
        {
            cargandoDatos = true;

            // 1. Filtro de Planes
            var planes = planCtrl.ObtenerTodos();
            DataTable dtFiltroPlan = new DataTable();
            dtFiltroPlan.Columns.Add("Nombre");
            dtFiltroPlan.Rows.Add("Todos");
            foreach (var p in planes) dtFiltroPlan.Rows.Add(p.Nombre);

            cmbPlan.DataSource = dtFiltroPlan;
            cmbPlan.DisplayMember = "Nombre";
            cmbPlan.ValueMember = "Nombre";

            // 2. Filtro de Estado
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new string[] { "Todos", "Activos", "Inactivos" });
            cmbEstado.SelectedIndex = 0;

            cargandoDatos = false;
        }

        private void CargarListasRegistro()
        {
            // Cargar Combo Sexos
            var listaSexos = sexoCtrl.ObtenerTodos();
            cmbSexo.DataSource = listaSexos;
            cmbSexo.DisplayMember = "Descripcion";
            cmbSexo.ValueMember = "Id_Sexo";

            // Cargar Combo Planes
            var listaPlanes = planCtrl.ObtenerTodos();
            cmbPlanRegistro.DataSource = listaPlanes;
            cmbPlanRegistro.DisplayMember = "Nombre";
            cmbPlanRegistro.ValueMember = "Id_Plan";
        }

        private void RefrescarTabla()
        {
            if (cargandoDatos) return;

            string busqueda = txtBuscarNombre.Text.Trim();
            string filtroPlan = cmbPlan.Text;
            string filtroEstado = cmbEstado.Text;

            dgvSocios.DataSource = socioCtrl.ObtenerSociosFiltrados(busqueda, filtroPlan, filtroEstado);

            if (dgvSocios.Columns["Precio"] != null)
                dgvSocios.Columns["Precio"].DefaultCellStyle.Format = "C2";

            dgvSocios.ClearSelection();
            LimpiarCajas();
        }

        private void txtBuscarNombre_TextChanged(object sender, EventArgs e) => RefrescarTabla();
        private void cmbPlan_SelectedIndexChanged(object sender, EventArgs e) => RefrescarTabla();
        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e) => RefrescarTabla();

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
            if (cargandoDatos || dgvSocios.CurrentRow == null) return;

            var fila = dgvSocios.CurrentRow;
            if (fila.Cells["ID Socio"].Value != null)
            {
                idSocioSeleccionado = Convert.ToInt32(fila.Cells["ID Socio"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
                txtPrimerAp.Text = fila.Cells["Paterno"].Value?.ToString();
                txtSegundoAp.Text = fila.Cells["Materno"].Value?.ToString();
                txtTelefono.Text = fila.Cells["Teléfono"].Value?.ToString();
                cmbSexo.Text = fila.Cells["Sexo"].Value?.ToString();
                cmbPlanRegistro.Text = fila.Cells["Plan"].Value?.ToString();
                dtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text)) return;

            var nuevoSocio = new Socio
            {
                Id_Plan = (int)cmbPlanRegistro.SelectedValue,
                Id_Sexo = (int)cmbSexo.SelectedValue,
                Nombre = txtNombre.Text,
                Primer_Apellido = txtPrimerAp.Text,
                Segundo_Apellido = txtSegundoAp.Text,
                Telefono = txtTelefono.Text,
                Fecha_Registro = DateTime.Now,
                Activo = "1"
            };

            socioCtrl.Agregar(nuevoSocio);
            MessageBox.Show("Socio registrado en MongoDB");
            RefrescarTabla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSocioSeleccionado == 0) return;

            var socioEditado = new Socio
            {
                Id_Socio = idSocioSeleccionado,
                Id_Plan = (int)cmbPlanRegistro.SelectedValue,
                Id_Sexo = (int)cmbSexo.SelectedValue,
                Nombre = txtNombre.Text,
                Primer_Apellido = txtPrimerAp.Text,
                Segundo_Apellido = txtSegundoAp.Text,
                Telefono = txtTelefono.Text,
                Fecha_Registro = dtpFecha.Value
            };

            socioCtrl.Editar(socioEditado);
            MessageBox.Show("Socio actualizado");
            RefrescarTabla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSocioSeleccionado == 0) return;

            var res = MessageBox.Show("¿Eliminar socio?", "Confirmar", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                socioCtrl.Eliminar(idSocioSeleccionado);
                RefrescarTabla();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCajas();
        private void btnRegresar_Click(object sender, EventArgs e) => this.Close();
    }
}