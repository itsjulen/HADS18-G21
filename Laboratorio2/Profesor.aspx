<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="Laboratorio2.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="email,codigogrupo" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="email" HeaderText="email" ReadOnly="True" SortExpression="email" />
                <asp:BoundField DataField="codigogrupo" HeaderText="codigogrupo" ReadOnly="True" SortExpression="codigogrupo" />
                <asp:ButtonField CommandName="Edit" Text="Editar" />
                <asp:ButtonField CommandName="Update" Text="Update" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-TAREASConnectionString %>" DeleteCommand="DELETE FROM [ProfesoresGrupo] WHERE [email] = @email AND [codigogrupo] = @codigogrupo" InsertCommand="INSERT INTO [ProfesoresGrupo] ([email], [codigogrupo]) VALUES (@email, @codigogrupo)" SelectCommand="SELECT * FROM [ProfesoresGrupo] WHERE ([email] = @email)">
            <DeleteParameters>
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="codigogrupo" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="codigogrupo" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="email" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        
    </form>
</body>
</html>
