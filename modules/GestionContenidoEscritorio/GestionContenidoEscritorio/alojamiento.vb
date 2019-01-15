Public Class alojamiento
    Dim nombre, telefono, direccion, email, web As String
    Dim certificado, club, restaurante, tienda, autocaravana As Boolean
    Dim capacidad As Integer
    Dim cod_postal, latlong, poblacion, provincia, firma As String
    Sub New()

    End Sub

    Public Function getProvincia() As String
        Return provincia
    End Function

    Public Function getcapacity() As Integer
        Return capacidad
    End Function

    Public Function getFirma() As String
        Return firma
    End Function

    Public Function getLatlong() As String
        Return latlong
    End Function

    Public Function getNombre() As String
        Return nombre
    End Function

    Public Function getDireccion() As String
        Return direccion
    End Function

    Public Function getPoblacion() As String
        Return poblacion
    End Function

    Public Function getCodPostal() As Integer
        Return cod_postal
    End Function

    Public Function getTelefono() As Integer
        Return telefono
    End Function

    Public Function getEmail() As String
        Return email
    End Function

    Public Function getSitioWeb() As String
        Return web
    End Function

    Public Sub setProvincia(ByVal prov As String)
        provincia = prov
    End Sub

    Public Sub setcapacity(ByVal capa As Integer)
        capacidad = capa
    End Sub

    Public Sub setFirma(ByVal fir As String)
        firma = fir
    End Sub

    Public Sub setLatlong(ByVal lat As String)
        latlong = lat
    End Sub

    Public Sub setNombre(ByVal nom As String)
        nombre = nom
    End Sub

    Public Sub setDireccion(ByVal dir As String)
        direccion = dir
    End Sub

    Public Sub setPoblacion(ByVal mun As String)
        poblacion = mun
    End Sub

    Public Sub setCodPostal(ByVal cod As Integer)
        cod_postal = cod
    End Sub

    Public Sub setTelefono(ByVal tel As Integer)
        telefono = tel
    End Sub

    Public Sub setEmail(ByVal em As String)
        email = em
    End Sub

    Public Sub setSitioWeb(ByVal sw As String)
        web = sw
    End Sub
End Class
