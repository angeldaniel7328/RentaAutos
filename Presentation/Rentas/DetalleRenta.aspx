<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleRenta.aspx.cs" Inherits="Presentation.Rentas.DetalleRenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Detalle Renta</h3>
            <h4>ID:
                <asp:Label ID="lblIdRenta" runat="server" Text=""></asp:Label></h4>
            <hr />
        </div>
        <div class="col-md-10 col-md-offset-1">
            <dl class="dl-horizontal">
                <dt><label for="<%=lblFechaHora.ClientID %>">Fecha y hora:</label></dt>
                <dd><asp:Label ID="lblFechaHora" runat="server" Text=""></asp:Label></dd>

                <dt><label for="<%=lblCuotaTotal.ClientID %>">Cuota total:</label></dt>
                <dd><asp:Label ID="lblCuotaTotal" runat="server" Text=""></asp:Label></dd>

                <dt><label for="<%=lblPlazo.ClientID %>">Plazo:</label></dt>
                <dd><asp:Label ID="lblPlazo" runat="server" Text=""></asp:Label></dd>
                
                <dt><label for="<%=lblNombreCliente.ClientID %>">Cliente:</label></dt>
                <dd><asp:Label ID="lblNombreCliente" runat="server" Text=""></asp:Label></dd>

                <dt><label for="<%=imgFotoCliente %>">Foto:</label></dt>
                <dd><asp:Image ID="imgFotoCliente" Width="200" Height="200" runat="server" /></dd>

                <dt><label for="<%=lblAutomovil.ClientID %>">Automovil:</label></dt>
                <dd><asp:Label ID="lblAutomovil" runat="server" Text=""></asp:Label></dd>

                <dt><label for="<%=imgFotoAutomovil %>">Foto:</label></dt>
                <dd><asp:Image ID="imgFotoAutomovil" Width="200" Height="200" runat="server" /></dd>
            </dl>
           
        </div>
        <div class="row form-group col-md-10 col-md-offset-4" style="padding-top:20px">
            <div class="col-md-4">
                <asp:Button ID="btnDevolver" runat="server" Text="Registrar devolución" CssClass="btn btn-success" OnClick="btnDevolver_Click" />
            </div>
        </div>
    </div>
</asp:Content>