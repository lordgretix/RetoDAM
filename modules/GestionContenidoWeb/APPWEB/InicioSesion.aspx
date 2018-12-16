<%@ Page Language="VB" AutoEventWireup="false" CodeFile="InicioSesion.aspx.vb" Inherits="InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"  />
    <link href="Recursos/css/InicioSesion.css" rel="stylesheet" />   
    <title></title>
</head>
<body>
    <div class="container well contenedor">
        <div class="row">
            <div class="col-xs-12">
                <h2>Iniciar Sesión</h2>
            </div>
        </div>

        <form id="form1" runat="server" class="form-horizontal">
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
               <div class="form-group">
                <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-10">
                     <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
             <div class="form-group">
                 <asp:Label  ID="lblMensaje" runat="server" Font-Bold="True" Font-Underline="False" ForeColor="Red" ></asp:Label>
            <asp:Button ID="btnInicio" runat="server" Text="Iniciar"  CssClass="form-control btn btn-primary" />
        </div>
       
        </form>
    </div>
</body>
</html>
