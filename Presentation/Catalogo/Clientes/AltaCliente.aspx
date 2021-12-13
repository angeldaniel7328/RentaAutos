<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaCliente.aspx.cs" Inherits="Presentation.Catalogo.Clientes.AltaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Alta Cliente</h3>
            <hr/>
        </div>

        <div class="row form-group">
            <label for="<%=txtNombre.ClientID %>">Nombre del cliente:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvtxtNombre" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtNombre" ErrorMessage="Nombre del cliente requerido"></asp:RequiredFieldValidator>
        </div>

        <div class="row form-group">
            <label for="<%=txtDireccion.ClientID %>">Dirección:</label>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Calle #. Colonia. CP"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvtxtDireccion" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtDireccion" ErrorMessage="Dirección del cliente requerida"></asp:RequiredFieldValidator>
        </div>

        <div class="row form-group">
            <label for="<%=txtTelefono.ClientID %>">Número de teléfono:</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="(000) 000-0000"></asp:TextBox>
            <div class="col-md-12" style="margin-bottom: 20px;">
                <div style="position: absolute; top: 0; left: 0">
                    <asp:RequiredFieldValidator ID="rfvtxtTelefono" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtTelefono" ErrorMessage="Teléfono de la persona requerido"></asp:RequiredFieldValidator>
                </div>
                <div style="position: absolute; top: 0; left: 0">
                    <asp:RegularExpressionValidator ID="revtxtTelefono" runat="server" CssClass="text-danger" ControlToValidate="txtTelefono" ValidationExpression="^[0-9]{10}$" ErrorMessage="El formato de teléfono debe contener 10 digitos"></asp:RegularExpressionValidator>
                </div>
            </div>
        </div>

        <div class="row form-group">
            <label for="<%=txtCorreo.ClientID %>">Correo eléctronico:</label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="nombre@host.com"></asp:TextBox>
            <div class="col-md-12" style="margin-bottom: 20px;">
                <div style="position: absolute; top: 0; left: 0">
                    <asp:RequiredFieldValidator ID="rfvtxtCorreo" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtCorreo" ErrorMessage="Correo de la persona requerido"></asp:RequiredFieldValidator>
                </div>
                <div style="position: absolute; top: 0; left: 0">
                    <asp:RegularExpressionValidator ID="revtxtCorreo" runat="server" CssClass="text-danger" ControlToValidate="txtCorreo" ValidationExpression="^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$" ErrorMessage="El formato de correo es nombre@host.com"></asp:RegularExpressionValidator>
                </div>
            </div>
        </div>
        
        <div class="row form-inline">
            <div class="col-md-12">
                <label>Selecciona foto:</label>
                <input type="file" class="btn btn-default btn-file" runat="server" id="subirImagen" style="display:inline-block" />
                <asp:Button ID="btnSubirImagen" runat="server" Text="Subir imagen" CssClass="btn btn-primary btn-xs" OnClick="btnSubirImagen_Click" />
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-3" style="text-align:center;">
                <label for="<%=subirImagen.ClientID%>">Foto:</label>
                    <asp:Image ID="imgFotoCliente" Width="200" Height="200" runat="server"></asp:Image>
                <label id="lblUrlFoto" runat="server"></label>
            </div>
        </div>
        <div class="row form-group">
            <asp:Button ID="btnGuardar" ValidationGroup="Guardar" runat="server" Text="Guardar" CssClass="btn btn-success" Visible="false" OnClick="btnGuardar_Click"></asp:Button>
        </div>

    </div>
</asp:Content>