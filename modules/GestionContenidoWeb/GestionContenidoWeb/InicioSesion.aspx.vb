Imports MySql.Data.MySqlClient

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

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            'Dim cadenaconexion As String = "server=localhost;database=hola;user id=root; password=;"
            ''Dim cadenaconexion As String = "server=kasserver.synology.me;database=reto_gp3;user id=gp3;port=3307; password=IFZWx5dEG12yt8QW;"
            'Dim conexion = New MySqlConnection(cadenaconexion)
            '' Dim con As New MySqlConnection(conexion.ToString)
            'conexion.Open()
            ''MsgBox("La conexion se realizo")
            Conexion.conectar()


        Catch ex As Exception
            MsgBox("No se pudo conectar " & ex.Message)
        End Try
    End Sub


End Class
