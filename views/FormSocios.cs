using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GYM_NoSql.Views
{
    public partial class FormSocios : Form
    {
        public FormSocios()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        private void FormSocios_Load(object sender, EventArgs e)
        {
            pnlDerecha.Left = this.ClientSize.Width - pnlDerecha.Width - 5;
            pnlDerecha.Height = this.ClientSize.Height - 55;
            dgvSocios.Width = this.ClientSize.Width - pnlDerecha.Width - 20;
            dgvSocios.Height = this.ClientSize.Height - 110;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
            => this.Close();

        private void dgvSocios_SelectionChanged(object sender, EventArgs e) { }
        private void btnAgregar_Click(object sender, EventArgs e) { }
        private void btnEditar_Click(object sender, EventArgs e) { }
        private void btnEliminar_Click(object sender, EventArgs e) { }
        private void btnLimpiar_Click(object sender, EventArgs e) { }
    }
}