using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace VehicleRental
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadReport();
        }

        private void LoadReport()
        {
            var connStr = ConfigurationManager.ConnectionStrings["VehicleRentalDB"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = @"
                    SELECT c.Name AS CustomerName, v.Model AS VehicleModel, ra.StartDate, ra.EndDate, ra.TotalCost
                    FROM RentalAgreements ra
                    JOIN Customers c ON ra.CustomerID = c.CustomerID
                    JOIN Vehicles v ON ra.VehicleID = v.VehicleID
                    WHERE ra.Status = 'Completed' ORDER BY ra.EndDate DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "RentalData");

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/RentalSummaryReport.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("RentalDataSet", ds.Tables["RentalData"]));
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}
