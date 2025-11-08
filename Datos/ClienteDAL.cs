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
    public class ClienteDAL
    {
        private ConexionBD conexion;
        public ClienteDAL()
        {
            conexion = new ConexionBD();
        }
        public bool Insertar(Cliente cliente)
        {
            try
            {
                string query = @"INSERT INTO Clientes (Nombre, Apellido, Identificacion, Telefono, Email, Direccion) 
                                VALUES (@Nombre, @Apellido, @Identificacion, @Telefono, @Email, @Direccion)";

                SqlParameter[] parametros = {
                    new SqlParameter("@Nombre", cliente.Nombre),
                    new SqlParameter("@Apellido", cliente.Apellido),
                    new SqlParameter("@Identificacion", cliente.Identificacion),
                    new SqlParameter("@Telefono", cliente.Telefono ?? (object)DBNull.Value),
                    new SqlParameter("@Email", cliente.Email ?? (object)DBNull.Value),
                    new SqlParameter("@Direccion", cliente.Direccion ?? (object)DBNull.Value)
                };

                return conexion.EjecutarComando(query, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar cliente: " + ex.Message);
            }
        }
        public bool Actualizar(Cliente cliente)
        {
            try
            {
                string query = @"UPDATE Clientes 
                                SET Nombre = @Nombre, Apellido = @Apellido, 
                                    Identificacion = @Identificacion, Telefono = @Telefono, 
                                    Email = @Email, Direccion = @Direccion 
                                WHERE ClienteID = @ClienteID";

                SqlParameter[] parametros = {
                    new SqlParameter("@ClienteID", cliente.ClienteID),
                    new SqlParameter("@Nombre", cliente.Nombre),
                    new SqlParameter("@Apellido", cliente.Apellido),
                    new SqlParameter("@Identificacion", cliente.Identificacion),
                    new SqlParameter("@Telefono", cliente.Telefono ?? (object)DBNull.Value),
                    new SqlParameter("@Email", cliente.Email ?? (object)DBNull.Value),
                    new SqlParameter("@Direccion", cliente.Direccion ?? (object)DBNull.Value)
                };

                return conexion.EjecutarComando(query, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar cliente: " + ex.Message);
            }
        }
        public bool Eliminar(int clienteID)
        {
            try
            {
                string query = "UPDATE Clientes SET Estado = 0 WHERE ClienteID = @ClienteID";
                SqlParameter[] parametros = { new SqlParameter("@ClienteID", clienteID) };
                return conexion.EjecutarComando(query, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cliente: " + ex.Message);
            }
        }
 
            public List<Cliente> ObtenerTodos()
            {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                string query = @"SELECT ClienteID, Nombre, Apellido, Identificacion, 
                                Telefono, Email, Direccion, FechaRegistro, Estado 
                                FROM Clientes WHERE Estado = 1";

                DataTable dt = conexion.EjecutarConsulta(query);

                foreach (DataRow row in dt.Rows)
                {
                    Cliente cliente = new Cliente
                    {
                        ClienteID = Convert.ToInt32(row["ClienteID"]),
                        Nombre = row["Nombre"].ToString(),
                        Apellido = row["Apellido"].ToString(),
                        Identificacion = row["Identificacion"].ToString(),
                        Telefono = row["Telefono"].ToString(),
                        Email = row["Email"].ToString(),
                        Direccion = row["Direccion"].ToString(),
                        FechaRegistro = Convert.ToDateTime(row["FechaRegistro"]),
                        Estado = Convert.ToBoolean(row["Estado"])
                    };
                    lista.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener clientes: " + ex.Message);
            }
            return lista;
        }

        public Cliente ObtenerPorID(int clienteID)
        {
            Cliente cliente = null;
            try
            {
                string query = @"SELECT ClienteID, Nombre, Apellido, Identificacion, 
                                Telefono, Email, Direccion, FechaRegistro, Estado 
                                FROM Clientes WHERE ClienteID = @ClienteID";

                SqlParameter[] parametros = { new SqlParameter("@ClienteID", clienteID) };
                DataTable dt = conexion.EjecutarConsulta(query, parametros);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    cliente = new Cliente
                    {
                        ClienteID = Convert.ToInt32(row["ClienteID"]),
                        Nombre = row["Nombre"].ToString(),
                        Apellido = row["Apellido"].ToString(),
                        Identificacion = row["Identificacion"].ToString(),
                        Telefono = row["Telefono"].ToString(),
                        Email = row["Email"].ToString(),
                        Direccion = row["Direccion"].ToString(),
                        FechaRegistro = Convert.ToDateTime(row["FechaRegistro"]),
                        Estado = Convert.ToBoolean(row["Estado"])
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener cliente: " + ex.Message);
            }
            return cliente;
        }
        public List<Cliente> Buscar(string criterio)
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                string query = @"SELECT ClienteID, Nombre, Apellido, Identificacion, 
                                Telefono, Email, Direccion, FechaRegistro, Estado 
                                FROM Clientes 
                                WHERE Estado = 1 AND 
                                (Nombre LIKE @Criterio OR Apellido LIKE @Criterio OR Identificacion LIKE @Criterio)";

                SqlParameter[] parametros = { new SqlParameter("@Criterio", "%" + criterio + "%") };
                DataTable dt = conexion.EjecutarConsulta(query, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Cliente cliente = new Cliente
                    {
                        ClienteID = Convert.ToInt32(row["ClienteID"]),
                        Nombre = row["Nombre"].ToString(),
                        Apellido = row["Apellido"].ToString(),
                        Identificacion = row["Identificacion"].ToString(),
                        Telefono = row["Telefono"].ToString(),
                        Email = row["Email"].ToString(),
                        Direccion = row["Direccion"].ToString(),
                        FechaRegistro = Convert.ToDateTime(row["FechaRegistro"]),
                        Estado = Convert.ToBoolean(row["Estado"])
                    };
                    lista.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar clientes: " + ex.Message);
            }
            return lista;
        }
        public DataTable ObtenerDataTable()
        {
            string query = @"SELECT ClienteID, Nombre, Apellido, Identificacion, 
                            Telefono, Email, Direccion 
                            FROM Clientes WHERE Estado = 1";
            return conexion.EjecutarConsulta(query);
        }
    }
}

