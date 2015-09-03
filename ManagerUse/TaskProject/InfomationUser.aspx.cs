using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ManagerUse;

namespace TaskProject
{
    public partial class InfomationUser : System.Web.UI.Page
    {
        public UserRepository DataUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Role"] != null)
                {
                    var sessionRole = (int)Session["Role"];
                    if (sessionRole == 1)
                    {
                        BindDataToGridView();
                    }
                    else
                    {
                        Response.Redirect("~/404.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/404.aspx");
                }
            }
        }

        /// <summary>
        /// Edit infomation users
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InfomationUser_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                ltError.Text = string.Empty;
                gvInfomationUser.EditIndex = e.NewEditIndex;
                BindDataToGridView();
            }
            catch (Exception ex)
            {
                ltError.Text = ex.Message;
            }
        }

        /// <summary>
        /// Cencel edit information users
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InfomationUser_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                ltError.Text = string.Empty;
                gvInfomationUser.EditIndex = -1;
                BindDataToGridView();
            }
            catch (Exception ex)
            {
                ltError.Text = ex.Message;
            }
        }

        /// <summary>
        /// Update information Users
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InfomationUser_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                ltError.Text = string.Empty;
                DataUser = UserRepository.GetInstance();
                var row = gvInfomationUser.Rows[e.RowIndex];
                var lbUserId = (Label)row.FindControl("lbUserID");
                var id = Convert.ToInt32(lbUserId.Text);
                var name = ((TextBox)(row.Cells[1].Controls[0])).Text;
                var email = ((TextBox)(row.Cells[2].Controls[0])).Text;
                var password = ((TextBox)(row.Cells[3].Controls[0])).Text;
                var address = ((TextBox)(row.Cells[4].Controls[0])).Text;
                var roles = ((TextBox)(row.Cells[5].Controls[0])).Text;
                var role = Convert.ToInt32(roles);
                if (DataUser.CheckEmail(email) == false)
                {
                    DataUser.UpdateUser(id, name, email, password, address, role);
                    gvInfomationUser.EditIndex = -1;
                    BindDataToGridView();
                    ltError.Text = "Update Successfully";
                }
                else
                {
                    ltError.Text = "The email already exists or have a used";
                }
            }
            catch (Exception ex)
            {
                ltError.Text = ex.Message;
            }
        }

        /// <summary>
        /// Delete infomation users
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InfomationUser_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ltError.Text = string.Empty;
                DataUser = UserRepository.GetInstance();

                /**
                var dataKey = gvInfomationUser.DataKeys[e.RowIndex];
                if (dataKey == null) return;
                var id = int.Parse(dataKey.Value.ToString());
                 */
                var row = gvInfomationUser.Rows[e.RowIndex];
                var lbUserId = (Label)row.FindControl("lbUserID");
                var id = Convert.ToInt32(lbUserId.Text.Trim());
                DataUser.DeleteUser(id);
                gvInfomationUser.EditIndex = -1;
                BindDataToGridView();
                ltError.Text = "Delete  Successfully";
            }
            catch (Exception ex)
            {
                ltError.Text = ex.Message;
            }
        }

        /// <summary>
        /// View information list users
        /// </summary>
        public void BindDataToGridView()
        {
            try
            {
                ltError.Text = string.Empty;
                DataUser = UserRepository.GetInstance();
                DataUser.ConnectDatabase();
                var viewCommmand = new SqlCommand("dbo.selectUser", DataUser.DbConnect)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var dataAdapter = new SqlDataAdapter(viewCommmand);
                var dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                gvInfomationUser.DataSource = dataSet;
                gvInfomationUser.DataBind();
                ltError.Text = "View  user Successfully";
            }
            catch (Exception ex)
            {
                ltError.Text = ex.Message;
            }
        }

        /// <summary>
        /// Insert infomation for users
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddRow_OnClick(object sender, EventArgs e)
        {
            try
            {
                ltError.Text = string.Empty;
                DataUser = UserRepository.GetInstance();
                var name = txtName.Text.Trim();
                var email = txtEmail.Text.Trim();
                var password = txtPass.Text.Trim();
                var address = txtAddress.Text.Trim();
                var role = Convert.ToInt32(ddlRole.SelectedValue);
                if (DataUser.CheckEmail(email) == false)
                {
                    DataUser.InsertUser(name, email, password, address, role);
                    gvInfomationUser.EditIndex = -1;
                    BindDataToGridView();
                    txtEmail.Text = "";
                    txtName.Text = "";
                    txtAddress.Text = "";
                    txtPass.Text = "";
                    ddlRole.SelectedValue = "none";
                    ltError.Text = "Insert user successfully";
                }
                else
                {
                    ltError.Text = "Insert user not successfully";
                }
            }
            catch (Exception ex)
            {
                ltError.Text = ex.Message;
            }
        }

        protected void gvInfomationUser_OnSorting(object sender, GridViewSortEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void gvInfomationUser_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInfomationUser.PageIndex = e.NewPageIndex;
        }
    }
}