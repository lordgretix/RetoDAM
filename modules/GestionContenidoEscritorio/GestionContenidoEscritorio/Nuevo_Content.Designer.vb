<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Nuevo_Content
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Text_nombre = New System.Windows.Forms.TextBox()
        Me.Text_tel = New System.Windows.Forms.TextBox()
        Me.Text_direccion = New System.Windows.Forms.TextBox()
        Me.Text_email = New System.Windows.Forms.TextBox()
        Me.Text_web = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Text_nombre
        '
        Me.Text_nombre.Location = New System.Drawing.Point(266, 48)
        Me.Text_nombre.Name = "Text_nombre"
        Me.Text_nombre.Size = New System.Drawing.Size(100, 20)
        Me.Text_nombre.TabIndex = 0
        '
        'Text_tel
        '
        Me.Text_tel.Location = New System.Drawing.Point(266, 89)
        Me.Text_tel.Name = "Text_tel"
        Me.Text_tel.Size = New System.Drawing.Size(100, 20)
        Me.Text_tel.TabIndex = 1
        '
        'Text_direccion
        '
        Me.Text_direccion.Location = New System.Drawing.Point(266, 129)
        Me.Text_direccion.Name = "Text_direccion"
        Me.Text_direccion.Size = New System.Drawing.Size(100, 20)
        Me.Text_direccion.TabIndex = 2
        '
        'Text_email
        '
        Me.Text_email.Location = New System.Drawing.Point(266, 171)
        Me.Text_email.Name = "Text_email"
        Me.Text_email.Size = New System.Drawing.Size(100, 20)
        Me.Text_email.TabIndex = 3
        '
        'Text_web
        '
        Me.Text_web.Location = New System.Drawing.Point(266, 210)
        Me.Text_web.Name = "Text_web"
        Me.Text_web.Size = New System.Drawing.Size(100, 20)
        Me.Text_web.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Telefono:"
        '
        'Nuevo_Content
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 434)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Text_web)
        Me.Controls.Add(Me.Text_email)
        Me.Controls.Add(Me.Text_direccion)
        Me.Controls.Add(Me.Text_tel)
        Me.Controls.Add(Me.Text_nombre)
        Me.Name = "Nuevo_Content"
        Me.Text = "Nuevo_Content"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Text_nombre As System.Windows.Forms.TextBox
    Friend WithEvents Text_tel As System.Windows.Forms.TextBox
    Friend WithEvents Text_direccion As System.Windows.Forms.TextBox
    Friend WithEvents Text_email As System.Windows.Forms.TextBox
    Friend WithEvents Text_web As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
