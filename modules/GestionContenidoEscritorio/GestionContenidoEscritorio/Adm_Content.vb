Imports MySql.Data.MySqlClient
Public Class Adm_Content
    Friend WithEvents Tabla As DataTable

    Private Sub Form2_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        desconectar()
    End Sub

    '<System.Diagnostics.DebuggerStepThrough()> _
    'Public Sub MisTablas()
    '    Me.Tabla = New DataTable
    'End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()

        Dim sql As String
        Dim das1 As New DataSet
        'sql = "SELECT * FROM alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='es'"
        sql = "SELECT a.id, a.nombre, a.telefono, a.direccion, a.email, a.web, a.firma, t.tipo, t.resumen FROM alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='es'"

        Dim commando As New MySqlCommand
        Dim adapter As New MySqlDataAdapter
        Try
            commando.Connection = cnn1
            commando.CommandText = sql
            adapter.SelectCommand = commando
            'Dim dato As MySqlDataReader
            'Dim cont As Integer = 0
            'das1.Clear()

            adapter.Fill(das1, "aaa")

            Me.DataGridView1.DataSource = das1.Tables("aaa")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub CastellanoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CastellanoToolStripMenuItem.Click
        conectar()

        Dim sql As String
        Dim das1 As New DataSet
        'sql = "SELECT * FROM alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='es'"
        sql = "SELECT a.id, a.nombre, a.telefono, a.direccion, a.email, a.web, a.firma, t.tipo, t.resumen FROM alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='es'"

        Dim commando As New MySqlCommand
        Dim adapter As New MySqlDataAdapter

        commando.Connection = cnn1
        commando.CommandText = sql
        adapter.SelectCommand = commando
        'Dim dato As MySqlDataReader
        'Dim cont As Integer = 0
        'das1.Clear()

        adapter.Fill(das1, "aaa")

        Me.DataGridView1.DataSource = das1.Tables("aaa")

    End Sub

    Private Sub EuskeraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EuskeraToolStripMenuItem.Click
        conectar()

        Dim sql As String
        Dim das1 As New DataSet
        'sql = "SELECT * FROM alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='es'"
        sql = "SELECT a.id, a.nombre, a.telefono, a.direccion, a.email, a.web, a.firma, t.tipo, t.resumen FROM alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='eus'"

        Dim commando As New MySqlCommand
        Dim adapter As New MySqlDataAdapter

        commando.Connection = cnn1
        commando.CommandText = sql
        adapter.SelectCommand = commando
        'Dim dato As MySqlDataReader
        'Dim cont As Integer = 0
        'das1.Clear()

        adapter.Fill(das1, "aaa")

        Me.DataGridView1.DataSource = das1.Tables("aaa")

    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        Nuevo_Content.Show()
    End Sub

    Private Sub CerrarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesionToolStripMenuItem.Click
        Me.Hide()
        Form_Ini.Show()
        Form_Ini.iniciado = False
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        MsgBox("Usuario iniciado: " & usuario)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim fila As Integer
        fila = Me.DataGridView1.CurrentRow.Index
        Dim id As Integer = Me.DataGridView1.Item(0, fila).Value
        Modif_Content.Load_view(id)
    End Sub

End Class