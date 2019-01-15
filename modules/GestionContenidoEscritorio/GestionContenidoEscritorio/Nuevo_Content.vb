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
        sql = "INSERT INTO alojamientos ( nombre, telefono, direccion, email, web, certificado, club, restaurante, tienda, autocaravana, "
        sql &= "capacidad, cod_postal, latlong, cod_poblacion, firma) VALUES ( @nom, @tel, @dir, @mail, "
        sql &= "@web, @certi, @club, @resta, @tienda, @auto, @capacy, @cp, @latlo, @codpo, @firma)"
        Dim commando As New MySqlCommand
        Dim adapter As New MySqlDataAdapter

        commando.Connection = cnn1
        commando.CommandText = sql
        adapter.SelectCommand = commando
    End Sub

    Private Sub Text_firma_TextChanged(sender As Object, e As EventArgs) Handles Text_firma.TextChanged

    End Sub

    Private Sub CerrarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesionToolStripMenuItem.Click
        Me.Hide()
        Form_Ini.Show()
        Form_Ini.iniciado = False
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        MsgBox("Usuario iniciado: " & usuario)
    End Sub

    Private Sub Btn_limpiar_Click(sender As Object, e As EventArgs) Handles Btn_limpiar.Click
        Me.Text_nombre.Clear()
        Me.Text_tel.Clear()
        Me.Text_direccion.Clear()
        Me.Text_email.Clear()
        Me.Text_web.Clear()
        Me.Text_Tipo.Clear()
        Me.Check_caravana.Checked = False
        Me.Check_certificado.Checked = False
        Me.Check_club.Checked = False
        Me.Check_restaurante.Checked = False
        Me.Check_tienda.Checked = False
        Me.Text_capacity.Clear()
        Me.Text_lat.Clear()
        Me.ComboBox_poblacion.SelectedIndex = -1
        Me.ComboBox_provincia.SelectedIndex = -1
        Me.ComboBox_cp.SelectedIndex = -1
        Me.Text_firma.Clear()
        Me.Text_resu.Clear()
        Me.Text_descripcion.Clear()

    End Sub

    Private Sub Nuevo_Content_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim sql As String = "SELECT DISTINCT provincia FROM codigos_postales"
            Dim cmd As New MySqlCommand(sql, cnn1)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Me.ComboBox_provincia.Items.Add(dr.Item(0))
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ComboBox_provincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_provincia.SelectedIndexChanged
        Try
            Me.ComboBox_poblacion.Items.Clear()

            Dim sql As String = "SELECT DISTINCT poblacion FROM codigos_postales where provincia ='" & Me.ComboBox_provincia.SelectedItem & "'"
            Dim cmd As New MySqlCommand(sql, cnn1)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Me.ComboBox_poblacion.Items.Add(dr.Item(0))
            End While
            dr.Close()
            Me.ComboBox_poblacion.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ComboBox_poblacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_poblacion.SelectedIndexChanged
        Try
            Me.ComboBox_cp.Items.Clear()

            Dim sql As String = "SELECT DISTINCT cod_postal FROM codigos_postales where poblacion ='" & Me.ComboBox_poblacion.SelectedItem & "'"
            Dim cmd As New MySqlCommand(sql, cnn1)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Me.ComboBox_cp.Items.Add(dr.Item(0))
            End While
            dr.Close()
            Me.ComboBox_cp.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class