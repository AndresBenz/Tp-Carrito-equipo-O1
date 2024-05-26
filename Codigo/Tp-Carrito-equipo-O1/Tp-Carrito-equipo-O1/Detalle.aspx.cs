using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Funcionalidades;
using Clases;
using System.Drawing;
using System.Net;
using System.Security.Cryptography.X509Certificates;


namespace Tp_Carrito_equipo_O1
{
    public partial class Detalle : System.Web.UI.Page
    {
        public List<Imagenes> Listaimg { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    RepositorioImagen repoimg = new RepositorioImagen();
                    string valor = Request.QueryString["id"];

                    // Verificar si el parámetro 'id' está presente y no es nulo o vacío
                    if (string.IsNullOrEmpty(valor))
                    {
                        lbNombre.Text = "Error: El ID del artículo no se proporcionó o es inválido.";
                        imgArticulo.ImageUrl = "https://static.vecteezy.com/system/resources/previews/005/337/799/non_2x/icon-image-not-found-free-vector.jpg";
                        lbDescripcion.Text = string.Empty;
                        lbPrecio.Text = string.Empty;
                        return;
                    }

                    RepositorioArticulo repoArt = new RepositorioArticulo();
                    Articulo artFiltrado = repoArt.BuscarID(int.Parse(valor));

                    if (artFiltrado == null)
                    {
                        lbNombre.Text = "Error: No se encontró el artículo.";
                        imgArticulo.ImageUrl = "https://static.vecteezy.com/system/resources/previews/005/337/799/non_2x/icon-image-not-found-free-vector.jpg";
                        lbDescripcion.Text = string.Empty;
                        lbPrecio.Text = string.Empty;
                        return;
                    }

                    // Asignar valores a los controles de descripción y precio
                    lbNombre.Text = artFiltrado.Nombre;

                     Listaimg =  repoimg.ObtenerImg(artFiltrado.id);
                    // Verificar si IdImagenUrl es null antes de acceder a ImagenURL
                    //if (artFiltrado.IdImagenUrl != null)
                    //{
                    //    if (!string.IsNullOrEmpty(artFiltrado.IdImagenUrl.ImagenURL))
                    //    {   

                    //        //ERROR ACA
                    //        imgArticulo.ImageUrl = artFiltrado.IdImagenUrl.ImagenURL;
                           
                    //    }
                    //    else
                    //    {
                    //        imgArticulo.ImageUrl = "https://static.vecteezy.com/system/resources/previews/005/337/799/non_2x/icon-image-not-found-free-vector.jpg";
                    //    }
                    //}
                    //else
                    //{
                    //    imgArticulo.ImageUrl = "https://static.vecteezy.com/system/resources/previews/005/337/799/non_2x/icon-image-not-found-free-vector.jpg";
                    //}

                    RptImg.DataSource = Listaimg; RptImg.DataBind();

                    lbDescripcion.Text = artFiltrado.descripcion;
                    lbPrecio.Text = artFiltrado.Precio.ToString();
                }
            }
            catch (Exception ex)
            {
               
                // Manejo de excepciones
                lbNombre.Text = "Error: " + ex.Message;
                lbDescripcion.Text = string.Empty;
                lbPrecio.Text = string.Empty;
                imgArticulo.ImageUrl = "https://static.vecteezy.com/system/resources/previews/005/337/799/non_2x/icon-image-not-found-free-vector.jpg";
            }
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            List<Articulo> ListaCarrito = Session["carrito"] as List<Articulo>;
            if (ListaCarrito == null)
            {
                ListaCarrito = new List<Articulo>();
            }
            string valor = Request.QueryString["id"]; //casteo  y del argument me trae explicito
            Articulo aux = new Articulo();
            RepositorioArticulo repo = new RepositorioArticulo();
            aux = repo.BuscarID(int.Parse(valor)); //busca por id
            ListaCarrito.Add(aux);
            Session["carrito"] = ListaCarrito;
            Response.Redirect("Detalle.aspx?id=" + valor);
        }
        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}