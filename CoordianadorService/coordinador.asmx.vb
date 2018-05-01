Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports AccesoABD.AccesoABD


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class coordinador
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function obtenerMedia(ByVal asignatura As string) As String
        Dim accesoDB As New AccesoABD.AccesoABD
        conectar()
        Return obtener_media(asignatura)
    End Function

End Class