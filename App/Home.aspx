<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="App.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="page-header">
                <h1>Xin chào <small><%=this.mCurrentUser%></small></h1>
                <asp:Button runat="server" CssClass="btn btn-danger" ID="btnLogout" Text="Đăng xuất" OnClick="btnLogout_Click" />
                <small>Phiên: <%=this.mSessionToken%></small>
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="form-group">
                        <label for="newBalance">
                            <asp:Label runat="server" Text="Số dư:" /></label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="newBalance" />
                    </div>
                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Thêm mới TK" OnClick="btnCreateAccount_Click" />
                </div>
            </div>
            <% if (this.mMessage != null) Response.Write(this.mMessage); %>
            <div class="panel panel-default">
                <div class="panel-heading">Danh sách tài khoản</div>
                <div class="panel-body">
                    <asp:ListView ID="ListView_Tabs" runat="server" OnItemCommand="ListView_Tabs_ItemCommand">
                        <LayoutTemplate>
                            <div class="list-group">
                                <asp:LinkButton ID="itemPlaceholder" runat="server" />
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-default list-group-item" CommandName="Transfer" CommandArgument='<%# Eval("number") %>' runat="server">
                        <%# Eval("number") %> <span class="badge"><%# Eval("balances") %> đ</span>
                            </asp:LinkButton>
                            </li>
                        </ItemTemplate>
                        <SelectedItemTemplate>
                            <asp:LinkButton CssClass="btn btn-default" CommandName="Transfer" CommandArgument='<%# Eval("number") %>' runat="server">
                        <%# Eval("number") %> <span class="badge"><%# Eval("balances") %> đ</span>
                            </asp:LinkButton>
                        </SelectedItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
