<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="notas.aspx.cs" Inherits="Notas_notas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="jumbotron">
        <h1 id ="NombreAlumno" runat="server"></h1>
        <p class="lead">Bienvenido</p>
    </div>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</asp:Content>

