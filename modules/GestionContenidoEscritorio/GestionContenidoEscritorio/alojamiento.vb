Public Class alojamiento
    Dim nombre, telefono, direccion, email, web As String
    Dim certificado, club, restaurante, tienda, autocaravana As Boolean
    Dim id, capacidad As Integer
    Dim cod_postal, latlong, municipio, territorio, firma, json As String
    Sub New()

    End Sub

    Public Function getNombre() As String
        Return nombre
    End Function

    Public Function getDireccion() As String
        Return direccion
    End Function

    Public Function getMunicipio() As String
        Return municipio
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

    Public Sub setNombre(ByVal nom As String)
        nombre = nom
    End Sub

    Public Sub setDireccion(ByVal dir As String)
        direccion = dir
    End Sub

    Public Sub setMunicipio(ByVal mun As String)
        municipio = mun
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
