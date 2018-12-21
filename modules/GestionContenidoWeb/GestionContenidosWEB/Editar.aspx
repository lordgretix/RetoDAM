<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Editar.aspx.vb" Inherits="Editar" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
        <div class="container">
            <h1>Gestion Alojamientos</h1>

            <hr>

            <label for="nombre"><b>Nombre</b></label>
            <input type="text" placeholder="Nombre" name="nombre" required>
            <br />

            <label for="psw"><b>Dirección</b></label>
            <input type="text" placeholder="Dirección" name="psw" required>
            <br />

            <label for="email"><b>Email</b></label>
            <input type="text" placeholder="Email" name="" required>
            <br />

            <label for="telefono"><b>Telefono</b></label>
            <input type="text" placeholder="telefono" name="telefono" required>
            <br />

            <label for="web"><b>Web</b></label>
            <input type="text" placeholder="Web" name="web" required>
            <br />

            <label for="cod_postal"><b>Codigo Postal</b></label>
            <input type="number" name="" required>
            <br />
            <hr>

            <button type="submit" class="registerbtn">Añadir</button>
            
        </div>
        <br />
        <div class="progress">
            <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width:40%">
                40% Complete (success)
            </div>
        </div>
    </asp:Content>