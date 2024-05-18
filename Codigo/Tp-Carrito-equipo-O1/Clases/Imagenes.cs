using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Imagenes
    {
        public int id { get; set; }
        public int idArticulo { get; set; }
        public string ImagenURL { get; set; }
        
        public override string ToString()
        {
            return ImagenURL;
        }

    }
}
