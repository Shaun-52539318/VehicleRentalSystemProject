<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="VehicleRental.Reports" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<html>
<head>
    <title>Reports</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />  <!-- Added meta tag for browser compatibility -->
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
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="700px" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="Default.aspx" BackColor="Black" style="font-size: xx-large">Home</asp:HyperLink>
    </form>
</body>
</html>