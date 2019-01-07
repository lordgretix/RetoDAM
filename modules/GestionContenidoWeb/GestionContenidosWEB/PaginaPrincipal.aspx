<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PaginaPrincipal.aspx.vb" Inherits="PaginaPrincipal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Buscar:  "></asp:Label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    <br />

    <asp:Button ID="Button1" runat="server" Text="Mostrar Tabla" class="btn btn-primary" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="Mapa" class="btn btn-primary" />
    <br />
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <br />
        <div id="tabla" style="overflow: scroll">
            <asp:GridView ID="GridView1" runat="server" Style="overflow: scroll" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True">
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#8BC34A" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#4caf50" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />

            </asp:GridView>
        </div>

        <section>
            <!-- Button to Open the Modal -->
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">
                Actualizar
            </button>
            <asp:Button ID="Button4" runat="server" Text="Insertar" class="btn btn-primary" />
            <asp:Button ID="Button5" runat="server" Text="Eliminar" class="btn btn-primary" />
            <!-- The Modal -->
            <div class="modal fade" id="myModal">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">

                        <!-- Modal Header -->
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Datos</h4>

                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <section>
                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label for="inputPassword4">Nombre</label>
                                        <asp:TextBox ID="tbNombre" runat="server" type="text" class="form-control" placeholder="Nombre"></asp:TextBox>

                                    </div>
                                    <div class="form-group col-md-6">
                                        <label for="inputEmail4">Email</label>
                                        <asp:TextBox ID="tbEmail" runat="server" ype="email" class="form-control" placeholder="Email"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label for="inputEmail4">Telefono</label>
                                        <asp:TextBox ID="tbTelefono" runat="server" type="tel" class="form-control"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <label for="inputAddress">Direccion</label>
                                        <asp:TextBox ID="tbDireccion" runat="server" type="text" class="form-control" placeholder="1234 Gran Vía "></asp:TextBox>

                                    </div>
                                    <div class="form-group col-md-6">
                                        <label for="inputAddress2">Web</label>
                                        <asp:TextBox ID="tbWeb" runat="server" type="text" class="form-control" placeholder="web"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label for="inputCity">Municipio</label>
                                        <asp:TextBox ID="tbMunicipio" runat="server" type="text" class="form-control"></asp:TextBox>

                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="inputState">Territorio</label>
                                       <%-- <select id="inputState" class="form-control">
                                            <option selected>Bizkaia</option>
                                            <option>Gipuzkoa</option>
                                            <option>Alava</option>
                                        </select>--%>
                                        <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                                            <asp:ListItem>Bizkaia</asp:ListItem>
                                            <asp:ListItem>Gipuzkoa</asp:ListItem>
                                            <asp:ListItem>Alava/Araba</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="form-group col-md-4">
                                        <label for="inputZip">Codigo Postal</label>
                                        <asp:TextBox ID="tbCP" runat="server" type="text" class="form-control"></asp:TextBox>

                                    </div>
                                    <div class="form-group col-md-10">
                                        <label for="inputCapacidad">Capacidad</label>
                                        <asp:TextBox ID="tbCapacidad" runat="server" type="number" class="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <section>
                                    <asp:Panel ID="Panel2" runat="server" Visible="True">
                                        <%--  <div>
                                            <asp:CheckBox ID="CheckBox6" runat="server" Text="Autocaravana" />

                                            <asp:CheckBox ID="CheckBox7" runat="server" Text="Restaurante" />

                                            <asp:CheckBox ID="CheckBox8" runat="server" Text="Club" />

                                            <asp:CheckBox ID="CheckBox9" runat="server" Text="Certificado" />

                                            <asp:CheckBox ID="CheckBox10" runat="server" Text="Tienda" />
                                        </div>--%>
                                    </asp:Panel>
                                </section>

                            </section>
                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">

                            <%-- <button type="button" class="btn btn-secondary" data-dismiss="modal">Actualizar</button>--%>
                            <asp:Button ID="Button3" runat="server" Text="Actualizar" class="btn btn-secondary" data-dismiss="modal" />
                        </div>

                    </div>
                </div>
            </div>
        </section>

    </asp:Panel>



</asp:Content>


