Imports MySql.Data.MySqlClient
Public Class Modif_Content

    Dim cod_poblacion, cod_postal, id_alo As String
    Private Sub Modif_Content_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub Load_view(id As Integer)
        id_alo = id
        conectar()
        Try
            Dim sql As String = "Select * from alojamientos where id = " & id
            Dim cmd As New MySqlCommand(sql, cnn1)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader
            If dr.HasRows Then

                Me.Text_nombre.Text = dr(1)
                Me.Text_tel.Text = dr(2)
                Me.Text_direccion.Text = dr(3)
                Me.Text_email.Text = dr(4)
                Me.Text_web.Text = dr(5)
                Me.Check_certificado.Checked = dr(6)
                Me.Check_club.Checked = dr(7)
                Me.Check_restaurante.Checked = dr(8)
                Me.Check_tienda.Checked = dr(9)
                Me.Check_caravana.Checked = dr(10)
                Me.Text_capacity.Text = dr(11)
                Me.Text_CP.Text = dr(12)
                cod_postal = dr(12)
                Me.Text_lat.Text = dr(13)
                cod_poblacion = dr(14)
                Me.Text_firma.Text = dr(15)

            End If
            dr.Close()
            sql = "Select * from traducciones where alojamiento = " & id & " and idioma= 'es'"
            Dim cmd2 As New MySqlCommand(sql, cnn1)
            dr = cmd2.ExecuteReader
            If dr.HasRows Then
                Me.Text_Tipo.Text = dr(3)
                Me.Text_resu.Text = dr(4)
                Me.Text_descripcion.Text = dr(5)

            End If
            dr.Close()
            sql = " Select * from codigos_postales where cod_poblacion = " & cod_poblacion & " and cod_postal = " & cod_postal
            Dim cmd3 As New MySqlCommand(sql, cnn1)
            dr = cmd3.ExecuteReader
            If dr.HasRows Then
                Me.Text_poblacion.Text = dr(3)
                Me.Text_provincia.Text = dr(4)
            End If
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Show()
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
        Try
            Dim sql As String = "Delete from alojamientos where id = " & id_alo & " on delete cascade"
            Dim cmd As New MySqlCommand(sql, cnn1)
            'MsgBox("El registro de " & Me.Text_nombre.Text & " eliminado")
            If MessageBox.Show("El registro de " & Me.Text_nombre.Text & " será eliminado", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd.ExecuteNonQuery()
                MsgBox("Registro eliminado")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Hide()
    End Sub
End Class