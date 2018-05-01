Imports System.Security.Cryptography
Imports AccesoABD.AccesoABD

Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Page.IsValid Then
            Dim pr As New matriculas.Matriculas
            Dim val = pr.comprobar(email.Text)
            If (val.Equals("SI")) Then
                Dim emailSender As New EnviarCorreo.Correo
                Randomize()
                Dim claveRnd As String = CStr(CInt(Rnd() * 9000000) + 1000000)
                conectar()
                Dim pass = password1.Text
                Dim mySHA256 As SHA256 = SHA256Managed.Create()
                pass = Convert.ToBase64String(mySHA256.ComputeHash(Encoding.UTF8.GetBytes(pass)))
                Dim ret As String = insertar_usuario(email.Text, nombre.Text, apellido.Text, CInt(claveRnd), tipo.Text, pass)
                If ret = "1" Then
                    Dim mensaje As String = "Confirma tu registro haciendo clik <a href='https://hads18-webapp21.azurewebsites.net//ConfirmarRegistro.aspx?email=" + email.Text + "&clave=" + claveRnd + "'>aquí</a>."
                    emailSender.enviarEmail(email.Text, mensaje)
                    Response.Write("<script language='javascript'> alert('Registro completado con éxito, revise el correo para realizar la confirmación.'); </script>")
                    Server.Transfer("InicioSesion.aspx", True)
                Else
                    errorMsg.Text = ret
                End If
                cerrarconexion()
            Else
                errorMsg.Text = "Usuario no matriculado"
            End If
        End If

    End Sub

    Private Sub email_TextChanged(sender As Object, e As EventArgs) Handles email.TextChanged
        Dim pr As New matriculas.Matriculas
        Dim val = pr.comprobar(email.Text)
        If (val.Equals("SI")) Then
            emailval.Text = "Email matriculado"
        Else
            emailval.Text = "Email no matriculado"
        End If
    End Sub
End Class