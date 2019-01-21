Imports MySql.Data.MySqlClient

Public Class Mapa

    Dim urlMaps As String
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        'Concatenamos la dirección con el Textbox añadimos la última sentencia para indicar que sólo se muestre el mapa
        urlMaps = "http://maps.google.es/maps?q=" & ComboBox1.SelectedItem
        Dim direccion As New Uri(urlMaps)
        'ASignamos como URL la direccion
        WebBrowser1.Url = direccion
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Adm_Content.Show()
        Me.Close()

    End Sub

    Private Sub Mapa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form_Ini.form_center(Me)
        conectar()
        Try
            Dim sql As String
            sql = "SELECT nombre FROM alojamientos"
            Dim cmd As New MySqlCommand(sql, cnn1)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Me.ComboBox1.Items.Add(dr.Item(0))
            End While
            urlMaps = "https://www.google.es/maps/"
            Dim direccion As New Uri(urlMaps)
            WebBrowser1.Url = direccion
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            desconectar()
        End Try
        Loading.Hide()
    End Sub
End Class