Imports MySql.Data.MySqlClient
Imports System.Data

Partial Class InicioSesion
    Inherits System.Web.UI.Page
    'copia de los datos 
    Dim das1 As New DataSet 'copia de los datos 
    Protected Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        'Dim dr As MySqlDataReader
        Dim cmd1 As New MySqlCommand
        Dim adap1 As New MySqlDataAdapter
        Dim sql As String

        sql = "Select nombre, password from usuario"
        Try 'NO ABRO LA CONEXION 
            cmd1 = New MySqlCommand(sql, Conexion.cnn1)
            adap1 = New MySqlDataAdapter(cmd1)
            das1.Clear() ' por si 
            adap1.Fill(das1, "aaa")
            Dim dv As New DataView
            dv.Table = Me.das1.Tables("aaa") ' estan TODOS los datos 
            dv.RowFilter = "nombre = '" & Me.txtNombre.Text & "' AND password= '" & Me.txtPassword.Text & "'"

            If dv.Count = 0 Then
                Me.lblMensaje.Visible = True
                Me.lblMensaje.Text = "Usuario no identificado"
            Else
                Response.Redirect("PaginaInicio.aspx")
                Me.lblMensaje.Visible = False
            End If
        Catch ex As Exception

        End Try

        'If Me.txtNombre.Text = "A" Then
        '    Response.Redirect("Default.aspx")
        'Else
        '    Me.lblMensaje.Visible = True
        '    Me.lblMensaje.Text = "Usuario no identificado"
        '    Me.txtNombre.Text = ""
        '    Me.txtPassword.Text = ""
        'End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'Me.lblMensaje.Visible = False
            'Me.txtNombre.Text = ""
            'Me.txtPassword.Text = ""
            Conexion.conectar()

        Catch ex As Exception
            MsgBox("No se pudo conectar " & ex.Message)
        End Try
    End Sub


End Class
