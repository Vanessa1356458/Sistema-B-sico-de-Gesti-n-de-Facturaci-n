using Sistema_Básico_de_Gestión_de_Facturación.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Básico_de_Gestión_de_Facturación.Datos
{
    public class ProductoDAL
    {
        private ConexionBD conexion;
        public ProductoDAL()
        {
            conexion = new ConexionBD();
        }
    
    public bool Insertar(Producto producto)
        {
            try
            {
                string query = @"INSERT INTO Productos (CategoriaID, NombreProducto, Descripcion, PrecioUnitario, Stock) 
                                VALUES (@CategoriaID, @NombreProducto, @Descripcion, @PrecioUnitario, @Stock)";

                SqlParameter[] parametros = {
                    new SqlParameter("@CategoriaID", producto.CategoriaID),
                    new SqlParameter("@NombreProducto", producto.NombreProducto),
                    new SqlParameter("@Descripcion", producto.Descripcion ?? (object)DBNull.Value),
                    new SqlParameter("@PrecioUnitario", producto.PrecioUnitario),
                    new SqlParameter("@Stock", producto.Stock)
                };

                return conexion.EjecutarComando(query, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar producto: " + ex.Message);
            }
        }

        public bool Actualizar(Producto producto)
        {
            try
            {
                string query = @"UPDATE Productos 
                                SET CategoriaID = @CategoriaID, NombreProducto = @NombreProducto, 
                                    Descripcion = @Descripcion, PrecioUnitario = @PrecioUnitario, 
                                    Stock = @Stock 
                                WHERE ProductoID = @ProductoID";

                SqlParameter[] parametros = {
                    new SqlParameter("@ProductoID", producto.ProductoID),
                    new SqlParameter("@CategoriaID", producto.CategoriaID),
                    new SqlParameter("@NombreProducto", producto.NombreProducto),
                    new SqlParameter("@Descripcion", producto.Descripcion ?? (object)DBNull.Value),
                    new SqlParameter("@PrecioUnitario", producto.PrecioUnitario),
                    new SqlParameter("@Stock", producto.Stock)
                };

                return conexion.EjecutarComando(query, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar producto: " + ex.Message);
            }
        }
        public bool Eliminar(int productoID)
        {
            try
            {
                string query = "UPDATE Productos SET Estado = 0 WHERE ProductoID = @ProductoID";
                SqlParameter[] parametros = { new SqlParameter("@ProductoID", productoID) };
                return conexion.EjecutarComando(query, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar producto: " + ex.Message);
            }

        }
        public List<Producto> ObtenerTodos()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                string query = @"SELECT p.ProductoID, p.CategoriaID, p.NombreProducto, 
                                p.Descripcion, p.PrecioUnitario, p.Stock, p.Estado,
                                c.NombreCategoria
                                FROM Productos p
                                INNER JOIN Categorias c ON p.CategoriaID = c.CategoriaID
                                WHERE p.Estado = 1";

                DataTable dt = conexion.EjecutarConsulta(query);

                foreach (DataRow row in dt.Rows)
                {
                    Producto producto = new Producto
                    {
                        ProductoID = Convert.ToInt32(row["ProductoID"]),
                        CategoriaID = Convert.ToInt32(row["CategoriaID"]),
                        NombreProducto = row["NombreProducto"].ToString(),
                        Descripcion = row["Descripcion"].ToString(),
                        PrecioUnitario = Convert.ToDecimal(row["PrecioUnitario"]),
                        Stock = Convert.ToInt32(row["Stock"]),
                        Estado = Convert.ToBoolean(row["Estado"]),
                        NombreCategoria = row["NombreCategoria"].ToString()
                    };
                    lista.Add(producto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos: " + ex.Message);
            }
            return lista;
        }
        public Producto ObtenerPorID(int productoID)
        {
            Producto producto = null;
            try
            {
                string query = @"SELECT p.ProductoID, p.CategoriaID, p.NombreProducto, 
                                p.Descripcion, p.PrecioUnitario, p.Stock, p.Estado,
                                c.NombreCategoria
                                FROM Productos p
                                INNER JOIN Categorias c ON p.CategoriaID = c.CategoriaID
                                WHERE p.ProductoID = @ProductoID";

                SqlParameter[] parametros = { new SqlParameter("@ProductoID", productoID) };
                DataTable dt = conexion.EjecutarConsulta(query, parametros);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    producto = new Producto
                    {
                        ProductoID = Convert.ToInt32(row["ProductoID"]),
                        CategoriaID = Convert.ToInt32(row["CategoriaID"]),
                        NombreProducto = row["NombreProducto"].ToString(),
                        Descripcion = row["Descripcion"].ToString(),
                        PrecioUnitario = Convert.ToDecimal(row["PrecioUnitario"]),
                        Stock = Convert.ToInt32(row["Stock"]),
                        Estado = Convert.ToBoolean(row["Estado"]),
                        NombreCategoria = row["NombreCategoria"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener producto: " + ex.Message);
            }
            return producto;
        }
        public List<Producto> Buscar(string criterio)
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                string query = @"SELECT p.ProductoID, p.CategoriaID, p.NombreProducto, 
                                p.Descripcion, p.PrecioUnitario, p.Stock, p.Estado,
                                c.NombreCategoria
                                FROM Productos p
                                INNER JOIN Categorias c ON p.CategoriaID = c.CategoriaID
                                WHERE p.Estado = 1 AND p.NombreProducto LIKE @Criterio";

                SqlParameter[] parametros = { new SqlParameter("@Criterio", "%" + criterio + "%") };
                DataTable dt = conexion.EjecutarConsulta(query, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Producto producto = new Producto
                    {
                        ProductoID = Convert.ToInt32(row["ProductoID"]),
                        CategoriaID = Convert.ToInt32(row["CategoriaID"]),
                        NombreProducto = row["NombreProducto"].ToString(),
                        Descripcion = row["Descripcion"].ToString(),
                        PrecioUnitario = Convert.ToDecimal(row["PrecioUnitario"]),
                        Stock = Convert.ToInt32(row["Stock"]),
                        Estado = Convert.ToBoolean(row["Estado"]),
                        NombreCategoria = row["NombreCategoria"].ToString()
                    };
                    lista.Add(producto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar productos: " + ex.Message);
            }
            return lista;
        }
        public bool ActualizarStock(int productoID, int cantidad)
        {
            try
            {
                string query = "UPDATE Productos SET Stock = Stock - @Cantidad WHERE ProductoID = @ProductoID";
                SqlParameter[] parametros = {
                    new SqlParameter("@ProductoID", productoID),
                    new SqlParameter("@Cantidad", cantidad)
                };
                return conexion.EjecutarComando(query, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar stock: " + ex.Message);
            }
        }
        public DataTable ObtenerDataTable()
        {
            string query = @"SELECT p.ProductoID, p.NombreProducto, p.Descripcion, 
                            p.PrecioUnitario, p.Stock, c.NombreCategoria
                            FROM Productos p
                            INNER JOIN Categorias c ON p.CategoriaID = c.CategoriaID
                            WHERE p.Estado = 1";
            return conexion.EjecutarConsulta(query);
        }

    }

}

