using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Funcionalidades;
using Clases;
using System.Drawing;


namespace Tp_Carrito_equipo_O1
{
    public partial class Detalle : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                    string valor = Request.QueryString["id"].ToString();


                    RepositorioArticulo repoArt = new RepositorioArticulo();
                    Articulo artFiltrado = new Articulo();
                    artFiltrado = repoArt.BuscarID(int.Parse(valor));
                    lbNombre.Text = artFiltrado.Nombre;



                    if (artFiltrado.IdImagenUrl != null && !string.IsNullOrEmpty(artFiltrado.IdImagenUrl.ImagenURL))//Verifico que nuevamente la imagen al ver detalle no sea nula 
                    {
                        imgArticulo.ImageUrl = artFiltrado.IdImagenUrl.ImagenURL;
                    }
                    else
                    {
                        imgArticulo.ImageUrl = "https://static.vecteezy.com/system/resources/previews/005/337/799/non_2x/icon-image-not-found-free-vector.jpg";
                    }

                    lbDescripcion.Text = artFiltrado.descripcion;
                    lbPrecio.Text = artFiltrado.Precio.ToString();
                
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                lbNombre.Text = "Error: " + ex.Message;
                imgArticulo.ImageUrl = "https://static.vecteezy.com/system/resources/previews/005/337/799/non_2x/icon-image-not-found-free-vector.jpg";
                lbDescripcion.Text = string.Empty;
                lbPrecio.Text = string.Empty;
            }

        }
    }
}