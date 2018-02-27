<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Modificar.aspx.vb" Inherits="Laboratorio2.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        td {
            padding: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <th colspan="2">CAMBIO DE CONTRASEÑA</th>
                </tr>
                <tr>
                    <td>Email:
                    </td>
                    <td>
                        <asp:TextBox ID="email" runat="server" BorderStyle="Double"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator runat="server" ErrorMessage="Email no válido" ControlToValidate="email" EnableClientScript="False" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ID="emailValidator" Style="color: #FF0000"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button3" runat="server" Text="Solicitar cambio de contraseña" Width="100%" BorderStyle="Double" />
                    </td>
                    <td>
                        <asp:TextBox ID="claveRnd" runat="server" Visible="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Clave: </td>
                    <td>
                        <asp:TextBox ID="clave" runat="server" BorderStyle="Double"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="claveVal" runat="server"></asp:Label>
                    </td>
                </tr>
        </div>
        <tr>
            <td>Contraseña nueva: </td>
            <td>
                <asp:TextBox ID="password1" runat="server" BorderStyle="Double"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="password1Validation" runat="server" ErrorMessage="Contraseña obligatoria" ControlToValidate="password1" EnableClientScript="False" Enabled="False" style="color: #FF0000" ViewStateMode="Disabled"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Repite la contraseña:</td>
            <td>
                <asp:TextBox ID="password2" runat="server" BorderStyle="Double"></asp:TextBox>
            </td>
            <td>
                <asp:CompareValidator ID="password2Validation" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToCompare="password1" ControlToValidate="password2" EnableClientScript="False" Enabled="False" style="color: #FF0000" ValidateRequestMode="Disabled"></asp:CompareValidator>
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Cambiar contraseña" BorderStyle="Double" width="100%"/></td>
        </tr>
        </table>

    </form>
</body>
</html>
