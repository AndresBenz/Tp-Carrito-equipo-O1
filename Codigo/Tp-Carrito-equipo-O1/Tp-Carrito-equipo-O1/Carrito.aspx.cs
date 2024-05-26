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
                    // Agrupar los artículos por su ID y contar cuántas veces se repite cada ID
                    var agrupados = carrito.GroupBy(a => a.id)
                                   .Select(g => new {
                                       id = g.Key,
                                       Cantidad = g.Count(),
                                       Precio = g.First().Precio,
                                       IdImagenUrl = g.First().IdImagenUrl.ImagenURL,
                                       Nombre = g.First().Nombre,
                                       Descripcion = g.First().descripcion,

                                   });

                    repRepetirdor.DataSource = agrupados; // Usar la lista agrupada en lugar de la lista original
                    repRepetirdor.DataBind();

                    decimal total = agrupados.Sum(item => item.Precio * item.Cantidad);
                    Session["total"] = total;

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

        protected void repRepetirdor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var item = e.Item.DataItem as dynamic;
                System.Web.UI.WebControls.Label lbCantidad = (System.Web.UI.WebControls.Label)e.Item.FindControl("lbCantidad");
                

                lbCantidad.Text = "Cantidad: " + item.Cantidad.ToString();
                
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


            List<Articulo> carrito = (List<Articulo>)Session["carrito"];
            if (carrito != null)
            { 
                Session["total"] = 0;
            lbTotal.Text = Session["total"].ToString();
            Session["carrito"] = null;
            MessageBox.Show(" Que disfrutes tu compra ");
            Response.Redirect("Carrito.aspx");
            }
            else
            {
                MessageBox.Show("No hay articulos en el carrito");
                Response.Redirect("Carrito.aspx");

            }


        }
    }
}
    
