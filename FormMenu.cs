using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GYM_NoSql.Views;

namespace GYM_NoSql
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        // Método reutilizable para abrir cualquier form
        private void AbrirForm(Form form)
        {
            this.Hide();
            form.WindowState = FormWindowState.Maximized;
            form.FormClosed += (s, e) => {
                this.Show();
                this.WindowState = FormWindowState.Maximized;
            };
            form.Show();
        }

        private void btnSocios_Click(object sender, EventArgs e)
            => AbrirForm(new FormSocios());

        private void btnPlanes_Click(object sender, EventArgs e)
            => AbrirForm(new FormPlanes());

        private void btnMembresias_Click(object sender, EventArgs e)
            => AbrirForm(new FormMembresias());

        private void btnPagos_Click(object sender, EventArgs e)
            => AbrirForm(new FormPagos());

        private void FormMenu_Load(object sender, EventArgs e)
        {
            pnlBotones.Left = (this.ClientSize.Width - pnlBotones.Width) / 2;
            pnlBotones.Top = (this.ClientSize.Height - pnlBotones.Height) / 2 + 40;
        }
    }
}
