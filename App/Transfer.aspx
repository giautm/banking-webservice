<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="App.Transfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous"/>
</head>
<body>
    <div class="container">
        <div class="page-header">
            <h1>Tiến hành chuyển tiền</h1>
        </div>
        <form id="form1" runat="server">
            <% if (this.mMessageError != null)
                    Response.Write(this.mMessageError);
            %>
            <div class="form-group">
                <label for="bankNumber">
                    <asp:Label runat="server" Text="Chuyển từ tài khoản:" /></label>
                <asp:TextBox runat="server" CssClass="form-control" ID="bankNumber" ReadOnly="true" />
            </div>
            <div class="form-group">
                <label for="balances">
                    <asp:Label runat="server" Text="Số dư:" /></label>
                <asp:TextBox runat="server" CssClass="form-control" ID="balances" ReadOnly="true" />
            </div>
            <div class="form-group">
                <label for="transferTo">
                    <asp:Label runat="server" Text="Chuyển đến tài khoản:" /></label>
                <asp:TextBox runat="server" CssClass="form-control" ID="transferTo" />
            </div>
            <div class="form-group">
                <label for="amount">
                    <asp:Label runat="server" Text="Số tiền muốn chuyển:" /></label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtAmount" OnTextChanged="txtAmount_TextChanged" />
            </div>
            <asp:Button CssClass="btn btn-primary" runat="server" Text="Thực hiện" ID="btnTransfer" OnClick="Execute_Click" />
        </form>
    </div>
</body>
</html>
