Imports MySql.Data.MySqlClient
Imports System.Data
Partial Class Editar
    Inherits System.Web.UI.Page
    Dim das1 As New DataSet
    Dim idSeleccionado As Integer
    Dim CP, CMuni As Integer
    Dim certficado, club, bar, tienda, autocaravana As Integer

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

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
        Conexion.desconectar()
        CP = Convert.ToInt32(DDL_CP.SelectedValue.ToString)
        CMuni = ConseguirCod_Poblacion()

        'Valores check
        CheckBox()

        Dim sql As String
        Conexion.conectar()
        'SQL INSERTAR ALOJAMIENTO
        sql = "INSERT INTO alojamientos "
        sql &= "( nombre, telefono, direccion, email, web, "
        sql &= "certificado, club, restaurante, tienda, autocaravana, "
        sql &= "capacidad, cod_postal, latlong, cod_poblacion, firma, json) "
        'VALORES
        sql &= "VALUES ( '" & Me.tbNombre.Text & "', '" & Me.tbTelefono.Text & "', '" & Me.tbDireccion.Text & "', '" & Me.tbEmail.Text & "', '" & Me.tbWeb.Text & "',"
        sql &= " '" & certficado & "', '" & club & "', '" & bar & "', '" & tienda & "', '" & autocaravana & "', "
        sql &= "'5', '" & CP & "', '" & Me.tbLatitud.Text & "', '" & CMuni & "', '" & tbFirma.Text & "', '')"

        Dim commando As New MySqlCommand(sql, Conexion.cnn1)
        Dim adapter As New MySqlDataAdapter(commando)
        Try
            commando.ExecuteNonQuery()
            MsgBox("Insertado con exito!")

            'INSERTAR DATOS DE TRADUCCIONES
            InsertaTraduccion()
        Catch ex As Exception
            MsgBox("Failed !" & vbCrLf & ex.Message)
        Finally
            Conexion.desconectar()
        End Try
    End Sub

    Protected Sub DDL_provincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_provincia.SelectedIndexChanged
        'MsgBox(DDL_provincia.SelectedValue.ToString)
        Dim sql As String
        sql = "SELECT DISTINCT poblacion FROM codigos_postales WHERE provincia='" & DDL_provincia.SelectedValue.ToString & "'"
        LlenarMunicipios(sql)

    End Sub
    Protected Sub DDL_municipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_municipio.SelectedIndexChanged
        Dim sql As String
        sql = "SELECT DISTINCT cod_postal FROM codigos_postales WHERE poblacion='" & DDL_municipio.SelectedValue.ToString & "'"
        LlenarCodigos(sql)
    End Sub

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
        ' LlenarMunicipios("SELECT DISTINCT poblacion FROM codigos_postales WHERE provincia='" & DDL_provincia.SelectedValue.ToString & "'")
        LlenarCodigos("SELECT DISTINCT cod_postal, cod_poblacion FROM codigos_postales WHERE poblacion='" & DDL_municipio.SelectedValue.ToString & "'")
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
        CP = Convert.ToInt32(DDL_CP.SelectedValue.ToString)


        'MsgBox(DDL_CP.SelectedValue.ToString)
        Conexion.desconectar()
    End Sub
    Function ConseguirCod_Poblacion() As Integer
        Dim sql = "SELECT DISTINCT  cod_poblacion FROM codigos_postales WHERE cod_postal='" & DDL_CP.SelectedValue.ToString & "'"
        Conexion.conectar()
        Try
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()
            While dr.Read
                'MsgBox(dr.Item(0))
                CMuni = Convert.ToInt32(dr.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Conexion.desconectar()
        Return CMuni
    End Function

    Private Sub InsertaTraduccion()
        Conexion.desconectar()

        Dim sql As String
        Conexion.conectar()
        'SQL INSERTAR ALOJAMIENTO INSERT INTO traducciones 
        '(id,alojamiento,idioma,tipo,resumen,descripcion)
        'VALUES(NULL,(SELECT id FROM alojamientos WHERE firma = 'KAT123'),'es','Albergues','RESUMEN','DESCR');
        sql = "INSERT INTO traducciones "
        sql &= "(id,alojamiento,idioma,tipo,resumen,descripcion)"
        'VALORES
        sql &= "VALUES(NULL,(SELECT id FROM alojamientos WHERE firma = '" & tbFirma.Text & "'),'es','Albergues','RESUMEN','" & tb_descripcion.Text & "')"


        Dim commando As New MySqlCommand(sql, Conexion.cnn1)
        Dim adapter As New MySqlDataAdapter(commando)

        Try
            commando.ExecuteNonQuery()
            MsgBox("Insertado con exito!")

        Catch ex As Exception
            MsgBox("Failed !" & vbCrLf & ex.Message)
        Finally
            Conexion.desconectar()
        End Try
    End Sub

    Private Sub CheckBox()

        'CERTIFICADO
        If Me.cb_certificado.Checked = True Then
            certficado = 1
        Else
            certficado = 0
        End If
        'CLUB
        If Me.cb_club.Checked = True Then
            club = 1
        Else
            club = 0
        End If
        'RESTAURANTE-BAR
        If Me.cb_bar.Checked = True Then
            bar = 1
        Else
            bar = 0
        End If
        'TIENDA
        If Me.cb_tienda.Checked = True Then
            tienda = 1
        Else
            tienda = 0
        End If
        'AUTOCARAVANA
        If Me.cb_auto.Checked = True Then
            autocaravana = 1
        Else
            autocaravana = 0
        End If

    End Sub

End Class
