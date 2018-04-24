Public Class CerrarSesion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session.Contents("tipo").Equals("Alumno")) Then
            CType(Application.Contents("Alumnos"), ArrayList).Remove(Session.Contents("email"))
        ElseIf (Session.Contents("tipo").Equals("Profesor")) Then
            CType(Application.Contents("Profesores"), ArrayList).Remove(Session.Contents("email"))
        End If
        Session.Abandon()
        Response.Redirect("InicioSesion.aspx", True)
    End Sub

End Class