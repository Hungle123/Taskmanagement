using System;
using System.Web.UI;
using ManagerUse;


namespace TaskProject.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMessage.Text = string.Empty;
                var registerUser = UserRepository.GetInstance();
                var userName = UserName.Text;
                var email = Email.Text;
                var pass = Password.Text;
                var address = Address.Text;
                if (registerUser.CheckEmail(email) == false)
                {
                    registerUser.InsertUser(userName, email, pass, address, 2);
                    UserName.Text = "";
                    Email.Text = "";
                    Password.Text = "";
                    ConfirmPassword.Text = "";
                    Address.Text = "";
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {
                    ErrorMessage.Text = "Email already exists or have a used.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }

        }
    }
}