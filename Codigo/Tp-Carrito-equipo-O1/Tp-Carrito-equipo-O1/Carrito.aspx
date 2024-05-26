<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Tp_Carrito_equipo_O1.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-container {
            display: flex;
            flex-direction: column; 
            justify-content: center; 
            align-items: center; 
            min-height: 100vh; 
            padding: 20px; 
        }

        .card {
            margin-bottom: 20px; 
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            transition: transform 0.2s;
            width: 100%; 
            max-width: 540px; 
        }

            .card:hover {
                transform: translateY(-5px);
                box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2);
            }

        .card-img-container {
            height: 500px;
            display: flex;
            justify-content: center; 
            align-items: center; 
        }

        .card-img-top {
            max-width: 100%; 
            max-height: 100%;
            object-fit: cover; 
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
    <div class="card-container">
        <asp:Repeater ID="repRepetirdor" runat="server">
            <ItemTemplate>
                <div class="card">
                    <div class="card-img-container">
                        <img src='<%#Eval("IdImagenUrl") %>' class="card-img-top" alt="...">
                    </div>
                    <div class="card-body">
                        <h5 class="card-title">Nombre del artículo: <%#Eval("Nombre") %></h5>
                        <p class="card-text">Descripción: <%#Eval("Descripcion") %></p>
                        <asp:Label ID="lbCantidad" runat="server" Text='<%# "Cantidad: " + Eval("Cantidad") %>'  />                     
                        <p class="card-text">Precio por unidad: $<%#Eval("Precio") %></p>
                        <asp:Button Text="Eliminar" CssClass="btn btn-danger btn-eliminar" CommandName="Eliminar" CommandArgument='<%# Container.ItemIndex %>' runat="server" OnCommand="EliminarArticulo" />
                    </div>
                </div>      
           </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="form-floating mb-3">
        <h3><asp:Label ID="lbTotal" runat="server" Text=""></asp:Label></h3>
        <asp:Button ID="BtnFinalizar" runat="server" Text="Finalizar Compra.." CssClass="btn btn-primary btn-lg btn-block" OnClick="btnFinalizar_Click" />
    </div>
</asp:Content>
