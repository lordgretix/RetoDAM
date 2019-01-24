Public Class Loading

    Private Sub Loading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form_Ini.form_center(Me)
        Dim img As Image = Image.FromFile("load_imag.gif")
        Me.PictureBox1.Image = img
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
    End Sub
End Class