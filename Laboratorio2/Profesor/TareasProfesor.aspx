﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TareasProfesor.aspx.vb" Inherits="Laboratorio2.TareasProfesor" %>

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
                        Gestión de tareas genéricas
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CerrarSesion.aspx">Cerrar Sesión</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        Selecionar Asignatura:<br />
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
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-TAREASConnectionString %>" SelectCommand="SELECT * FROM [TareasGenericas] WHERE ([CodAsig] = @CodAsig)" DeleteCommand="DELETE FROM [TareasGenericas] WHERE [Codigo] = @Codigo" InsertCommand="INSERT INTO [TareasGenericas] ([Codigo], [Descripcion], [CodAsig], [HEstimadas], [Explotacion], [TipoTarea]) VALUES (@Codigo, @Descripcion, @CodAsig, @HEstimadas, @Explotacion, @TipoTarea)" UpdateCommand="UPDATE [TareasGenericas] SET [Descripcion] = @Descripcion, [CodAsig] = @CodAsig, [HEstimadas] = @HEstimadas, [Explotacion] = @Explotacion, [TipoTarea] = @TipoTarea WHERE [Codigo] = @Codigo">
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
                        <SelectParameters>
                            <asp:ControlParameter ControlID="codasig" Name="CodAsig" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Descripcion" Type="String" />
                            <asp:Parameter Name="CodAsig" Type="String" />
                            <asp:Parameter Name="HEstimadas" Type="Int32" />
                            <asp:Parameter Name="Explotacion" Type="Boolean" />
                            <asp:Parameter Name="TipoTarea" Type="String" />
                            <asp:Parameter Name="Codigo" Type="String" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Insertar" runat="server" Text="INSERTAR NUEVA TABLA" ClientIDMode="AutoID" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" DataSourceID="SqlDataSource2" GridLines="None" AutoGenerateColumns="False" DataKeyNames="Codigo" ForeColor="#333333" AllowSorting="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField CancelText="Cancelar" DeleteText="Borrar" EditText="Editar" InsertText="Insertar" NewText="Nuevo" SelectText="Seleccionar" ShowEditButton="True" UpdateText="Actualizar" />
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="CodAsig" HeaderText="CodAsig" SortExpression="CodAsig" />
                <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion" />
                <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Profesor/Profesor.aspx">Volver</asp:HyperLink>
    </form>
</body>
</html>
