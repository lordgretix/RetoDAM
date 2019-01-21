Imports MySql.Data.MySqlClient
Public Class Modif_Content

    Dim cod_poblacion, cod_postal, id_alo, poblcaion, provincia As String
    Public idioma As String = "es"
    Dim castellano As Boolean = False
    Dim euskera As Boolean = False

    Public Sub Load_view(id As Integer)
        Dim indexcodpos As Integer
        Dim intValue As Integer
        id_alo = id
        conectar()
        llenarComboboxs()
        Try
            Dim sql As String = "Select * from alojamientos where id = " & id
            Dim cmd As New MySqlCommand(sql, cnn1)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    Me.Text_nombre.Text = dr.Item(1)
                    Me.Text_tel.Text = dr.Item(2)
                    Me.Text_direccion.Text = dr.Item(3)
                    Me.Text_email.Text = dr.Item(4)
                    Me.Text_web.Text = dr.Item(5)
                    Me.Check_certificado.Checked = dr.Item(6)
                    Me.Check_club.Checked = dr.Item(7)
                    Me.Check_restaurante.Checked = dr.Item(8)
                    Me.Check_tienda.Checked = dr.Item(9)
                    Me.Check_caravana.Checked = dr.Item(10)
                    Me.Text_capacity.Text = dr.Item(11)
                    cod_postal = dr.Item(12)
                    Me.ComboBox_cp.SelectedItem = cod_postal
                    Me.Text_lat.Text = dr.Item(13)
                    cod_poblacion = dr.Item(14) 'no esta cargado aun ya que estamos cogiendo el codigo 
                    Me.Text_firma.Text = dr.Item(15)
                End While

            End If
            dr.Close()

            sql = "Select * from traducciones where alojamiento = " & id & " and idioma= 'es'"
            Dim cmd2 As New MySqlCommand(sql, cnn1)
            dr = cmd2.ExecuteReader
            If dr.HasRows Then
                castellano = True
                While dr.Read
                    Me.Text_Tipo.Text = dr.Item(3)
                    Me.Text_resu.Text = dr.Item(4)
                    Me.Text_descripcion.Text = dr.Item(5)
                End While
                dr.Close()
                euskera = tieneEus(id)
                'si tiene en catellano comprbaria si tiene en euskera
            Else
                'si no tiene en catellano buscará direcamente en euskera
                dr.Close()
                sql = "Select * from traducciones where alojamiento = " & id & " and idioma= 'eus'"
                Dim cmd2_eu As New MySqlCommand(sql, cnn1)
                dr = cmd2_eu.ExecuteReader
                If dr.HasRows Then
                    euskera = True
                    While dr.Read
                        Me.Text_Tipo.Text = dr.Item(3)
                        Me.Text_resu.Text = dr.Item(4)
                        Me.Text_descripcion.Text = dr.Item(5)
                    End While
                End If
            End If

            sql = "select * from codigos_postales where cod_poblacion= " & cod_poblacion & " and cod_postal= " & cod_postal
            Dim cmd3 As New MySqlCommand(sql, cnn1)
            dr.Close()
            dr = cmd3.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    poblcaion = dr.Item(3)
                    provincia = dr.Item(4)
                End While
            End If
            dr.Close()
            Me.ComboBox_poblacion.SelectedItem = poblcaion
            Me.ComboBox_provincia.SelectedItem = provincia
            Loading.Close()
            For i As Integer = 0 To ComboBox_cp.Items.Count - 1
                ComboBox_cp.SelectedIndex = i
                intValue = ComboBox_cp.Items(i)
                If intValue = cod_postal Then
                    indexcodpos = i
                End If
            Next
            Me.ComboBox_cp.SelectedIndex = indexcodpos

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        desconectar()
        Me.Show()
        Me.ComboBox_poblacion.SelectedItem = poblcaion
        Me.ComboBox_cp.SelectedIndex = indexcodpos
        ' por alguna razon tengo que volver a darle seleccionar para poder manntener la seleccion
        'Me.MenuStrip1.Items(1).Enabled = False

        If castellano Then
            CastellanoToolStripMenuItem1.Enabled = False
        End If
        If euskera Then
            EuskeraToolStripMenuItem1.Enabled = False
        End If

    End Sub
    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        Nuevo_Content.Show()
        Me.Hide()
    End Sub

    Private Sub CerrarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesionToolStripMenuItem.Click
        Me.Hide()
        Form_Ini.Show()
        Form_Ini.iniciado = False
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        MsgBox("Usuario iniciado: " & usuario)
    End Sub

    Private Sub Btn_borrar_Click(sender As Object, e As EventArgs) Handles Btn_borrar.Click
        conectar()
        Dim sql As String
        Try
            sql = "Delete from alojamientos where id = " & id_alo
            Dim cmd As New MySqlCommand(sql, cnn1)
            'MsgBox("El registro de " & Me.Text_nombre.Text & " eliminado")
            If MessageBox.Show("El registro de " & Me.Text_nombre.Text & " será eliminado", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd.ExecuteNonQuery()
                MsgBox("Registro eliminado")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        sql = "SELECT a.id, a.nombre, a.telefono, a.direccion, a.email, a.web, a.firma, t.tipo, t.resumen FROM alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='es'"
        Adm_Content.cargardata(sql)
        Me.Hide()
        desconectar()
    End Sub

    Private Sub Btn_save_Click(sender As Object, e As EventArgs) Handles Btn_save.Click
        conectar()
        Try
            MsgBox(Me.ComboBox_cp.SelectedItem)
            Dim sql As String
            sql = "update alojamientos set nombre= @nom, telefono= @tel, direccion= @dir, email= @mail,"
            sql &= "web= @web, certificado= @certi, club= @club, restaurante= @resta, tienda= @tienda,"
            sql &= "autocaravana= @auto, capacidad= @capacy, cod_postal= @cp, latlong= @latlo, "
            sql &= "cod_poblacion= @codpob where firma= @firma"
            'las firmas no son editables
            Dim cmd As New MySqlCommand(sql, cnn1)
            cmd.Parameters.AddWithValue("@nom", Me.Text_nombre.Text)
            cmd.Parameters.AddWithValue("@tel", Me.Text_tel.Text)
            cmd.Parameters.AddWithValue("@dir", Me.Text_direccion.Text)
            cmd.Parameters.AddWithValue("@mail", Me.Text_email.Text)
            cmd.Parameters.AddWithValue("@web", Me.Text_web.Text)
            cmd.Parameters.AddWithValue("@certi", Me.Check_certificado.Checked)
            cmd.Parameters.AddWithValue("@club", Me.Check_club.Checked)
            cmd.Parameters.AddWithValue("@resta", Me.Check_restaurante.Checked)
            cmd.Parameters.AddWithValue("@tienda", Me.Check_tienda.Checked)
            cmd.Parameters.AddWithValue("@auto", Me.Check_caravana.Checked)
            cmd.Parameters.AddWithValue("@capacy", Me.Text_capacity.Text)
            cmd.Parameters.AddWithValue("@cp", Me.ComboBox_cp.SelectedItem)
            cmd.Parameters.AddWithValue("@latlo", Me.Text_lat.Text)
            'poblacion hay que hacer un query para coger el codigo ya que en el combobox esta los nombres
            ' MsgBox(obtenerCodPob())
            cmd.Parameters.AddWithValue("@codpob", obtenerCodPob())
            cmd.Parameters.AddWithValue("@firma", Me.Text_firma.Text)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            Dim sql As String
            sql = "update traducciones set alojamiento= @id_alo, idioma= @idioma, tipo=@tipo, "
            sql &= "resumen= @resumen, descripcion= @descripcion where id=@id_tradu"

            Dim cmd As New MySqlCommand(sql, cnn1)
            'hay que hacer un query para obtener el id de la alojamiento el cual relaciona las dos tablas
            cmd.Parameters.AddWithValue("@id_alo", obtenerCodAlo())
            cmd.Parameters.AddWithValue("@idioma", idioma) 'por defecto esta en castellano
            cmd.Parameters.AddWithValue("@tipo", Me.Text_Tipo.Text)
            cmd.Parameters.AddWithValue("@resumen", Me.Text_resu.Text)
            cmd.Parameters.AddWithValue("@descripcion", Me.Text_descripcion.Text)
            cmd.Parameters.AddWithValue("@id_tradu", obtenerIdTradu())
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MsgBox("actualizado")
        Adm_Content.cargardata("SELECT a.id, a.nombre, a.telefono, a.direccion, a.email, a.web, a.firma, t.tipo, t.resumen FROM alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='es'")
        desconectar()
        Me.Hide()
    End Sub

    Private Sub llenarComboboxs()
        'llena los tres combobox sin uso de filtros para poder cargar datos
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
        Try
            Me.ComboBox_poblacion.Items.Clear()

            Dim sql As String = "SELECT DISTINCT poblacion FROM codigos_postales"
            Dim cmd As New MySqlCommand(sql, cnn1)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Me.ComboBox_poblacion.Items.Add(dr.Item(0))
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            Me.ComboBox_cp.Items.Clear()

            Dim sql As String = "SELECT DISTINCT cod_postal FROM codigos_postales"
            Dim cmd As New MySqlCommand(sql, cnn1)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Me.ComboBox_cp.Items.Add(dr.Item(0))
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function obtenerCodAlo() As Object

        Dim cod_alo As String = ""
        Try
            Dim sql As String = "SELECT id FROM alojamientos where firma ='" & Me.Text_firma.Text & "' "
            Dim cmd As New MySqlCommand(sql, cnn1)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                cod_alo = (dr.Item(0))
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return cod_alo

    End Function

    Private Function obtenerIdTradu() As Object
        Dim cod_tradu As String = ""
        Try
            Dim sql As String = "SELECT id FROM traducciones where alojamiento ='" & id_alo & "' "
            sql &= "and idioma='" & idioma & "'"
            Dim cmd As New MySqlCommand(sql, cnn1)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                cod_tradu = (dr.Item(0))
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return cod_tradu

    End Function

    Private Function obtenerCodPob() As Object

        Dim cod_pob As String = ""
        Try
            Dim sql As String = "SELECT cod_poblacion FROM codigos_postales where poblacion ='" & Me.ComboBox_poblacion.SelectedItem & "' "
            sql &= "and provincia='" & Me.ComboBox_provincia.SelectedItem & "'"
            'MsgBox(Me.ComboBox_poblacion.SelectedItem)
            'MsgBox(Me.ComboBox_provincia.SelectedItem)

            Dim cmd As New MySqlCommand(sql, cnn1)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                cod_pob = (dr.Item(0))
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return cod_pob

    End Function

    Private Sub ComboBox_provincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_provincia.SelectedIndexChanged
        conectar()
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
        desconectar()
    End Sub

    Private Sub ComboBox_poblacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_poblacion.SelectedIndexChanged
        conectar()
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
        desconectar
    End Sub

    Private Sub CastellanoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CastellanoToolStripMenuItem.Click
        idioma = "es"
        cambiarIdioma()
    End Sub

    Private Sub EuskeraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EuskeraToolStripMenuItem.Click
        idioma = "eus"
        cambiarIdioma()
    End Sub

    Private Function tieneEus(id As Integer) As Boolean
        Dim tiene As Boolean = False
        Dim dr As MySqlDataReader
        Dim sql As String
        sql = "Select * from traducciones where alojamiento = " & id & " and idioma= 'eus'"
        Dim cmd2_eu As New MySqlCommand(sql, cnn1)
        dr = cmd2_eu.ExecuteReader
        If dr.HasRows Then
            tiene = True
        End If
        dr.Close()

        Return tiene
    End Function

    Private Sub CastellanoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CastellanoToolStripMenuItem1.Click
        AddIdioma.AddIdioma("es", id_alo)
    End Sub

    Private Sub EuskeraToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EuskeraToolStripMenuItem1.Click
        AddIdioma.AddIdioma("eus", id_alo)
    End Sub

    Private Sub cambiarIdioma()
        conectar()
        Dim dr As MySqlDataReader
        Dim sql As String
        Try
            sql = "Select * from traducciones where alojamiento = " & id_alo & " and idioma= '" & idioma & "'"
            Dim cmd2_eu As New MySqlCommand(sql, cnn1)
            dr = cmd2_eu.ExecuteReader
            If dr.HasRows Then
                euskera = True
                While dr.Read
                    Me.Text_Tipo.Text = dr.Item(3)
                    Me.Text_resu.Text = dr.Item(4)
                    Me.Text_descripcion.Text = dr.Item(5)
                End While
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub Modif_Content_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        desconectar()
    End Sub
End Class