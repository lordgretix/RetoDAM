<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Actualizar.aspx.vb" Inherits="Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <%--Formulario--%>
    <section>
        <fieldset>
            <legend>Alojamiento</legend>
            <br />
            <%--DATOS--%>
            <div class="form-row">
                <div class="form-group col-md-5">
                    <label for="inputNombre">Nombre</label>
                    <asp:TextBox ID="tbNombre" runat="server" type="text" class="form-control" placeholder="Nombre"></asp:TextBox>
                </div>
                <div class="form-group col-md-5">
                    <label for="inputEmail4">Email</label>
                    <asp:TextBox ID="tbEmail" runat="server" type="email" class="form-control" placeholder="Email"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                    <label for="inputTelefono">Telefono</label>
                    <asp:TextBox ID="tbTelefono" runat="server" type="tel" class="form-control"></asp:TextBox>
                </div>
            </div>
            <%-- DIRECCION Y DIR WEB--%>
            <section>
                <div class="form-row">
                    <div class="form-group col-md-5">
                        <label for="inputAddress2">Web</label>
                        <asp:TextBox ID="tbWeb" runat="server" type="text" class="form-control" placeholder="web"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-7">
                        <label for="inputAddress">Direccion</label>
                        <asp:TextBox ID="tbDireccion" runat="server" type="text" class="form-control" placeholder="1234 Gran Vía "></asp:TextBox>
                    </div>
                </div>
            </section>

            <%--DATOS DIRECCION--%>
            <div class="form-row">
                <div class="form-group col-md-4">
                    <label for="inputState">Territorio</label>
                    <asp:DropDownList ID="DDL_provincia" runat="server" class="form-control" AutoPostBack="True">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Bizkaia</asp:ListItem>
                        <asp:ListItem>Gipuzkoa</asp:ListItem>
                        <asp:ListItem Value="Araba/Alava">Araba/Alava</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-4">
                    <label for="inputMunicipio">Municipio</label>
                    <asp:DropDownList ID="DDL_municipio" runat="server" class="form-control" AutoPostBack="True"></asp:DropDownList>
                </div>

                <div class="form-group col-md-4">
                    <label for="inputZip">Codigo Postal</label>
                    <asp:DropDownList ID="DDL_CP" runat="server" class="form-control" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>
            <%--OTROS DATOS--%>
            <div class="form-row">
                  <div class="form-group col-md-3">
                    <label for="inputEmail4">Tipo Alojamiento</label>
                    <asp:DropDownList ID="DDL_Tipos" runat="server" class="form-control" AutoPostBack="True">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Agroturismos</asp:ListItem>
                        <asp:ListItem>Campings</asp:ListItem>
                        <asp:ListItem>Casas Rurales</asp:ListItem>                          
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-2">
                    <label for="inputEmail4">Capacidad</label>
                    <asp:TextBox ID="tbCapacidad" runat="server" type="number" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                    <label for="inputEmail4">Firma</label>
                    <asp:TextBox ID="tbFirma" runat="server" type="text" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group col-md-4">
                    <label for="inputEmail4">Latitud/Longitud</label>
                    <asp:TextBox ID="tbLatitud" runat="server" type="text" CssClass="form-control"></asp:TextBox>
                </div>
              
            </div>
             <%--DESCRIPCION Y TRADUCIONES--%>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="">Descripción</label>
                    <textarea class="form-control" id="tb_descripcion" rows="6"></textarea>
                </div>
                <div class="form-group col-md-6">
                    <label for="">Traduccion Euskera</label>
                    <textarea class="form-control" id="tb_traduccion" rows="6"></textarea>
                </div>
            </div>
        </fieldset>
    </section>
   <%--MAS OPCIONES LOS CHECKS--%>
     <section>
        <%--Las opciones--%>
        <p>
            <%--<asp:Button ID="Button1" runat="server" Text="Mostrar mas opciones" class="btn btn-primary" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample" />--%>
        </p>
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <div>
                <asp:CheckBox ID="cb_auto" runat="server" Text="Autocaravana" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  
                <asp:CheckBox ID="cb_bar" runat="server" Text="Restaurante" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  
                <asp:CheckBox ID="cb_club" runat="server" Text="Club" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;					

                <asp:CheckBox ID="cb_certificado" runat="server" Text="Certificado" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 
                <asp:CheckBox ID="cb_tienda" runat="server" Text="Tienda" />
            </div>
        </asp:Panel>
    </section>
    <%--BOTON INSERTAR Y BARRA DE PROGRESO--%>
    <section>
        <div class="form-row">
            <br />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" type="submit" CssClass="btn btn-primary" />
            <br />
            <br />
        </div>
        <div class="progress">
            <br />
            <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 40%">
                40% Complete (success)
           
            </div>
        </div>
    </section>
</asp:Content>
