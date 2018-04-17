<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AdministrarTareasGen.aspx.vb" Inherits="Laboratorio2.AdministrarTareasGen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-TAREASConnectionString %>" SelectCommand="SELECT * FROM [TareasGenericas]" DeleteCommand="DELETE FROM [TareasGenericas] WHERE [Codigo] = @Codigo" InsertCommand="INSERT INTO [TareasGenericas] ([Codigo], [Descripcion], [CodAsig], [HEstimadas], [Explotacion], [TipoTarea]) VALUES (@Codigo, @Descripcion, @CodAsig, @HEstimadas, @Explotacion, @TipoTarea)" UpdateCommand="UPDATE [TareasGenericas] SET [Descripcion] = @Descripcion, [CodAsig] = @CodAsig, [HEstimadas] = @HEstimadas, [Explotacion] = @Explotacion, [TipoTarea] = @TipoTarea WHERE [Codigo] = @Codigo">
            <DeleteParameters>
                <asp:Parameter Name="Codigo" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Codigo" Type="String" />
                <asp:Parameter Name="Descripcion" Type="String" />
                <asp:Parameter Name="CodAsig" Type="String" />
                <asp:Parameter Name="HEstimadas" Type="Int32" />
                <asp:Parameter Name="Explotacion" Type="Boolean" />
                <asp:Parameter Name="TipoTarea" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Descripcion" Type="String" />
                <asp:Parameter Name="CodAsig" Type="String" />
                <asp:Parameter Name="HEstimadas" Type="Int32" />
                <asp:Parameter Name="Explotacion" Type="Boolean" />
                <asp:Parameter Name="TipoTarea" Type="String" />
                <asp:Parameter Name="Codigo" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <div>
            <table>
                <tr>
                    <td style="text-align: right;">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CerrarSesion.aspx">Cerrar sesión</asp:HyperLink></td>
                    <td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Codigo" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" />
                                <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                <asp:BoundField DataField="CodAsig" HeaderText="CodAsig" SortExpression="CodAsig" />
                                <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                                <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion" />
                                <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/Admin.aspx">Volver</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
