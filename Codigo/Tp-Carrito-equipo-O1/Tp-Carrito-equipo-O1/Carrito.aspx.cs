using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                if(!IsPostBack)
                {
                    if (Session["carrito"] == null)
                    {
                        lbTotal.Text = "No hay artículos en el carrito";
                        return;
                    }
                    repRepetirdor.DataSource = Session["carrito"]; // repite hasta que se quede sin registros
                    repRepetirdor.DataBind(); //bindea
                    lbTotal.Text = Session["total"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}