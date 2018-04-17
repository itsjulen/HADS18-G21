<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InicioSesion.aspx.vb" Inherits="Laboratorio2.WebForm1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<style>
    td {
        padding: 5px;
        margin-left: 40px;
    }
</style>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <th colspan="2">INICIO DE SESIÓN</th>
                </tr>
                <tr>
                    <td>Email:
                    </td>
                    <td>
                        <asp:TextBox ID="email" runat="server" BorderStyle="Double"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator runat="server" ErrorMessage="Email no válido" ControlToValidate="email" EnableClientScript="False" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" style="color: #FF0000"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Contraseña: &nbsp;</td>
                    <td>
                        <asp:TextBox ID="password" runat="server" BorderStyle="Double" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="password" EnableClientScript="False" style="color: #FF0000"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Iniciar sesión" Width="100%" BorderStyle="Double" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="Registro" Width="100%" BorderStyle="Double" /></td>
                    <td>
                        <asp:Button ID="Button3" runat="server" Text="Cambiar contrseña" Width="100%" BorderStyle="Double" /></td>
                </tr>
            </table>
            <asp:Label ID="erMsg" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
