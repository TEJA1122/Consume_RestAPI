<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestingAPI.aspx.cs" Inherits="Consume_RestAPI.TestingAPI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="ID:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="URL:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server">Crim Check link</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
