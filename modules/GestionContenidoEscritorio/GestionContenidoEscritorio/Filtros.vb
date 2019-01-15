Public Class Filtros
   
    Private Sub Btn_buscar_Click(sender As Object, e As EventArgs) Handles Btn_buscar.Click
        Dim nom, dire As String
        Dim capacy As Integer
        nom = Me.Text_filnom.Text
        dire = Me.Text_fildir.Text
        capacy = Me.Numeric_fil.Value
        Dim sql As String
        sql = "SELECT a.id, a.nombre, a.telefono, a.direccion, a.email, a.web, a.firma, t.tipo, t.resumen "
        sql &= "FROM alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='es'"
        sql &= " and a.nombre like '%" & nom & "%' and a.direccion like '%" & dire & "%' and "
        sql &= " a.capacidad >=" & capacy
        Adm_Content.cargardata(sql)

        Me.Hide()
    End Sub
End Class