<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="VehicleRental.AddCustomer" %>
<!DOCTYPE html>
<html>
<head><title>Add Customer</title></head>
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
        <h2>Add New Customer</h2>
        <asp:Label Text="Name:" AssociatedControlID="txtName" runat="server" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtName" runat="server" />
        <br />
        <br />
        <br />
        <br />

        <asp:Label Text="Contact Details:" AssociatedControlID="txtContact" runat="server" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtContact" runat="server" />
        <br />
        <br />
        <br />
        <br />

        <asp:Label Text="Driver's License Number:" AssociatedControlID="txtDriverLicense" runat="server" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtDriverLicense" runat="server" />
        <br />
        <br />
        <br />

        <asp:Label Text="Address:" AssociatedControlID="txtAddress" runat="server" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="3" />
        <br />
        <br />
        <br />
        <br />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="btnAdd" runat="server" Text="Add Customer" OnClick="btnAdd_Click" /><br /><br />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Label ID="lblMessage" ForeColor="Green" runat="server" BackColor="White" />

        <br /><br />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />

        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="Default.aspx" BackColor="White">Home</asp:HyperLink>
    </div>
</form>
</body>
</html>
