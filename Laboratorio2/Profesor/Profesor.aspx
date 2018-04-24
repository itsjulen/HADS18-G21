﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="Laboratorio2.Profesor" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table border="1">
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server">Asignaturas </asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Profesor/TareasProfesor.aspx">Tareas</asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Profesor/EstadisticaProfesor.aspx">Estadística</asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Profesor/ImportarXML.aspx">Importar v. XMLDocument</asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Profesor/Exportar.aspx">Exportar</asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink3" runat="server">Grupos</asp:HyperLink>
            </td>
            <td>Gestión Web de Tareas-Dedicación
                <br />
                <br />
                Profesores 
            </td>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </tr>
    </table>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="USUARIOS LOGEADOS: "></asp:Label>
                <asp:Label ID="Logeados" runat="server"></asp:Label>
                <br />
                <asp:ListBox ID="Alumnos" runat="server"></asp:ListBox>
                <ajaxToolkit:DragPanelExtender ID="Alumnos_DragPanelExtender" runat="server" BehaviorID="Alumnos_DragPanelExtender" DragHandleID="Alumnos" TargetControlID="Alumnos" />
                <asp:ListBox ID="Profesores" runat="server"></asp:ListBox>
                <ajaxToolkit:DragPanelExtender ID="Profesores_DragPanelExtender" runat="server" BehaviorID="Profesores_DragPanelExtender" DragHandleID="Profesores" TargetControlID="Profesores" />
                <asp:Timer ID="Timer1" runat="server" Interval="6000">
                </asp:Timer>
            </ContentTemplate>
             
        </asp:UpdatePanel>
    </form>
</body>
</html>
