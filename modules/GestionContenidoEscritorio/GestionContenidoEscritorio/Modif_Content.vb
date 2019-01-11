Imports MySql.Data.MySqlClient
Public Class Modif_Content

    Private Sub Modif_Content_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub Load_view(id As Integer)
        conectar()
        Dim sql As String = "Select * from alojamientos where id = " & id
        Dim cmd As New MySqlCommand(sql, cnn1)
        Dim dr As MySqlDataReader
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            While dr.Read

            End While
        End If

    End Sub
End Class