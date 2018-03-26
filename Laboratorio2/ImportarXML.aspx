<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportarXML.aspx.vb" Inherits="Laboratorio2.ImportarXML" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        Profesor <br />
                        Importar tareas genéricas</td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CerrarSesion.aspx">Cerrar Sesión</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        Selecionar Asignatura a importar:<br />
                        <asp:DropDownList ID="codasig" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-TAREASConnectionString %>" 
                        SelectCommand="SELECT [Asignaturas].[codigo] FROM ([Asignaturas] INNER JOIN [GruposClase] ON [Asignaturas].[codigo]=[GruposClase].[codigoasig]) INNER JOIN [ProfesoresGrupo] ON [ProfesoresGrupo].[codigogrupo]=[GruposClase].[codigo] WHERE ([ProfesoresGrupo].[email] = @email)">
                        <SelectParameters>
                            <asp:SessionParameter Name="email" SessionField="email" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Insertar" runat="server" Text="IMPORTAR (XMLD)" ClientIDMode="AutoID" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:Xml ID="Xml1" runat="server"></asp:Xml>
        <br />
        <asp:Label ID="ErrorMSG" runat="server" Text=""></asp:Label>
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Profesor.aspx">Volver</asp:HyperLink>
    </form>
</body>
</html>
