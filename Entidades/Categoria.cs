using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Básico_de_Gestión_de_Facturación.Entidades
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }

        public Categoria() { }

        public Categoria(string nombreCategoria)
        {
            NombreCategoria = nombreCategoria;
        }
    }
}
