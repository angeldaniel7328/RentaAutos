<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaAutomoviles.aspx.cs" Inherits="Presentation.Catalogo.Automoviles.ListaAutomoviles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .fotogv {
            padding:5px;
        }
    </style>
    <div class="container">
        <div class="row" style="margin-bottom:18px">
            <h3>Lista Automoviles</h3>
            <hr />
        </div>
        <div class ="row col-md-10 col-md-offset-1">
            <asp:GridView ID="gvAutomoviles" runat="server" AutoGenerateColumns="false"
                DataKeyNames="IdAutomovil" OnRowCommand="gvAutomoviles_RowCommand">
                <Columns>
                    <asp:ImageField HeaderText="Foto" ReadOnly="true"
                        DataImageUrlField="UrlFoto" ControlStyle-Width="110px"
                        ControlStyle-CssClass="fotogv"></asp:ImageField>
                    <asp:BoundField HeaderText="Id" ItemStyle-Width="50px"
                        DataField="IdAutomovil" ReadOnly="true" />
                    <asp:BoundField HeaderText="Marca" ItemStyle-Width="150px"
                        DataField="Marca" />
                    <asp:BoundField HeaderText="Modelo" ItemStyle-Width="80px"
                        DataField="Modelo" />
                    <asp:BoundField HeaderText="Matricula" ItemStyle-Width="80px"
                        DataField="Matricula" />
                    <asp:TemplateField HeaderText="Disponible" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <div style="width:100%">
                                <div style="width:25%;margin:0 auto">
                                    <asp:CheckBox ID="chkDisponible" runat="server" Enabled="false" Checked='<%#Eval("Disponibilidad") %>' />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-success btn-xs" 
                        Text="Seleccionar" CommandName="Select" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
