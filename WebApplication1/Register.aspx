<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtUsername" runat="server"/>
        <asp:TextBox ID="txtPassword" runat="server"/>
    </div>
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Đăng nhập" />
        <asp:TextBox ID="txtResult" runat="server"></asp:TextBox>
    </form>
</body>
</html>
