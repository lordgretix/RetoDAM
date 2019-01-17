
Partial Class Update
    Inherits System.Web.UI.Page

    Protected Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton1.Click, UpdateButton2.Click
        DateTimeLabel1.Text = DateTime.Now.ToString()
        DateTimeLabel2.Text = DateTime.Now.ToString()
    End Sub
End Class
