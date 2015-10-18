using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicSignUp
{
    public partial class signup : System.Web.UI.Page
    {
        static string firstName, lastName, countryName, password, passwordConfirm;

        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = (string)Session["Username"];
            string email = (string)Session["Email"];

            lblWelcome.Text = "Welcome " + userName + "!";
        }

        protected void btnSubmitInfo_Click(object sender, EventArgs e)
        {
            firstName = txtFirstName.Text;
            lastName = txtLastName.Text;
            countryName = txtCountry.Text;
            password = txtPassword.Text;
            passwordConfirm = txtPwConfirmRequire.Text;

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

            else if (txtPassword.Text == txtPwConfirmRequire.Text)
            {
                lblPasswordRequire.Visible = false;
                lblPasswordConfirmRequire.Visible = false;
            }

            else
            {
                try
                {

                }

                catch
                {

                }


                // Response.Redirect("/signupSuccess.aspx");
            }

        }
    }
}