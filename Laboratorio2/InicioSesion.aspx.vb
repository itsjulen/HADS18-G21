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
        Dim resp As Integer = iniciar_sesion(email.Text, password.Text)
        cerrarconexion()
        Select Case resp
            Case 0
                Response.Write("<script language='javascript'> alert('Usuario correcto, bienvenido'); </script>")
                Server.Transfer("Inicio.aspx", True)
            Case 1
                erMsg.Text = "El usuario no ha sido confirmado"
            Case 2
                erMsg.Text = "Usuario o contraseña incorrecto"
        End Select
    End Sub
End Class