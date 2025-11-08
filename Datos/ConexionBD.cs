using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Básico_de_Gestión_de_Facturación.Datos
{
    public class ConexionBD
    {
        private string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SistemaFacturacion;Integrated Security=True";
    
        private SqlConnection conexion;

        public ConexionBD()
        {
            conexion = new SqlConnection(cadenaConexion);
        }
        public bool AbrirConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message,
                    "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void CerrarConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la conexión: " + ex.Message);
            }
        }
        public bool EjecutarComando(string query, SqlParameter[] parametros = null)
        {
            try
            {
                if (AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    if (parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }

                    cmd.ExecuteNonQuery();
                    CerrarConexion();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar comando: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CerrarConexion();
                return false;
            }
        }
        public DataTable EjecutarConsulta(string query, SqlParameter[] parametros = null)
        {
            DataTable dt = new DataTable();
            try
            {
                if (AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    if (parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar consulta: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CerrarConexion();
            }
            return dt;
        }

        public object EjecutarEscalar(string query, SqlParameter[] parametros = null)
        {
            object resultado = null;
            try
            {
                if (AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    if (parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }

                    resultado = cmd.ExecuteScalar();
                    CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar consulta escalar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CerrarConexion();
            }
            return resultado;
        }
        public bool ProbarConexion()
        {
            if (AbrirConexion())
            {
                CerrarConexion();
                return true;
            }
            return false;
        }
    }
}

