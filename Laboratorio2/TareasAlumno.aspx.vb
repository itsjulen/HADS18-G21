Public Class TareasAlumnoaspx
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow()
        Response.Redirect(“InstanciarTarea.aspx?codigo=" & row.Cells(1).Text & "&hestimadas=" & row.Cells(3).Text)
    End Sub
End Class