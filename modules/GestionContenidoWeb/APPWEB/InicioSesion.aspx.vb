
Partial Class InicioSesion
    Inherits System.Web.UI.Page

    Protected Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        If Me.txtNombre.Text = "A" Then
            Response.Redirect("Default.aspx")
        Else
            Me.lblMensaje.Visible = True
            Me.lblMensaje.Text = "Usuario no identificado"
            Me.txtNombre.Text = ""
            Me.txtPassword.Text = ""
        End If
    End Sub
End Class
