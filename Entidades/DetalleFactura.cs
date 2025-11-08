using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Básico_de_Gestión_de_Facturación.Entidades
{
    public class DetalleFactura
    {
        public int DetalleID { get; set; }
        public int FacturaID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
        public string NombreProducto { get; set; }

        public DetalleFactura() { }

        public DetalleFactura(int productoID, string nombreProducto, int cantidad, decimal precioUnitario)
        {
            ProductoID = productoID;
            NombreProducto = nombreProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            Descuento = 0;
            CalcularSubtotal();
        }

        // Método para calcular subtotal del detalle
        public void CalcularSubtotal()
        {
            Subtotal = (Cantidad * PrecioUnitario) - Descuento;
        }
    }
}

