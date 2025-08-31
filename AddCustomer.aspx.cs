using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VehicleRental
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Name is required.";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["VehicleRentalDB"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "INSERT INTO Customers (Name, ContactDetails, DriverLicenseNumber, Address) " +
                               "VALUES (@Name, @Contact, @DriverLicense, @Address)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                cmd.Parameters.AddWithValue("@DriverLicense", txtDriverLicense.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Customer added successfully.";
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
            txtName.Text = "";
            txtContact.Text = "";
            txtDriverLicense.Text = "";
            txtAddress.Text = "";
        }
    }
}
