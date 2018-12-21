<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PaginaPrincipal.aspx.vb" Inherits="PaginaPrincipal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<br />
    <asp:Label ID="Label1" runat="server" Text="Buscar:  "></asp:Label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Mostrar Tabla" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="Mapa" />
    <br />
    <br />

    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="182px" Width="225px">
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
      
    </asp:GridView>
    <%--<iframe id="iframePaginaHija" name="iframePaginaHija" src="Mapa.html" style="height: 722px; width: 1054px"></iframe>--%>
    </asp:Content>


