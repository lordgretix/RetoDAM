Imports MySql.Data.MySqlClient
Imports System.Data
Partial Class PaginaPrincipal
    Inherits System.Web.UI.Page
    Dim das1 As New DataSet
    Dim idSeleccionado As Integer

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Conexion.conectar()
        'Me.Panel1.Visible = True
        'mostrarTabla()

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Conexion.conectar()
        If Me.Panel1.Visible = True Then
            Me.Panel1.Visible = False
            Me.Button1.Text = "Mostrar tabla"

        Else
            Me.Panel1.Visible = True
            Me.Button1.Text = "Ocultar tabla"
        End If
        mostrarTabla()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("VistaMapa.aspx")
    End Sub


    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex
        mostrarTabla()

    End Sub
    Private Sub mostrarTabla()
        Conexion.desconectar()
        Conexion.conectar()
        Me.GridView1.DataBind()
        Me.GridView1.AutoGenerateSelectButton = True
        Dim sql As String
        Dim mistring As String = ""
        'sql = "SELECT * FROM alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='es'"
        sql = "SELECT a.id as ID,t.tipo as Tipo,a.nombre as Nombre,a.direccion as Direccion,a.telefono as Telefono,a.email as Email,a.web as WEB FROM alojamientos a, traducciones t where a.id = t.alojamiento and t.idioma='es'"
        'sql = "SELECT * FROM alojamientos "
        Dim commando As New MySqlCommand(sql, Conexion.cnn1)
        Dim adapter As New MySqlDataAdapter(commando)

        contarfilas(sql)
        Try
            adapter.Fill(das1, "Cliente")
            Me.GridView1.Width = 50
            Me.GridView1.Height = 100
            Me.GridView1.DataSource = das1.Tables("Cliente")
            Me.GridView1.DataBind()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
      
        Me.Button6.Enabled = True

        'Me.tb_Buscar.Text = GridView1.SelectedRow.Cells(2).Text 'tipo/nombre

        Me.tbNombre.Text = GridView1.SelectedRow.Cells(3).Text
        Me.tbDireccion.Text = GridView1.SelectedRow.Cells(4).Text
        Me.tbTelefono.Text = GridView1.SelectedRow.Cells(5).Text
        Me.tbEmail.Text = GridView1.SelectedRow.Cells(6).Text
        Me.tbWeb.Text = GridView1.SelectedRow.Cells(7).Text

        'Me.tbMunicipio.Text = GridView1.SelectedRow.Cells(15).Text
        'Me.tbCP.Text=GridView1.SelectedRow.Cells(7).Text

    End Sub



    Private Sub contarfilas(sql As String)
        Dim commando As New MySqlCommand(sql, Conexion.cnn1)
        'CONTAR FILAS
        Try
            Dim count As Integer
            count = 0
            Dim dr As MySqlDataReader
            dr = commando.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    count += 1
                End While
                dr.Close()
            End If
            Me.lb_Contador.Text = "Hay : " & count & " filas."
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Response.Redirect("Editar.aspx")
    End Sub

    Protected Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        'ordenacion por COUNTRY = USA, CITY
        Dim dv As New DataView
        dv.Table = Me.das1.Tables("aaa") ' estan TODOS los datos 
        dv.RowFilter = "id = '" & Me.tb_Buscar.Text & "'"

        Me.GridView1.DataSource = dv
        Me.lb_Contador.Text = dv.Count & " Filas"
        GridView1.SelectedRowStyle.BackColor = Drawing.Color.Red
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        idSeleccionado = GridView1.SelectedRow.Cells(1).Text 'id
        Dim sql As String
        sql = "DELETE FROM alojamientos  "
        sql &= " WHERE id = '" & idSeleccionado & "'"
        'DELETE FROM `alojaminetos2` WHERE `alojaminetos2`.`id` = 4"
        Dim commando As New MySqlCommand(sql, Conexion.cnn1)

        Dim result As Integer
        Try
            Conexion.conectar()
            result = commando.ExecuteNonQuery
            'MsgBox(result)
            If result = 1 Then
                'MsgBox("ELIMINADO!",MsgBoxStyle.YesNoCancel)
                mostrarTabla()
            Else
                MsgBox("¡Error!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
   
    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Response.Redirect("~\Actualizar.aspx?" + Me.GridView1.SelectedRow.Cells(1).Text)
    End Sub

End Class
