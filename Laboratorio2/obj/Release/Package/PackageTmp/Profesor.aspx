<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="Laboratorio2.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <table border="1">
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server">Asignaturas </asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TareasProfesor.aspx">Tareas</asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/EstadisticaProfesor.aspx">Estadística</asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink3" runat="server">Grupos</asp:HyperLink>
            </td>
            <td>Gestión Web de Tareas-Dedicación
                <br />
                <br />
                Profesores 
            </td>
        </tr>
    </table>
</body>
</html>
