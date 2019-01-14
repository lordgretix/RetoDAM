Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Conexion
    Public Shared cnn1 As MySqlConnection

    Public Shared Sub conectar()
        Dim cadenaconexion As String = "server=kasserver.synology.me;database=reto_gp3;user id=gp3;port=3307; password=IFZWx5dEG12yt8QW;"
        'Dim cadenaconexion As String = "server=localhost;database=hola;user id=root; password=;"
        cnn1 = New MySqlConnection(cadenaconexion)

        Try
            If cnn1.State = ConnectionState.Closed Then
                cnn1.Open()
            End If
            'MsgBox("hecho")
        Catch ex As Exception
            'MsgBox(ex.Message) 'Este msgbox saler algo rao

        End Try
    End Sub
    Public Shared Sub desconectar()
        Dim cadenaconexion As String = "server=localhost;database=hola;user id=root; password=;"
        cnn1 = New MySqlConnection(cadenaconexion)

        Try
            If cnn1.State = ConnectionState.Open Then
                cnn1.Close()
            End If
            ' MsgBox("connecting...")
            cnn1.Close()
            'MsgBox("cerrado")
        Catch ex As Exception
            ' MsgBox(ex.Message)

        End Try
    End Sub
End Class
