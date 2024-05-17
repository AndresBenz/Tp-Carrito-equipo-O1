<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Tp_Carrito_equipo_O1.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container col-md-4">
      
        <asp:Image ID="imgArticulo" runat="server"/>
        <p> Nombre:  <asp:Label ID="lbNombre" runat="server"></asp:Label></p>
        <p> Descripcion:  <asp:Label ID="lbDescripcion" runat="server" Text="Descripcion: "></asp:Label></p>
        <p> Precio:  <asp:Label ID="lbPrecio" runat="server" Text="Precio: "></asp:Label> </p>
 </div>
    <%--<asp:Repeater ID="repRepetirdor" runat="server">
    <ItemTemplate> <%// lo que este dentro del item template es lo que se va a repetior segun este armado. %>

        <div class="col-md-4"> 
            <div class="card mb-4"> 
                <img src='<%#Eval("IdImagenUrl.ImagenURL") %>' class="card-img-top" alt="..."> <%--// cuando se usa repeater, se usa #Eval("NamePropiedad")
                <div class="card-body">
                    <h5 class="card-title">Nombre del articulo: <%#Eval("Nombre") %></h5>
                    <p class="card-text">Descripcion: <%#Eval("Descripcion") %></p>
                    <p class="card-text">Precio: $<%#Eval("Precio") %></p>

                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>--%>
</asp:Content>
