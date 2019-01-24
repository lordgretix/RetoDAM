﻿Imports System.Data.OleDb
'Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class Form_Ini

    Public cnn1 As MySqlConnection
    Public iniciado As Boolean = False
    Private Function encriptarPassword() As String
        Dim SHA256 As SHA256 = SHA256Managed.Create()
        Dim hash() As Byte = SHA256.ComputeHash(Encoding.UTF8.GetBytes(Me.TextPassword.Text))

        Dim res As String = ""
        For i = 0 To hash.Length - 1
            res &= hash(i).ToString("X2")
        Next


        'Me.TextBox1.Text = res.ToLower
        Return res.ToLower
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_center(Me)
        Dim connStr As String = "server=kasserver.synology.me;database=reto_gp3;port=3307;user id=gp3;password=IFZWx5dEG12yt8QW;"
        cnn1 = New MySqlConnection(connStr)
        encriptarPassword()
        Try
            ' MsgBox("connecting...")
            cnn1.Open()
            ' MsgBox("hecho")
            Me.TextUser.Text = "sam"
            Me.TextPassword.Text = "1234"
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cnn1.Close()
        End Try
    End Sub

    Private Sub validarUserPasswor()
        Dim sql As String
        sql = "select * from usuarios where nombre='" & Me.TextUser.Text & "'"


        'sentencia que buscar el usuario introducido en la base de datos
        Me.lab_fail.Visible = False
        Me.Label_acceso.Visible = False
        Try
            cnn1.Open()
            Dim cmd As New MySqlCommand(sql, cnn1)

            Dim str As String = ""
            Dim data As MySqlDataReader
            Dim adapter As New MySqlDataAdapter
            Dim command As New MySqlCommand

            command.CommandText = sql
            command.Connection = cnn1
            adapter.SelectCommand = command
            data = command.ExecuteReader()

            While data.Read
                If data.HasRows = True Then
                    'tiene ese usuario registrado
                    If data(2).ToString = encriptarPassword() Then
                        'contraseña conicide
                        If data(3).ToString = 2 Then
                            'acepta si eres el rolo de editor de contenido
                            iniciado = True
                            Me.lab_fail.Visible = False
                            Me.Label_acceso.Visible = False
                            usuario = Me.TextUser.Text
                        Else
                            'el role asignado a ese usuario no tiene acceso a gestional contenidos
                            Me.Label_acceso.Visible = True
                            iniciado = False
                        End If

                    Else
                        'la contraseña no corresponde al usuario
                        Me.lab_fail.Visible = True
                    End If

                Else
                    Me.lab_fail.Visible = True
                    'no esta registrado ese usuario en la base de datos
                End If

            End While
        Catch ex As Exception

        Finally
            Try
                If cnn1.State = ConnectionState.Open Then
                    cnn1.Close()
                End If
            Catch ex As Exception

            End Try

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_inicial.Click
        validarUserPasswor()
        If iniciado Then
            Me.Hide()
            Loading.Show()
            Adm_Content.Show()

        End If

    End Sub
    Public Sub form_center(ByVal frm As Form, Optional ByVal parent As Form = Nothing)

        Dim x As Integer
        Dim y As Integer
        Dim r As Rectangle

        If Not parent Is Nothing Then
            r = parent.ClientRectangle
            x = r.Width - frm.Width + parent.Left
            y = r.Height - frm.Height + parent.Top
        Else
            r = Screen.PrimaryScreen.WorkingArea
            x = r.Width - frm.Width
            y = r.Height - frm.Height
        End If

        x = CInt(x / 2)
        y = CInt(y / 2)

        frm.StartPosition = FormStartPosition.Manual
        frm.Location = New Point(x, y)
    End Sub
End Class