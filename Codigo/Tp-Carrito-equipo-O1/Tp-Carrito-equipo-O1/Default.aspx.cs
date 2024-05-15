using Clases;
using Funcionalidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Carrito_equipo_O1
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            RepositorioArticulo articulo = new RepositorioArticulo();
            ListaArticulos = articulo.ListarConSp();
            repRepetirdor.DataSource = ListaArticulos;
            repRepetirdor.DataBind();
        }
    }
}
