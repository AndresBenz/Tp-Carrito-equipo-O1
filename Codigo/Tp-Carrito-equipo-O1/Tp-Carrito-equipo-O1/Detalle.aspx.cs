using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Funcionalidades;
using Clases;


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


                    imgArticulo.ImageUrl = artFiltrado.IdImagenUrl.ImagenURL;
                    lbDescripcion.Text = artFiltrado.descripcion;
                    lbPrecio.Text = artFiltrado.Precio.ToString();
                
            }
            catch (Exception)
            {

                throw new Exception("");
            }
            
        }
    }
}