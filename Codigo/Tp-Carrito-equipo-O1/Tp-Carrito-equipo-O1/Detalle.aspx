<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Tp_Carrito_equipo_O1.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Incluir las bibliotecas de Bootstrap y jQuery -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.bundle.min.js"></script>
    <style>
        .detalle-titulo {
            font-weight: bold;
            font-size: 24px; /* Tamaño de fuente más grande */
            margin-bottom: 10px; /* Espacio inferior */
            border-bottom: 2px solid #007bff; /* Línea inferior azul */
            padding-bottom: 5px; /* Espacio entre el texto y la línea */
        }
        .detalle-texto {
            font-size: 18px; /* Tamaño de fuente más grande */
            margin-bottom: 15px; /* Espacio inferior */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div style="text-align: center; margin-bottom: 20px;">
            <p class="detalle-titulo">Nombre: <asp:Label ID="lbNombre" runat="server" style="font-weight: normal;"></asp:Label></p>
            <p class="detalle-texto">Descripción: <asp:Label ID="lbDescripcion" runat="server"></asp:Label></p>
            <p class="detalle-texto">Precio: <asp:Label ID="lbPrecio" runat="server"></asp:Label></p>
        </div>

        <div class="row justify-content-center">
            <div class="col-md-6">
                <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                    <div class="carousel-inner">
                        <asp:Repeater ID="RptImg" runat="server">
                            <ItemTemplate>
                                <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                    <img src='<%# Eval("ImagenURL") %>' class="d-block w-100" alt="Imagen del artículo" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>
        </div>

            <asp:Image ID="imgArticulo" runat="server" style="max-width: 100%; height: auto; display: block; margin: 0 auto;" />
        
    </div>

    <script>
        $(document).ready(function () {
            // Inicializar el carrusel al cargar la página
            $('.carousel').carousel();
        });
    </script>
</asp:Content>