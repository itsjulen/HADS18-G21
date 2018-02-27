<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConfirmarRegistro.aspx.vb" Inherits="Laboratorio2.ConfirmarRegistro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<style type="text/css">
    td {
        padding: 5px;
    }
</style>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Email:
                    </td>
                    <td>
                        <asp:TextBox ID="email" runat="server" BorderStyle="Double" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Clave de confirmación:
                    </td>
                    <td>
                        <asp:TextBox ID="clave" runat="server" BorderStyle="Double" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Confirmar registro" Width="100%" BorderStyle="Double" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
