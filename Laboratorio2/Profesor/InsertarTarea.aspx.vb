Imports System.Data.SqlClient

Public Class InsertarTabla
    Inherits System.Web.UI.Page
    Dim dsttareas As New DataSet
    Dim daptareas As SqlDataAdapter
    Dim tbltareas As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            dsttareas = Session("datos")
            daptareas = Session("adaptador")
        Else
            Dim con As New SqlConnection
            con.ConnectionString = “Server=tcp:hads21-2018.database.windows.net,1433;Initial Catalog=HADS21-TAREAS;Persist Security Info=False;User ID=jv21;Password=VeskoJulen21;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            daptareas = New SqlDataAdapter("select * from TareasGenericas", con)
            Dim bldtareas As New SqlCommandBuilder(daptareas)
            daptareas.Fill(dsttareas, "TareasGenericas")
            tbltareas = dsttareas.Tables("TareasGenericas")
            Session("datos") = dsttareas
            Session("adaptador") = daptareas
        End If
    End Sub

    Protected Sub añadir_Click(sender As Object, e As EventArgs) Handles añadir.Click
        tbltareas = dsttareas.Tables("TareasGenericas")
        Dim R As DataRow = tbltareas.NewRow()
        R("Codigo") = codigo.Text
        R("Descripcion") = desc.Text
        R("CodAsig") = asig.Text
        R("HEstimadas") = horas.Text
        R("Explotacion") = False
        R("TipoTarea") = tipo.Text
        tbltareas.Rows.Add(R)
        daptareas.Update(tbltareas)
        tbltareas.AcceptChanges()
        Response.Redirect("TareasProfesor.aspx", True)
    End Sub
End Class