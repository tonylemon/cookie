<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="cookie.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        table input[type=text],input[type=password],input[type=submit]{
            border:1px;
            border-style:solid;
            border-color:#808080;
            height:30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">
            <tr><td Width="120" style="text-align:center;">用户名:</td><td><asp:TextBox ID="txtUserName" runat="server" Width="300"></asp:TextBox></td></tr>
            <tr><td style="text-align:center;">密&nbsp;&nbsp;&nbsp;码:</td><td><asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="300"></asp:TextBox></td></tr>
            <tr><td colspan="2" style="text-align:center;" height="50">
                <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" Width="80"/>
                <asp:CheckBox ID="CheckBox1" runat="server" Text="7天免登陆"/>
                </td></tr>
        </table>
        </div>
    </form>
</body>
</html>
