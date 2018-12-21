Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Security.Cryptography

Partial Class InicioSesion
    Inherits System.Web.UI.Page
    'copia de los datos 
    Dim das1 As New DataSet 'copia de los datos 
    Protected Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        'Dim dr As MySqlDataReader
        Dim cmd1 As New MySqlCommand
        Dim adap1 As New MySqlDataAdapter
        Dim sql As String

        sql = "Select nombre, password from usuarios"
        Try 'NO ABRO LA CONEXION 
            cmd1 = New MySqlCommand(sql, Conexion.cnn1)
            adap1 = New MySqlDataAdapter(cmd1)

            das1.Clear() ' por si 
            adap1.Fill(das1, "aaa")
            Dim dv As New DataView
            dv.Table = Me.das1.Tables("aaa") ' estan TODOS los datos 

            'ENCRIPTAMOS LA CONTRASEÑA PARA COTEJARLA CON LA BBDD
            Dim contraseña As String
            contraseña = encriptar(Me.txtPassword.Text)
            'MsgBox(contraseña)
            ' Me.lblMensaje.Text = contraseña
            dv.RowFilter = "nombre = '" & Me.txtNombre.Text & "' AND password= '" & contraseña & "'"
            'dv.RowFilter = "nombre = '" & Me.txtNombre.Text & "' AND password= '" & Me.txtPassword.Text & "'"

            If dv.Count = 0 Then
                Me.lblMensaje.Visible = True
                Me.lblMensaje.Text = "Usuario no identificado"
            Else
                Response.Redirect("PaginaPrincipal.aspx")
                Me.lblMensaje.Visible = False
            End If
        Catch ex As Exception

        End Try

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

    Private Sub validarUserPasswor()
        'Dim iniciado As Boolean = False
        'Dim sql As String
        'sql = "select * from usuarios where nombre='" & Me.TextUser.Text & "'"

        'Try
        '    ' MsgBox(sql)
        '    cnn1.Open()
        '    Dim cmd As New MySqlCommand(sql, cnn1)

        '    Dim str As String = ""
        '    Dim data As MySqlDataReader
        '    Dim adapter As New MySqlDataAdapter
        '    Dim command As New MySqlCommand

        '    command.CommandText = sql
        '    command.Connection = cnn1
        '    adapter.SelectCommand = command
        '    data = command.ExecuteReader()

        '    While data.Read
        '        If data.HasRows = True Then
        '            ' MsgBox(data(1).ToString)
        '            If data(1).ToString = Me.TextUser.Text Then
        '                If data(2).ToString = Me.TextPassword.Text Then
        '                    'MsgBox("Sucsess")
        '                    iniciado = True
        '                    Me.lab_fail.Visible = False
        '                Else
        '                    'la contraseña no corresponde al usuario
        '                    Me.lab_fail.Visible = True
        '                End If

        '            Else
        '                'no existe el usuario
        '                Me.lab_fail.Visible = True
        '            End If

        '        Else
        '            '   MsgBox("Login Failed! Please try again or contact support")
        '        End If

        '    End While
        'Catch ex As Exception

        'Finally
        '    Try
        '        If cnn1.State = ConnectionState.Open Then
        '            cnn1.Close()
        '        End If
        '    Catch ex As Exception

        '    End Try

        'End Try

    End Sub
    Function encriptar(pass As String) As String
        Dim SHA256 As SHA256 = SHA256Managed.Create()
        Dim hash() As Byte = SHA256.ComputeHash(Encoding.UTF8.GetBytes(pass))

        Dim res As String = ""
        For i = 0 To hash.Length - 1
            res &= hash(i).ToString("X2")
        Next

        'Console.WriteLine(res.ToLower)
        Return res.ToLower
    End Function
End Class

