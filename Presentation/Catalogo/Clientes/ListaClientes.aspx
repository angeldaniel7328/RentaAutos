<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaClientes.aspx.cs" Inherits="Presentation.Catalogo.Clientes.ListaClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .fotogv {
            padding:5px;
        }
    </style>
    <div class="container">
        <div class="row" style="margin-bottom:18px">
            <h3>Lista Clientes</h3>
            <hr/>
        </div>
        <div class ="row col-md-10 col-md-offset-1">
            <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="false"
                DataKeyNames="IdCliente" OnRowCommand="gvClientes_RowCommand">
                <Columns>
                    <asp:ImageField HeaderText="Foto" ReadOnly="true" DataImageUrlField="UrlFoto" ControlStyle-Width="110px" ControlStyle-CssClass="fotogv"></asp:ImageField>
                    <asp:BoundField HeaderText="Id" ItemStyle-Width="50px" DataField="IdCliente" ReadOnly="true" />
                    <asp:BoundField HeaderText="Nombre" ItemStyle-Width="150px" DataField="Nombre" />
                    <asp:BoundField HeaderText="Direccion" ItemStyle-Width="80px" DataField="Direccion" />
                    <asp:BoundField HeaderText="Telefono" ItemStyle-Width="80px" DataField="Telefono" />
                    <asp:BoundField HeaderText="Correo" ItemStyle-Width="80px" DataField="Correo" />
                    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-success btn-xs" Text="Seleccionar" CommandName="Select" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>