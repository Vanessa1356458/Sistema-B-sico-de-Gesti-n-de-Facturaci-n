using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Básico_de_Gestión_de_Facturación
{
    public partial class FormMenuPrincipalcs : Form
    {
        public FormMenuPrincipalcs()
        {
            InitializeComponent();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnVendedores = new System.Windows.Forms.Button();
            this.btnFacturacion = new System.Windows.Forms.Button();
            this.btnConsultarFacturas = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblEstadoConexion = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(100, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Sistema de Gestión de Facturación";

            // btnClientes
            this.btnClientes.Font = new System.Drawing.Font("Arial", 12F);
            this.btnClientes.Location = new System.Drawing.Point(150, 80);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(300, 50);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Gestionar Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);

            // btnProductos
            this.btnProductos.Font = new System.Drawing.Font("Arial", 12F);
            this.btnProductos.Location = new System.Drawing.Point(150, 140);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(300, 50);
            this.btnProductos.TabIndex = 2;
            this.btnProductos.Text = "Gestionar Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);

            // btnVendedores
            this.btnVendedores.Font = new System.Drawing.Font("Arial", 12F);
            this.btnVendedores.Location = new System.Drawing.Point(150, 200);
            this.btnVendedores.Name = "btnVendedores";
            this.btnVendedores.Size = new System.Drawing.Size(300, 50);
            this.btnVendedores.TabIndex = 3;
            this.btnVendedores.Text = "Gestionar Vendedores";
            this.btnVendedores.UseVisualStyleBackColor = true;
            this.btnVendedores.Click += new System.EventHandler(this.btnVendedores_Click);

            // btnFacturacion
            this.btnFacturacion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnFacturacion.Location = new System.Drawing.Point(150, 260);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Size = new System.Drawing.Size(300, 50);
            this.btnFacturacion.TabIndex = 4;
            this.btnFacturacion.Text = "Nueva Factura";
            this.btnFacturacion.UseVisualStyleBackColor = true;
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click);

            // btnConsultarFacturas
            this.btnConsultarFacturas.Font = new System.Drawing.Font("Arial", 12F);
            this.btnConsultarFacturas.Location = new System.Drawing.Point(150, 320);
            this.btnConsultarFacturas.Name = "btnConsultarFacturas";
            this.btnConsultarFacturas.Size = new System.Drawing.Size(300, 50);
            this.btnConsultarFacturas.TabIndex = 5;
            this.btnConsultarFacturas.Text = "Consultar Facturas";
            this.btnConsultarFacturas.UseVisualStyleBackColor = true;
            this.btnConsultarFacturas.Click += new System.EventHandler(this.btnConsultarFacturas_Click);

            // btnSalir
            this.btnSalir.Font = new System.Drawing.Font("Arial", 12F);
            this.btnSalir.Location = new System.Drawing.Point(150, 400);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(300, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // lblEstadoConexion
            this.lblEstadoConexion.AutoSize = true;
            this.lblEstadoConexion.Location = new System.Drawing.Point(250, 470);
            this.lblEstadoConexion.Name = "lblEstadoConexion";
            this.lblEstadoConexion.Size = new System.Drawing.Size(100, 13);
            this.lblEstadoConexion.TabIndex = 7;
            this.lblEstadoConexion.Text = "Verificando conexión...";

            // FormMenuPrincipal
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.lblEstadoConexion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConsultarFacturas);
            this.Controls.Add(this.btnFacturacion);
            this.Controls.Add(this.btnVendedores);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Facturación - Menú Principal";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnVendedores;
        private System.Windows.Forms.Button btnFacturacion;
        private System.Windows.Forms.Button btnConsultarFacturas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblEstadoConexion;
        


        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            formClientes.ShowDialog();
        }
        private void btnProductos_Click(object sender, EventArgs e)
        {
            FormProductos formProductos = new FormProductos();
            formProductos.ShowDialog();
        }
        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            FormPocesarPago formFacturacion = new FormPocesarPago();
            formFacturacion.ShowDialog();
        }
        private void btnConsultarFacturas_Click(object sender, EventArgs e)
        {
            FormConsultarFacturas formConsultar = new FormConsultarFacturas();
            formConsultar.ShowDialog();
        }
        private void btnVendedores_Click(object sender, EventArgs e)
        {
            FormVendedores formVendedores = new FormVendedores();
            formVendedores.ShowDialog();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del sistema?", "Confirmar Salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }    
    }
}

