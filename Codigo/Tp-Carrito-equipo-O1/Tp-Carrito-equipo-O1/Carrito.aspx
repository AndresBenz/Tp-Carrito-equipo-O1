<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Tp_Carrito_equipo_O1.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
     <div class="container text-center">
    <div class="row">
        <asp:Repeater runat="server" ID="rpCarrito">
       
            <ItemTemplate>
                <div class="col-md-4"> 
                    <div class="card mb-4"> 
                        <img src='<%#Eval("IdImagenUrl.ImagenURL") %>' class="card-img-top" alt="..."> <%--// cuando se usa repeater, se usa #Eval("NamePropiedad")--%>
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <p class="card-text"><%#Eval("Precio") %></p>
                           
                            
                        </div>
                    </div>
                </div>
                
            </ItemTemplate>
                
        </asp:Repeater>

    </div>
</div>
   
</asp:Content>
