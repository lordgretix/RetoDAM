﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Adm_Content
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_add = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.InicioToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CerrarSesionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InicioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IdiomaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CastellanoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EuskeraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Btn_buscar = New System.Windows.Forms.Button()
        Me.Label_num = New System.Windows.Forms.Label()
        Me.Btn_Count = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(35, 133)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(822, 399)
        Me.DataGridView1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Administracion de locales de alojamientos"
        '
        'Btn_add
        '
        Me.Btn_add.Location = New System.Drawing.Point(752, 100)
        Me.Btn_add.Name = "Btn_add"
        Me.Btn_add.Size = New System.Drawing.Size(104, 23)
        Me.Btn_add.TabIndex = 2
        Me.Btn_add.Text = "&Añadir Nuevo"
        Me.Btn_add.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InicioToolStripMenuItem1, Me.InicioToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(883, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'InicioToolStripMenuItem1
        '
        Me.InicioToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserToolStripMenuItem, Me.ToolStripMenuItem1, Me.CerrarSesionToolStripMenuItem})
        Me.InicioToolStripMenuItem1.Name = "InicioToolStripMenuItem1"
        Me.InicioToolStripMenuItem1.Size = New System.Drawing.Size(48, 20)
        Me.InicioToolStripMenuItem1.Text = "&Inicio"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.UserToolStripMenuItem.Text = "&User"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(149, 6)
        '
        'CerrarSesionToolStripMenuItem
        '
        Me.CerrarSesionToolStripMenuItem.Name = "CerrarSesionToolStripMenuItem"
        Me.CerrarSesionToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CerrarSesionToolStripMenuItem.Text = "&Cerrar sesion"
        '
        'InicioToolStripMenuItem
        '
        Me.InicioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuscarToolStripMenuItem, Me.NuevoToolStripMenuItem, Me.ActualizarToolStripMenuItem, Me.IdiomaToolStripMenuItem})
        Me.InicioToolStripMenuItem.Name = "InicioToolStripMenuItem"
        Me.InicioToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.InicioToolStripMenuItem.Text = "&Contenidos"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BuscarToolStripMenuItem.Text = "&Buscar"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NuevoToolStripMenuItem.Text = "&Nuevo"
        '
        'ActualizarToolStripMenuItem
        '
        Me.ActualizarToolStripMenuItem.Name = "ActualizarToolStripMenuItem"
        Me.ActualizarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ActualizarToolStripMenuItem.Text = "&Actualizar"
        '
        'IdiomaToolStripMenuItem
        '
        Me.IdiomaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CastellanoToolStripMenuItem, Me.EuskeraToolStripMenuItem})
        Me.IdiomaToolStripMenuItem.Name = "IdiomaToolStripMenuItem"
        Me.IdiomaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.IdiomaToolStripMenuItem.Text = "&Idioma"
        '
        'CastellanoToolStripMenuItem
        '
        Me.CastellanoToolStripMenuItem.Name = "CastellanoToolStripMenuItem"
        Me.CastellanoToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.CastellanoToolStripMenuItem.Text = "&Castellano"
        '
        'EuskeraToolStripMenuItem
        '
        Me.EuskeraToolStripMenuItem.Name = "EuskeraToolStripMenuItem"
        Me.EuskeraToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.EuskeraToolStripMenuItem.Text = "&Euskera"
        '
        'Btn_buscar
        '
        Me.Btn_buscar.Location = New System.Drawing.Point(752, 71)
        Me.Btn_buscar.Name = "Btn_buscar"
        Me.Btn_buscar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_buscar.TabIndex = 4
        Me.Btn_buscar.Text = "Buscar"
        Me.Btn_buscar.UseVisualStyleBackColor = True
        '
        'Label_num
        '
        Me.Label_num.AutoSize = True
        Me.Label_num.Location = New System.Drawing.Point(35, 100)
        Me.Label_num.Name = "Label_num"
        Me.Label_num.Size = New System.Drawing.Size(0, 13)
        Me.Label_num.TabIndex = 5
        '
        'Btn_Count
        '
        Me.Btn_Count.Location = New System.Drawing.Point(671, 100)
        Me.Btn_Count.Name = "Btn_Count"
        Me.Btn_Count.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Count.TabIndex = 6
        Me.Btn_Count.Text = "Contar"
        Me.Btn_Count.UseVisualStyleBackColor = True
        '
        'Adm_Content
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 544)
        Me.Controls.Add(Me.Btn_Count)
        Me.Controls.Add(Me.Label_num)
        Me.Controls.Add(Me.Btn_buscar)
        Me.Controls.Add(Me.Btn_add)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Adm_Content"
        Me.Text = "Adm_Content"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btn_add As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents InicioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InicioToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CerrarSesionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActualizarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_buscar As System.Windows.Forms.Button
    Friend WithEvents IdiomaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CastellanoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EuskeraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label_num As System.Windows.Forms.Label
    Friend WithEvents Btn_Count As System.Windows.Forms.Button
End Class
