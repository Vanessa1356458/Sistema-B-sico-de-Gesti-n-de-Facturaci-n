using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Básico_de_Gestión_de_Facturación.Entidades
{
    public class FormaPago
    {
        public int FormaPagoID { get; set; }
        public string NombreFormaPago { get; set; }
        public string Descripcion { get; set; }

        public FormaPago() { }

        public FormaPago(string nombreFormaPago)
        {
            NombreFormaPago = nombreFormaPago;
        }
    }
}
