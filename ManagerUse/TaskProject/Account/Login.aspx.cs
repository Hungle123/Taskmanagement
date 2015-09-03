using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using ManagerUse;

namespace TaskProject.Account
{
    public partial class Login : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn(object sender, EventArgs e)
        {
            var id = 0;
            var name = "";
            var role = 0;
            var loginFrom = new DbConnection();
            loginFrom.ConnectDatabase();
            var loginCommand = new SqlCommand("dbo.loginForm", loginFrom.DbConnect)
            {
                CommandType = CommandType.StoredProcedure
            };
            loginCommand.Parameters.AddWithValue("email", Email.Text);
            loginCommand.Parameters.AddWithValue("password", Password.Text);

            var reader = loginCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["UserID"]);
                    name = (Convert.ToString(reader["Name"])).Trim();
                    role = Convert.ToInt32(reader["RoleID"]);
                }
                Session["UserID"] = id;
                Session["Name"] = name;
                Session["Role"] = role;
                Session["Email"] = Email.Text;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}