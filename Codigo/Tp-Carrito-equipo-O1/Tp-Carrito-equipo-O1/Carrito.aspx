<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Tp_Carrito_equipo_O1.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
<asp:Repeater ID="repRepetirdor" runat="server">
    <ItemTemplate> <%// lo que este dentro del item template es lo que se va a repetior segun este armado. %>
        <div class="card mb-3 " style="max-width: 540px;">
            <div class="row g-0"> 
                <div class="col-md-4"> 
                    <img src='<%#Eval("IdImagenUrl.ImagenURL") %>' class="card-img-top" alt="...">
                 </div>
                <div class="col-md-8">
                    <div class="card-body">
                     <h5 class="card-title">Nombre del articulo: <%#Eval("Nombre") %></h5>
                     <p class="card-text">Descripcion: <%#Eval("Descripcion") %></p>
                     <p class="card-text">Precio: $<%#Eval("Precio") %></p>
                    </div>
                   </div>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
    <div class="form-floating mb-3">
    <h3>Total $:<asp:Label ID="lbTotal" runat="server" Text=""></asp:Label></h3>
    </div>
</asp:Content>
