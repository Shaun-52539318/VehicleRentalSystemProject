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
    public partial class PaymentProcessing : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["VehicleRentalDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadActiveRentals();
                txtPaymentDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LoadPayments();
            }
        }

        private void LoadActiveRentals()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = @"SELECT ra.RentalID, CONCAT(c.Name, ' - ', v.Model, ' (RentalID: ', ra.RentalID, ')') AS RentalInfo 
                                 FROM RentalAgreements ra
                                 JOIN Customers c ON ra.CustomerID = c.CustomerID
                                 JOIN Vehicles v ON ra.VehicleID = v.VehicleID
                                 WHERE ra.Status = 'Active'
                                 ORDER BY c.Name";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlRentals.DataSource = dt;
                ddlRentals.DataValueField = "RentalID";
                ddlRentals.DataTextField = "RentalInfo";
                ddlRentals.DataBind();
                ddlRentals.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Rental--", "0"));
            }
        }

        private void LoadPayments()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "SELECT PaymentID, RentalID, PaymentDate, Amount, PaymentMethod FROM Payments ORDER BY PaymentDate DESC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvPayments.DataSource = dt;
                gvPayments.DataBind();
            }
        }

        protected void btnAddPayment_Click(object sender, EventArgs e)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            if (ddlRentals.SelectedValue == "0")
            {
                lblMessage.Text = "Please select a rental.";
                return;
            }

            DateTime paymentDate;
            if (!DateTime.TryParse(txtPaymentDate.Text, out paymentDate))
            {
                lblMessage.Text = "Invalid payment date.";
                return;
            }

            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount) || amount <= 0)
            {
                lblMessage.Text = "Amount must be a positive number.";
                return;
            }

            string paymentMethod = ddlPaymentMethod.SelectedValue;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string insertQuery = @"INSERT INTO Payments (RentalID, PaymentDate, Amount, PaymentMethod)
                                       VALUES (@RentalID, @PaymentDate, @Amount, @PaymentMethod)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@RentalID", ddlRentals.SelectedValue);
                cmd.Parameters.AddWithValue("@PaymentDate", paymentDate);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Payment recorded successfully.";
                    LoadPayments();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}
