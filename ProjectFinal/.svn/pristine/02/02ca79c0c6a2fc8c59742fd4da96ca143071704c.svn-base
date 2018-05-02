<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CruiseReservationApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 92px;
        }
    </style>
</head>
<body>
    <form id="frmLogin" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2">
                    UserName:</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" 
                        ControlToValidate="txtUserName" ErrorMessage="UserName is required." style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Password:</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                        ControlToValidate="txtPassword" ErrorMessage="Password is required." style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnLogin" runat="server" Text="Login" Width="225px" OnClick="btnLogin_Click" />
        <br />
        <asp:Label ID="lblInvalid" runat="server" style="color: #FF0000" 
            Text="Invalid UserName and/or Password." Visible="False"></asp:Label>
    
    </div>
    </form>
</body>
</html>
