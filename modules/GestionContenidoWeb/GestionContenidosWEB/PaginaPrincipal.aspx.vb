Imports MySql.Data.MySqlClient
Imports System.Data
Partial Class PaginaPrincipal
    Inherits System.Web.UI.Page

    Dim das1 As New DataSet
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Conexion.conectar()
        Dim sql As String
        Dim mistring As String = ""
        sql = "SELECT * FROM alojamientos"
        Dim commando As New MySqlCommand(sql, Conexion.cnn1)
        Dim adapter As New MySqlDataAdapter(commando)

        adapter.Fill(das1, "Cliente")
        Me.GridView1.Width = 50
        Me.GridView1.Height = 100
        Me.GridView1.DataSource = das1.Tables("Cliente")
        Me.GridView1.DataBind()

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("VistaMapa.aspx")
    End Sub
End Class
