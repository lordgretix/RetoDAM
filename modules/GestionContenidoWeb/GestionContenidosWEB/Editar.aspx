<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Editar.aspx.vb" Inherits="Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <section>
        <fieldset>
            <legend>Alojamiento</legend>
            <br />

            <div class="form-row">
                <div class="form-group col-md-4">
                    <label for="inputPassword4">Nombre</label>
                    <input type="password" class="form-control" id="inputPassword4" placeholder="Nombre">
                </div>
                <div class="form-group col-md-4">
                    <label for="inputEmail4">Email</label>
                    <input type="email" class="form-control" id="inputEmail4" placeholder="Email">
                </div>
                <div class="form-group col-md-2">
                    <label for="inputEmail4">Telefono</label>
                    <input type="tel" class="form-control" id="inputTelefono">
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-4">
                    <label for="inputAddress">Direccion</label>
                    <input type="text" class="form-control" id="inputAddress" placeholder="1234 Main St">
                </div>
                <div class="form-group col-md-4">
                    <label for="inputAddress2">Web</label>
                    <input type="text" class="form-control" id="inputAddress2" placeholder="web">
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-4">
                    <label for="inputCity">Municipio</label>
                    <input type="text" class="form-control" id="inputCity">
                </div>
                <div class="form-group col-md-4">
                    <label for="inputState">Territorio</label>
                    <select id="inputState" class="form-control">
                        <option selected>Bizkaia</option>
                        <option>Gipuzkoa</option>
                        <option>Alava</option>
                    </select>
                </div>

                <div class="form-group col-md-4">
                    <label for="inputZip">Codigo Postal</label>
                    <input type="text" class="form-control" id="inputZip">
                </div>
                <div class="form-group col-md-2">
                    <label for="inputEmail4">Capacidad</label>
                    <input type="number" class="form-control" id="inputCapacidad">
                </div>
            </div>
            <div class="form-row">
                 <div class="form-group col-md-10">
                      <label for="">Descripción</label>
                     <textarea class="form-control" id="exampleFormControlTextarea1" rows="6"></textarea>
                    
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

            <button type="submit" class="btn btn-primary">Añadir</button>
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
