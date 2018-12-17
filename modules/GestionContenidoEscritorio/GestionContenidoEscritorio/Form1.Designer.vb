<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextUser = New System.Windows.Forms.TextBox()
        Me.TextPassword = New System.Windows.Forms.TextBox()
        Me.Btn_inicial = New System.Windows.Forms.Button()
        Me.lab_fail = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(68, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(68, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password"
        '
        'TextUser
        '
        Me.TextUser.Location = New System.Drawing.Point(148, 58)
        Me.TextUser.Name = "TextUser"
        Me.TextUser.Size = New System.Drawing.Size(100, 20)
        Me.TextUser.TabIndex = 1
        '
        'TextPassword
        '
        Me.TextPassword.Location = New System.Drawing.Point(148, 100)
        Me.TextPassword.Name = "TextPassword"
        Me.TextPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextPassword.Size = New System.Drawing.Size(100, 20)
        Me.TextPassword.TabIndex = 2
        '
        'Btn_inicial
        '
        Me.Btn_inicial.Location = New System.Drawing.Point(258, 198)
        Me.Btn_inicial.Name = "Btn_inicial"
        Me.Btn_inicial.Size = New System.Drawing.Size(75, 23)
        Me.Btn_inicial.TabIndex = 0
        Me.Btn_inicial.Text = "Aceptar"
        Me.Btn_inicial.UseVisualStyleBackColor = True
        '
        'lab_fail
        '
        Me.lab_fail.AutoSize = True
        Me.lab_fail.Font = New System.Drawing.Font("Stencil", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lab_fail.ForeColor = System.Drawing.Color.Red
        Me.lab_fail.Location = New System.Drawing.Point(68, 142)
        Me.lab_fail.Name = "lab_fail"
        Me.lab_fail.Size = New System.Drawing.Size(203, 13)
        Me.lab_fail.TabIndex = 5
        Me.lab_fail.Text = "Usuario y/o password incorrecto"
        Me.lab_fail.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 272)
        Me.Controls.Add(Me.lab_fail)
        Me.Controls.Add(Me.Btn_inicial)
        Me.Controls.Add(Me.TextPassword)
        Me.Controls.Add(Me.TextUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextUser As System.Windows.Forms.TextBox
    Friend WithEvents TextPassword As System.Windows.Forms.TextBox
    Friend WithEvents Btn_inicial As System.Windows.Forms.Button
    Friend WithEvents lab_fail As System.Windows.Forms.Label

End Class
