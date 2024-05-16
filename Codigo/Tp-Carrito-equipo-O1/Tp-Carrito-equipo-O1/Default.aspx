﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp_Carrito_equipo_O1.Default" %>

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
                                <p class="card-text"><%#Eval("Descripcion") %></p>
                                <p class="card-text"><%#Eval("Precio") %></p>
                                <a href="Carrito">Agregar al carrito</a>
                                <asp:Button Text="Ejemplo" runat="server" CssClass="btn btn-primary" ID="btnEjemplo" CommandArgument='<%#Eval("id")%>' CommandName="ArticuloID" OnClick="btnEjemplo_Click" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
