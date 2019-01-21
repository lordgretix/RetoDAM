<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Ini
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Ini))
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
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Name = "Label2"
        '
        'TextUser
        '
        resources.ApplyResources(Me.TextUser, "TextUser")
        Me.TextUser.Name = "TextUser"
        '
        'TextPassword
        '
        resources.ApplyResources(Me.TextPassword, "TextPassword")
        Me.TextPassword.Name = "TextPassword"
        '
        'Btn_inicial
        '
        resources.ApplyResources(Me.Btn_inicial, "Btn_inicial")
        Me.Btn_inicial.BackColor = System.Drawing.Color.LimeGreen
        Me.Btn_inicial.ForeColor = System.Drawing.Color.White
        Me.Btn_inicial.Name = "Btn_inicial"
        Me.Btn_inicial.UseVisualStyleBackColor = False
        '
        'lab_fail
        '
        resources.ApplyResources(Me.lab_fail, "lab_fail")
        Me.lab_fail.BackColor = System.Drawing.Color.Transparent
        Me.lab_fail.ForeColor = System.Drawing.Color.Red
        Me.lab_fail.Name = "lab_fail"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Name = "Label3"
        '
        'Label_acceso
        '
        resources.ApplyResources(Me.Label_acceso, "Label_acceso")
        Me.Label_acceso.BackColor = System.Drawing.Color.Transparent
        Me.Label_acceso.ForeColor = System.Drawing.Color.Red
        Me.Label_acceso.Name = "Label_acceso"
        '
        'Form_Ini
        '
        Me.AcceptButton = Me.Btn_inicial
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label_acceso)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lab_fail)
        Me.Controls.Add(Me.Btn_inicial)
        Me.Controls.Add(Me.TextPassword)
        Me.Controls.Add(Me.TextUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form_Ini"
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
