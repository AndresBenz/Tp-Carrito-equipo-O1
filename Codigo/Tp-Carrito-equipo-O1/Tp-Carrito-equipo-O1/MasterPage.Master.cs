using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Carrito_equipo_O1
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        List<Articulo> contCarrito = new List<Articulo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["carrito"] != null)
            {
                if (!IsPostBack)
                {

            contCarrito = (List<Articulo>)Session["carrito"];

            lbContador.Text = contCarrito.Count.ToString();
                }
            
            } 
                
        }
    }
}