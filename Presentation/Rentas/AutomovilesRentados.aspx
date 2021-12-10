<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AutomovilesRentados.aspx.cs" Inherits="Presentation.Rentas.AutomovilesRentados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Automoviles en Renta</h3>
            <hr/>
        </div>

        <div class="row col-md-10 col-md-offset-1">
            <asp:GridView ID="gvRentas" runat="server" AutoGenerateColumns="false" DataKeyNames="IdRenta" OnRowCommand="gvRentas_RowCommand">
                <Columns>
                    <asp:ImageField HeaderText="Foto Automovil" ReadOnly="true" DataImageUrlField="UrlFotoAutomovil" ControlStyle-Width="110px" ControlStyle-CssClass="fotogv"></asp:ImageField>
                    <asp:ImageField HeaderText="Foto Cliente" ReadOnly="true" DataImageUrlField="UrlFotoCliente" ControlStyle-Width="110px" ControlStyle-CssClass="fotogv"></asp:ImageField>
                    <asp:BoundField HeaderText="Id" ItemStyle-Width="50px" DataField="IdRenta" ReadOnly="true" />
                    <asp:BoundField HeaderText="Fecha" ItemStyle-Width="150px" DataField="FechaHora" />
                    <asp:BoundField HeaderText="Cliente" ItemStyle-Width="200px" DataField="NombreCliente" />
                    <asp:BoundField HeaderText="Automovil" ItemStyle-Width="200px" DataField="NombreAutomovil" />
                    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-success btn-xs" Text="Seleccionar" CommandName="Select" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>