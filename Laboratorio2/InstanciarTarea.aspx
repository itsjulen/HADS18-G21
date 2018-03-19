<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InstanciarTarea.aspx.vb" Inherits="Laboratorio2.InstanciarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table>
                <tr>
                    <td>Usuario</td>
                    <td>
                        <asp:TextBox ID="usuario" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Tarea</td>
                    <td>
                        <asp:TextBox ID="tarea" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">HorasEst.</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="hest" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Horas Reales: </td>
                    <td>
                        <asp:TextBox ID="hreal" runat="server" CssClass="auto-style2"></asp:TextBox>
                    </td>
                </tr>
               
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="crear" runat="server" Text="Crear Tarea" />
                        <br />
                        <asp:GridView ID="GridView1" runat="server">
                        </asp:GridView>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="TareasAlumno" runat="server" NavigateUrl="~/TareasAlumno.aspx">Pagina Anterior</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
