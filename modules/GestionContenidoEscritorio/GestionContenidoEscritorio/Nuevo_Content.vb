Imports MySql.Data.MySqlClient

Public Class Nuevo_Content

    Public added As Boolean = False
    Private Sub Btn_add_Click(sender As Object, e As EventArgs) Handles Btn_add.Click
        añadir()

    End Sub

    Private Sub añadir()
        Dim sql As String
        Dim das1 As New DataSet
        'sql = "Insert into alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='es'"
        'sql = "SELECT a.id, a.nombre, a.telefono, a.direccion, a.email, a.web, a.firma, a.municipio, territorio, t.tipo, t.resumen FROM alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='es'"
        sql = "INSERT INTO alojaminetos2 (`id`, `nombre`, `telefono`, `direccion`, `email`, `web`, `certificado`, `club`, `restaurante`, `tienda`, `autocaravana`, `capacidad`, `cod_postal`, `latlong`, `municipio`, `territorio`, `firma`, `json`) VALUES ('', 'asd', 'sdga', 'sdfsadf', 'adfg', 'adfga', '1', '1', '1', '1', '1', '234', 'cfggf', 'asdfasf', 'sdgfsada', 'adsfagsdg', 'asdfsadg', 'sfghsgh')"
        Dim commando As New MySqlCommand
        Dim adapter As New MySqlDataAdapter

        commando.Connection = cnn1
        commando.CommandText = sql
        adapter.SelectCommand = commando
    End Sub
End Class