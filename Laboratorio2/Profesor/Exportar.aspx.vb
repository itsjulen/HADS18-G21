Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Public Class Exportar
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
        If File.Exists(Server.MapPath("App_Data/" & codasig.SelectedValue & ".xml")) Then
            ErrorMSG.Text = ""
            Xml1.Visible = True
            Xml1.DocumentSource = Server.MapPath("App_Data/" & codasig.SelectedValue & ".xml")
            Xml1.TransformSource = Server.MapPath("App_Data/XSLTFile.xsl")
        Else
            ErrorMSG.Text = "No hay XML a mostrar"
            Xml1.Visible = False
        End If
    End Sub

    Private Sub codasig_DataBound(sender As Object, e As EventArgs) Handles codasig.DataBound
        If File.Exists(Server.MapPath("App_Data/" & codasig.SelectedValue & ".xml")) Then
            ErrorMSG.Text = ""
            Xml1.Visible = True
            Xml1.DocumentSource = Server.MapPath("App_Data/" & codasig.SelectedValue & ".xml")
            Xml1.TransformSource = Server.MapPath("App_Data/XSLTFile.xsl")
        Else
            ErrorMSG.Text = "No hay XML a mostrar"
            Xml1.Visible = False
        End If
    End Sub

    Private Sub exportarbtn_Click(sender As Object, e As EventArgs) Handles exportarbtn.Click
        Dim xd As New XmlDocument
        Try
            xd.Load(Server.MapPath("App_Data/" & codasig.SelectedValue & ".xml"))
        Catch ex As FileNotFoundException
            Dim docNode As XmlNode = xd.CreateXmlDeclaration("1.0", "UTF-8", Nothing)
            xd.AppendChild(docNode)
            Dim tareas As XmlNode = xd.CreateElement("tareas")
            xd.AppendChild(tareas)
        End Try
        tbltareas = dsttareas.Tables("TareasGenericas")
        For Each row As DataRow In tbltareas.Select("CODASIG = '" & codasig.SelectedValue & "'")
            Dim tarea As XmlElement
            tarea = xd.CreateElement("tarea")
            Dim at As XmlAttribute = xd.CreateAttribute("codigo")
            Dim xt As XmlText
            xt = xd.CreateTextNode(row("codigo"))
            at.AppendChild(xt)
            tarea.Attributes.Append(at)

            Dim descripcion As XmlElement
            descripcion = xd.CreateElement("descripcion")
            Dim xtdesc As XmlText
            xtdesc = xd.CreateTextNode(row("descripcion"))
            descripcion.AppendChild(xtdesc)
            tarea.AppendChild(descripcion)

            Dim hestimadas As XmlElement
            hestimadas = xd.CreateElement("hestimadas")
            Dim xthest As XmlText
            xthest = xd.CreateTextNode(row("hestimadas"))
            hestimadas.AppendChild(xthest)
            tarea.AppendChild(hestimadas)

            Dim explotacion As XmlElement
            explotacion = xd.CreateElement("explotacion")
            Dim xtexp As XmlText
            xtexp = xd.CreateTextNode(row("explotacion"))
            explotacion.AppendChild(xtexp)
            tarea.AppendChild(explotacion)

            Dim tipotarea As XmlElement
            tipotarea = xd.CreateElement("tipotarea")
            Dim xttipo As XmlText
            xttipo = xd.CreateTextNode(row("tipotarea"))
            tipotarea.AppendChild(xttipo)
            tarea.AppendChild(tipotarea)

            xd.DocumentElement.AppendChild(tarea)
        Next row
        xd.Save(Server.MapPath("App_Data/" & codasig.SelectedValue & ".xml"))
    End Sub
End Class