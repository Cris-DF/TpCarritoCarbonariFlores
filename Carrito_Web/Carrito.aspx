<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Carrito_Web.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center">Carrito</h1>
    <br />
    <asp:Label ID="lblCarritoVacio" runat="server"  Text="CARRITO VACIO" style="text-align:center"></asp:Label>

    <div class="p-3 m-0 border-0 bd-example">
        <asp:Repeater runat="server" ID="repCarrito">
            <ItemTemplate>
                <div class="card mb-3" style="text-align: center">
                    <div class="row g-0">
                        <div class="col-md-3">
                            <img class="img-fluid rounded-start" src='<%#Eval("ImagenUrl") %>' onerror="src='media/imgDefaultCarrito.png'" style="max-height: 150px">
                        </div>
                        <div class="col-md-4" style="text-align: left">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text">
                                    <%#Eval("Descripcion") %>
                                </p>
                                <p class="card-text">
                                    <asp:Button class="btn btn-primary" ID="Button1" runat="server" OnClick="BtnEliminar_Click" CommandArgument='<%# Eval("Id")%>' CommandName="idProd" Text="Eliminar" />
                                </p>
                                <%--
                                <p class="card-text"><small class="text-muted">cantidad:</small></p>
                                <p class="card-text">
                                                                        <asp:Button class="btn btn-primary" ID="BtnMenosCant" runat="server" OnClick="BtnMenosCant_Click" CommandArgument='<%# Eval("Id")%>' CommandName="idProd" Text="-" />
                                    <small class="text-muted"><%#Eval("Cantidad") %></small>
                                    <asp:Button class="btn btn-primary" ID="BtnMasCant" runat="server" OnClick="BtnMasCant_Click" CommandArgument='<%# Eval("Id")%>' CommandName="idProd" Text="+" />--%>
                                </p>
                            </div>
                        </div>
                        <div class="col-md-3" style="text-align: center">
                            <p class="card-text"><small class="text-muted">Cantidad:</small></p>
                            <p class="card-text">
                                <asp:Button class="btn btn-primary" ID="BtnMenosCant" runat="server" OnClick="BtnMenosCant_Click" CommandArgument='<%# Eval("Id")%>' CommandName="idProd" Text="-" />
                                <small class="text-muted"><%#Eval("Cantidad") %></small>
                                <asp:Button class="btn btn-primary" ID="BtnMasCant" runat="server" OnClick="BtnMasCant_Click" CommandArgument='<%# Eval("Id")%>' CommandName="idProd" Text="+" />
                            </p>
                        </div>

                        <div class="col-md-2">
                            <h4>
                                <p class="card-text" style="text-align: center">$<%#Eval("Precio") %> </p>
                            </h4>
                        </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

<%--    -- total carrito--%>
        <div class="p-3 m-0 border-0 bd-example">
            <itemtemplate>
                <div class="card mb-3" style="text-align: center">
                    <div class="row g-0">
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-3" style="text-align: left">
                            <div class="card-body">
                            </div>
                        </div>
                        <div class="col-md-3" style="text-align: right">
                            <h4>TOTAL A PAGAR</h4>
                        </div>

                        <div class="col-md-3"style="text-align: right; padding-right: 30px">
                            <h4>
                                <asp:Label ID="lblTotalCarrito" runat="server" Text="$"></asp:Label>
                            </h4>
                        </div>
                    </div>
                </div>
            </itemtemplate>
        </div>
</asp:Content>
