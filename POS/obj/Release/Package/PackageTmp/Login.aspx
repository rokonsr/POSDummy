<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="POS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/site.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            width: 100px;
            height: 40px;
        }
        .auto-style3 {
            height: 40px;
        }
        .auto-style6 {
            width: 100px;
            height: 50px;
        }
        .auto-style7 {
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="login">
        <table>
            <tr>
                <td class="auto-style6"><b>Username :</b></td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtUserName" runat="server" Width="220px" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"><b>Password :</b></td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtPassword" runat="server" Width="220px" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style3">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" Width="110px" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
