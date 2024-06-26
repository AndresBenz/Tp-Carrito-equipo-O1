﻿using Clases;
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
        public List<Imagenes> Listaimg {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            RepositorioArticulo articulo = new RepositorioArticulo();
            RepositorioImagen img = new RepositorioImagen();
            ListaArticulos = articulo.ListarConSpImgIndividual();
            Listaimg = img.Listar();
            
            if(!IsPostBack)
            {
                //rptImg.DataSource = Listaimg;
                //rptImg.DataBind(); 
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
            Response.Redirect("Default.aspx");
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
            Response.Redirect("Detalle.aspx?id=" + valor);
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            List<Articulo> listaFiltrada;
            string filtro = txtBuscar.Text.ToLower();
            // Criterio de filtracion: Nombre o Codigo de Articulo con al menos 2 caracteres
            if (filtro.Length >= 2)
            {
                listaFiltrada = ListaArticulos.FindAll(X => X.Nombre.ToLower().Contains(filtro));
            }
            else
            {
                listaFiltrada = ListaArticulos;
            }


            repRepetirdor.DataSource = listaFiltrada;
            repRepetirdor.DataBind();
        }

        protected void txtBuscar_TextChanged1(object sender, EventArgs e)
        {

        }
    }
}
