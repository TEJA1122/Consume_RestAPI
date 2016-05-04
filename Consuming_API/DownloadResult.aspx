<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadResult.aspx.cs" Inherits="Consuming_API.DownloadResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Enter Check ID:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Check Status" Width="241px" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
    <div>
    
    </div>
    </form>
</body>
</html>
