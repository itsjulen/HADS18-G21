<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EstadisticaProfesor.aspx.vb" Inherits="Laboratorio2.EstadisticaProfesor" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-TAREASConnectionString %>" SelectCommand="SELECT [Descripción], AVG([HReales]), AVG(HEstimadas) FROM [TareasPersonales] GROUP BY [Descripción]"></asp:SqlDataSource>
    </div>
    <table>
        <tr>
            <td>Media de horas reales de dedicación y horas estimadas&nbsp; </td>
            <td>
                &nbsp;&nbsp;&nbsp; <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CerrarSesion.aspx">Cerrar sesión</asp:HyperLink></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="Descripción" YValueMembers="Column1">
                        </asp:Series>
                        <asp:Series Name="Series2" XValueMember="Descripción" YValueMembers="Column2">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Profesor.aspx">Volver</asp:HyperLink></td>
        </tr>
    </table>

</body>
</html>
