Imports System.Security.Cryptography
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
        Dim pass = password.Text
        Dim mySHA256 As SHA256 = SHA256Managed.Create()
        pass = Convert.ToBase64String(mySHA256.ComputeHash(Encoding.UTF8.GetBytes(pass)))
        Dim resp As String = iniciar_sesion(email.Text, pass)
        cerrarconexion()
        If resp.Equals("Profesor") Then
            If (email.Text.Equals("vadillo@ehu.es")) Then
                System.Web.Security.FormsAuthentication.SetAuthCookie("vadillo", False)
            Else
                System.Web.Security.FormsAuthentication.SetAuthCookie("profesor", False)
            End If
            Session.Contents("email") = email.Text
            Session.Contents("tipo") = "Profesor"
            CType(Application.Contents("Profesores"), ArrayList).Add(email.Text)
            Response.Redirect("Profesor/Profesor.aspx")
        ElseIf resp.Equals("Alumno") Then
            System.Web.Security.FormsAuthentication.SetAuthCookie("alumno", False)
            Session.Contents("email") = email.Text
            CType(Application.Contents("Alumnos"), ArrayList).Add(email.Text)
            Session.Contents("tipo") = "Alumno"
            Response.Redirect("Alumno/Alumno.aspx")
        ElseIf resp.Equals("Admin") Then
            System.Web.Security.FormsAuthentication.SetAuthCookie("admin", False)
            Session.Contents("email") = email.Text
            Session.Contents("tipo") = "Admin"
            Response.Redirect("Admin/Admin.aspx")
        ElseIf resp.Equals("Error1") Then
            erMsg.Text = "El usuario no ha sido confirmado"
        ElseIf resp.Equals("Error2") Then
            erMsg.Text = "Usuario o contraseña incorrecto"
        End If

    End Sub

End Class