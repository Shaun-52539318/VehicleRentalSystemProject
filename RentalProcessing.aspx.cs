using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace VehicleRental
{
    public partial class RentalProcessing : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["VehicleRentalDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomers();
                LoadAvailableVehicles();
                LoadActiveRentals();
                txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtReturnDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void LoadCustomers()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "SELECT CustomerID, Name FROM Customers ORDER BY Name";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                ddlCustomers.DataSource = dt;
                ddlCustomers.DataValueField = "CustomerID";
                ddlCustomers.DataTextField = "Name";
                ddlCustomers.DataBind();

                ddlCustomers.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Customer--", "0"));
            }
        }

        private void LoadAvailableVehicles()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                // Only available vehicles
                string query = "SELECT VehicleID, Model FROM Vehicles WHERE AvailabilityStatus = 'Available' ORDER BY Model";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                ddlVehicles.DataSource = dt;
                ddlVehicles.DataValueField = "VehicleID";
                ddlVehicles.DataTextField = "Model";
                ddlVehicles.DataBind();

                ddlVehicles.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Vehicle--", "0"));
            }
        }

        private void LoadActiveRentals()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = @"SELECT RentalID, CONCAT(Name, ' - ', Model, ' (Start: ', StartDate, ')') AS RentalInfo 
                                 FROM RentalAgreements ra
                                 JOIN Customers c ON ra.CustomerID = c.CustomerID
                                 JOIN Vehicles v ON ra.VehicleID = v.VehicleID
                                 WHERE ra.Status = 'Active' ORDER BY StartDate";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                ddlActiveRentals.DataSource = dt;
                ddlActiveRentals.DataValueField = "RentalID";
                ddlActiveRentals.DataTextField = "RentalInfo";
                ddlActiveRentals.DataBind();

                ddlActiveRentals.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Rental--", "0"));
            }
        }

        protected void btnCreateRental_Click(object sender, EventArgs e)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;

            if (ddlCustomers.SelectedValue == "0" || ddlVehicles.SelectedValue == "0")
            {
                lblMessage.Text = "Please select a customer and a vehicle.";
                return;
            }

            DateTime startDate, endDate;
            if (!DateTime.TryParse(txtStartDate.Text, out startDate))
            {
                lblMessage.Text = "Invalid start date.";
                return;
            }
            if (!DateTime.TryParse(txtEndDate.Text, out endDate))
            {
                lblMessage.Text = "Invalid end date.";
                return;
            }
            if (endDate < startDate)
            {
                lblMessage.Text = "End date cannot be before start date.";
                return;
            }

            decimal rentalRatePerDay = 100m; // Assume a fixed daily rate or query vehicle for rate

            int days = (endDate - startDate).Days + 1;
            decimal totalCost = days * rentalRatePerDay;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                // Insert rental agreement
                string insertQuery = @"INSERT INTO RentalAgreements (CustomerID, VehicleID, StartDate, EndDate, TotalCost, Status)
                                       VALUES (@CustomerID, @VehicleID, @StartDate, @EndDate, @TotalCost, 'Active')";
                MySqlCommand cmdInsert = new MySqlCommand(insertQuery, conn);
                cmdInsert.Parameters.AddWithValue("@CustomerID", ddlCustomers.SelectedValue);
                cmdInsert.Parameters.AddWithValue("@VehicleID", ddlVehicles.SelectedValue);
                cmdInsert.Parameters.AddWithValue("@StartDate", startDate);
                cmdInsert.Parameters.AddWithValue("@EndDate", endDate);
                cmdInsert.Parameters.AddWithValue("@TotalCost", totalCost);
                cmdInsert.ExecuteNonQuery();

                // Update vehicle availability to 'Rented'
                string updateVehicleQuery = "UPDATE Vehicles SET AvailabilityStatus = 'Rented' WHERE VehicleID = @VehicleID";
                MySqlCommand cmdUpdateVehicle = new MySqlCommand(updateVehicleQuery, conn);
                cmdUpdateVehicle.Parameters.AddWithValue("@VehicleID", ddlVehicles.SelectedValue);
                cmdUpdateVehicle.ExecuteNonQuery();
            }

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Rental created successfully! Total cost: R " + totalCost.ToString("F2");

            // Refresh vehicle and rentals dropdowns
            LoadAvailableVehicles();
            LoadActiveRentals();
        }

        protected void btnReturnVehicle_Click(object sender, EventArgs e)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;

            if (ddlActiveRentals.SelectedValue == "0")
            {
                lblMessage.Text = "Please select an active rental to return.";
                return;
            }

            DateTime returnDate;
            if (!DateTime.TryParse(txtReturnDate.Text, out returnDate))
            {
                lblMessage.Text = "Invalid return date.";
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                // Get rental info (StartDate, VehicleID)
                string selectQuery = @"SELECT StartDate, VehicleID FROM RentalAgreements WHERE RentalID = @RentalID";
                MySqlCommand cmdSelect = new MySqlCommand(selectQuery, conn);
                cmdSelect.Parameters.AddWithValue("@RentalID", ddlActiveRentals.SelectedValue);
                MySqlDataReader reader = cmdSelect.ExecuteReader();

                if (!reader.Read())
                {
                    lblMessage.Text = "Rental not found.";
                    return;
                }

                DateTime startDate = reader.GetDateTime("StartDate");
                int vehicleId = reader.GetInt32("VehicleID");
                reader.Close();

                if (returnDate < startDate)
                {
                    lblMessage.Text = "Return date cannot be before start date.";
                    return;
                }

                // Calculate new total cost if returned late/early (optional)
                decimal rentalRatePerDay = 100m;
                int rentalDays = (returnDate - startDate).Days + 1;
                if (rentalDays < 1)
                    rentalDays = 1;
                decimal totalCost = rentalDays * rentalRatePerDay;

                // Update rental agreement - mark as completed, update end date and total cost
                string updateRental = @"UPDATE RentalAgreements 
                                        SET EndDate = @ReturnDate, TotalCost = @TotalCost, Status = 'Completed' 
                                        WHERE RentalID = @RentalID";
                MySqlCommand cmdUpdateRental = new MySqlCommand(updateRental, conn);
                cmdUpdateRental.Parameters.AddWithValue("@ReturnDate", returnDate);
                cmdUpdateRental.Parameters.AddWithValue("@TotalCost", totalCost);
                cmdUpdateRental.Parameters.AddWithValue("@RentalID", ddlActiveRentals.SelectedValue);
                cmdUpdateRental.ExecuteNonQuery();

                // Update vehicle availability to 'Available'
                string updateVehicle = "UPDATE Vehicles SET AvailabilityStatus = 'Available' WHERE VehicleID = @VehicleID";
                MySqlCommand cmdUpdateVehicle = new MySqlCommand(updateVehicle, conn);
                cmdUpdateVehicle.Parameters.AddWithValue("@VehicleID", vehicleId);
                cmdUpdateVehicle.ExecuteNonQuery();
            }

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Vehicle returned successfully!";

            // Refresh dropdowns
            LoadAvailableVehicles();
            LoadActiveRentals();
        }
    }
}
