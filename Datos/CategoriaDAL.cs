using Sistema_Básico_de_Gestión_de_Facturación.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Básico_de_Gestión_de_Facturación.Datos
{
    public class CategoriaDAL
    {
        private ConexionBD conexion;
        public CategoriaDAL()
        {
            conexion = new ConexionBD();
        }
        public List<Categoria> ObtenerTodas()
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                string query = "SELECT CategoriaID, NombreCategoria, Descripcion FROM Categorias";
                DataTable dt = conexion.EjecutarConsulta(query);

                foreach (DataRow row in dt.Rows)
                {
                    Categoria categoria = new Categoria
                    {
                        CategoriaID = Convert.ToInt32(row["CategoriaID"]),
                        NombreCategoria = row["NombreCategoria"].ToString(),
                        Descripcion = row["Descripcion"].ToString()
                    };
                    lista.Add(categoria);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener categorías: " + ex.Message);
            }
            return lista;
        }
        public DataTable ObtenerDataTable()
        {
            string query = "SELECT CategoriaID, NombreCategoria FROM Categorias";
            return conexion.EjecutarConsulta(query);
        }
    }
}
