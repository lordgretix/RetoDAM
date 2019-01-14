<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Editar.aspx.vb" Inherits="Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <section>
        <fieldset>
            <legend>Alojamiento</legend>
            <br />

            <div class="form-row">
                <div class="form-group col-md-4">
                    <label for="inputNombre">Nombre</label>
                    <asp:TextBox ID="tbNombre" runat="server" type="text" class="form-control" placeholder="Nombre"></asp:TextBox>
                </div>
                <div class="form-group col-md-4">
                    <label for="inputEmail4">Email</label>
                    <asp:TextBox ID="tbEmail" runat="server" type="email" class="form-control" placeholder="Email"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                    <label for="inputTelefono">Telefono</label>
                    <asp:TextBox ID="tbTelefono" runat="server" type="tel" class="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-4">
                    <label for="inputAddress">Direccion</label>
                    <asp:TextBox ID="tbDireccion" runat="server" type="text" class="form-control" placeholder="1234 Gran Vía "></asp:TextBox>
                </div>
                <div class="form-group col-md-4">
                    <label for="inputAddress2">Web</label>
                    <asp:TextBox ID="tbWeb" runat="server" type="text" class="form-control" placeholder="web"></asp:TextBox>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-4">
                    <label for="inputMunicipio">Municipio</label>
                     <asp:DropDownList ID="DDL_municipio" runat="server" class="form-control">
                    </asp:DropDownList>
                   
                </div>
                <div class="form-group col-md-4">
                    <label for="inputState">Territorio</label>
                    <asp:DropDownList ID="DDL_provincia" runat="server" class="form-control" AutoPostBack="True">
                        <asp:ListItem>Bizkaia</asp:ListItem>
                        <asp:ListItem>Gipuzkoa</asp:ListItem>
                        <asp:ListItem Value="Araba/Alava">Araba/Alava</asp:ListItem>
                    </asp:DropDownList>
                    <%--  <select id="inputState" class="form-control">
                        <option selected>Bizkaia</option>
                        <option>Gipuzkoa</option>
                        <option>Alava</option>
                    </select>--%>
                </div>

                <div class="form-group col-md-4">
                    <label for="inputZip">Codigo Postal</label>
                    <asp:DropDownList ID="DDL_CP" runat="server" class="form-control">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem></asp:ListItem>

                    </asp:DropDownList>
                    <%--<asp:TextBox ID="tbCP" runat="server" type="text" class="form-control"  placeholder="00000"></asp:TextBox>--%>
                </div>
                <div class="form-group col-md-2">
                    <label for="inputEmail4">Capacidad</label>
                    <%--<input type="number" class="form-control" id="inputCapacidad">--%>
                    <asp:TextBox ID="tbCapacidad" runat="server" type="number" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="">Resumen</label>
                    <%--<textarea class="form-control" id="exampleFormControlTextarea1" rows="7"></textarea>--%>
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" Rows="7"></asp:TextBox>
                </div>
                <div class="form-group col-md-6">
                    <label for="">Descripción</label>
                    <textarea class="form-control" id="exampleFormControlTextarea2" rows="6"></textarea>

                </div>
            </div>


        </fieldset>

    </section>
    <section>
        <%--Las opciones--%>
        <p>

            <asp:Button ID="Button1" runat="server" Text="Mostrar mas opciones" class="btn btn-primary" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample" />
        </p>
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <div>
                <asp:CheckBox ID="CheckBox6" runat="server" Text="Autocaravana" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="CheckBox7" runat="server" Text="Restaurante" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="CheckBox8" runat="server" Text="Club" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="CheckBox9" runat="server" Text="Certificado" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="CheckBox10" runat="server" Text="Tienda" />
            </div>
        </asp:Panel>

    </section>
    <section>
        <div class="form-row">
            <br />

            <%--<button type="submit" class="btn btn-primary">Añadir</button>--%>
            <asp:Button ID="btnInsertar" runat="server" Text="Añadir" type="submit" class="btn btn-primary" />
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
