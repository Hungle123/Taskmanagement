using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ManagerUse
{
    public class TaskRepository : DbConnection
    {
        public const string NameText = "Name:";
        public const string DescriptionText = "Description:";
        public const string TypeText = "Type:";
        public const string UserText = "User:";
        public const string StateText = "State:";
        public const string CompalateText = "CompletedPercent:";

        public List<Task> Tasks { get; set; }

        /// <summary>
        /// The instance of this class
        /// </summary>
        private static TaskRepository _instance;

        /// <summary>
        /// Create Constructor for the class TaskRepository
        /// </summary>
        private TaskRepository() { }

        /// <summary>
        /// Create method excute singleton
        /// </summary>
        /// <returns></returns>
        public static TaskRepository GetIntance()
        {
            if (_instance == null)
            {
                _instance = new TaskRepository();
            }
            return _instance;
        }

        /// <summary>
        /// This is method read list of tasks from a text file
        /// </summary>
        /// <returns></returns>
        public List<Task> ReadText()
        {
            Tasks = new List<Task>();
            var name = "";
            var description = "";
            var userName = "";
            var type = TaskType.Bug;
            var state = TaskState.ToDo;
            try
            {
                var taskInfo = new StreamReader("task.txt");
                string listTask;
                var i = 0;
                while ((listTask = taskInfo.ReadLine()) != null)
                {
                    var line = listTask.Trim();
                    var startWithName = line.StartsWith(NameText);
                    var startWithDesciption = line.StartsWith(DescriptionText);
                    var startWithType = line.StartsWith(TypeText);
                    var startWithUser = line.StartsWith(UserText);
                    var startWithState = line.StartsWith(StateText);
                    var startWithComplate = line.StartsWith(CompalateText);

                    int indexOfValue;

                    if (startWithName)
                    {
                        indexOfValue = NameText.Length;
                        name = line.Substring(indexOfValue).Trim();
                    }
                    else if (startWithDesciption)
                    {
                        indexOfValue = DescriptionText.Length;
                        description = line.Substring(indexOfValue).Trim();
                    }
                    else if (startWithType)
                    {
                        indexOfValue = TypeText.Length;
                        var typeName = line.Substring(indexOfValue).Trim();
                        switch (typeName)
                        {
                            case "Bug":
                                type = TaskType.Bug;
                                break;
                            case "Feature":
                                type = TaskType.Feature;
                                break;
                        }
                    }
                    else if (startWithUser)
                    {
                        indexOfValue = UserText.Length;
                        userName = line.Substring(indexOfValue).Trim();
                    }
                    else if (startWithState)
                    {
                        indexOfValue = StateText.Length;
                        var typeState = line.Substring(indexOfValue).Trim();
                        switch (typeState)
                        {
                            case "ToDo":
                                state = TaskState.ToDo;
                                break;
                            case "Doing":
                                state = TaskState.Doing;
                                break;
                            case "Done":
                                state = TaskState.Done;
                                break;
                            case "Tested":
                                state = TaskState.Tested;
                                break;
                        }
                    }
                    else if (startWithComplate)
                    {
                        indexOfValue = CompalateText.Length;
                        var subComplate = line.Substring(indexOfValue).Trim();
                        var complate = int.Parse(subComplate.Replace("%", ""));
                        var user = new List<User> { new User() { Name = userName } };
                        Tasks.Add(new Task(i, name, description, type, user, state, complate));
                    }
                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }
            return Tasks;
        }

        /// <summary>
        /// Method to list of task of the selected user 
        /// and seleted state in TaskRepostory class 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public IList<Task> GetUserTasks(User user, TaskState state)
        {
            var listTasks = new List<Task>();
            // ReSharper disable once InvertIf
            if (user != null)
            {
                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (var task in Tasks)
                {
                    var result = task.ContainUser(user);
                    if (result && task.State == state)
                    {
                        listTasks.Add(task);
                    }
                }
            }
            return listTasks;
        }

        public List<Task> ViewTask(int id)
        {
            ConnectDatabase();
            var tasks = new List<Task>();
            var viewTask = new SqlCommand("dbo.selectTask", DbConnect);
            viewTask.Parameters.AddWithValue("@TaskID", id);
            viewTask.CommandType = CommandType.StoredProcedure;
            using (var reader = viewTask.ExecuteReader())
            {
                try
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["TaskID"]);
                        var name = Convert.ToString(reader["Name"]);
                        var description = Convert.ToString(reader["Description"]);
                        var type = Convert.ToInt32(reader["Type"]);
                        var types = (TaskType)type;
                        var state = Convert.ToInt32(reader["State"]);
                        var states = (TaskState)state;
                        var complate = Convert.ToInt32(reader["ComplatedPercent"]);
                        tasks.Add(new Task()
                        {
                            TaskId = id,
                            Name = name,
                            Description = description,
                            Type = types,
                            State = states,
                            CompletedPercent = complate
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Message: " + ex.Message);
                }
            }
            return tasks;
        }

        /// <summary>
        /// insert info for the tasks
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <param name="state"></param>
        /// <param name="complate"></param>
        public void InsertTask(string name, string description, int type, int state, int complate)
        {
            try
            {
                ConnectDatabase();
                var insertCommand = new SqlCommand("dbo.insertTask", DbConnect);
                insertCommand.Parameters.AddWithValue("@Name", name);
                insertCommand.Parameters.AddWithValue("@Description", description);
                insertCommand.Parameters.AddWithValue("@Type", type);
                insertCommand.Parameters.AddWithValue("@State", state);
                insertCommand.Parameters.AddWithValue("@complate", complate);
                insertCommand.CommandType = CommandType.StoredProcedure;
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
            }
        }

        /// <summary>
        /// update info for the tasks
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <param name="state"></param>
        /// <param name="complate"></param>
        public void UpdateTask(int id, string name, string description, int type, int state, int complate)
        {
            try
            {
                ConnectDatabase();
                var updateCommand = new SqlCommand("dbo.updateTask", DbConnect);
                updateCommand.Parameters.AddWithValue("@TaskID", id);
                updateCommand.Parameters.AddWithValue("@Name", name);
                updateCommand.Parameters.AddWithValue("@Description", description);
                updateCommand.Parameters.AddWithValue("@Type", type);
                updateCommand.Parameters.AddWithValue("@State", state);
                updateCommand.Parameters.AddWithValue("@Complate", complate);
                updateCommand.CommandType = CommandType.StoredProcedure;
                updateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
            }
        }

        /// <summary>
        /// Delete task of list tasks
        /// </summary>
        /// <param name="id"></param>
        public void DeleteTask(int id)
        {
            try
            {
                ConnectDatabase();
                var deleteCommand = new SqlCommand("dbo.deleteTask", DbConnect);
                deleteCommand.Parameters.AddWithValue("@TaskID", id);
                deleteCommand.CommandType = CommandType.StoredProcedure;
                deleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message: " + ex.Message);
            }
        }
    }
}
