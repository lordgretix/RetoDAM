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
        sql = "SELECT a.id, a.nombre, a.telefono, a.direccion, a.email, a.web, a.firma, a.municipio, territorio, t.tipo, t.resumen FROM alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='es'"

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

    Private Sub QuinesSomosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuinesSomosToolStripMenuItem.Click

    End Sub
End Class