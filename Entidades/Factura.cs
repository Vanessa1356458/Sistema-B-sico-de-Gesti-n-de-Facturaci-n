using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Básico_de_Gestión_de_Facturación.Entidades
{
    public class Factura
    {
        public int FacturaID { get; set; }
        public string NumeroFactura { get; set; }
        public int ClienteID { get; set; }
        public int VendedorID { get; set; }
        public int FormaPagoID { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }

        // Propiedades de navegación
        public string NombreCliente { get; set; }
        public string NombreVendedor { get; set; }
        public string NombreFormaPago { get; set; }

        // Lista de detalles de la factura
        public List<DetalleFactura> Detalles { get; set; }

        public Factura()
        {
            Detalles = new List<DetalleFactura>();
            FechaEmision = DateTime.Now;
            Estado = "Pagada";
        }

        // Método para calcular totales
        public void CalcularTotales()
        {
            Subtotal = 0;
            foreach (var detalle in Detalles)
            {
                Subtotal += detalle.Subtotal;
            }

            IVA = Subtotal * 0.15m; // 15% de IVA en Honduras
            Total = Subtotal + IVA - Descuento;
        }

        // Método para generar número de factura
        public string GenerarNumeroFactura()
        {
            return $"FAC-{DateTime.Now:yyyyMMdd}-{FacturaID:D6}";
        }
    }
}
