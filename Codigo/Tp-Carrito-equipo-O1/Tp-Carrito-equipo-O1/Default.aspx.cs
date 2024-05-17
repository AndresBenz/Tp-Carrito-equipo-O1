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

            if(!IsPostBack)
            {
            repRepetirdor.DataSource = ListaArticulos; // repite hasta que se quede sin registros
            repRepetirdor.DataBind(); //bindea
            }
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            List<Articulo> ListaCarrito = Session["carrito"] as List<Articulo>;
            if (ListaCarrito == null)
            {
                ListaCarrito = new List<Articulo>();
            }
            string valor = ((Button)sender).CommandArgument; //casteo  y del argument me trae explicito
            Articulo aux = new Articulo();
            RepositorioArticulo repo = new RepositorioArticulo();
            aux= repo.BuscarID(int.Parse(valor)); //busca por id
            ListaCarrito.Add(aux);
            Session["carrito"] = ListaCarrito;
            Session["total"] = ListaCarrito.Sum(x => x.Precio); //itera sobre cada objeto de la lista y suma el precio
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
            Response.Redirect("Detalle.aspx?id=" + valor);
        }
    }
}
