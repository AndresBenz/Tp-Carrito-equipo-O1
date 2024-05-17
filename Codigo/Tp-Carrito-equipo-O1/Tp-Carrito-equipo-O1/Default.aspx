<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp_Carrito_equipo_O1.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="d-flex justify-content-center">Articulos</h1>
    <div class="container text-center">
        <div class="row">
            <asp:Repeater ID="repRepetirdor" runat="server">
                <ItemTemplate> <%// lo que este dentro del item template es lo que se va a repetior segun este armado. %>
                    
                    <div class="col-md-4"> 
                        <div class="card mb-4"> 
                            <img src='<%#Eval("IdImagenUrl.ImagenURL") %>' class="card-img-top" alt="..."> <%--// cuando se usa repeater, se usa #Eval("NamePropiedad")--%>
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text">ID: <%#Eval("id") %></p>
                                <p class="card-text">Descripcion: <%#Eval("Descripcion") %></p>
                                <p class="card-text">Precio: $<%#Eval("Precio") %></p>
                                <asp:Button Text="Añadir" runat="server" CssClass="btn btn-primary" ID="btnAñadir" CommandArgument='<%#Eval("id")%>' CommandName="ArticuloID" OnClick="btnAñadir_Click" />
                                <asp:Button Text="Ver Detalle" runat="server" CssClass="btn btn-primary" ID="btnDetalle" CommandArgument='<%#Eval("id")%>' CommandName="ArticuloID" OnClick="btnDetalle_Click" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
