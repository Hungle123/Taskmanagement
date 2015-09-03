using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskProject.Account
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Session.RemoveAll();
                messageLogout.Text = "Logout successfully";
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}