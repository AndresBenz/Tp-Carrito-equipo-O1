<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp_Carrito_equipo_O1.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .articulo-img {
            width: 100%;
            height: 500px; 
            object-fit: cover;
        }
     
    </style>
     
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="d-flex justify-content-center">Artículos</h1>
    <div class="container text-center">
        <asp:TextBox placeholder="Buscar producto..." AutoPostBack="true" ID="txtBuscar" CssClass="form-control me-2" runat="server" OnTextChanged="txtBuscar_TextChanged"/>

        <div class="row">
            <asp:Repeater ID="repRepetirdor" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="card mb-4">
                            <img src='<%# Eval("IdImagenUrl.ImagenURL") %>' class="card-img-top articulo-img" alt="Imagen del artículo">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text">ID: <%# Eval("id") %></p>
                                <p class="card-text">Descripción: <%# Eval("Descripcion") %></p>
                                <p class="card-text">Precio: $<%# Eval("Precio") %></p>
                                <asp:Button Text="Añadir" runat="server" CssClass="btn btn-primary" ID="btnAñadir" CommandArgument='<%# Eval("id") %>' CommandName="ArticuloID" OnClick="btnAñadir_Click" />
                                <asp:Button Text="Ver Detalle" runat="server" CssClass="btn btn-primary" ID="btnDetalle" CommandArgument='<%# Eval("id") %>' CommandName="ArticuloID" OnClick="btnDetalle_Click" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            var defaultImageUrl = "https://cdn-icons-png.flaticon.com/512/6455/6455737.png"
            var images = document.querySelectorAll('.articulo-img');
            images.forEach(function (img) {
                img.onerror = function () {
                    this.src = defaultImageUrl;
                };
            });
        });
    </script>
</asp:Content>