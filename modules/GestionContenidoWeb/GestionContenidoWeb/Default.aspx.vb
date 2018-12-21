
Partial Class _Default
    Inherits System.Web.UI.Page

    
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        ' Me.TextBox1.Text = GridView1.SelectedRow.Cells(2).Text

        Me.Response.Redirect("Default2.aspx?id=" + GridView1.SelectedRow.Cells(1).Text + "&nombre=" + GridView1.SelectedRow.Cells(2).Text + "&descripcion=" + GridView1.SelectedRow.Cells(3).Text)

    End Sub


End Class
