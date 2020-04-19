<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebRole1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Mail Id: <asp:TextBox ID="mid" runat="server"></asp:TextBox>
        <br />
        Subject: <asp:TextBox ID="sub" runat="server"></asp:TextBox>
        <br />
        Message: <asp:TextBox ID="msg" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="sumbmit" Text="Insert" runat="server" OnClick="sumbmit_Click" />
    </div>
    </form>
</body>
</html>
