<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carrito_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-xxl">
        <br />
        <div class="row">
            <div class="col-2" style="background-color: lightgray">
                <h4>Filtros: </h4>
                <div class="row">
                    <asp:Label ID="lblMarca" runat="server" Text="Marca:  "></asp:Label>
                    <asp:DropDownList class="form-select" ID="lbMarca" AutoPostBack="true" OnSelectedIndexChanged="lbMarca_SelectedIndexChanged" Style="width: 190px" runat="server"></asp:DropDownList>
                </div>
                <br />
                <div class="row">
                    <asp:Label ID="lblCateg" runat="server" Text="Categoria: "></asp:Label>
                    <asp:DropDownList class="form-select" ID="lbCategoria" AutoPostBack="true" OnSelectedIndexChanged="lbCategoria_SelectedIndexChanged" Style="width: 190px" runat="server"></asp:DropDownList>
                </div>
                <br />
                <div class="row">
                    <hr />
                    <asp:Label ID="lblBusqlibre" runat="server" Text="Producto a buscar: "></asp:Label>
                    <asp:TextBox class="form-control" ID="txtABuscar" runat="server"></asp:TextBox>
                    <div>
                        <br />
                        <asp:Button class="btn btn-primary" ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" CommandArgument='<%# Eval("Nombre")%>' CommandName="nombre" Text="Buscar" />
                    </div>
                </div>
            </div>

            <div class="col-10 container">
                <div class="row row-cols-auto g-4" id="Productos">
                    <asp:Repeater runat="server" ID="repProductos">
                        <ItemTemplate>
                            <div class="col">
                                <div class="card h-100" style="width: 13rem;">
                                    <img src='<%#Eval("ImagenUrl") %>' class="card-img-top" onerror="src='media/imgDefault.jpg'">
                                    <div class="card-body row align-items-end" style="text-align:center; align-content:center">
                                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                        <h6 class="card-subtitle">$<%#Eval("Precio") %></h6>
                                        <%--                     <p class="card-text"><%#Eval("Descripcion") %></p>--%>
                                    </div>
                                    <div class="card-footer text-center">
                                        <asp:Button class="btn btn-primary" ID="BtnCard" runat="server" OnClick="BtnCard_Click" CommandArgument='<%# Eval("Id")%>' CommandName="idProd" Text="Agregar al carrito" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
