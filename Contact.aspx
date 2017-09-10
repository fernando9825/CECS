<%@ Page AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" Language="C#" MasterPageFile="~/Site.Master"  Title="Contacto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <row>

         <div class="col-md-6">
        
        <h3>Fernando Roman Ventura Alvarado</h3>
        <asp:Image ID="Image1" runat="server" ImageUrl="https://scontent-mia3-1.xx.fbcdn.net/v/t1.0-9/fr/cp0/e15/q65/15747458_1128461123937839_5852419289446133333_n.jpg?efg=eyJpIjoidCJ9&amp;oh=0440ebc1e1f0cbeb4e8f510dd0d60589&amp;oe=5A5F3ADA" Width="314px" Height="300px" />
        <br />
    <address>
        San Miguel, San Miguel, El Salvador.</address>

    <address>
        <strong>E-mail:</strong>   <a href="mailto:fer25alvarado@gmail.com">Fer25alvarado@gmail.com</a><br />
        <strong>Facebook:</strong> <a href="https://www.facebook.com/fernando9825">Fernando Alvarado</a>
    </address>
    </div>

    <div class="col-md-6">
        
         <h3>Miguel Ángel Mendoza Meza</h3>
        <asp:Image ID="Image2" runat="server" ImageUrl="https://scontent-mia3-1.xx.fbcdn.net/v/t31.0-8/fr/cp0/e15/q65/20626859_1267044693405867_3491973672436280656_o.jpg?efg=eyJpIjoidCJ9&amp;oh=19c731fcfab298c4c4d015dbfd6daf77&amp;oe=5A16A041" Width="300px" />
        <br />
    <address>
        San Miguel, San Miguel, El Salvador.</address>

    <address>
        <strong>E-mail:</strong>   <a href="mailto:m98amm@gmail.com">m98amm@gmail.com</a><br />
        <strong>Facebook:</strong> <a href="https://www.facebook.com/miguel.mendoza09">Miguel Mendoza</a>
    </address>

    </div>
    </row>
   
   
</asp:Content>
