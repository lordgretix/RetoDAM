Imports System.Data.OleDb
'Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class Form1

    Public cnn1 As MySqlConnection
    Dim iniciado As Boolean = False
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connStr As String = "server=kasserver.synology.me;database=reto_gp3;port=3307;user id=gp3;password=IFZWx5dEG12yt8QW;"
        cnn1 = New MySqlConnection(connStr)

        Try
            ' MsgBox("connecting...")
            cnn1.Open()
            MsgBox("hecho")
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cnn1.Close()
        End Try
    End Sub

    Private Sub validarUserPasswor()
        Dim sql As String
        sql = "select * from usuarios where nombre='" & Me.TextUser.Text & "'"

        Try
            ' MsgBox(sql)
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
                    ' MsgBox(data(1).ToString)
                    If data(1).ToString = Me.TextUser.Text Then
                        If data(2).ToString = Me.TextPassword.Text Then
                            'MsgBox("Sucsess")
                            iniciado = True
                            Me.lab_fail.Visible = False
                        Else
                            'la contraseña no corresponde al usuario
                            Me.lab_fail.Visible = True
                        End If

                    Else
                        'no existe el usuario
                        Me.lab_fail.Visible = True
                    End If

                Else
                    '   MsgBox("Login Failed! Please try again or contact support")
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
            Form2.Show()
            Me.Hide()
        End If

    End Sub
End Class