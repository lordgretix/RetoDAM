<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.vb" Inherits="Contact" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<br />
    <asp:Label ID="Label1" runat="server" Text="Buscar:  "></asp:Label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Mostrar Tabla" />
    <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    
    </asp:Content>
