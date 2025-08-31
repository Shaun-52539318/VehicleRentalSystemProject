<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VehicleRental.Default" %>

<!DOCTYPE html>
<html>
<head>
    <title>Vehicle Rental System - Home</title>
    <style type="text/css">
        .auto-style2 {
            text-align: center;
            font-size: x-large;
            color: #FFFFFF;
        }
        .auto-style3 {
            text-align: center;
            font-size: xx-large;
            color: #000000;
        }
        .auto-style4 {
            color: #000000;
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
        <div style="margin: 20px; height: 950px; color: #00FF00;">
            <h1 class="auto-style3"><em>Welcome to Vehicle Rental System</em></h1>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br /><br />

            <br />
            <br />
            <br />
            <br />
            <p class="auto-style2" style="color: #00FF00"><em class="auto-style4"><strong>T</strong></em><span class="auto-style4"><em><strong>he Vehicle Rental System is designed to facilitate and modernize corporate vehicle rental and return procedures. The system will manage inventories through customer records, Smooth rental Transactions and Track payments efficiently. The system will also improve customer happiness and operational efficiency by incorporating advanced features such as sorting, data backups, and internet-based application for remote access</strong></em></span></p>
            <br /><br />

            <br /><br />

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

            <br /><br />

            <br /><br />

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:HyperLink ID="hlAddCustomer" runat="server" NavigateUrl="AddCustomer.aspx" BackColor="White">Add Customer</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;

            <asp:HyperLink ID="hlListCustomers" runat="server" NavigateUrl="ListCustomers.aspx" BackColor="White">View/Edit Customers</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;

            <asp:HyperLink ID="hlAddVehicle" runat="server" NavigateUrl="AddVehicle.aspx" BackColor="White">Add Vehicle</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;

            <asp:HyperLink ID="hlListVehicles" runat="server" NavigateUrl="ListVehicles.aspx" BackColor="White">View/Edit Vehicles</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;

            <asp:HyperLink ID="hlRentalProcessing" runat="server" NavigateUrl="RentalProcessing.aspx" BackColor="White">Rental Processing</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:HyperLink ID="hlPayments" runat="server" NavigateUrl="PaymentProcessing.aspx" BackColor="White">Manage Payments</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;

            <asp:HyperLink ID="hlReports" runat="server" NavigateUrl="Reports.aspx" BackColor="White">View Reports</asp:HyperLink>
        </div>
    </form>
</body>
</html>
