<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListCustomers.aspx.cs" Inherits="VehicleRental.ListCustomers" %>
<!DOCTYPE html>
<html>
<head><title>Customer List</title>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
    </style>
</head>
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
        <h2 class="auto-style1">Customer List</h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerID"
            OnRowEditing="gvCustomers_RowEditing" OnRowCancelingEdit="gvCustomers_RowCancelingEdit"
            OnRowUpdating="gvCustomers_RowUpdating" OnRowDeleting="gvCustomers_RowDeleting" BackColor="White" Height="246px" Width="593px">
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="ContactDetails" HeaderText="Contact Details" />
                <asp:BoundField DataField="DriverLicenseNumber" HeaderText="Driver License" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" BackColor="White"></asp:Label>

        <br /><br />

        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="Default.aspx" BackColor="White">Home</asp:HyperLink>
    </div>
</form>
</body>
</html>
