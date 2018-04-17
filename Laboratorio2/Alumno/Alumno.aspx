<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Alumno.aspx.vb" Inherits="Laboratorio2.Alumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <table border="1" >
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Alumno/TareasAlumno.aspx">Tareas Genericas </asp:HyperLink> <br />
                <asp:HyperLink ID="HyperLink2" runat="server">Tareas Propias</asp:HyperLink> <br />
                <asp:HyperLink ID="HyperLink3" runat="server">Grupos</asp:HyperLink>
            </td>
            <td>
                Gestión Web de Tareas-Dedicación
                <br />
                <br /> 
                Alumnos
            </td>
        </tr>
    </table>
</body>
</html>
