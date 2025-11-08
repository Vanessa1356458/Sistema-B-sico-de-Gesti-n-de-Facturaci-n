using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Básico_de_Gestión_de_Facturación.Entidades
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }

        public Cliente() { }

        public Cliente(string nombre, string apellido, string identificacion)
        {
            Nombre = nombre;
            Apellido = apellido;
            Identificacion = identificacion;
            Estado = true;
            FechaRegistro = DateTime.Now;
        }
        public string NombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }

    }
}
