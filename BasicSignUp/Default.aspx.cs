using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicSignUp
{
    public partial class Default : System.Web.UI.Page
    {
        static string userName, email;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected bool userSearch(string userName)
        {
            SqlConnection signup = new SqlConnection(SqlDataSource1.ConnectionString);
            SqlCommand user = new SqlCommand();

            user.CommandType = System.Data.CommandType.Text;
            user.CommandText = ("SELECT * FROM User WHERE User_Username='" + userName + "';");
            user.Connection = signup;

            signup.Open();
            try
            {
                user.ExecuteNonQuery();
                return true;
            }

            catch
            {
                return false;
            }

            finally
            {
                signup.Close();
            }
        }

        protected bool emailSearch(string userEmail)
        {
            SqlConnection signup = new SqlConnection(SqlDataSource1.ConnectionString);
            SqlCommand email = new SqlCommand();

            email.CommandType = System.Data.CommandType.Text;
            email.CommandText = ("SELECT * FROM User WHERE User_Email='" + userEmail + "';");
            email.Connection = signup;

            signup.Open();
            try
            {
                email.ExecuteNonQuery();
                return true;
            }

            catch
            {
                return false;
            }

            finally
            {
                signup.Close();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            userName = txtUserName.Text;
            email = txtEmail.Text;

            bool userExists, emailExists;
            
            if (txtUserName.Text == "" || txtEmail.Text == "")
            {
                if (txtUserName.Text == "") flagUserName.Visible = true; else flagUserName.Visible = false;
                if (txtEmail.Text == "") flagEmail.Visible = true; else flagEmail.Visible = false;
                Response.Redirect(Request.RawUrl);
            }

            userExists = userSearch(userName);
            emailExists = emailSearch(email);

            if (userExists == true)
            {
                flagUserName.Text = "That username already exists, please choose a different one.";
                flagUserName.Visible = true;
            }
            
            else if (emailExists == true)
            {
                flagEmail.Text = "That email is already in use, please use a different one.";
                flagEmail.Visible = true;
            }
            else
            {
                Session["UserName"] = txtUserName.Text;
                Session["Email"] = txtEmail.Text;
                Response.Redirect("/signup.aspx");
            }
        }
    }
}