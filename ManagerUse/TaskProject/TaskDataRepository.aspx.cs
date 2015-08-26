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
                BindDataTaskToGridView();
        }

        protected void btnTask_OnClick(object sender, EventArgs e)
        {
            try
            {
                ltError.Text = string.Empty;
                DataTask = TaskRepository.GetIntance();
                var name = txtName.Text.Trim();
                var description = txtDescription.Text.Trim();
                var type = Convert.ToInt32(txtType.Text.Trim());
                var state = Convert.ToInt32(txtState.Text.Trim());
                var complate = Convert.ToInt32(txtComplate.Text.Trim());
                DataTask.InsertTask(name,description,type,state,complate);
                gvTaskRepository.EditIndex = -1;
                BindDataTaskToGridView();
                ltError.Text = "Insert user successfully";
            }
            catch (Exception ex)
            {
                ltError.Text = ex.Message;
            }
        }

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

        protected void gvTaskRepository_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                ltError.Text = string.Empty;
                DataTask = TaskRepository.GetIntance();
                var row = gvTaskRepository.Rows[e.RowIndex];
                var hiddenField = (HiddenField)row.FindControl("hdnTaskID");
                var id = Convert.ToInt32(hiddenField.Value);
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

        protected void gvTaskRepository_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ltError.Text = string.Empty;
                DataTask = TaskRepository.GetIntance();
                var row = gvTaskRepository.Rows[e.RowIndex];
                var hiddenField = (HiddenField)row.FindControl("hdnTaskID");
                var id = Convert.ToInt32(hiddenField.Value);
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
    }
}