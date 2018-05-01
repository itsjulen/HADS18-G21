Public Class coordinador
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim c As New coordinador21.coordinador
        Label3.Text = DropDownList1.Text
        media.Text = c.obtenerMedia(DropDownList1.Text)
    End Sub

    Private Sub DropDownList1_DataBound(sender As Object, e As EventArgs) Handles DropDownList1.DataBound
        Dim c As New coordinador21.coordinador
        Label3.Text = DropDownList1.Text
        media.Text = c.obtenerMedia(DropDownList1.Text)
    End Sub
End Class