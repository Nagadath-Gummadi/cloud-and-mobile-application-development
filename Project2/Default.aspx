<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TableWebRole.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="insertTable" runat="server" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell>Enter First Name:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtFN" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Enter Last Name:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtLN" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Enter Contact Number:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtCN" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Choose Contact Type:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="lstCT" runat="server">
                        <asp:ListItem>Family</asp:ListItem>
                        <asp:ListItem>Friends</asp:ListItem>
                        <asp:ListItem>Others</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <asp:Button ID="cmdInsert" runat="server" Text="Insert Contact" OnClick="cmdInsert_Click" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <hr />
        <asp:GridView ID="contactsGrid" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false" OnRowCommand="contactsGrid_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                <asp:BoundField HeaderText="Last Name" DataField="LastName" />
                <asp:BoundField HeaderText="Contact Number" DataField="RowKey" />
                <asp:BoundField HeaderText="Contact Type" DataField="PartitionKey" />
                <asp:ButtonField HeaderText="Edit Column" ButtonType="Button" Text="Edit" />
            </Columns>
        </asp:GridView>
    </div>
    <fieldset runat="server" id="Editfs" visible="false">
        <legend>Edit</legend>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>First Name:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtefn" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Last Name:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txteln" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Contact Number:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtecn" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Contact Type:</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtect" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="cmdub" runat="server" Text="Replace" OnClick="cmdub_Click" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="cmddb" runat="server" Text="Delete" OnClick="cmddb_Click" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </fieldset>
    </form>
</body>
</html>

