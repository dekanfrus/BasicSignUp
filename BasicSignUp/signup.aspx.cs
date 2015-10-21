using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace BasicSignUp
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = (string)Session["Username"];
            string email = (string)Session["Email"];

            lblWelcome.Text = "Welcome " + userName + "!";
        }

        protected static bool passwordComplexity(string userPass)
        {
            return Regex.IsMatch(userPass, @"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*s).*$");
        }

        protected void btnSubmitInfo_Click(object sender, EventArgs e)
        {
            string userName = (string)Session["Username"];
            string email = (string)Session["Email"];
            string password = txtPassword.Text;
            bool complex = false;

            if (txtPassword.Text == txtPwConfirmRequire.Text)
            {
                lblPasswordRequire.Visible = false;
                lblPasswordConfirmRequire.Visible = false;
            }

            if (!passwordComplexity(password))
            {
                lblPasswordRequire.Visible = true;
                lblPasswordRequire.Text = "Password does not meet complexity requirements.";
            }

            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtCountry.Text == "" || txtPassword.Text == "" || txtPwConfirmRequire.Text == "")
            {
                if (txtFirstName.Text == " " || txtFirstName.Text == "")
                {
                    lblFirstNameRequire.Visible = true;
                    lblFirstNameRequire.Text = "This field is required";
                }
                else if (txtFirstName.Text != "")
                {
                    lblFirstNameRequire.Visible = false;
                }

                if (txtLastName.Text == " " || txtLastName.Text == "")
                {
                    lblLastNameRequire.Visible = true;
                    lblLastNameRequire.Text = "This field is required";
                }
                else if (txtLastName.Text != "")
                {
                    lblLastNameRequire.Visible = false;
                }

                if (txtCountry.Text == " " || txtCountry.Text == "")
                {
                    lblCountryRequire.Visible = true;
                    lblCountryRequire.Text = "This field is required";
                }
                else if (txtCountry.Text != "")
                {
                    lblCountryRequire.Visible = false;
                }

                if (txtPassword.Text == " " || txtPwConfirmRequire.Text == "")
                {
                    lblPasswordRequire.Visible = true;
                    lblPasswordRequire.Text = "This field is required";
                }
                else if (txtPassword.Text != "")
                {
                    lblPasswordRequire.Visible = false;
                }

                if (txtPwConfirmRequire.Text == " " || txtPwConfirmRequire.Text == "")
                {
                    lblPasswordConfirmRequire.Visible = true;
                    lblPasswordConfirmRequire.Text = "This field is required";
                }
                else if (txtPwConfirmRequire.Text != "")
                {
                    lblPasswordConfirmRequire.Visible = false;
                }                
            }
            else if (txtPassword.Text != txtPwConfirmRequire.Text)
            {
                lblPasswordRequire.Visible = true;
                lblPasswordRequire.Text = "Passwords must match!";
                lblPasswordConfirmRequire.Visible = true;
                lblPasswordConfirmRequire.Text = "Passwords must match!";
            }

            else
            {
                // Setup the SQL connection and parameterize the command input to prevent SQL injection
                SqlConnection signup = new SqlConnection(SqlDataSource1.ConnectionString);
                SqlCommand newUser = new SqlCommand("INSERT INTO [User] (User_UserName, User_Password, User_Email, User_FName, User_LName, User_Country) VALUES (@username, @password, @email, @fName, @lName, @country)", signup);
                newUser.Parameters.AddWithValue("@username", userName);
                newUser.Parameters.AddWithValue("@password", txtPassword.Text);
                newUser.Parameters.AddWithValue("@email", email);
                newUser.Parameters.AddWithValue("@fName", txtFirstName.Text);
                newUser.Parameters.AddWithValue("@lName", txtLastName.Text);
                newUser.Parameters.AddWithValue("@country", txtCountry.Text);
             

                try
                {
                   signup.Open();
                   newUser.ExecuteNonQuery();

                    Response.Redirect("/signupSuccess.aspx");
                }

                catch(Exception error)
                {
                    txtError.Visible = true;
                    txtError.Text = error.Message;
                }
                finally
                {
                    signup.Close();
                }

            }

        }
    }
}