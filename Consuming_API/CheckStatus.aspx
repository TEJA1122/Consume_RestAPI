<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckStatus.aspx.cs" Inherits="Consuming_API.CheckStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Enter Check ID:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Check Status" Width="241px" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server"></asp:Label>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" Visible="False">Crim Check link</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
