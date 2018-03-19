Public Class TareasAlumnoaspx
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

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow()
        Response.Redirect(“InstanciarTarea.aspx?codigo=" & row.Cells(1).Text & "&descripcion=" & row.Cells(2).Text & "&hestimadas=" & row.Cells(3).Text)
    End Sub
End Class