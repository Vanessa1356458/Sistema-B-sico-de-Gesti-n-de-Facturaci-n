using Sistema_Básico_de_Gestión_de_Facturación.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Básico_de_Gestión_de_Facturación
{
    public partial class FormClientes : Form
    {
        private ConexionBD conexion;
        private int clienteSeleccionado = 0;
        public FormClientes()
        {
            InitializeComponent();
            conexion = new ConexionBD();
            CargarClientes();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(300, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 26);
            this.lblTitulo.Text = "Gestión de Clientes";

            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 50);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 13);
            this.lblNombre.Text = "Nombre:";

            // txtNombre
            this.txtNombre.Location = new System.Drawing.Point(120, 47);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);

            // lblApellido
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(20, 80);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(50, 13);
            this.lblApellido.Text = "Apellido:";

            // txtApellido
            this.txtApellido.Location = new System.Drawing.Point(120, 77);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(200, 20);

            // lblIdentificacion
            this.lblIdentificacion.AutoSize = true;
            this.lblIdentificacion.Location = new System.Drawing.Point(20, 110);
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Size = new System.Drawing.Size(80, 13);
            this.lblIdentificacion.Text = "Identificación:";

            // txtIdentificacion
            this.txtIdentificacion.Location = new System.Drawing.Point(120, 107);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(200, 20);

            // lblTelefono
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(350, 50);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(55, 13);
            this.lblTelefono.Text = "Teléfono:";

            // txtTelefono
            this.txtTelefono.Location = new System.Drawing.Point(450, 47);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 20);

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(350, 80);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(450, 77);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);

            // lblDireccion
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(350, 110);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(58, 13);
            this.lblDireccion.Text = "Dirección:";

            // txtDireccion
            this.txtDireccion.Location = new System.Drawing.Point(450, 107);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(200, 20);

            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(120, 145);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnEliminar
            this.btnEliminar.Location = new System.Drawing.Point(230, 145);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // btnLimpiar
            this.btnLimpiar.Location = new System.Drawing.Point(340, 145);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 30);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // lblBuscar
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(20, 195);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(43, 13);
            this.lblBuscar.Text = "Buscar:";

            // txtBuscar
            this.txtBuscar.Location = new System.Drawing.Point(120, 192);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(400, 20);

            // btnBuscar
            this.btnBuscar.Location = new System.Drawing.Point(530, 190);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 23);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            // dgvClientes
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(20, 230);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(750, 250);
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick);

            // FormClientes
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtIdentificacion);
            this.Controls.Add(this.lblIdentificacion);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblIdentificacion;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        
        private void CargarClientes()
        {
            string query = "SELECT ClienteID, Nombre, Apellido, Identificacion, Telefono, Email, Direccion FROM Clientes WHERE Estado = 1";
            DataTable dt = conexion.EjecutarConsulta(query);
            dgvClientes.DataSource = dt;
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtIdentificacion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            clienteSeleccionado = 0;
            btnGuardar.Text = "Guardar";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtIdentificacion.Text))
            {
                MessageBox.Show("Nombre e Identificación son obligatorios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clienteSeleccionado == 0) // Insertar nuevo
            {
                string query = @"INSERT INTO Clientes (Nombre, Apellido, Identificacion, Telefono, Email, Direccion) 
                                VALUES (@Nombre, @Apellido, @Identificacion, @Telefono, @Email, @Direccion)";

                SqlParameter[] parametros = {
                    new SqlParameter("@Nombre", txtNombre.Text),
                    new SqlParameter("@Apellido", txtApellido.Text),
                    new SqlParameter("@Identificacion", txtIdentificacion.Text),
                    new SqlParameter("@Telefono", txtTelefono.Text),
                    new SqlParameter("@Email", txtEmail.Text),
                    new SqlParameter("@Direccion", txtDireccion.Text)
                };

                if (conexion.EjecutarComando(query, parametros))
                {
                    MessageBox.Show("Cliente guardado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                    LimpiarCampos();
                }
            }
            else // Actualizar existente
            {
                string query = @"UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, Identificacion = @Identificacion, 
                                Telefono = @Telefono, Email = @Email, Direccion = @Direccion WHERE ClienteID = @ClienteID";

                SqlParameter[] parametros = {
                    new SqlParameter("@ClienteID", clienteSeleccionado),
                    new SqlParameter("@Nombre", txtNombre.Text),
                    new SqlParameter("@Apellido", txtApellido.Text),
                    new SqlParameter("@Identificacion", txtIdentificacion.Text),
                    new SqlParameter("@Telefono", txtTelefono.Text),
                    new SqlParameter("@Email", txtEmail.Text),
                    new SqlParameter("@Direccion", txtDireccion.Text)
                };

                if (conexion.EjecutarComando(query, parametros))
                {
                    MessageBox.Show("Cliente actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                    LimpiarCampos();
                }
            }
        }
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];
                clienteSeleccionado = Convert.ToInt32(fila.Cells["ClienteID"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
                txtIdentificacion.Text = fila.Cells["Identificacion"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtEmail.Text = fila.Cells["Email"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();
                btnGuardar.Text = "Actualizar";
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "UPDATE Clientes SET Estado = 0 WHERE ClienteID = @ClienteID";
                SqlParameter[] parametros = { new SqlParameter("@ClienteID", clienteSeleccionado) };

                if (conexion.EjecutarComando(query, parametros))
                {
                    MessageBox.Show("Cliente eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                    LimpiarCampos();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                string query = @"SELECT ClienteID, Nombre, Apellido, Identificacion, Telefono, Email, Direccion 
                                FROM Clientes WHERE Estado = 1 AND 
                                (Nombre LIKE @Buscar OR Apellido LIKE @Buscar OR Identificacion LIKE @Buscar)";

                SqlParameter[] parametros = { new SqlParameter("@Buscar", "%" + txtBuscar.Text + "%") };
                DataTable dt = conexion.EjecutarConsulta(query, parametros);
                dgvClientes.DataSource = dt;
            }
            else
            {
                CargarClientes();
            }
        }
    }

}
