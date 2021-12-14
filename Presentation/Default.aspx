<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentation._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Renta de automoviles</h1>
        <h2 class="lead">Caso pr&aacute;ctico</h2>
    </div>

    <div>
        <asp:Image ID="Portada" runat="server" ImageUrl="~/imagen_central.jpg" Height="628px" Width="1166px"  />
    </div>
    
    <div class="row">
        <div class="col-md-4">
            <h3>Equipo 10</h3>
            <h4>Angel Daniel Lopez Vazquez</h4>
            <h4>Abinadad Morales Montan</h4>
            <h4>Marco Antonio Ramirez Valencia</h4>
        </div>
    </div>
</asp:Content>