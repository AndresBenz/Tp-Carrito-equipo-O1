<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp_Carrito_equipo_O1.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <style>
        .articulo-img {
            width: 100%;
            height: 400px;
            object-fit: cover;
        }

        .btn-custom-blue {
            background-color: #87CEFA; 
            color: white;
            border: none;
            transition: transform 0.3s ease, background-color 0.3s ease; 
        }

        .btn-custom-green {
        background-color: #00c400; 
        color: white;
        border: none;
        transition: transform 0.3s ease, background-color 0.3s ease; 
        }

        .btn-custom-blue:hover {
            background-color: #4682B4; 
            transform: scale(1.1); 
        }

        .btn-large {
            font-size: 20px; 
            padding: 15px 30px; 
            transition: transform 0.3s ease, background-color 0.3s ease; 
        }

        .btn-large:hover {
            transform: scale(1.1); 
            background-color: #0056b3; 
        }

        .detalle-titulo {
            font-weight: bold;
            font-size: 24px; 
            margin-bottom: 10px; 
            border-bottom: 2px solid #007bff; 
            padding-bottom: 5px; 
        }

        .detalle-texto {
            font-size: 18px; 
            margin-bottom: 15px; 
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="d-flex justify-content-center">Tienda Mundo Shop</h1>
    <div class="container text-center my-4">
        <div class="row justify-content-center align-items-center">
            <div class="col-lg-6 offset-lg-2">
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control border border-primary rounded-pill me-2" placeholder="Buscar producto..." AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged"></asp:TextBox>
            </div>
            <div class="col-lg-2">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary btn-block" />
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="repRepetirdor" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100">
                            <img src='<%# Eval("IdImagenUrl.ImagenURL") %>' class="card-img-top articulo-img" alt="Imagen del artículo">
                               <div style="text-align: center; margin-top: 20px;">
                                
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text">Descripción: <%# Eval("Descripcion") %></p>
                                <p class="card-text">Precio: $<%# Eval("Precio") %></p>
                                <asp:Button Text="Añadir al carrito" runat="server" CssClass="btn btn-success btn-large my-2 mx-1 " ID="btnAñadir" CommandArgument='<%# Eval("id") %>' CommandName="ArticuloID" OnClick="btnAñadir_Click" />
                                <asp:Button Text="Ver Detalle" runat="server" CssClass="btn btn-primary btn-large my-2 mx-1" ID="btnDetalle" CommandArgument='<%# Eval("id") %>' CommandName="ArticuloID" OnClick="btnDetalle_Click" />
                                 </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            var defaultImageUrl = "https://cdn-icons-png.flaticon.com/512/6455/6455737.png";
            var images = document.querySelectorAll('.card-img-top.articulo-img');
            images.forEach(function (img) {
                img.onerror = function () {
                    this.src = defaultImageUrl;
                };
            });
        });
    </script>
</asp:Content>
