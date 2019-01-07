
Partial Class About
    Inherits Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.Panel1.Visible = True Then
            Me.Panel1.Visible = False
            Me.Button1.Text = "Mostrar mas opciones"
        Else
            Me.Panel1.Visible = True
            Me.Button1.Text = "Ocultar opciones"
        End If
    End Sub

End Class