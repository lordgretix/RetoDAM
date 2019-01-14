Imports MySql.Data.MySqlClient
Imports System.Data
Partial Class Editar
    Inherits System.Web.UI.Page
    Dim das1 As New DataSet
    Dim idSeleccionado As Integer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'fillDropDownList()
        DDL_municipio.Enabled = False
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.Panel1.Visible = True Then
            Me.Panel1.Visible = False
            Me.Button1.Text = "Mostrar mas opciones"
        Else
            Me.Panel1.Visible = True
            Me.Button1.Text = "Ocultar opciones"
        End If
    End Sub

    Protected Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Conexion.conectar()

        Dim sql As String
        'sql = "INSERT alojamientos (nombre, telefono, direccion, " & _
        '                        "email, web, certificado, club,restaurante,tienda,autocaravana,capacidad,cod_postal,latlong,municipio,territorio,firma)" & _
        '                        "VALUES ('" & nombre & "', '" & telefono & "', '" & direccion & "', " & _
        '                        "'New Contact Title', 'Italy', 'New Phone', 'New FAX')"

        sql = "INSERT INTO alojaminetos2 (id, nombre, telefono, direccion, email," & _
            " web, certificado, club, restaurante, tienda, autocaravana, capacidad," & _
            " cod_postal, latlong, municipio, territorio, firma, json)" & _
            " VALUES ('3', '" & tbNombre.Text & "', '" & tbTelefono.Text & "', '" & tbDireccion.Text & "', '" & tbEmail.Text & "'," & _
            " '" & tbWeb.Text & "', '0', '0', '0', '0', '0', '6'," & _
            " '23545', '23213213,3323 ', '" & "Aia" & "', 'Bizkaia', 'BI921', '')"
        Dim commando As New MySqlCommand(sql, Conexion.cnn1)
        ' Dim adapter As New MySqlDataAdapter(commando)

        Dim rows As Integer
        Try
            'rows = commando.ExecuteNonQuery()
            commando.ExecuteNonQuery()
            MsgBox("New customer inserted successfully!")
        Catch ex As Exception
            MsgBox("Failed to insert new customer!" & vbCrLf & ex.Message)
        Finally
            Conexion.desconectar()
        End Try
    End Sub


  

    Protected Sub DDL_provincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_provincia.SelectedIndexChanged
        MsgBox(DDL_provincia.SelectedValue.ToString)
        Dim sql As String
        sql = "SELECT DISTINCT poblacion FROM codigos_postales WHERE provincia='" & DDL_provincia.SelectedValue.ToString & "'"
        DDL_municipio.Enabled = True
        fillDropDownList(sql)
        
    End Sub
    Protected Sub fillDropDownList(sql As String)
        Conexion.conectar()
        Try

            'Dim sql As String = "SELECT DISTINCT poblacion FROM codigos_postales WHERE provincia='Bizkaia'"
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            While dr.Read
                Me.DDL_municipio.Items.Add(dr.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Conexion.desconectar()
    End Sub
End Class
