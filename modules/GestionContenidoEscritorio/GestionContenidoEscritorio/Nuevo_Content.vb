Imports MySql.Data.MySqlClient

Public Class Nuevo_Content

    Public idioma As String = "es"
    Public added As Boolean = False
    Dim tipo, firma As Boolean
    Private Sub Btn_add_Click(sender As Object, e As EventArgs) Handles Btn_add.Click
        añadir()

    End Sub

    Private Sub añadir()
        If Not Me.Text_firma.Text.Equals("") AndAlso Not Me.Text_Tipo.Text.Equals("") AndAlso Not Me.Text_nombre.Text.Equals("") Then
            'añadir datos a tabla de alojamientos
            If comprabarFirma(Me.Text_firma.Text) Then
                Try
                    Dim sql As String
                    sql = "INSERT INTO alojamientos (nombre, telefono, direccion, email, web, certificado, club, restaurante, tienda, autocaravana, "
                    sql &= "capacidad, cod_postal, latlong, cod_poblacion, firma) VALUES ( @nom, @tel, @dir, @mail, "
                    sql &= "@web, @certi, @club, @resta, @tienda, @auto, @capacy, @cp, @latlo, @codpob, @firma)"
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
                    cmd.Parameters.AddWithValue("@codpob", obtenerCodPob())
                    cmd.Parameters.AddWithValue("@firma", Me.Text_firma.Text) 'la firma es unica
                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                'añadir datos a tabla de traducciones
                Try
                    Dim sql As String
                    sql = "INSERT INTO traducciones (alojamiento, idioma, tipo, resumen, descripcion) values (@id_alo, "
                    sql &= "@idioma, @tipo, @resumen, @descripcion)"
                    Dim cmd As New MySqlCommand(sql, cnn1)
                    'hay que hacer un query para obtener el id de la alojamiento el cual relaciona las dos tablas
                    cmd.Parameters.AddWithValue("@id_alo", obtenerCodAlo())
                    cmd.Parameters.AddWithValue("@idioma", idioma) 'por defecto esta en castellano
                    cmd.Parameters.AddWithValue("@tipo", Me.Text_Tipo.Text)
                    cmd.Parameters.AddWithValue("@resumen", Me.Text_resu.Text)
                    cmd.Parameters.AddWithValue("@descripcion", Me.Text_descripcion.Text)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                Me.Hide()

            Else
                MsgBox("Esta firma ya esta en uso, intentalo con uno nuevo")
            End If
        Else
            If Me.Text_nombre.Text.Equals("") Then
                Me.textwarn1.Visible = True
            End If
            If Me.Text_Tipo.Text.Equals("") Then
                Me.textwarn2.Visible = True
            End If
            If Me.Text_firma.Text.Equals("") Then
                Me.textwarn3.Visible = True
            End If
        End If

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

    Private Sub Nuevo_Content_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        desconectar()
    End Sub

    Private Sub Nuevo_Content_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
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
        tipo = False
        firma = False
    End Sub

    Private Sub ComboBox_provincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_provincia.SelectedIndexChanged
        'Dim tabla As New DataTable

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

            'la siguente forma es meterlo como una tabla pero da un fallo al 
            'intentar cargar los codigos postales
            'Dim adap = New MySqlDataAdapter(cmd)
            'adap.Fill(tabla)
            'Me.ComboBox_poblacion.DataSource = tabla
            'Me.ComboBox_poblacion.DisplayMember = "poblacion"
            'Me.ComboBox_poblacion.ValueMember = "cod_poblacion"
            'Me.ComboBox_poblacion.SelectedIndex = -1

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

    Private Function obtenerCodPob() As Object
        Dim cod_pob As String = ""
        Try
            Dim sql As String = "SELECT cod_poblacion FROM codigos_postales where poblacion ='" & Me.ComboBox_poblacion.SelectedItem & "' "
            sql &= "and provincia='" & Me.ComboBox_provincia.SelectedItem & "'"
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
    Private Function comprabarFirma(firma As String) As Object
        Dim existe As Boolean = False
        Try
            Dim sql As String = "SELECT firma FROM alojamientos"
            Dim cmd As New MySqlCommand(sql, cnn1)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                If dr.HasRows Then
                    existe = dr.Item(0).Equals(firma)
                End If

            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return existe
    End Function

    Private Sub CastellanoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CastellanoToolStripMenuItem.Click
        idioma = "es"
    End Sub

    Private Sub EuskeraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EuskeraToolStripMenuItem.Click
        idioma = "eus"
    End Sub
End Class