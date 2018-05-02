<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReserveCruise.aspx.cs" Inherits="CruiseReservationApplication.ReserveCruise" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reserve Cruise</title>
    <style type="text/css">
        .style1
        {
            height: 100%;
        }
        .style2
        {
            width: 67px;
        }
        .newStyle1
        {
            font-size: xx-large;
            font-weight: bold;
            color: #FF9900;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding:10px">
        <div class="style1">
            <asp:Table id="tableMenu" runat="server" HorizontalAlign="Left" CellSpacing="10" CellPadding="3">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:HyperLink ID="hyperLinkHome" NavigateUrl="~/HomePage.aspx" Text="Home" runat="server"></asp:HyperLink>
                    </asp:TableCell></asp:TableRow></asp:Table></div><br />
        <br />
        <hr />
        Cruise:<asp:DropDownList ID="ddlCruise" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlCruise_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp; Cabin number:
        <asp:TextBox ID="txtCabinNo" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="txtCabinNo">Cabin number is required.</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lblDestTitle" runat="server" Text="Destinations:"></asp:Label>
        <br />
        <asp:Label ID="lblDestinations" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnReserve" runat="server" OnClick="btnReserve_Click" Text="Reserve Cruise" />
&nbsp;&nbsp;
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
    </form>
</body>
</html>
