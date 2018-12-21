
Imports MySql.Data.MySqlClient
Imports System.Data
Partial Class Contact
    Inherits Page

    Dim das1 As New DataSet
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

   
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Conexion.conectar()
        Dim sql As String
        Dim mistring As String = ""
        sql = "SELECT * FROM departamento"
        Dim commando As New MySqlCommand(sql, Conexion.cnn1)
        Dim adapter As New MySqlDataAdapter(commando)

        adapter.Fill(das1, "Cliente")
        Me.GridView1.DataSource = das1.Tables("Cliente")
        Me.GridView1.DataBind()


    End Sub
End Class