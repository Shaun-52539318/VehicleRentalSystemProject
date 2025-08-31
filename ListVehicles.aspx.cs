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
    public partial class ListVehicles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadVehicles();
        }

        private void LoadVehicles()
        {
            string cs = ConfigurationManager.ConnectionStrings["VehicleRentalDB"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                string query = "SELECT VehicleID, Model, Year, AvailabilityStatus FROM Vehicles";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvVehicles.DataSource = dt;
                gvVehicles.DataBind();
            }
        }

        protected void gvVehicles_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvVehicles.EditIndex = e.NewEditIndex;
            LoadVehicles();
        }

        protected void gvVehicles_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvVehicles.EditIndex = -1;
            LoadVehicles();
        }

        protected void gvVehicles_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int vehicleId = Convert.ToInt32(gvVehicles.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvVehicles.Rows[e.RowIndex];

            string model = ((System.Web.UI.WebControls.TextBox)row.Cells[1].Controls[0]).Text.Trim();
            int year = int.Parse(((System.Web.UI.WebControls.TextBox)row.Cells[2].Controls[0]).Text.Trim());
            string availability = ((System.Web.UI.WebControls.TextBox)row.Cells[3].Controls[0]).Text.Trim();

            string cs = ConfigurationManager.ConnectionStrings["VehicleRentalDB"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                string query = "UPDATE Vehicles SET Model=@Model, Year=@Year, AvailabilityStatus=@Status WHERE VehicleID=@VehicleID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Status", availability);
                cmd.Parameters.AddWithValue("@VehicleID", vehicleId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            gvVehicles.EditIndex = -1;
            lblMessage.Text = "Vehicle updated successfully.";
            LoadVehicles();
        }

        protected void gvVehicles_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int vehicleId = Convert.ToInt32(gvVehicles.DataKeys[e.RowIndex].Value);
            string cs = ConfigurationManager.ConnectionStrings["VehicleRentalDB"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    // Find all rental agreements for this vehicle
                    string getRentalIdsQuery = "SELECT RentalID FROM RentalAgreements WHERE VehicleID=@VehicleID";
                    MySqlCommand getRentalIdsCmd = new MySqlCommand(getRentalIdsQuery, conn);
                    getRentalIdsCmd.Parameters.AddWithValue("@VehicleID", vehicleId);
                    var rentalIds = new List<int>();
                    using (var reader = getRentalIdsCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rentalIds.Add(reader.GetInt32(0));
                        }
                    }
                    // Delete payments for each rental agreement
                    foreach (var rentalId in rentalIds)
                    {
                        string deletePaymentsQuery = "DELETE FROM Payments WHERE RentalID=@RentalID";
                        MySqlCommand deletePaymentsCmd = new MySqlCommand(deletePaymentsQuery, conn);
                        deletePaymentsCmd.Parameters.AddWithValue("@RentalID", rentalId);
                        deletePaymentsCmd.ExecuteNonQuery();
                    }
                    // Delete rental agreements for the vehicle
                    string deleteAgreementsQuery = "DELETE FROM RentalAgreements WHERE VehicleID=@VehicleID";
                    MySqlCommand deleteAgreementsCmd = new MySqlCommand(deleteAgreementsQuery, conn);
                    deleteAgreementsCmd.Parameters.AddWithValue("@VehicleID", vehicleId);
                    deleteAgreementsCmd.ExecuteNonQuery();
                    // Delete the vehicle
                    string query = "DELETE FROM Vehicles WHERE VehicleID=@VehicleID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@VehicleID", vehicleId);
                    cmd.ExecuteNonQuery();
                }
                lblMessage.Text = "Vehicle and all related rental agreements and payments deleted successfully.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error deleting vehicle: " + ex.Message;
            }
            LoadVehicles();
        }
    }
}
