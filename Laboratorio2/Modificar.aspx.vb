Imports System.Security.Cryptography
Imports AccesoABD.AccesoABD
Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If emailValidator.IsValid Then
            Randomize()
            claveRnd.Text = CStr(CInt(Rnd() * 9000000) + 1000000)
            Dim mensaje As String = "La clave para recuperar la contraseña es: " & claveRnd.Text
            Dim emailSender As New EnviarCorreo.Correo
            conectar()
            If solicitar_cambio(email.Text, CInt(claveRnd.Text)) Then
                Response.Write("<script language='javascript'> alert('Ha sido enviado un correo con la clave para cambiar la contraseña'); </script>")
                emailSender.enviarEmail(email.Text, mensaje)
            Else
                Response.Write("<script language='javascript'> alert('No se ha encontrado el usuario'); </script>")
            End If
            cerrarconexion()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        password1Validation.Validate()
        password2Validation.Validate()
        If password1Validation.IsValid And password2Validation.IsValid Then
            conectar()
            Dim pass = password1.Text
            Dim mySHA256 As SHA256 = SHA256Managed.Create()
            pass = Convert.ToBase64String(mySHA256.ComputeHash(Encoding.UTF8.GetBytes(pass)))
            If cambiar_password(email.Text, clave.Text, pass) Then
                Response.Write("<script language='javascript'> alert('Modificación correcta'); </script>")
            Else
                Response.Write("<script language='javascript'> alert('No se ha modificado la contraseña'); </script>")
            End If
        End If

    End Sub
End Class