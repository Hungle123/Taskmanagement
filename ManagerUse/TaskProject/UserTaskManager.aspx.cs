using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ManagerUse;

namespace TaskProject
{
    public partial class UserTaskManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Role"] != null)
                {
                    var sessionRole = (int)Session["Role"];
                    if (sessionRole == 1)
                    {
                        ViewUserNameDropdownList();
                        ViewTaskNameDropdownList();
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
        ///   Insert for usertask managerment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUserTask_OnClick(object sender, EventArgs e)
        {
            try
            {
                ltMessage.Text = string.Empty;
                var dataManager = new UserTasks();
                var userId = Convert.ToInt32(ddlUserName.SelectedValue);
                var taskId = Convert.ToInt32(ddlTaskName.SelectedValue);
                dataManager.InsertUserTask(userId, taskId);
                gvUserTask.EditIndex = -1;
                ltMessage.Text = "Insert Successflly !";
                ddlUserName.SelectedValue = "none";
                ddlTaskName.SelectedValue = "none";
                BindDataToGridView();
            }
            catch (Exception ex)
            {
                ltMessage.Text = ex.Message;
            }
        }

        /// <summary>
        /// View User Name for Dropdown list
        /// </summary>
        public void ViewUserNameDropdownList()
        {
            var listUserName = new DbConnection();
            listUserName.ConnectDatabase();
            var viewCommand = new SqlCommand("dbo.selectUser", listUserName.DbConnect)
            {
                CommandType = CommandType.StoredProcedure
            };
            var dataAdapter = new SqlDataAdapter(viewCommand);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            ddlUserName.DataSource = dataSet;
            ddlUserName.DataTextField = "Name";
            ddlUserName.DataValueField = "UserID";
            ddlUserName.DataBind();
            ddlUserName.Items.Insert(0, new ListItem("-- select --", "none"));
        }

        /// <summary>
        ///   View task name for Dropdown list
        /// </summary>
        public void ViewTaskNameDropdownList()
        {
            var listTaskName = new DbConnection();
            listTaskName.ConnectDatabase();
            var viewCommand = new SqlCommand("dbo.selectTask", listTaskName.DbConnect)
            {
                CommandType = CommandType.StoredProcedure
            };
            var dataAdapter = new SqlDataAdapter(viewCommand);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            ddlTaskName.DataSource = dataSet;
            ddlTaskName.DataTextField = "Name";
            ddlTaskName.DataValueField = "TaskID";
            ddlTaskName.DataBind();
            ddlTaskName.Items.Insert(0, new ListItem("-- select --", "none"));
        }

        /// <summary>
        /// View infomation for UserTask managerment
        /// </summary>
        public void BindDataToGridView()
        {
            try
            {
                var dataManager = new DbConnection();
                dataManager.ConnectDatabase();
                var viewCommand = new SqlCommand("dbo.selectUserTask", dataManager.DbConnect)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var dataAdapter = new SqlDataAdapter(viewCommand);
                var dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                gvUserTask.DataSource = dataSet;
                gvUserTask.DataBind();
                ltMessage.Text = "View data compate !";
            }
            catch (Exception ex)
            {
                ltMessage.Text = ex.Message;
            }
        }

        /// <summary>
        /// Edit information for UserTask Manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvUserTask_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                ltMessage.Text = string.Empty;
                gvUserTask.EditIndex = e.NewEditIndex;
                BindDataToGridView();

            }
            catch (Exception ex)
            {
                ltMessage.Text = ex.Message;
            }
        }


        /// <summary>
        /// Cancel for edit usertask managerment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvUserTask_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                ltMessage.Text = string.Empty;
                gvUserTask.EditIndex = -1;
                BindDataToGridView();
            }
            catch (Exception ex)
            {
                ltMessage.Text = ex.Message;
            }
        }

        /// <summary>
        /// Update for user task managerment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvUserTask_OnRowUpdating(object sender, GridViewUpdateEventArgs gridViewUpdateEventArgs)
        {
            try
            {
                ltMessage.Text = string.Empty;
              //  var dataManager = new UserTasks();


            }
            catch (Exception ex)
            {
                ltMessage.Text = ex.Message;
            }
        }

        /// <summary>
        /// Delete row user task manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvUserTask_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ltMessage.Text = string.Empty;
                var dataManager = new UserTasks();
                var row = gvUserTask.Rows[e.RowIndex];
                var lbUserTask = (Label)row.FindControl("lbUserTask");
                var id = Convert.ToInt32(lbUserTask.Text);
                dataManager.DeleteUserTask(id);
                BindDataToGridView();
                ltMessage.Text = "Delete Successflly!";
            }
            catch (Exception ex)
            {
                ltMessage.Text = ex.Message;
            }
        }

        /// <summary>
        /// View userID, TaskID over Dropdownlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvUserTask_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            var dataUser = new DbConnection();
            dataUser.ConnectDatabase();
            if (e.Row.RowType == DataControlRowType.DataRow && gvUserTask.EditIndex == e.Row.RowIndex)
            {
                var ddlUserId = (DropDownList)e.Row.FindControl("ddlUser_ID");
                var viewUser = new SqlCommand("select distinct UserID from Users", dataUser.DbConnect);
                var dataAdapterUser = new SqlDataAdapter(viewUser);
                var dataSetUser = new DataSet();
                dataAdapterUser.Fill(dataSetUser);
                ddlUserId.DataSource = dataSetUser;
                ddlUserId.DataTextField = "UserID";
                ddlUserId.DataValueField = "UserID";
                ddlUserId.DataBind();

                var ddlTaskId = (DropDownList)e.Row.FindControl("ddlTask_ID");
                var viewTask = new SqlCommand("select distinct TaskID from Tasks", dataUser.DbConnect);
                var dataAdapterTask = new SqlDataAdapter(viewTask);
                var dataSetTask = new DataSet();
                dataAdapterTask.Fill(dataSetTask);
                ddlTaskId.DataSource = dataSetTask;
                ddlTaskId.DataTextField = "TaskID";
                ddlTaskId.DataValueField = "TaskID";
                ddlTaskId.DataBind();
            }
        }

        protected void ddlUserID_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var ddlUserId = (DropDownList)sender;
            var row = (GridViewRow)ddlUserId.NamingContainer;
            if (row != null)
            {
                if ((row.RowState = DataControlRowState.Edit) > 0)
                {

                }
            }
        }

        protected void gvUserTask_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUserTask.PageIndex = e.NewPageIndex;
            gvUserTask.DataBind();
        }

        protected void ddlTaskID_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void ddlTask_ID_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}