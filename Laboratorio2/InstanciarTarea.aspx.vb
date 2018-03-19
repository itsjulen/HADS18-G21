Imports System.Data.SqlClient

Public Class InstanciarTarea
    Inherits System.Web.UI.Page
    Dim dsttareas As New DataSet
    Dim daptareas As SqlDataAdapter
    Dim tbltareas As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.IsNewSession Then
            Response.Write("<script language='javascript'> alert('Acceso denegado a esta página.'); </script>")
            Response.Redirect("InicioSesion.aspx", True)
        End If
        If Not Session.Contents("tipo").Equals("Alumno") Then
            Response.Write("<script language='javascript'> alert('Acceso denegado a esta página.'); </script>")
            Response.Redirect("InicioSesion.aspx", True)
        End If
        If Page.IsPostBack Then
            dsttareas = Session("datos")
            daptareas = Session("adaptador")
        Else
            Dim con As New SqlConnection
            con.ConnectionString = “Server=tcp:hads21-2018.database.windows.net,1433;Initial Catalog=HADS21-TAREAS;Persist Security Info=False;User ID=jv21;Password=VeskoJulen21;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            daptareas = New SqlDataAdapter("select * from TareasPersonales", con)
            Dim bldtareas As New SqlCommandBuilder(daptareas)
            daptareas.Fill(dsttareas, "TareasPersonales")
            tbltareas = dsttareas.Tables("TareasPersonales")
            GridView1.DataSource = tbltareas
            GridView1.DataBind()
            Session("datos") = dsttareas
            Session("adaptador") = daptareas
        End If
        usuario.Text = Session("email")
        hest.Text = Request.Item("hestimadas")
        tarea.Text = Request.Item("codigo")
    End Sub

    Protected Sub crear_Click(sender As Object, e As EventArgs) Handles crear.Click
        tbltareas = dsttareas.Tables("TareasPersonales")
        Dim R As DataRow = tbltareas.NewRow()
        R("Descripción") = Request.Item("descripcion")
        R("HEstimadas") = hest.Text
        R("HReales") = hreal.Text
        R("Email") = usuario.Text
        tbltareas.Rows.Add(R)
        daptareas.Update(tbltareas)
        tbltareas.AcceptChanges()
        Response.Redirect("TareasAlumno.aspx")
    End Sub
End Class