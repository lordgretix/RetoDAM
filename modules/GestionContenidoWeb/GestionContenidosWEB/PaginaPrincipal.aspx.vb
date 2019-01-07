Imports MySql.Data.MySqlClient
Imports System.Data
Partial Class PaginaPrincipal
    Inherits System.Web.UI.Page
    Dim das1 As New DataSet

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Conexion.conectar()
        If Me.Panel1.Visible = True Then
            Me.Panel1.Visible = False
            Me.Button1.Text = "Mostrar tabla"
        Else
            Me.Panel1.Visible = True
            Me.Button1.Text = "Ocultar tabla"
        End If
        mostrarTabla()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("VistaMapa.aspx")
    End Sub


    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex
        mostrarTabla()

    End Sub
    Private Sub mostrarTabla()
        Conexion.conectar()
        Me.GridView1.AutoGenerateSelectButton = True
        Dim sql As String
        Dim mistring As String = ""
        'sql = "SELECT * FROM alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='es'"
        sql = "SELECT a.id,t.tipo,a.nombre,a.direccion,a.telefono,a.email,a.web,a.municipio,a.territorio FROM alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='es'"
        Dim commando As New MySqlCommand(sql, Conexion.cnn1)
        Dim adapter As New MySqlDataAdapter(commando)
        Try
            adapter.Fill(das1, "Cliente")
            Me.GridView1.Width = 50
            Me.GridView1.Height = 100
            Me.GridView1.DataSource = das1.Tables("Cliente")
            Me.GridView1.DataBind()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
       
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        'GridViewRow(fila = Me.GridView1.SelectedRow)
        Me.TextBox2.Text = GridView1.SelectedRow.Cells(2).Text
        Me.TextBox1.Text = GridView1.SelectedRow.Cells(2).Text
        Me.TextBox3.Text = GridView1.SelectedRow.Cells(3).Text
        Me.TextBox4.Text = GridView1.SelectedRow.Cells(4).Text
    End Sub

End Class
