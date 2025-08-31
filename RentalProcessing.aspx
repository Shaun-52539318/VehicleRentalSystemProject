<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentalProcessing.aspx.cs" Inherits="VehicleRental.RentalProcessing" %>

<!DOCTYPE html>
<html>
<head><title>Rental Processing</title></head>
<body style="
    margin: 0;
    height: 100vh;
    background-position: center;
    background-image: url('Screenshot 2025-08-28 200420.png');
    background-repeat: no-repeat;
    background-size: cover;
">
<form id="form1" runat="server">
    <h2>Rental Agreement Processing</h2>

    <!-- Rent Vehicle Section -->
    <fieldset>
        <legend>Create Rental Agreement</legend>
        <asp:Label Text="Select Customer:" AssociatedControlID="ddlCustomers" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlCustomers" runat="server" /><br />
        <br />

        <asp:Label Text="Select Vehicle:" AssociatedControlID="ddlVehicles" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlVehicles" runat="server" /><br />
        <br />

        <asp:Label Text="Start Date:" AssociatedControlID="txtStartDate" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtStartDate" runat="server" Text='<%# DateTime.Now.ToString("yyyy-MM-dd") %>' /><br />
        <br />

        <asp:Label Text="End Date:" AssociatedControlID="txtEndDate" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEndDate" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
        <br />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="btnCreateRental" runat="server" Text="Create Rental" OnClick="btnCreateRental_Click" />
        <br />
        <br />
    </fieldset>

    <br />

    <!-- Return Vehicle Section -->
    <fieldset>
        <legend>Return Vehicle</legend>
        <asp:Label Text="Select Active Rental:" AssociatedControlID="ddlActiveRentals" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlActiveRentals" runat="server" /><br />
        <br />

        <asp:Label Text="Return Date:" AssociatedControlID="txtReturnDate" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtReturnDate" runat="server" Text='<%# DateTime.Now.ToString("yyyy-MM-dd") %>' /><br />
        <br />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="btnReturnVehicle" runat="server" Text="Process Return" OnClick="btnReturnVehicle_Click" />
    </fieldset>

    <br />

    &nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" BackColor="White" />

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <br /><br />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="Default.aspx" BackColor="White" Font-Size="XX-Large" ForeColor="#0000CC">Home</asp:HyperLink>
</form>
</body>
</html>
