Public Class TareasProfesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.IsNewSession Then
            Response.Write("<script language='javascript'> alert('Acceso denegado a esta página.'); </script>")
            Response.Redirect("InicioSesion.aspx", True)
        End If
        If Not Session.Contents("tipo").Equals("Profesor") Then
            Response.Write("<script language='javascript'> alert('Acceso denegado a esta página.'); </script>")
            Response.Redirect("InicioSesion.aspx", True)
        End If
    End Sub

    Protected Sub Insertar_Click(sender As Object, e As EventArgs) Handles Insertar.Click
        Response.Redirect("InsertarTarea.aspx", True)
    End Sub

    Private Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView1.Sorting
    End Sub
End Class