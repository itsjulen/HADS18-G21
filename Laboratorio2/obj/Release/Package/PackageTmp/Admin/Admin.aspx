<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Admin.aspx.vb" Inherits="Laboratorio2.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1">
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/AdministrarTareasGen.aspx">Administrar tareas genéricas</asp:HyperLink>
                    </td>
                    <td>Bienvenido al panel de administrador</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
