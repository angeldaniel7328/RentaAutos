<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaAutomovil.aspx.cs" Inherits="Presentation.Catalogo.Automoviles.AltaAutomovil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Alta Automovil</h3>
            <hr/>
        </div>

        <div class="row form-group">
            <label for="<%=txtMatricula.ClientID%>">Matricula:</label>
            <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control" placeholder="XXX-0000"></asp:TextBox>
            <div style="position:absolute;top:0;left:0;">
                <asp:RequiredFieldValidator ID="rfvTxtMatricula" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtMatricula" ErrorMessage="Matricula del auto requerida">
                </asp:RequiredFieldValidator>
            </div>
            <div style="position:absolute;top:0;left:0;">
                <asp:RegularExpressionValidator ID="revTxtMatricula" runat="server" CssClass="text-danger" ControlToValidate="txtMatricula" ValidationExpression="^[A-Z]{3}-[0-9]{4}$" ErrorMessage="El formato de la matricula es XXX-0000 (Mayusculas)">
                </asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="row form-group">
            <label for="<%=txtMarca.ClientID%>">Marca:</label>
            <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" placeholder="Marca"></asp:TextBox>
            <div style="position:absolute;top:0;left:0;">
                <asp:RequiredFieldValidator ID="rfvTxtMarca" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtMarca" ErrorMessage="Marca del auto requerido">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row form-group">
            <label for="<%=txtModelo.ClientID%>">Modelo:</label>
            <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control" placeholder="Modelo"></asp:TextBox>
            <div style="position:absolute;top:0;left:0;">
                <asp:RequiredFieldValidator ID="rfvTxtModelo" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtModelo" ErrorMessage="Modelo del auto requerido">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row form-group">
            <label for="<%=txtCuota.ClientID%>">Cuota:</label>
            <asp:TextBox ID="txtCuota" runat="server" CssClass="form-control" placeholder="0.00"></asp:TextBox>
            <div style="position:absolute;top:0;left:0;">
                <asp:RequiredFieldValidator ID="rfvTxtCuota" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtCuota" ErrorMessage="Cuota requerida">
                </asp:RequiredFieldValidator>
            </div>
            <div style="position:absolute;top:0;left:0;">
                <asp:RegularExpressionValidator ID="revTxtCuota" runat="server" CssClass="text-danger" ControlToValidate="txtCuota" ValidationExpression="^[0-9]+(\.[0-9][0-9]?)?$" ErrorMessage="La cuota es un valor decimal">
                </asp:RegularExpressionValidator>
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
                    <asp:Image ID="imgFotoAutomovil" Width="200" Height="200" runat="server"></asp:Image>
                <label id="lblUrlFoto" runat="server"></label>
            </div>
        </div>
        <div class="row form-group">
            <asp:Button ID="btnGuardar" ValidationGroup="Guardar" runat="server" Text="Guardar" CssClass="btn btn-success" Visible="false" OnClick="btnGuardar_Click"></asp:Button>
        </div>

    </div>
</asp:Content>