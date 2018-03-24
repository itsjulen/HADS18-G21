Imports System.Data.SqlClient
Imports System.Xml

Public Class ImportarXML
    Inherits System.Web.UI.Page

    Dim xmld As New XmlDocument
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

    Private Sub codasig_SelectedIndexChanged(sender As Object, e As EventArgs) Handles codasig.SelectedIndexChanged
        Xml1.DocumentSource = Server.MapPath("App_Data/" & codasig.SelectedValue & ".xml")
        Xml1.TransformSource = Server.MapPath("App_Data/XSLTFile.xsl")
    End Sub

    Private Sub codasig_DataBound(sender As Object, e As EventArgs) Handles codasig.DataBound
        Xml1.DocumentSource = Server.MapPath("App_Data/" & codasig.SelectedValue & ".xml")
        Xml1.TransformSource = Server.MapPath("App_Data/XSLTFile.xsl")
    End Sub

    Protected Sub Insertar_Click(sender As Object, e As EventArgs) Handles Insertar.Click
        xmld.Load(Server.MapPath("App_Data/" & codasig.SelectedValue & ".xml"))
        Dim Tareas As XmlNodeList
        Tareas = xmld.GetElementsByTagName("tarea")
        tbltareas = dsttareas.Tables("TareasGenericas")
        Dim tarea As XmlNode
        For Each tarea In Tareas
            Dim R As DataRow = tbltareas.NewRow()
            R("Codigo") = tarea.Attributes.ItemOf(0).Value
            R("Descripcion") = tarea("descripcion").InnerText
            R("CodAsig") = codasig.SelectedValue
            R("HEstimadas") = tarea("hestimadas").InnerText
            R("Explotacion") = tarea("explotacion").InnerText
            R("TipoTarea") = tarea("tipotarea").InnerText
            tbltareas.Rows.Add(R)
        Next
        daptareas.Update(tbltareas)
        tbltareas.AcceptChanges()
    End Sub
End Class