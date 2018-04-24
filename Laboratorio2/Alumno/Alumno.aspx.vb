Public Class Alumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Logeados.Text = CType(Application.Contents("Alumnos"), ArrayList).Count & " Alumno/s y " & CType(Application.Contents("Profesores"), ArrayList).Count & " Profesor/es"
        Profesores.DataSource = Application.Contents("Profesores")
        Profesores.DataBind()
        Alumnos.DataSource = Application.Contents("Alumnos")
        Alumnos.DataBind()
    End Sub

End Class