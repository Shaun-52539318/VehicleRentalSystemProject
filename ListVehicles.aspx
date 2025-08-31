<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListVehicles.aspx.cs" Inherits="VehicleRental.ListVehicles" %>

<!DOCTYPE html>
<html>
<head><title>Vehicle List</title></head>
<body style="
    margin: 0;
    height: 100vh;
    background-position: center;
    background-image: url('Screenshot 2025-08-28 200420.png');
    background-repeat: no-repeat;
    background-size: cover;
">
<form id="form1" runat="server">
    <div>
        <h2>Vehicle List</h2>
        <asp:GridView ID="gvVehicles" runat="server" AutoGenerateColumns="False" DataKeyNames="VehicleID"
            OnRowEditing="gvVehicles_RowEditing" OnRowCancelingEdit="gvVehicles_RowCancelingEdit"
            OnRowUpdating="gvVehicles_RowUpdating" OnRowDeleting="gvVehicles_RowDeleting" BackColor="White" Height="296px" Width="627px">
            <Columns>
                <asp:BoundField DataField="VehicleID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Model" HeaderText="Model" />
                <asp:BoundField DataField="Year" HeaderText="Year" />
                <asp:BoundField DataField="AvailabilityStatus" HeaderText="Status" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" BackColor="White"></asp:Label>

        <br /><br />

        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="Default.aspx" BackColor="White" Font-Size="XX-Large">Home</asp:HyperLink>
    </div>
</form>
</body>
</html>
