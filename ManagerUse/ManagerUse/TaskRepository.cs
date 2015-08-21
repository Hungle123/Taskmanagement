using System;
using System.Collections.Generic;
using System.IO;

namespace ManagerUse
{
    public class TaskRepository
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
                        var user = new List<User> {new User(userName)};
                        Tasks.Add(new Task(name, description, type, user, state, complate));
                    }
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
    }
}
