Imports AccesoABD.AccesoABD

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Server.Transfer("Registro.aspx", True)
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Server.Transfer("Modificar.aspx", True)
    End Sub

    Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        conectar()
        Dim resp As String = iniciar_sesion(email.Text, password.Text)
        cerrarconexion()
        If resp.Equals("Profesor") Then
            Session.Contents("email") = email.Text
            Session.Contents("tipo") = "Profesor"
            Response.Redirect("Profesor.aspx")
        ElseIf resp.Equals("Alumno") Then
            Session.Contents("email") = email.Text
            Session.Contents("tipo") = "Alumno"
            Response.Redirect("Alumno.aspx")
        ElseIf resp.Equals("Error1") Then
            erMsg.Text = "El usuario no ha sido confirmado"
        ElseIf resp.Equals("Error2") Then
            erMsg.Text = "Usuario o contraseña incorrecto"
        End If
    End Sub
End Class