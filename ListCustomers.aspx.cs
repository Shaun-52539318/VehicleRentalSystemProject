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
    public partial class ListCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadCustomers();
        }

        private void LoadCustomers()
        {
            string connStr = ConfigurationManager.ConnectionStrings["VehicleRentalDB"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "SELECT CustomerID, Name, ContactDetails, DriverLicenseNumber, Address FROM Customers";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvCustomers.DataSource = dt;
                    gvCustomers.DataBind();
                }
            }
        }

        protected void gvCustomers_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvCustomers.EditIndex = e.NewEditIndex;
            LoadCustomers();
        }

        protected void gvCustomers_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvCustomers.EditIndex = -1;
            LoadCustomers();
        }

        protected void gvCustomers_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int customerId = Convert.ToInt32(gvCustomers.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvCustomers.Rows[e.RowIndex];
            string name = ((System.Web.UI.WebControls.TextBox)row.Cells[1].Controls[0]).Text.Trim();
            string contact = ((System.Web.UI.WebControls.TextBox)row.Cells[2].Controls[0]).Text.Trim();
            string driverLicense = ((System.Web.UI.WebControls.TextBox)row.Cells[3].Controls[0]).Text.Trim();
            string address = ((System.Web.UI.WebControls.TextBox)row.Cells[4].Controls[0]).Text.Trim();

            string connStr = ConfigurationManager.ConnectionStrings["VehicleRentalDB"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = @"UPDATE Customers SET Name=@Name, ContactDetails=@Contact, 
                                DriverLicenseNumber=@DriverLicense, Address=@Address WHERE CustomerID=@CustomerID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@DriverLicense", driverLicense);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            gvCustomers.EditIndex = -1;
            lblMessage.Text = "Customer updated successfully.";
            LoadCustomers();
        }

        protected void gvCustomers_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int customerId = Convert.ToInt32(gvCustomers.DataKeys[e.RowIndex].Value);
            string connStr = ConfigurationManager.ConnectionStrings["VehicleRentalDB"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    // Check for related rental agreements
                    string checkQuery = "SELECT COUNT(*) FROM RentalAgreements WHERE CustomerID=@CustomerID";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@CustomerID", customerId);
                    int relatedCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (relatedCount > 0)
                    {
                        lblMessage.Text = "Cannot delete customer: There are rental agreements linked to this customer.";
                        return;
                    }
                    // Proceed with delete
                    string query = "DELETE FROM Customers WHERE CustomerID=@CustomerID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.ExecuteNonQuery();
                }
                lblMessage.Text = "Customer deleted successfully.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error deleting customer: " + ex.Message;
            }
            LoadCustomers();
        }
    }
}
