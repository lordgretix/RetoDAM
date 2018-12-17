
Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Label1.Text = "Id: " & Me.Request.Params("id")
        Me.Label2.Text = "Nombre: " & Me.Request.Params("nombre")
        Me.Label3.Text = "Descripcion: " & Me.Request.Params("descripcion")
    End Sub
End Class
