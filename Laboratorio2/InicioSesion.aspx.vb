Imports AccesoABD.AccesoABD

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session.Contents("tipo") Is Nothing Then
            If Session.Contents("tipo").Equals("Alumno") Then
                Response.Redirect("Alumno.aspx", True)
            Else
                Response.Redirect("Profesor.aspx", True)
            End If
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Server.Transfer("Registro.aspx", True)
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Server.Transfer("Modificar.aspx", True)
    End Sub

    Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        conectar()
        Dim resp As Integer = iniciar_sesion(email.Text, password.Text)
        cerrarconexion()
        Select Case resp
            Case 0 'Profesor
                Response.Write("<script language='javascript'> alert('Bienvenido/a, profesor/a'); </script>")
                Session.Contents("email") = email.Text
                Session.Contents("tipo") = "Profesor"
                Response.Redirect("Profesor.aspx", True)
            Case 1
                erMsg.Text = "El usuario no ha sido confirmado"
            Case 2
                erMsg.Text = "Usuario o contraseña incorrecto"
            Case 3
                Response.Write("<script language='javascript'> alert('Bienvenido/a, alumno/a'); </script>")
                Session.Contents("email") = email.Text
                Session.Contents("tipo") = "Alumno"
                Response.Redirect("Alumno.aspx", True)
        End Select
    End Sub
End Class