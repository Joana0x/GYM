using GYM_NoSql.Views;
using System.Windows.Forms;
using System;

namespace GYM_NoSql
{
    partial class FormMenu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.btnSocios = new System.Windows.Forms.Button();
            this.btnPlanes = new System.Windows.Forms.Button();
            this.btnPagos = new System.Windows.Forms.Button();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Text = "Sistema de Gimnasio";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Height = 80;

            // lblSubtitulo
            this.lblSubtitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(180, 200, 180);
            this.lblSubtitulo.Text = "GYM-NoSql";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitulo.Height = 30;

            // btnSocios
            this.btnSocios.Text = "Socios";
            this.btnSocios.Size = new System.Drawing.Size(260, 55);
            this.btnSocios.Location = new System.Drawing.Point(0, 0);
            this.btnSocios.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSocios.BackColor = System.Drawing.Color.White;
            this.btnSocios.ForeColor = System.Drawing.Color.FromArgb(27, 94, 32);
            this.btnSocios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSocios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(27, 94, 32);
            this.btnSocios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSocios.Click += new System.EventHandler(this.btnSocios_Click);

            // btnPlanes
            this.btnPlanes.Text = "Planes";
            this.btnPlanes.Size = new System.Drawing.Size(260, 55);
            this.btnPlanes.Location = new System.Drawing.Point(0, 65);
            this.btnPlanes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPlanes.BackColor = System.Drawing.Color.White;
            this.btnPlanes.ForeColor = System.Drawing.Color.FromArgb(27, 94, 32);
            this.btnPlanes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlanes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(27, 94, 32);
            this.btnPlanes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlanes.Click += new System.EventHandler(this.btnPlanes_Click);

            // btnPagos
            this.btnPagos.Text = "Pagos";
            this.btnPagos.Size = new System.Drawing.Size(260, 55);
            this.btnPagos.Location = new System.Drawing.Point(0, 130);
            this.btnPagos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPagos.BackColor = System.Drawing.Color.White;
            this.btnPagos.ForeColor = System.Drawing.Color.FromArgb(27, 94, 32);
            this.btnPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(27, 94, 32);
            this.btnPagos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagos.Click += new System.EventHandler(this.btnPagos_Click);

            // pnlBotones
            this.pnlBotones.Size = new System.Drawing.Size(260, 195);
            this.pnlBotones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBotones.BackColor = System.Drawing.Color.Transparent;
            this.pnlBotones.Controls.Add(this.btnSocios);
            this.pnlBotones.Controls.Add(this.btnPlanes);
            this.pnlBotones.Controls.Add(this.btnPagos);

            // FormMenu
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.BackColor = System.Drawing.Color.FromArgb(69, 90, 73);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormMenu";
            this.Text = "Sistema de Gimnasio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnSocios;
        private System.Windows.Forms.Button btnPlanes;
        private System.Windows.Forms.Button btnPagos;
        private System.Windows.Forms.Panel pnlBotones;
    }
}