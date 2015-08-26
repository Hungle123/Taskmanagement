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
                BindDataToGridView();
            }
        }

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

        protected void InfomationUser_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                ltError.Text = string.Empty;
                DataUser = UserRepository.GetInstance();
                var row = gvInfomationUser.Rows[e.RowIndex];
                var hdnUserId = (HiddenField)row.FindControl("hdnUserID");
                var id = Convert.ToInt32(hdnUserId.Value);
                var name = ((TextBox)(row.Cells[1].Controls[0])).Text;
                var email = ((TextBox)(row.Cells[2].Controls[0])).Text;
                DataUser.UpdateUser(id, name, email);
                gvInfomationUser.EditIndex = -1;
                BindDataToGridView();
                ltError.Text = "Update Successfully";
            }
            catch (Exception ex)
            {
                ltError.Text = ex.Message;
            }
        }

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
                var hdnUserId = (HiddenField)row.FindControl("hdnUserID");
                var id = Convert.ToInt32(hdnUserId.Value);
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

        protected void btnAddRow_OnClick(object sender, EventArgs e)
        {
            try
            {
                ltError.Text = string.Empty;
                DataUser = UserRepository.GetInstance();
                var name = txtName.Text.Trim();
                var email = txtEmail.Text.Trim();
                DataUser.InsertUser(name, email);
                gvInfomationUser.EditIndex = -1;
                BindDataToGridView();
                ltError.Text = "Insert user successfully";
            }
            catch (Exception ex)
            {
                ltError.Text = ex.Message;
            }
        }
    }
}