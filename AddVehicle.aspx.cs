using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace VehicleRental
{
    public partial class AddVehicle : System.Web.UI.Page
    {
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtModel.Text) || string.IsNullOrWhiteSpace(txtYear.Text))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please enter Model and Year.";
                return;
            }

            int year;
            if (!int.TryParse(txtYear.Text.Trim(), out year))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Year must be a valid number.";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["VehicleRentalDB"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "INSERT INTO Vehicles (Model, Year, AvailabilityStatus) VALUES (@Model, @Year, @Status)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Model", txtModel.Text.Trim());
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Vehicle added successfully.";
                    ClearFields();
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }

        private void ClearFields()
        {
            txtModel.Text = "";
            txtYear.Text = "";
            ddlStatus.SelectedIndex = 0;
        }
    }
}
