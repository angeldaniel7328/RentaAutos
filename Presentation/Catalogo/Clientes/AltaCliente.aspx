﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaCliente.aspx.cs" Inherits="Presentation.Catalogo.Clientes.AltaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Alta Clientes</h3>
            <hr />
        </div>

        <div class="row form-group">
            <label for="<%=txtNombre.ClientID%>">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
            <div style="position:absolute;top:0;left:0;">
                <asp:RequiredFieldValidator ID="rfvTxtNombre" 
                    ValidationGroup="Guardar" runat="server" CssClass="text-danger" 
                    ControlToValidate="txtNombre" ErrorMessage="Nombre del cliente requerido">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row form-group">
            <label for="<%=txtTelefono.ClientID%>">Telefono:</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="000-000-0000"></asp:TextBox>
            <div style="position:absolute;top:0;left:0;">
                <asp:RequiredFieldValidator ID="rfvTxtTelefono" ValidationGroup="Guardar" runat="server" CssClass="text-danger" 
                    ControlToValidate="txtTelefono" ErrorMessage="Telefono del cliente requerido">
                </asp:RequiredFieldValidator>
            </div>
            <div style="position:absolute;top:0;left:0;">
                <asp:RegularExpressionValidator ID="revTxttelefono" runat="server" CssClass="text-danger" 
                    ControlToValidate="txtTelefono" ValidationExpression="^[0-9]{10}$" 
                    ErrorMessage="El formato del telefono debe contener 10 valores numericos">
                </asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="row form-group">
            <label for="<%=txtDireccion.ClientID%>">Direccion:</label>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Direccion"></asp:TextBox>
            <div style="position:absolute;top:0;left:0;">
                <asp:RequiredFieldValidator ID="rfvTxtDireccion" 
                    ValidationGroup="Guardar" runat="server" CssClass="text-danger" 
                    ControlToValidate="txtDireccion" ErrorMessage="Direccion del cliente requerido">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row form-group">
            <label for="<%=txtCorreo.ClientID%>">Correo:</label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo"></asp:TextBox>
            <div style="position:absolute;top:0;left:0;">
                <asp:RequiredFieldValidator ID="rfvTxtCorreo" ValidationGroup="Guardar" runat="server" CssClass="text-danger" 
                    ControlToValidate="txtCorreo" ErrorMessage="Correo del cliente requerido">
                </asp:RequiredFieldValidator>
            </div>
            <div style="position:absolute;top:0;left:0;">
                <asp:RegularExpressionValidator ID="revTxtCorreo" runat="server" CssClass="text-danger" 
                    ControlToValidate="txtCorreo" ValidationExpression="^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$" 
                    ErrorMessage="El formato del correo no es valido">
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
                 <asp:Image ID="imgFotoBarco" Width="200" Height="200" runat="server">
                 </asp:Image>
                <label id="lblUrlFoto" runat="server"></label>
            </div>
        </div>
        <div class="row form-group">
            <asp:Button ID="btnGuardar" ValidationGroup="Guardar" runat="server" Text="Guardar" 
                CssClass="btn btn-success" Visible="false" OnClick="btnGuardar_Click">
            </asp:Button>
        </div>
    </div>
</asp:Content>