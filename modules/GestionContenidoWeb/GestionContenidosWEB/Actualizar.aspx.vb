Imports MySql.Data.MySqlClient
Imports System.Data
Partial Class Editar
    Inherits System.Web.UI.Page
    Dim das1 As New DataSet
    Dim CMuni As Integer
    Dim CP, Territorio, Municipio, idSeleccionado As String
    Dim sql As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        idSeleccionado = Request.QueryString().ToString()
        ' Dim clave As String = Request.QueryString().ToString()
        Me.Panel1.Visible = True
        If Not Page.IsPostBack Then
            rellenarDatos()
           
        End If

    End Sub
   
   
    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        MsgBox(idSeleccionado)

        CP = Convert.ToInt32(DDL_CP.SelectedValue.ToString)
        'CMuni = ConseguirCod_Poblacion()
        Dim sql As String
        Conexion.conectar()

        'sql = "update alojamientos set nombre= @nom, telefono= @tel, direccion= @dir, email= @mail,"
        'sql &= "web= @web, certificado= @certi, club= @club, restaurante= @resta, tienda= @tienda,"
        'sql &= "autocaravana= @auto, capacidad= @capacy, cod_postal= @cp, latlong= @latlo, "
        'sql &= "cod_poblacion= @codpob, firma= @firma)"
        sql = "UPDATE alojamientos Set nombre = '" & tbNombre.Text & "' WHERE alojamientos.id = '" & idSeleccionado & "'"
        Dim commando As New MySqlCommand(sql, Conexion.cnn1)
        Dim result As Integer
        Try
            Conexion.conectar()
            result = commando.ExecuteNonQuery
            MsgBox(result)
            If result = 1 Then
                MsgBox("Actualizado con exito!")
            Else
                MsgBox("¡Error!")
            End If
        Catch ex As Exception
            MsgBox("Error :" & vbCrLf & ex.Message)
        Finally
            Conexion.desconectar()
        End Try

    End Sub


    'SI CAMBIA LA PROVINCIA O EL MUNICIPIO 
    Protected Sub DDL_provincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_provincia.SelectedIndexChanged
        'MsgBox(DDL_provincia.SelectedValue.ToString)

        sql = "SELECT DISTINCT poblacion FROM codigos_postales WHERE provincia='" & DDL_provincia.SelectedValue.ToString & "'"
        LlenarMunicipios(sql)

    End Sub
    Protected Sub DDL_municipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_municipio.SelectedIndexChanged
        Dim sql As String
        sql = "SELECT DISTINCT cod_postal FROM codigos_postales WHERE poblacion='" & DDL_municipio.SelectedValue.ToString & "'"
        LlenarCodigos(sql)
    End Sub

    'LLENAR MUNICIPIOS Y CODIGOS POSTALES
    Protected Sub LlenarMunicipios(sql As String)
        Me.DDL_municipio.Items.Clear()
        Conexion.conectar()
        Try
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing
            dr = cmd.ExecuteReader()
            While dr.Read
                Me.DDL_municipio.Items.Add(dr.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        LlenarCodigos("SELECT DISTINCT cod_postal FROM codigos_postales WHERE poblacion='" & DDL_municipio.SelectedValue.ToString & "'")
        Conexion.desconectar()
    End Sub
    Protected Sub LlenarCodigos(sql As String)
        Me.DDL_CP.Items.Clear()
        Conexion.conectar()
        Try
            'Dim sql As String = "SELECT DISTINCT poblacion FROM codigos_postales WHERE provincia='Bizkaia'"
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()
            While dr.Read
                Me.DDL_CP.Items.Add(dr.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'CP = Convert.ToInt32(DDL_CP.SelectedValue.ToString)
        CP = DDL_CP.SelectedValue.ToString

        'MsgBox(DDL_CP.SelectedValue.ToString)
        Conexion.desconectar()
    End Sub

    'LLENAR DATOS
    Private Sub rellenarDatos()
        MsgBox(idSeleccionado)
        Conexion.conectar()
        Try
            Dim sql As String

            sql = "SELECT nombre,direccion,telefono,web,capacidad,firma,cod_postal,latlong,email FROM alojamientos WHERE id = '" & idSeleccionado & "'"
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            While dr.Read
                'NOMBRE
                If Not IsDBNull(dr.Item(0)) Then
                    Me.tbNombre.Text = dr.Item(0)
                Else
                    Me.tbNombre.Text = ""
                End If
                'DIRECCION
                If Not IsDBNull(dr.Item(1)) Then
                    Me.tbDireccion.Text = dr.Item(1)
                Else
                    Me.tbDireccion.Text = ""
                End If
                'TELEFONO
                If Not IsDBNull(dr.Item(2)) Then
                    Me.tbTelefono.Text = dr.Item(2)
                Else
                    Me.tbTelefono.Text = ""
                End If
                'WEB
                If Not IsDBNull(dr.Item(3)) Then
                    Me.tbWeb.Text = dr.Item(3)
                Else
                    Me.tbWeb.Text = ""
                End If
                'CAPACIDAD
                If Not IsDBNull(dr.Item(4)) Then
                    Me.tbCapacidad.Text = dr.Item(4)
                Else
                    Me.tbCapacidad.Text = ""
                End If
                'FIRMA
                If Not IsDBNull(dr.Item(5)) Then
                    Me.tbFirma.Text = dr.Item(5)
                Else
                    Me.tbFirma.Text = ""
                End If
                '_____________ CP _______________

                CP = dr.Item(6)
                ConseguirTerritorio(CP)
                'MsgBox(CP)
                '____________________________

                'LATITUD
                If Not IsDBNull(dr.Item(7)) Then
                    Me.tbLatitud.Text = dr.Item(7)
                Else
                    Me.tbLatitud.Text = ""
                End If
                'EMAIL
                If Not IsDBNull(dr.Item(8)) Then
                    Me.tbEmail.Text = dr.Item(8)
                Else
                    Me.tbEmail.Text = ""
                End If

            End While

            dr.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub

    'CONSEGUIR DATOS DE LAS BBDD
    Function ConseguirTerritorio(Optional CP As String = Nothing) As String
        Dim sql = "SELECT DISTINCT  provincia FROM codigos_postales WHERE cod_postal='" & CP & "'"
        Dim nombre As String = ""
        Conexion.conectar()
        Try
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()
            While dr.Read
                nombre = dr.Item(0)
                Territorio = nombre
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Cargo la lista con los municipios deL TERRITORIO al que pertenece este alojamiento
        sql = "SELECT DISTINCT poblacion FROM codigos_postales WHERE provincia='" & Territorio & "'"
        DDL_provincia.SelectedValue = Territorio
        LlenarMunicipios(sql)
        'Consigo el MUNICIPIO del alojamiento
        Municipio = ConseguirMunicipio(CP)
        DDL_municipio.SelectedValue = Municipio

        'Cargo los CODIGOS POSTALES que tenga ese municipio
        sql = "SELECT DISTINCT cod_postal FROM codigos_postales WHERE poblacion='" & Municipio & "'"
        LlenarCodigos(sql)
        DDL_CP.SelectedValue = CP

        Conexion.desconectar()
        Return nombre
    End Function
    Function ConseguirCod_Poblacion(Optional CP As String = Nothing) As String
        Dim sql = "SELECT DISTINCT  cod_poblacion FROM codigos_postales WHERE cod_postal='" & CP & "'"
        Dim nombre As String = ""
        Conexion.conectar()
        Try
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()
            While dr.Read
                'MsgBox(dr.Item(0))
                CMuni = Convert.ToInt32(dr.Item(0))
                nombre = dr.Item(0)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Conexion.desconectar()
        Return nombre
    End Function
    Function ConseguirMunicipio(Optional CP As String = Nothing) As String

        Conexion.desconectar()
        Dim sql = "SELECT DISTINCT  poblacion FROM codigos_postales WHERE cod_postal='" & CP & "'"
        Dim nombre As String = ""
        Conexion.conectar()
        Try
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()
            While dr.Read
                'MsgBox(dr.Item(0))
                nombre = dr.Item(0)
                Municipio = nombre
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Conexion.desconectar()
        Return nombre
    End Function
End Class
