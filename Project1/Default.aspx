<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Default.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="ImageSelector" runat="server" /><br />
        <asp:Button ID="cmdUpload" runat="server" Text="Upload" OnClick="cmdUpload_Click" />
        <hr />
        <asp:ListView ID="ImageGrid" runat="server">
            <ItemTemplate>
                <asp:Image runat="server" ImageUrl= "<%#((Microsoft.WindowsAzure.Storage.Blob.IListBlobItem)Container.DataItem).Uri %>"
                    width="500px" Height="300" />
            </ItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
