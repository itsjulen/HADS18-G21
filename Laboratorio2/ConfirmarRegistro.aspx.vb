Imports AccesoABD.AccesoABD

Public Class ConfirmarRegistro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString.Count = 2 Then
            email.Text = Request.QueryString("email")
            clave.Text = Request.QueryString("clave")
        Else
            Response.Write("<script language='javascript'> alert('No deberías estar en esta página'); </script>")
            Server.Transfer("InicioSesion.aspx", True)
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conectar()
        Dim resp As Boolean = confirmar_usuario(email.Text, clave.Text)
        cerrarconexion()
        If resp Then
            Response.Write("<script language='javascript'> alert('Confirmación realizada con éxito'); </script>")
            Server.Transfer("Inicio.aspx", True)
        Else
            Response.Write("<script language='javascript'> alert('No se ha podido realizar la confirmación'); </script>")
            Server.Transfer("InicioSesion.aspx", True)
        End If
    End Sub
End Class