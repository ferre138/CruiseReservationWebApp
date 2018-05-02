<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservations.aspx.cs" Inherits="CruiseReservationApplication.Reservations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reservations</title>
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
                        <asp:LinkButton ID="hyperLinkHome" runat="server" OnClick="hyperLinkHome_Click" />
                    </asp:TableCell><asp:TableCell>
                        <asp:HyperLink ID="hyperLinkReserveCruise" NavigateUrl="~/ReserveCruise.aspx" Text="Reserve Cruise" runat="server"></asp:HyperLink>
                    </asp:TableCell></asp:TableRow></asp:Table></div><br />
        <br />
        <hr />
        <asp:Label ID="lblFullName" runat="server"></asp:Label><br />
        <br />
        <asp:Label ID="lblReservations" runat="server" Text="Reservations:"></asp:Label><asp:GridView ID="gvReservations" runat="server" AutoGenerateColumns="False" OnRowCommand="gvReservations_RowCommand" OnRowDeleting="gvReservations_RowDeleting" OnRowEditing="gvReservations_RowEditing"><Columns>
                <asp:BoundField DataField="ShipId" HeaderText="Ship ID" /><asp:BoundField DataField="ShipName" HeaderText="Ship Name" />
                <asp:BoundField DataField="CabinNo" HeaderText="Cabin #" />
                <asp:BoundField DataField="Destinations" HeaderText="Destinations" />
                <asp:ButtonField ButtonType="Button" CommandName="CANCEL" Text="Cancel Reservation" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblNoReservations" runat="server" ForeColor="Red" Text="No reservartions yet." Visible="False"></asp:Label>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label><br />
    
    </div>
    </form>
</body>
</html>
