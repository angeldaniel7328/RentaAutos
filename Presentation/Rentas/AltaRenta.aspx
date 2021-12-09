<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaRenta.aspx.cs" Inherits="Presentation.Rentas.AltaRenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Alta Renta</h3>
            <hr/>
        </div>

        <div class="row form-group">
            <label for="<%=FechaRenta.ClientID %>">Fecha y Hora de renta:</label>
            <input id="FechaRenta" runat="server" type="text" class="form-control" />
            <div style="position: absolute; top: 0; left: 0">
                <asp:RequiredFieldValidator ID="rfvtxtFechaRenta" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="FechaRenta" ErrorMessage="Fecha de la renta requerida"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row form-group">
            <label for="<%=FechaDevolucion.ClientID %>">Fecha y Hora de devolución:</label>
            <input id="FechaDevolucion" runat="server" type="text" class="form-control"/>
            <div style="position: absolute; top: 0; left: 0">
                <asp:RequiredFieldValidator ID="rfvtxtFechaDevolucion" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="FechaDevolucion" ErrorMessage="Fecha de la devolucion requerida"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row form-group">
            <label for="<%=txtCuota.ClientID%>">Cuota:</label>
            <asp:TextBox ID="txtCuota" runat="server" CssClass="form-control" placeholder="0.00" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="row form-group">
            <label for="<%=ddlCliente.ClientID %>">Cliente:</label>
            <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control" style="width:25%" AutoPostBack="true">
                <asp:ListItem Value="0" Text="Selecciona el cliente"></asp:ListItem>
            </asp:DropDownList>        
        </div>

        <div class="row form-group">
            <label for="<%=ddlAutomovil.ClientID %>">Automovil a rentar:</label>
            <asp:DropDownList ID="ddlAutomovil" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlAutomovil_SelectedIndexChanged" style="width:25%">
                <asp:ListItem Value="0" Text="Selecciona Automovil"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvddlAutomovil" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="ddlAutomovil" InitialValue="0" ErrorMessage="Selecciona el automovil"></asp:RequiredFieldValidator>
        </div>
        
        <div class="row form-group">
            <asp:Button ID="btnGuardar" ValidationGroup="Guardar" runat="server" Text="Guardar" CssClass="btn btn-success" Visible="true" OnClick="btnGuardar_Click"/>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            $.datetimepicker.setLocale('es');
            $("#<%=FechaRenta.ClientID%>").datetimepicker({
                format: 'd/m/Y H:i',
                minDate: '0'
            });
            $("#<%=FechaDevolucion.ClientID%>").datetimepicker({
                format: 'd/m/Y H:i',
                minDate: '0'
            });
        });
    </script>
</asp:Content>