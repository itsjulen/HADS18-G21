<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registro.aspx.vb" Inherits="Laboratorio2.WebForm2" %>

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
    .auto-style1 {
        color: #FF0000;
    }
    .auto-style2 {
        width: 292px;
    }
    .auto-style3 {
        height: 23px;
    }
</style>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table>
                <tr>
                    <th colspan="2" class="auto-style3">REGISTRO DE USUARIO</th>
                </tr>
                <tr>
                    <td>Email*:
                    </td>
                    <td class="auto-style2">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="email" runat="server" BorderStyle="Double" AutoPostBack="True"></asp:TextBox>
                                <asp:Label runat="server" ID="emailval"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email obligatorio" ControlToValidate="email" EnableClientScript="False" CssClass="auto-style1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email incorrecto" ControlToValidate="email" EnableClientScript="False" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Style="float: left;" CssClass="auto-style1"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td>Nombre*:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="nombre" runat="server" BorderStyle="Double"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nombre obligatorios" ControlToValidate="nombre" EnableClientScript="False" Style="color: #FF0000"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>Apellidos*:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="apellido" runat="server" BorderStyle="Double"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Apellidos obligatorios" ControlToValidate="apellido" EnableClientScript="False" Style="color: #FF0000"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>Contraseña*:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="password1" runat="server" TextMode="Password" BorderStyle="Double"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Contraseña obligatoria" ControlToValidate="password1" EnableClientScript="False" Style="color: #FF0000"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>Repita la contraseña*:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="password2" runat="server" TextMode="Password" BorderStyle="Double"></asp:TextBox></td>
                    <td>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToCompare="password1" ControlToValidate="password2" EnableClientScript="False" CssClass="auto-style1"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Contraseña obligatoria" ControlToValidate="password2" EnableClientScript="False" Style="float: left;" CssClass="auto-style1"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>Rol*:</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="tipo" runat="server" Width="100%">
                            <asp:ListItem Value="Alumno">Alumno</asp:ListItem>
                            <asp:ListItem Value="Profesor">Profesor</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Registrarse" Width="100%" BorderStyle="Double" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="errorMsg" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
