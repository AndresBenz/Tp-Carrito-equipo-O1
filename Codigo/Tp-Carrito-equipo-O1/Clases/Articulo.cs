using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clases
{
    public class Articulo
    {
        public int id {  get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string descripcion { get; set; }

        public Marca idMarca { get; set; } // toma del objeto Marca(clase)

        public Categoria idCategoria { get; set; } // toma del objeto Categoria (clase)

        public decimal Precio { get; set; }

        public Imagenes IdImagenUrl { get; set; } //toma del objeto Imagenes (clase)
    }
}
