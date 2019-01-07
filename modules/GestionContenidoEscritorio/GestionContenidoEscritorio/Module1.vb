Imports MySql.Data.MySqlClient

Module Module1
    Public cnn1 As MySqlConnection

    Dim connStr As String = "server=kasserver.synology.me;database=reto_gp3;port=3307;user id=gp3;password=IFZWx5dEG12yt8QW;"
    Public Sub conectar()
        cnn1 = New MySqlConnection(connStr)

        Try
            If cnn1.State = ConnectionState.Closed Then
                cnn1.Open()
            End If
            ' MsgBox("connecting...")
            cnn1.Open()
            'MsgBox("hecho")
        Catch ex As Exception
            ' MsgBox(ex.Message) Este msgbox saler algo rao
        
        End Try
    End Sub
    Public Sub desconectar()
        cnn1 = New MySqlConnection(connStr)

        Try
            If cnn1.State = ConnectionState.Open Then
                cnn1.Close()
            End If
            ' MsgBox("connecting...")
            cnn1.Close()
            ' MsgBox("cerrado")
        Catch ex As Exception
            ' MsgBox(ex.Message)
       
        End Try
    End Sub
End Module
