<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Filtros
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
        Me.Text_filnom = New System.Windows.Forms.TextBox()
        Me.Btn_buscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Text_fildir = New System.Windows.Forms.TextBox()
        Me.Numeric_fil = New System.Windows.Forms.NumericUpDown()
        CType(Me.Numeric_fil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Text_filnom
        '
        Me.Text_filnom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_filnom.Location = New System.Drawing.Point(181, 35)
        Me.Text_filnom.Name = "Text_filnom"
        Me.Text_filnom.Size = New System.Drawing.Size(179, 22)
        Me.Text_filnom.TabIndex = 0
        '
        'Btn_buscar
        '
        Me.Btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_buscar.Location = New System.Drawing.Point(351, 128)
        Me.Btn_buscar.Name = "Btn_buscar"
        Me.Btn_buscar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_buscar.TabIndex = 9
        Me.Btn_buscar.Text = "Buscar"
        Me.Btn_buscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Direccion"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(45, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Capacidad (>=)"
        '
        'Text_fildir
        '
        Me.Text_fildir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_fildir.Location = New System.Drawing.Point(181, 66)
        Me.Text_fildir.Name = "Text_fildir"
        Me.Text_fildir.Size = New System.Drawing.Size(179, 22)
        Me.Text_fildir.TabIndex = 1
        '
        'Numeric_fil
        '
        Me.Numeric_fil.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Numeric_fil.Location = New System.Drawing.Point(181, 94)
        Me.Numeric_fil.Name = "Numeric_fil"
        Me.Numeric_fil.Size = New System.Drawing.Size(179, 21)
        Me.Numeric_fil.TabIndex = 2
        '
        'Filtros
        '
        Me.AcceptButton = Me.Btn_buscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 163)
        Me.Controls.Add(Me.Numeric_fil)
        Me.Controls.Add(Me.Text_fildir)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Text_filnom)
        Me.Controls.Add(Me.Btn_buscar)
        Me.Name = "Filtros"
        Me.Text = "Filtros"
        CType(Me.Numeric_fil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Text_filnom As System.Windows.Forms.TextBox
    Friend WithEvents Btn_buscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Text_fildir As System.Windows.Forms.TextBox
    Friend WithEvents Numeric_fil As System.Windows.Forms.NumericUpDown
End Class
