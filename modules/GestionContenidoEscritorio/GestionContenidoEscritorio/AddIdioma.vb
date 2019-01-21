Imports MySql.Data.MySqlClient
Public Class AddIdioma
    Dim idioma As String
    Dim id_alo As Integer
    Private Sub Btn_limpiar_Click(sender As Object, e As EventArgs) Handles Btn_limpiar.Click
        Me.Text_Tipo.Text = Nothing
        Me.Text_resu.Text = Nothing
        Me.Text_descripcion.Text = Nothing
    End Sub

    Private Sub Btn_cancel_Click(sender As Object, e As EventArgs) Handles Btn_cancel.Click
        Me.Hide()
    End Sub

    Private Sub Btn_add_Click(sender As Object, e As EventArgs) Handles Btn_add.Click
        conectar()
        Try
            Dim sql As String
            sql = "INSERT INTO traducciones (alojamiento, idioma, tipo, resumen, descripcion) values (@id_alo, "
            sql &= "@idioma, @tipo, @resumen, @descripcion)"
            Dim cmd As New MySqlCommand(sql, cnn1)
            'hay que hacer un query para obtener el id de la alojamiento el cual relaciona las dos tablas
            cmd.Parameters.AddWithValue("@id_alo", id_alo)
            cmd.Parameters.AddWithValue("@idioma", idioma) 'por defecto esta en castellano
            cmd.Parameters.AddWithValue("@tipo", Me.Text_Tipo.Text)
            cmd.Parameters.AddWithValue("@resumen", Me.Text_resu.Text)
            cmd.Parameters.AddWithValue("@descripcion", Me.Text_descripcion.Text)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MsgBox("Añadido con exito")
        Me.Hide()
    End Sub
    Public Sub AddIdioma(ByVal idom As String, ByVal id As Integer)
        id_alo = id
        idioma = idom
        Me.Show()
    End Sub

    Private Sub AddIdioma_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        desconectar()
    End Sub
End Class