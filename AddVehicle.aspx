<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddVehicle.aspx.cs" Inherits="VehicleRental.AddVehicle" %>

<!DOCTYPE html>
<html>
<head><title>Add Vehicle</title></head>
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
        <h2>Add New Vehicle</h2>

        <asp:Label Text="Model:" AssociatedControlID="txtModel" runat="server" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtModel" runat="server" />&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />

        <asp:Label Text="Year:" AssociatedControlID="txtYear" runat="server" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtYear" runat="server" Width="128px" />
        <br />
        <br />
        <br />
        <br />

        <asp:Label Text="Availability Status:" AssociatedControlID="ddlStatus" runat="server" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlStatus" runat="server">
            <asp:ListItem Text="Available" Value="Available" />
            <asp:ListItem Text="Rented" Value="Rented" />
        </asp:DropDownList>
        <br />
        <br />
        <br />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="btnAdd" runat="server" Text="Add Vehicle" OnClick="btnAdd_Click" />
        <br />
        <br /><br />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" BackColor="White" />

        <br />
        <br />
        <br />
        <br />

        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="Default.aspx" BackColor="White">Home</asp:HyperLink>
    </div>
</form>
</body>
</html>
