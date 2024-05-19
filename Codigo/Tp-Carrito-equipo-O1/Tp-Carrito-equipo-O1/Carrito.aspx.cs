using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Clases;
using Funcionalidades;

namespace Tp_Carrito_equipo_O1
{
    public partial class Carrito : System.Web.UI.Page
    {
      

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> carrito = (List<Articulo>)Session["carrito"];
                if (!IsPostBack)
                {
                    if (Session["carrito"] == null)
                    {
                        lbTotal.Text = "No hay artículos en el carrito";
                        return;
                    }
                    repRepetirdor.DataSource = Session["carrito"]; // repite hasta que se quede sin registros
                    repRepetirdor.DataBind(); //bindea
                    Session["total"] = carrito.Sum(x => x.Precio); //itera sobre cada objeto de la lista y suma el precio
                    decimal total = carrito.Sum(x => x.Precio);

                    //usar total > 0 para que no muestre el mensaje si hay articulos en el carrito
                    //hcaer nuevo label para mostrar el mensaje de vacio
                    if (total == 0)
                    {
                        lbTotal.Text = "No hay artículos en el carrito";
                        return;
                    }
                    if(total > 0)
                    {
                        lbTotal.Text = "El total es: $" + Session["total"].ToString();
                        return;
                    }
                }
                
                    
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
       
        protected void EliminarArticulo(object sender, CommandEventArgs e)
        {
            try
            {
                int indice = Convert.ToInt32(e.CommandArgument);

                List<Articulo> carrito = (List<Articulo>)Session["carrito"];
                if (carrito != null && carrito.Count > indice)
                {
                    carrito.RemoveAt(indice);
                    Session["carrito"] = carrito;

                    // Actualiza el Repeater
                    repRepetirdor.DataSource = carrito;
                    repRepetirdor.DataBind();
                    lbTotal.Text = Session["total"].ToString();
                }
                Response.Redirect("Carrito.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {

            Session["total"] = 0;
            lbTotal.Text = Session["total"].ToString();
            Session["carrito"] = null;
            MessageBox.Show(" Que disfrutes tu compra ");
            Response.Redirect("Carrito.aspx");


        }
    }
}
    
