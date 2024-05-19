<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Tp_Carrito_equipo_O1.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-container {
            display: flex;
            flex-direction: column; /* Asegura que los elementos se apilen verticalmente */
            justify-content: center; /* Centra horizontalmente dentro del contenedor */
            align-items: center; /* Centra verticalmente dentro del contenedor */
            min-height: 100vh; /* Establece el alto mínimo como 100% de la altura visible de la ventana */
            padding: 20px; /* Añade espacio alrededor del contenedor */
        }

        .card {
            margin-bottom: 20px; /* Espacio entre cada tarjeta */
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            transition: transform 0.2s;
            width: 100%; /* Ajusta el ancho de la tarjeta */
            max-width: 540px; /* Ancho máximo de la tarjeta según tu diseño */
        }

            .card:hover {
                transform: translateY(-5px);
                box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2);
            }

        .card-img-container {
            height: 500px; /* Altura deseada para la imagen */
            display: flex;
            justify-content: center; /* Centra horizontalmente la imagen */
            align-items: center; /* Centra verticalmente la imagen */
        }

        .card-img-top {
            max-width: 100%; /* Ajusta el ancho máximo de la imagen */
            max-height: 100%; /* Ajusta el alto máximo de la imagen */
            object-fit: cover; /* Ajusta el tamaño de la imagen para cubrir completamente el contenedor */
        }

        .card-body {
            padding: 15px;
        }

        .btn-eliminar {
            width: 100%;
        }

        .form-floating {
            text-align: center;
        }

        .total-label {
            font-size: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="form-floating mb-3">
     <h3>
         <asp:Label ID="lbTotal" runat="server" Text=""></asp:Label></h3>
 </div>

    <div class="card-container">
        <asp:Repeater ID="repRepetirdor" runat="server">
            <ItemTemplate>
                <div class="card">
                    <div class="card-img-container">
                        <img src='<%#Eval("IdImagenUrl.ImagenURL") %>' class="card-img-top" alt="...">
                    </div>
                    <div class="card-body">
                        <h5 class="card-title">Nombre del artículo: <%#Eval("Nombre") %></h5>
                        <p class="card-text">Descripción: <%#Eval("Descripcion") %></p>
                        <p class="card-text">Precio: $<%#Eval("Precio") %></p>
                        <asp:Button Text="Eliminar" CssClass="btn btn-danger btn-eliminar" CommandName="Eliminar" CommandArgument='<%# Container.ItemIndex %>' runat="server" OnCommand="EliminarArticulo" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
   
</asp:Content>
