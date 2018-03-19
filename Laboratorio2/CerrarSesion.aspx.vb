Public Class CerrarSesion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Abandon()
        Response.Redirect("InicioSesion.aspx", True)
    End Sub

End Class