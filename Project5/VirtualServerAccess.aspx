<%@ Page Language = "C#" AutoEventWireup="true" CodeBehind="Vi rtualSqlServerAccess.aspx.cs" Inherits="VirtualSqlServer.VirtualSqlServerAccess" %>

<!DOCTYPE html>

<html xmlns = "http://www.w3.org/1999/xhtml" >
< head runat="server">
    <title></title>
</head>
<body>
    <form id = "form1" runat="server">
    <div>
     

        <asp:SqlDataSource ID = "SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:tempConnectionString %>" DeleteCommand="DELETE FROM [Student] WHERE [regno] = @original_regno AND (([studentname] = @original_studentname) OR ([studentname] IS NULL AND @original_studentname IS NULL)) AND (([section] = @original_section) OR ([section] IS NULL AND @original_section IS NULL))" InsertCommand="INSERT INTO [Student] ([studentname], [regno], [section]) VALUES (@studentname, @regno, @section)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Student]" UpdateCommand="UPDATE [Student] SET [studentname] = @studentname, [section] = @section WHERE [regno] = @original_regno AND (([studentname] = @original_studentname) OR ([studentname] IS NULL AND @original_studentname IS NULL)) AND (([section] = @original_section) OR ([section] IS NULL AND @original_section IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name = "original_regno" Type="String" />
                <asp:Parameter Name = "original_studentname" Type="String" />
                <asp:Parameter Name = "original_section" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name = "studentname" Type="String" />
                <asp:Parameter Name = "regno" Type="String" />
                <asp:Parameter Name = "section" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name = "studentname" Type="String" />
                <asp:Parameter Name = "section" Type="String" />
                <asp:Parameter Name = "original_regno" Type="String" />
                <asp:Parameter Name = "original_studentname" Type="String" />
                <asp:Parameter Name = "original_section" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:Table ID = "Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>Name:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID = "txtname" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    Reg No.
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID = "txtregno" runat= "server" ></ asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    Section:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID = "ddlsection" runat= "server" >
                        < asp:ListItem>A</asp:ListItem>
                        <asp:ListItem>B</asp:ListItem>
                        <asp:ListItem>C</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableFooterRow>
                <asp:TableCell ColumnSpan = "2" HorizontalAlign= "Center" >
                    < asp:Button ID = "cmdinsert" runat= "server" Text= "Insert" OnClick= "cmdinsert_Click" /></ asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
        
        <br />
        <asp:GridView ID = "GridView1" runat= "server" AllowSorting= "True" AutoGenerateColumns= "False" DataKeyNames= "regno" DataSourceID= "SqlDataSource1">
            < Columns >
                < asp:CommandField ShowDeleteButton = "True" ShowEditButton= "True" />
                < asp:BoundField DataField = "studentname" HeaderText= "studentname" SortExpression= "studentname" />
                < asp:BoundField DataField = "regno" HeaderText= "regno" ReadOnly= "True" SortExpression= "regno" />
                < asp:BoundField DataField = "section" HeaderText= "section" SortExpression= "section" />
            </ Columns >
        </ asp:GridView>
     

    </div>
    </form>
</body>
</html>

