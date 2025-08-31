<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentProcessing.aspx.cs" Inherits="VehicleRental.PaymentProcessing" %>

<!DOCTYPE html>
<html>
<head><title>Payment Processing</title></head>
<body style="
    margin: 0;
    height: 100vh;
    background-position: center;
    background-image: url('Screenshot 2025-08-28 200420.png');
    background-repeat: no-repeat;
    background-size: cover;
">
<form id="form1" runat="server">
    <h2>Record Payment</h2>

    <asp:Label Text="Select Rental:" AssociatedControlID="ddlRentals" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlRentals" runat="server" /><br />
    <br />

    <asp:Label Text="Payment Date:" AssociatedControlID="txtPaymentDate" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtPaymentDate" runat="server" Text='<%# DateTime.Now.ToString("yyyy-MM-dd") %>' /><br />
    <br />

    <asp:Label Text="Amount:" AssociatedControlID="txtAmount" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtAmount" runat="server" /><br />
    <br />

    <asp:Label Text="Payment Method:" AssociatedControlID="ddlPaymentMethod" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlPaymentMethod" runat="server">
        <asp:ListItem Text="Cash" />
        <asp:ListItem Text="Credit Card" />
        <asp:ListItem Text="Bank Transfer" />
        <asp:ListItem Text="Mobile Payment" />
    </asp:DropDownList>
    <br />
    <br />
    <br />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:Button ID="btnAddPayment" runat="server" Text="Add Payment" OnClick="btnAddPayment_Click" /><br /><br />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" BackColor="White" /><br />

    <h2>Payment History</h2>
    <asp:GridView ID="gvPayments" runat="server" AutoGenerateColumns="False" BackColor="White">
        <Columns>
            <asp:BoundField DataField="PaymentID" HeaderText="Payment ID" />
            <asp:BoundField DataField="RentalID" HeaderText="Rental ID" />
            <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:C}" />
            <asp:BoundField DataField="PaymentMethod" HeaderText="Method" />
        </Columns>
    </asp:GridView>

    <br /><br />

    <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="Default.aspx" BackColor="White" Font-Size="XX-Large">Home</asp:HyperLink>
</form>
</body>
</html>
