Public Class Profesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session.Contents("tipo").Equals("Profesor") Then
            Response.Write("<script language='javascript'> alert('Acceso denegado a esta página.'); </script>")
            Response.Redirect("InicioSesion.aspx", True)
        End If
    End Sub

End Class