Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Security.Cryptography

Partial Class InicioSesion
    Inherits System.Web.UI.Page
    'copia de los datos 
    Dim das1 As New DataSet 'copia de los datos 
    Dim iniciado As Boolean = False
    Protected Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click

        Dim sql As String
        sql = "select * from usuarios where nombre='" & Me.txtNombre.Text & "'"
        'sentencia que buscar el usuario introducido en la base de datos
        Me.lblMensaje.Visible = False
        'Me.Label_acceso.Visible = False
        Try
            Conexion.conectar()

            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)

            Dim str As String = ""
            Dim data As MySqlDataReader
            Dim adapter As New MySqlDataAdapter
            Dim command As New MySqlCommand

            command.CommandText = sql
            command.Connection = Conexion.cnn1
            adapter.SelectCommand = command
            data = command.ExecuteReader()

            While data.Read
                If data.HasRows = True Then
                    'tiene ese usuario registrado
                    If data(2).ToString = encriptar(Me.txtPassword.Text) Then
                        'contraseña conicide
                        If data(3).ToString = 2 Then
                            'acepta si eres el rolo de editor de contenido
                            iniciado = True
                            Me.lblMensaje.Visible = False

                            'usuario = Me.TextUser.Text
                        Else
                            'el role asignado a ese usuario no tiene acceso a gestional contenidos
                            Me.lblMensaje.Text = "Sin acceso"
                            Me.lblMensaje.Visible = True
                            iniciado = False
                        End If

                    Else
                        'la contraseña no corresponde al usuario
                        Me.lblMensaje.Text = "Usuario no identificado o contraseña incorrecta"
                        Me.lblMensaje.Visible = True
                    End If

                Else
                    Me.lblMensaje.Visible = True
                    'no esta registrado ese usuario en la base de datos
                End If

            End While
        Catch ex As Exception

        Finally
            Try
                Conexion.desconectar()
                'If cnn1.State = ConnectionState.Open Then
                '    cnn1.Close()
                'End If
            Catch ex As Exception

            End Try

        End Try

        If iniciado Then
            Response.Redirect("Default.aspx")
            '        Me.lblMensaje.Visible = False
        End If
  
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

    Protected Sub inicio()
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
                Response.Redirect("Default.aspx")
                Me.lblMensaje.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class

