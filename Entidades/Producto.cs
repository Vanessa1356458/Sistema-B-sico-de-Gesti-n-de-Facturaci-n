using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Básico_de_Gestión_de_Facturación.Entidades
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public int CategoriaID { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }

        // Propiedad de navegación
        public string NombreCategoria { get; set; }

        public Producto() { }

        public Producto(string nombreProducto, decimal precioUnitario, int categoriaID)
        {
            NombreProducto = nombreProducto;
            PrecioUnitario = precioUnitario;
            CategoriaID = categoriaID;
            Estado = true;
            Stock = 0;
        }
    }
}
