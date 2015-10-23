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
        int userExists, emailExists;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected int userSearch(string userName)
        {
            SqlConnection signup = new SqlConnection(SqlDataSource1.ConnectionString);
            SqlCommand user = new SqlCommand();

            user.CommandType = System.Data.CommandType.Text;
            user.CommandText = ("SELECT * FROM [User] WHERE User_Username='" + userName + "';");
            user.Connection = signup;

            signup.Open();
            try
            {
                userExists = user.ExecuteNonQuery();
                return userExists;
            }

            catch(Exception error)
            {
                txtError2.Text = error.Message;
                txtError2.Visible = true;
                return userExists;
            }

            finally
            {
                signup.Close();
            }
        }

        protected int emailSearch(string userEmail)
        {
            SqlConnection signup = new SqlConnection(SqlDataSource1.ConnectionString);
            SqlCommand email = new SqlCommand();

            email.CommandType = System.Data.CommandType.Text;
            email.CommandText = ("SELECT * FROM [User] WHERE User_Email='" + userEmail + "';");
            email.Connection = signup;

            signup.Open();
            try
            {
                email.ExecuteNonQuery();
                return emailExists;
            }

            catch (Exception error)
            {
                txtError2.Text = error.Message;
                txtError2.Visible = true;
                return emailExists;
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

            int userExists, emailExists;
            
            if (txtUserName.Text == "" || txtEmail.Text == "")
            {
                if (txtUserName.Text == "") flagUserName.Visible = true; else flagUserName.Visible = false;
                if (txtEmail.Text == "") flagEmail.Visible = true; else flagEmail.Visible = false;
                Response.Redirect(Request.RawUrl);
            }

            userExists = userSearch(userName);
            emailExists = emailSearch(email);

            if (userExists == 1)
            {
                flagUserName.Text = "* That username already exists, please choose a different one.";
                flagUserName.Visible = true;
            }
            
            else if (emailExists == 1)
            {
                flagEmail.Text = "* That email is already in use, please use a different one.";
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