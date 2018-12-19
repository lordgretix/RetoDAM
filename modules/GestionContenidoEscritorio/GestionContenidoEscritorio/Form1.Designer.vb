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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label_acceso = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(68, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(68, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password"
        '
        'TextUser
        '
        Me.TextUser.Location = New System.Drawing.Point(148, 58)
        Me.TextUser.Name = "TextUser"
        Me.TextUser.Size = New System.Drawing.Size(100, 20)
        Me.TextUser.TabIndex = 0
        '
        'TextPassword
        '
        Me.TextPassword.Location = New System.Drawing.Point(148, 100)
        Me.TextPassword.Name = "TextPassword"
        Me.TextPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextPassword.Size = New System.Drawing.Size(100, 20)
        Me.TextPassword.TabIndex = 1
        '
        'Btn_inicial
        '
        Me.Btn_inicial.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Btn_inicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_inicial.ForeColor = System.Drawing.Color.Black
        Me.Btn_inicial.Location = New System.Drawing.Point(71, 183)
        Me.Btn_inicial.Name = "Btn_inicial"
        Me.Btn_inicial.Size = New System.Drawing.Size(200, 23)
        Me.Btn_inicial.TabIndex = 2
        Me.Btn_inicial.Text = "Aceptar"
        Me.Btn_inicial.UseVisualStyleBackColor = False
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(96, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Inicial Sesión"
        '
        'Label_acceso
        '
        Me.Label_acceso.AutoSize = True
        Me.Label_acceso.Font = New System.Drawing.Font("Stencil", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_acceso.ForeColor = System.Drawing.Color.Red
        Me.Label_acceso.Location = New System.Drawing.Point(68, 155)
        Me.Label_acceso.Name = "Label_acceso"
        Me.Label_acceso.Size = New System.Drawing.Size(238, 13)
        Me.Label_acceso.TabIndex = 7
        Me.Label_acceso.Text = "Este usuario no tiene permiso de acceso"
        Me.Label_acceso.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 272)
        Me.Controls.Add(Me.Label_acceso)
        Me.Controls.Add(Me.Label3)
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label_acceso As System.Windows.Forms.Label

End Class
