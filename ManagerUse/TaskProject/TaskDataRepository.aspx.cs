using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ManagerUse;


namespace TaskProject
{

    public partial class TaskDataRepository : System.Web.UI.Page
    {
        public TaskRepository DataTask;

        protected void Page_Load(object sender, EventArgs e)
        {
           
             if (!Page.IsPostBack)
            {
                if (Session["Role"] != null)
                {
                    var sessionRole = (int)Session["Role"];
                    if (sessionRole == 1)
                    {
                        BindDataTaskToGridView();
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
        /// Insert infomation Task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnTask_OnClick(object sender, EventArgs e)
        {
            try
            {
                ltError.Text = string.Empty;
                DataTask = TaskRepository.GetIntance();
                var name = txtName.Text.Trim();
                var description = txtDescription.Text.Trim();
                var type = Convert.ToInt32(ddlType.SelectedValue);
                var state = Convert.ToInt32(ddlState.SelectedValue);
                var complate = Convert.ToInt32(txtComplate.Text.Trim());
                DataTask.InsertTask(name, description, type, state, complate);
                gvTaskRepository.EditIndex = -1;
                BindDataTaskToGridView();
                txtName.Text = "";
                txtComplate.Text = "";
                txtDescription.Text = "";
                ddlState.SelectedValue = "none";
                ddlType.SelectedValue = "none";
                ltError.Text = "Insert user successfully";
            }
            catch (Exception ex)
            {
                ltError.Text = ex.Message;
            }
        }

        /// <summary>
        /// Edit infomation for task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvTaskRepository_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                ltError.Text = string.Empty;
                gvTaskRepository.EditIndex = e.NewEditIndex;
                BindDataTaskToGridView();
            }
            catch (Exception ex)
            {
                ltError.Text = ex.Message;
            }
        }


        /// <summary>
        /// Cancel edit infomation for task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvTaskRepository_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                ltError.Text = string.Empty;
                gvTaskRepository.EditIndex = -1;
                BindDataTaskToGridView();
            }
            catch (Exception ex)
            {
                ltError.Text = ex.Message;
            }
        }

        /// <summary>
        ///   Update information for task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvTaskRepository_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                ltError.Text = string.Empty;
                DataTask = TaskRepository.GetIntance();
                var row = gvTaskRepository.Rows[e.RowIndex];
                var lbTaskId = (Label)row.FindControl("lbTaskID");
                var id = Convert.ToInt32(lbTaskId.Text.Trim());
                var name = ((TextBox)(row.Cells[1].Controls[0])).Text;
                var description = ((TextBox)(row.Cells[2].Controls[0])).Text;
                var typeTask = ((TextBox)(row.Cells[3].Controls[0])).Text;
                var type = Convert.ToInt32(typeTask);
                var stateTask = ((TextBox)(row.Cells[4].Controls[0])).Text;
                var state = Convert.ToInt32(stateTask);
                var complateTask = ((TextBox)(row.Cells[5].Controls[0])).Text;
                var complate = Convert.ToInt32(complateTask);
                DataTask.UpdateTask(id, name, description, type, state, complate);
                gvTaskRepository.EditIndex = -1;
                BindDataTaskToGridView();
                ltError.Text = "Update task successfully";
            }
            catch (Exception ex)
            {
                ltError.Text = ex.Message;
            }
        }


        /// <summary>
        /// Delete information for task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvTaskRepository_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ltError.Text = string.Empty;
                DataTask = TaskRepository.GetIntance();
                var row = gvTaskRepository.Rows[e.RowIndex];
                var lbTaskId = (Label)row.FindControl("lbTaskID");
                var id = Convert.ToInt32(lbTaskId.Text.Trim());
                DataTask.DeleteTask(id);
                gvTaskRepository.EditIndex = -1;
                BindDataTaskToGridView();
                ltError.Text = "Delete task Successfully";
            }
            catch (Exception ex)
            {
                ltError.Text = ex.Message;
            }
        }

        /// <summary>
        /// view information for task
        /// </summary>
        public void BindDataTaskToGridView()
        {
            try
            {
                ltError.Text = string.Empty;
                DataTask = TaskRepository.GetIntance();
                DataTask.ConnectDatabase();
                var viewCommand = new SqlCommand("dbo.selectTask", DataTask.DbConnect)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var dataAdapter = new SqlDataAdapter(viewCommand);
                var dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                gvTaskRepository.DataSource = dataSet;
                gvTaskRepository.DataBind();
                ltError.Text = "View task Successfully";
            }
            catch (Exception ex)
            {
                ltError.Text = ex.Message;
            }
        }

        protected void gvTaskRepository_OnSorting(object sender, GridViewSortEventArgs e)
        {

        }
    }
}