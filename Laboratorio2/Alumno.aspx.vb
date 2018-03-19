Public Class Alumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.IsNewSession Then
            Response.Write("<script language='javascript'> alert('Acceso denegado a esta página.'); </script>")
            Response.Redirect("InicioSesion.aspx", True)
        End If
        If Not Session.Contents("tipo").Equals("Alumno") Then
            Response.Write("<script language='javascript'> alert('Acceso denegado a esta página.'); </script>")
            Response.Redirect("InicioSesion.aspx", True)
        End If
    End Sub

End Class