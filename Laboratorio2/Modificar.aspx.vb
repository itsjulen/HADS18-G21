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
            emailSender.enviarEmail(email.Text, mensaje)
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If claveRnd.Text = clave.Text Then
            password1Validation.Validate()
            password2Validation.Validate()
            If password1Validation.IsValid And password2Validation.IsValid Then
                Response.Write("<script language='javascript'> alert('Modificación correcta'); </script>")
            End If
        Else
            claveVal.Text = "La clave no es válida, es " & claveRnd.Text
        End If


    End Sub
End Class